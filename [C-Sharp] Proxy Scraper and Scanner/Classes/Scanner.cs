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
using System.Threading;

using xNet;
using CS_Proxy.Proxy;
using CS_Proxy.Lists;

namespace CS_Proxy.Classes.Multithreaded
{
    public class Scanner
    {
        private static ProxyManager ProxyMgr;

        public static bool TerminateThreads { get; set; }
        public static bool PauseThreads { get; set; }

        public static int Threads { get; private set; }

        public static int Scanned { get; private set; } //dead + alive
        public static int Alive { get; private set; } //proxies alive
        public static int Dead { get; private set; } //dead proxies 
        public static int Https { get; private set; }
        public static int Socks { get; private set; }
        public static int Trans { get; private set; }
        public static int High { get; private set; }
        public static int Elite { get; private set; }

        public bool isRunning { get; private set; }

        public Scanner(ProxyManager proxyMgr)
        {
            ProxyMgr = proxyMgr; //ref
            Reset();
        }

        public bool Reset()
        {
            if (Threads == 0)
            {
                Alive = 0;
                Dead = 0;
                Https = 0;
                Socks = 0;
                Trans = 0;
                High = 0;
                Elite = 0;
                if(ProxyMgr!=null)
                    ProxyMgr.Reset();

                return true;
            }

            return false;
        }

        public void Start()
        {
            if (ProxyMgr == null || ProxyMgr.Count < 1)
                return;

            Threads++;
            MyProxy proxy = ProxyMgr.RecommendProxy(); //Recommended proxy is from List<> not HashSet<>
            while (proxy != null && !TerminateThreads)
            {
                while (PauseThreads)
                {
                    Thread.Sleep(333);
                    if (TerminateThreads)
                    {
                        PauseThreads = false;
                        continue; //confirm to which loop this applies to nub
                    }
                }

                proxy.Test();
                Scanned++;
                if (proxy.isAlive)
                {
                    Alive++;
                    if (proxy.Type == ProxyType.Http)
                        Https++;
                    else
                        Socks++;

                    if (proxy.AnonLevel == Anonymity.Transparent)
                        Trans++;
                    else if (proxy.AnonLevel == Anonymity.High)
                        High++;
                    else if (proxy.AnonLevel == Anonymity.Elite)
                        Elite++;

                    ProxyMgr.AddToAlive(proxy); //has lock in-case of IndexOutOfRange Exc
                    Program.UI.AddToListView(proxy);
                }
                else
                {
                    Dead++;
                    ProxyMgr.Dead.Add(proxy);
                }

                //Program.UI.UpdateScannerUI();
                proxy = ProxyMgr.RecommendProxy(); //cycle proxies
            }//stop scan

            Threads--;
            Console.WriteLine(string.Format("***Thread '{0}' terminated, reason is '{1}'... '{2}' Threads left running...",
                Thread.CurrentThread.Name, TerminateThreads?"STOP PRESSED":"FINISHED", Threads.ToString())); //Debug

            //Program.UI.UpdateScannerUI(); //Sends Message that scanning has finished!!!
            //Reset();
        }
    }
}