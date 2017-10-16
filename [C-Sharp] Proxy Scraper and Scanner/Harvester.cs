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
using System.Text.RegularExpressions;
using System.Net;

using HtmlAgilityPack;

namespace CS_Proxy
{
    //Not written for multi-threading - not worth it
    class Harvester
    {
        private List<string> Queries = new List<string>();
        private List<string> BlackList = new List<string>();
        private List<string> BlogList = new List<string>();
        private bool VisitBlogs = false; //In blogs/forums proxies are usually not in front page but threads -> if set to true -> visit blog/forum and obtain threads
        private int Pages = 10;
        private int Timeout;

        public HashSet<string> Harvested = new HashSet<string>();

        public Harvester(List<string> queries, int pages, bool visitBlogs, int timeout)
        {
            Pages = pages;
            VisitBlogs = visitBlogs;
            Timeout = timeout;
            PopulateBlackList();
            if (visitBlogs)
                PopulateBlogList();

            DateTime today = DateTime.Now;
            for (int q = 0; q < queries.Count; ++q)
            {
                string str = queries[q].ToLower();
                str = str.Replace("{d}", today.ToString("d"));
                str = str.Replace("{dd}", today.ToString("dd"));
                str = str.Replace("{mm}", today.ToString("MM"));
                str = str.Replace("{mmm}", today.ToString("MMM"));
                str = str.Replace("{mmmm}", today.ToString("MMMM"));
                str = str.Replace("{yy}", today.ToString("yy"));
                str = str.Replace("{yyyy}", today.ToString("yyyy"));

                Queries.Add(str.ToLower());
            }
        }

        private void PopulateBlogList()
        {
            BlogList.Clear();
            BlogList.Add("blog");
            BlogList.Add("forum");
        }

        private bool isInBloglist(string url)
        {
            foreach(string str in BlogList)
            {
                if (url.Contains(str))
                    return true;
            }
            return false;
        }

        private void PopulateBlackList()
        {
            BlackList.Clear();
            BlackList.Add("javascript");
            BlackList.Add("wiki");
            BlackList.Add("microsoft");
            BlackList.Add("facebook");
            BlackList.Add("report");
            BlackList.Add("twitter");
        }

        private bool isBlacklisted(string url)
        {
            for(int i = 0; i <BlackList.Count; ++i)
            {
                if (url.Contains(BlackList[i]))
                    return true;
            }
            return false;
        }

        public void GetURLs()
        {
            MyWebClient wc = new MyWebClient();
            wc.Timeout = Timeout;

            int qNo = 0;
            foreach (string query in Queries)
            {
                qNo++;
                string searchURL = string.Concat("http://www.bing.com/search?q=", query);

                for (int page = 1; page <= Pages; ++page)
                {
                    Console.WriteLine("Harvesting URLs from Page {0}", page.ToString());
                    string html = string.Empty;
                    try
                    {
                        html = wc.DownloadString(searchURL).Replace("&amp;", "&");
                    }
                    catch (WebException) { html = string.Empty; }
                    catch (NotSupportedException) { html = string.Empty; }
                    catch (ArgumentNullException) { html = string.Empty; }
                    if (html == string.Empty)
                        continue;

                    string nextPageID = "title=\"Next page\" href=\"";
                    int nextPageIndex = html.IndexOf(nextPageID);
                    if (nextPageIndex > 0)
                    {
                        int start = nextPageIndex + nextPageID.Length;
                        int end = html.IndexOf("\"", start);
                        searchURL = string.Concat("http://www.bing.com", html.Substring(start, end - start)).Replace("&amp;","&");
                    }
                    else
                        searchURL = string.Empty;


                    HtmlDocument docu = new HtmlDocument();
                    docu.LoadHtml(html);
                    foreach (HtmlNode link in docu.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        // Get the value of the HREF attribute
                        string url = link.GetAttributeValue("href", string.Empty);

                        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                        {
                            if (!isBlacklisted(url) && Harvested.Add(url))
                            {
                                Console.WriteLine(" - {0}", url);
                                Program.UI.AddURL(url, qNo, Queries.Count, page, query);

                                if(isInBloglist(url))
                                {
                                    string _url = url.Replace("http://", "").Replace("https://", "");
                                    string baseUrl = string.Concat("http://", _url.Contains("/") ? _url.Substring(0, _url.IndexOf("/")) : _url);
                                    HtmlDocument docu2 = new HtmlDocument();
                                    string newhtml = string.Empty;
                                    try
                                    {
                                        newhtml = wc.DownloadString(url).Replace("&amp;", "&");
                                    }
                                    catch (WebException) { html = string.Empty; }
                                    catch (NotSupportedException) { html = string.Empty; }
                                    catch (ArgumentNullException) { html = string.Empty; }
                                    if (newhtml == string.Empty)
                                        continue;

                                    docu2.LoadHtml(newhtml);
                                    foreach (HtmlNode link2 in docu2.DocumentNode.SelectNodes("//a[@href]"))
                                    {
                                        string url2 = link2.GetAttributeValue("href", string.Empty);
                                        if (url2.Length <= 1)
                                            continue;

                                        if (!Uri.IsWellFormedUriString(url2, UriKind.Absolute)) //needs concatenating
                                        {
                                            if (url2[0] != '/')
                                                url2 = string.Concat(url, url2);
                                            else
                                                url2 = string.Concat(baseUrl, url2);
                                        }

                                        if (Uri.IsWellFormedUriString(url2, UriKind.Absolute))
                                        {
                                            if (!isBlacklisted(url) && Harvested.Add(url))
                                            {
                                                Console.WriteLine(" - {0}", url);
                                                Program.UI.AddURL(url, qNo, Queries.Count, page, query);
                                            }
                                        }
                                        else
                                            Console.WriteLine("NO - " + url2);
                                    }
                                }
                            }
                        }
                    }
                  
                    if (searchURL == string.Empty)
                        break;
                }

            } //next query

            Program.UI.ReportHarvest();
        }
    }
}
