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
using System.Net;
using System.Text.RegularExpressions;

using xNet;
using CS_Proxy.Classes.Multithreaded;

namespace CS_Proxy.Proxy
{
    public enum Anonymity { Transparent, High, Elite, Unknown }; //Transparent, High Elite

    public class MyProxy
    {
        #region Fields [+]
        public static bool ScanHTTP = true;
        public static bool ScanSOCKS = true;
        public static string Judge = string.Empty;
        public static int Timeout = 20000;

        public string Host { get; private set; }
        public int Port { get; private set; }
        public bool Tested { get; private set; }

        private T TestAndGet<T>(T obj)
        {
            if(!Tested)
                Test();
            return obj;
        }

        public bool isAlive { get; private set; }
        public int Latency { get; private set; }
        public ProxyType Type { get; private set; }
        public Anonymity AnonLevel { get; private set; }

        public static string IPv4 = string.Empty; //should be immutable and not masked
        #endregion

        private string GetHTML(string url)
        {
            string html = string.Empty;
            try
            {
                html = new WebClient().DownloadString(url);
            }
            catch (WebException) { }
            catch (ArgumentNullException) { }
            catch (NotSupportedException) { }

            return html;
        }

        private void Initialize(string host, int port)
        {
            Host = host;
            Port = port;
            Tested = false;
            isAlive = false;
            Latency = -1;
            Type = ProxyType.Http;

            if (Host.StartsWith("0."))
            {
                isMalformed = true;
                return;
            }

            if (IPv4 == string.Empty)
            {
                Console.WriteLine("Fetching machine IP Address!");
                IPv4 = GetHTML("http://v4.ipv6-test.com/api/myip.php").Trim();

                if (IPv4.Contains(".") == false || IPv4.Length < 7)
                {
                    string vars = GetHTML(Judge);
                    Match match = Regex.Match(vars, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                    if (match.Success)
                        IPv4 = match.Value;
                    else
                        Console.WriteLine("Critical Error: Cannot get IPv4 address from proxy judge.");
                }
            }

        }

        public MyProxy(string host, int port)
        {
            isMalformed = false;
            Initialize(host, port);
        }

        public bool isMalformed { get; private set; }
        public MyProxy(string proxy, bool? checkFormatting = false)
        {
            isMalformed = false;
            string[] parts = proxy.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2)
            {
                if (checkFormatting == false)
                {
                    //Assemble proxy: May be in two different configs Ip:Port or Port:Ip
                    string strHost = parts[0].Contains(".") ? parts[0] : parts[1];
                    string strPort = parts[0].Contains(".") ? parts[1] : parts[0];

                    int intPort;
                    if (int.TryParse(strPort, out intPort))
                        Initialize(strHost, intPort);
                    else
                    {
                        isMalformed = true; //unknown port
                        Initialize(strHost, 80);
                    }
                }
                else
                {
                    //Proxy is already in Ip:Port format :)
                    Initialize(parts[0], Convert.ToInt32(parts[1]));
                }
            }
            else
            {
                isMalformed = true;
                Initialize(proxy, 80); //unknown parts 
            }
        }

        ////Get ping status (bool) and latency (int)
        //public Tuple<bool, int> Ping(string ip)
        //{
        //    Ping pinger = new Ping();
        //    PingOptions pingOptions = new PingOptions();

        //    pingOptions.DontFragment = true;

        //    byte[] buffer = new byte[4] { 0, 0, 0, 0 };
        //    PingReply pingReply = pinger.Send(ip, Timeout, buffer, pingOptions);

        //    if (pingReply.Status == IPStatus.Success)
        //    {
        //        int latency = Convert.ToInt32(pingReply.RoundtripTime);
        //        return new Tuple<bool, int>(true, latency);
        //    }

        //    return new Tuple<bool, int>(false, Int32.MaxValue);
        //}

        public override string ToString()
        {
            return string.Concat(Host, ":", Port.ToString());
        }

        public void Test()
        {
            string proxy = ToString();
           // Console.WriteLine("      {0} is checking {1}.", System.Threading.Thread.CurrentThread.Name, proxy);

            ProxyType[] scanTypes; //http, socks4a, socks5, socks4
            if (ScanHTTP && ScanSOCKS)
            {
                //Populate order of ProxyTypes which will be scanned in order of likeliness it it's actual type. 
                if (Port == 80 || Port == 8080 || Port == 3128 || Port == 9999 || Port > 53000) //Typical HTTP Ports
                    scanTypes = new ProxyType[] { ProxyType.Http, ProxyType.Socks4, ProxyType.Socks5, ProxyType.Socks4a };
                else
                    scanTypes = new ProxyType[] { ProxyType.Socks4, ProxyType.Socks5, ProxyType.Http, ProxyType.Socks4a };
            }
            else
            {
                if (ScanHTTP)
                    scanTypes = new ProxyType[] { ProxyType.Http };
                else //ScanSOCKS
                    scanTypes = new ProxyType[] { ProxyType.Socks4, ProxyType.Socks5, ProxyType.Socks4a };
            }


            bool timeoutExceeded = false;
            foreach (ProxyType type in scanTypes)
            {
                if (timeoutExceeded || Scanner.TerminateThreads)
                    break;

                DateTime start = DateTime.Now;
                using (HttpRequest request = new HttpRequest())
                {
                    try
                    {
                        if (Port < 10 || Port > 65535)
                            continue;
                        request.UserAgent = Http.ChromeUserAgent();
                        request.Proxy = ProxyClient.Parse(type, proxy);
                        request.Proxy.ConnectTimeout = Timeout;
                        request.Proxy.ReadWriteTimeout = Timeout;

                        start = DateTime.Now;
                        try
                        {
                            request.Get(Judge);
                            HttpResponse response = request.Get(Judge);
                            string html = response.ToString();

                            Latency = Convert.ToInt32((DateTime.Now - start).TotalMilliseconds);
                            //Console.WriteLine(html);
                            if (response.StatusCode != xNet.HttpStatusCode.OK)
                            {
                                Console.WriteLine("Status [{0}]: {1} on using {2}.", response.StatusCode.ToString(), proxy, type.ToString());
                                continue;
                            }

                            isAlive = true;
                            if (html.Contains(IPv4))
                                AnonLevel = Anonymity.Transparent;
                            else if (html.Contains(Host))
                                AnonLevel = Anonymity.High;
                            else
                                AnonLevel = Anonymity.Elite;

                            Type = type;
                            Console.WriteLine("   Alive: {0} [{1}] [{2}] [{3}ms]", proxy, AnonLevel.ToString(), type.ToString(), Latency.ToString());
                            break;
                        }
                        catch (ArgumentException) { }
                        catch (System.IO.InvalidDataException) { }
                        catch (NullReferenceException) { } //internal xNet err (request is null; tried if(req==null)break; to no avail
                    }
                    catch (xNet.HttpException exc)
                    {
                        Console.WriteLine("{0} HttpException: {1} on using {2}.", exc.Status.ToString(), proxy, type.ToString());
                    }
                    catch (xNet.ProxyException exc)
                    {
                        Console.WriteLine("{0} ProxyException: {1} on using {2}.", exc.Message, proxy, type.ToString());
                    }
                    finally
                    {
                        int timeTaken = Convert.ToInt32((DateTime.Now - start).TotalMilliseconds);
                        if (timeTaken > Timeout)
                        {
                            Console.WriteLine("{0} IS DEAD :( --> [{1}ms]", proxy, timeTaken.ToString());
                            timeoutExceeded = true; //Proxy is Dead
                        }
                    }
                }

            }

            Tested = true;
        }
    }
}
