/*
 *[C#] Proxy Toolkit
 *Copyright (C) 2017  Juan Xuereb
 *
 *This program is free software: you can redistribute it and/or modify
 *it under the terms of the GNU General Public License as published by
 *the Free Software Foundation, either version 3 of the License, or
 *(at your option) any later version.
 *
 *This program is distributed in the hope that it will be useful,
 *but WITHOUT ANY WARRANTY; without even the implied warranty of
 *MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *GNU General Public License for more details.
 *You should have received a copy of the GNU General Public License
 *along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace CS_Proxy
{
    [System.ComponentModel.DesignerCategory("")] //annoying shit
    public class MyWebClient : WebClient
    {
        public int Timeout { get; set; }
        public MyWebClient() { }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = Timeout;
            return w;
        }
    }

    public class Scraper
    {
        public static int URLScraped { get; private set; } //info
        public static int Threads { get; private set; } //info
        public static int BadURLs { get; private set; } //info
        public static int EmptyURLs { get; private set; } //info
        public static bool TerminateThreads { get; set; } //controllers
        public static bool PauseThreads { get; set; } //controllers

        private static URLManager Mgr;

        private MyWebClient WC = new MyWebClient();

        public Scraper(URLManager mgr, int timeoutMS)
        {
            WC.Timeout = timeoutMS;
            Mgr = mgr;
            Reset();
        }

        ~Scraper()
        {
            Reset();
        }

        /// <summary>
        /// Reset all control static variables used when multithreading.
        /// </summary>
        private bool Reset()
        {
            if (Threads == 0)
            {
                EmptyURLs = 0;
                BadURLs = 0;
                URLScraped = 0;
                TerminateThreads = false;
                PauseThreads = false;
                if (Mgr != null)
                    Mgr.Reset();

                return true;
            }
            return false;
        }

        private List<MyProxy> proxiesFromHtml(string html)
        {
            List<MyProxy> proxies = new List<MyProxy>();

            /////Remove everything that can mislead
            html = html.Trim().ToLowerInvariant();

            //Remove time stamps ex '11h 44m 56s'; are usually adjacent to proxies so removal is encouraged for best results
            //Start from big [60] to small [0] so we have no trailing digits, ex: '52s' removing '2s' first and we have a trailing 5
            string[] suffixes = new string[] { "s", "m", "h", "d" };
            for (int i = 60; i >= 0; --i)
            {
                for (int s = 0; s < suffixes.Length; ++s)
                    html = html.Replace(string.Concat(i.ToString(), suffixes[s]), " ");
            }
            html = Regex.Replace(html, @"<[^>]+>|&nbsp;", " ").Trim(); //remove any html <tag> or non-breaking spaces
            const string timeRegex = @"(\s\d{1,2}:\d{1,2}\s)|(\s\d{1,2}:\d{1,2}:\d{1,2}\s)";
            html = Regex.Replace(html, timeRegex, " ").Trim(); //remove time 00:00:00 or 00:00
            html = Regex.Replace(html, @"\s+", " "); //remove extra spaces
            /////

            //Regex Cheat Sheet: https://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet
            //[1-3 Digits] [.1-3 Digit]x3 :or_ [2-5 Digits] | Same shit but Port first
            const string normalRegex = @"(\d{1,3}(\.\d{1,3}){3}(:|\s)\d{2,5})|(\d{2,5}(:|\s)\d{1,3}(\.\d{1,3}){3})";
            MatchCollection matches = Regex.Matches(html, normalRegex, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                string _proxy = match.ToString().Trim().Replace(" ", ":");
                string[] parts = _proxy.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                //Assemble proxy! May be in two different configs ip:port or port:ip
                if (parts.Length == 2)
                {
                    int portIndex = parts[0].Contains(".") ? 1 : 0;
                    int ipIndex = portIndex == 1 ? 0 : 1;
                    MyProxy proxy = new MyProxy(parts[ipIndex], Convert.ToInt32(parts[portIndex]));
                    proxies.Add(proxy);
                }
            }

            return proxies;
        }

        public void GetProxies()
        {
            if (Mgr == null || Mgr.Count < 1 || WC.Timeout < 1)
                return;

            Threads++;
            Program.UI.UpdateScrapeBtns();
            Thread.Sleep(100);

            string url = Mgr.RecommendURL();
            bool proxiesFound = false;
            while (url != string.Empty && !TerminateThreads)
            {
                while (PauseThreads)
                {
                    Thread.Sleep(333);
                    if (TerminateThreads)
                    {
                        PauseThreads = false;
                        continue;
                    }
                }

                string html = string.Empty;
                try
                {
                    html = WC.DownloadString(url);
                    List<MyProxy> proxies = proxiesFromHtml(html);

                    for (int p = 0; p < proxies.Count; ++p)
                    {
                        if (TerminateThreads) //sometimes looping inside this can take long
                            break;

                        Console.WriteLine("[+] {0} from {1} : {2}", proxies[p], url, Thread.CurrentThread.Name);
                        Program.UI.AddProxy(proxies[p]);
                    }
                    proxiesFound = proxies.Count > 0;
                }
                catch (ArgumentNullException) { BadURLs++; }
                catch (WebException) { BadURLs++; }
                catch (NotSupportedException) { BadURLs++; }
                //catch (Exception ) { BadURLs++; }
                finally
                {
                    //End of URL processing -> next loop
                    if (!proxiesFound)
                    {
                        Console.WriteLine("{0} was void of proxies.", url);
                        EmptyURLs++;
                    }

                    URLScraped++;
                    url = Mgr.RecommendURL(); //change URL
                }
            }

            Threads--;
            Program.UI.UpdateScrapeBtns(); //make sure this is before reset else stats get wiped
            Thread.Sleep(100);

            if (TerminateThreads) //if forced termination and reset() is invoked -> terminate all is reset to false :( (spaghetti ughh)
            {
                while (Threads > 0)
                    Thread.Sleep(250);
            }
            Reset();

            Console.WriteLine(string.Format("***Thread '{0}' terminated, reason is '{1}'... '{2}' Threads left running...",
                Thread.CurrentThread.Name, TerminateThreads ? "STOP PRESSED" : "FINISHED", Threads.ToString())); //Debug
        }


    }
}
