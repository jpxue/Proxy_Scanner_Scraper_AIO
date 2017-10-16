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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using System.IO;

namespace CS_Proxy
{
    public partial class Form1 : Form
    {
        URLManager URLMgr = new URLManager(); //Holds URLs which will need scraping
        HashSet<string> ProxiesScraped = new HashSet<string>(); //Proxies scraped from URLManager [DONT WANT DUPES]

        ProxyManager ProxyMgr = new ProxyManager(); //Holds Proxies which will need scanning
        //HashSet<MyProxy> ProxiesToScan = new HashSet<MyProxy>(); //Proxies to be scanned (same as those in ProxyMgr)
        ProxyFilter filter = new ProxyFilter("dangerous_ip_ranges.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proxyView.ContextMenuStrip = contextMenuStrip1;
            ScapePanelUI();
            EnableScanUI();
            proxyJudgesComboBox.SelectedIndex = 0;
            statusLbl.Text = "Status: Idle";
            scanPercentLbl.Text = "";
            queriesLeftLbl.Text = "";

            if (queryRTBox.Text.Contains("{"))
                HighlightQueryBox();

            if (!HasInternet())
            {
                statusLbl.Text = "Status: No Internet";
                MessageBox.Show(string.Concat("You do NOT have access to the internet.", Environment.NewLine, "Press 'OK' to Terminate."), "No Internet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            if (!filter.isInitialized)
            {
                removeDangCheck.Checked = false;
                removeDangCheck.Visible = false;
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        //Uses wininet.dll (best method)
        private static bool HasInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        private void ScapePanelUI()
        {
            scrapedPanel.Visible = ProxiesScraped.Count > 0;
            scrapeBtn.Enabled = URLMgr.Count > 0;

            urlsToScrapeLbl.Text = string.Format("URLs To Scrape: {0}", URLMgr.Count.ToString());
            urlsToScrapeLbl.Location = new Point(importURLsBtn.Location.X - urlsToScrapeLbl.Width - 15, urlsToScrapeLbl.Location.Y);
        }

        private void importURLsBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "URLs To Scrape";
            ofd.Filter = "Text Files|*.txt";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                URLMgr.Clear();
                uint badUrls = 0;
                foreach(string file in ofd.FileNames)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) //IMP: Add Exception Checks
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        string url;
                        while ((url = sr.ReadLine()) != null)
                        {
                            if (Uri.IsWellFormedUriString(url, UriKind.Absolute) && !URLMgr.Contains(url))
                                URLMgr.Add(url);
                            else
                                badUrls++;
                        }
                    }
                }

                //Update UI
                ScapePanelUI();

                MessageBox.Show(string.Format("A total of {0} URLs have been imported for scraping.{1}", URLMgr.Count.ToString(),
                    badUrls > 0 ? string.Format("{0}{1} URLs seem to be invalid and were thus omitted.", Environment.NewLine, badUrls.ToString()) : ""),
                    "Import URLs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static readonly Object scrapeUILock = new Object();
        private void UpdateScraperUI()
        {
            lock (scrapeUILock)
            {
                if (Scraper.TerminateThreads)
                    scrapeBtn.Invoke(new Action(() => scrapeBtn.Text = string.Concat("Threads = ", Scraper.Threads.ToString())));

                // scrapedListBox.Invoke(new Action(() => scrapedListBox.SelectedIndex = scrapedListBox.Items.Count - 1)); //force scroll down
                scrapedLbl.Invoke(new Action(() => scrapedLbl.Text = string.Format("Scraped: {0}", ProxiesScraped.Count.ToString()))); //update label
                scrapeProgBar.Invoke(new Action(() => scrapeProgBar.Value = Scraper.URLScraped)); //update progress bar

                if (statusStrip1.Parent.InvokeRequired)
                {
                    string statuslbl = string.Format("{0} out of {1} URLs Scraped!", Scraper.URLScraped.ToString(), URLMgr.Count.ToString());
                    statusStrip1.Parent.Invoke(new MethodInvoker(delegate { statusLbl.Text = statuslbl; }));
                }
            }
        }
        

        private void clearScrapeList()
        {
            ProxiesScraped.Clear();
            scrapedListBox.Items.Clear();
            scrapedLbl.Text = string.Format("Scraped: {0}", ProxiesScraped.Count.ToString());
            ScapePanelUI();
        }
        private void clearScrapedBtn_Click(object sender, EventArgs e)
        {
            clearScrapeList();
        }

        private static List<List<string>> Spliterino(List<string> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        private void scrapeBtn_Click(object sender, EventArgs e)
        {
            if(scrapeBtn.Text.StartsWith("Stop"))
            {
                scrapeBtn.Invoke(new Action(() => scrapeBtn.Enabled = false)); //spam click
                scrapeBtn.Text = "Stopping...";
                Scraper.TerminateThreads = true;
                return;
            }

            if(Convert.ToInt32(threadCountNumUpDown.Value) > URLMgr.Count)
            {
                MessageBox.Show("Thread count greater than number of URLs.", "Too Many Threads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!HasInternet())
            {
                statusLbl.Text = "Status: No Internet";
                MessageBox.Show("You do NOT have access to the internet.", "No Internet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clearScrapeList();
            scrapeProgBar.Maximum = URLMgr.Count;
            scrapedPanel.Visible = true;

            int TotalThreads = Convert.ToInt32(threadCountNumUpDown.Value);
            int Timeout = Convert.ToInt32(timeoutNumUpDown.Value) * 1000;

            Scraper.TerminateThreads = false;
            Scraper.PauseThreads = false;

            //Create the Threads
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "FormThread";

            Thread[] threads = new Thread[TotalThreads];
            for (int t = 0; t < TotalThreads; ++t)
            {
                Scraper scraper = new Scraper(URLMgr, Timeout);
                Thread thread = new Thread(new ThreadStart(scraper.GetProxies));
                thread.IsBackground = true; //imp so all auto terminate on formClosing()
                thread.Name = string.Concat("Scraper_#", t.ToString());
                threads[t] = thread;
                Thread.Sleep(10);
            }

            //Execute the Threads ALL @ once (better flow)
            for (int t = 0; t < TotalThreads; ++t)
            {
                threads[t].Start();
                Thread.Sleep(10);
            }
        }

        private void saveScrapedBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "ProxiesScraped.txt";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (string proxy in ProxiesScraped)
                        sw.WriteLine(proxy);
                }
            }
        }

        private void scrapedToScanner()
        {
            if (ProxiesScraped.Count == 0)
            {
                MessageBox.Show("Nothing to send to Scanner... Try scraping some proxies or import a list from the Scanner tab.", "No Scraped Proxies", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (removeDangCheck.Checked)
            {
                HashSet<string> nonDangerous = new HashSet<string>();
                foreach(string proxy in ProxiesScraped) //looping thru hashset not encouraged but w/e
                {
                    if (proxy!=null && !filter.isDangerous(proxy))
                        nonDangerous.Add(proxy);
                }
                ProxyMgr.Initialize(nonDangerous); //Don't have to create new instance because it already is a new instance
            }
            else
                ProxyMgr.Initialize(new HashSet<string>(ProxiesScraped)); //New instance, otherwise we have reference to ProxiesScraped which could be problematic if simult. scanning & scraping

            EnableScanUI();
            tabControl1.Invoke(new Action(() => tabControl1.SelectedIndex = 1));
        }
        private void toScannerBtn_Click(object sender, EventArgs e)
        {
            scrapedToScanner();
            if(scrapedListBox.Items.Count > ProxyMgr.Count)
                MessageBox.Show(string.Concat((scrapedListBox.Items.Count - ProxyMgr.Count).ToString(), " DANGEROUS Proxies were removed."), "Filter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void EnableScanUI()
        {
            proxiesToScanLbl.Invoke(new Action(() => proxiesToScanLbl.Text = string.Format("Proxies to Scan: {0}", ProxyMgr.Count.ToString())));
            using (Graphics g = CreateGraphics())
            {
                SizeF lblsize = g.MeasureString(proxiesToScanLbl.Text, proxiesToScanLbl.Font, 1000);
                Point loc = new Point(((importProxiesBtn.Width - Convert.ToInt32(lblsize.Width)) / 2) + importProxiesBtn.Location.X, proxiesToScanLbl.Location.Y);
                proxiesToScanLbl.Invoke(new Action(() => proxiesToScanLbl.Location = loc));
            }
            //proxiesToScanLbl.Location = new Point(importProxiesBtn.Location.X - proxiesToScanLbl.Width - 10, proxiesToScanLbl.Location.Y);
            scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Enabled = ProxyMgr.Count > 0));
        }

        private void importProxiesBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Proxies";
            ofd.Filter = "Text Files|*.txt";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ProxyMgr.Clear();
                uint badProxies = 0;
                uint duplicateProxies = 0;
                uint dangerousProxies = 0;
                foreach (string file in ofd.FileNames)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        string proxy;
                        while ((proxy = sr.ReadLine()) != null)
                        {
                            MyProxy myProxy = new MyProxy(proxy, true);
                            if (myProxy.isMalformed)
                                badProxies++;
                            else
                            {
                                if (removeDangCheck.Checked)
                                {
                                    if (filter.isDangerous(myProxy.ToString()))
                                    {
                                        dangerousProxies++;
                                        continue;
                                    }
                                }
                                if (!ProxyMgr.Add(myProxy.ToString())) //adding to hashset
                                    duplicateProxies++;
                            }
                        }
                    }
                }

                //Update UI
                EnableScanUI();

                MessageBox.Show(string.Format("A total of {0} Proxies have been imported for scanning.{1}{2}", ProxyMgr.Count.ToString(),
                    (badProxies + duplicateProxies) > 0 ? string.Format("{0} - {1} bad proxies and {2} duplicates were removed!",
                    Environment.NewLine, badProxies.ToString(), duplicateProxies.ToString()):"", dangerousProxies>0? string.Concat(Environment.NewLine,
                    " - ", dangerousProxies.ToString(), " DANGEROUS Proxies were also removed!"):""),
                    "Import Proxies", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void clearProxyView()
        {
            proxyView.Items.Clear();
        }

        DateTime ScanStart = DateTime.Now;
        private void Scan()
        {
            if (scanProxiesBtn.Text.StartsWith("Stop"))
            {
                scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Enabled = false)); //spam click
                scanProxiesBtn.Text = "Stopping...";
                Scanner.TerminateThreads = true;
                return;
            }

            if (Convert.ToInt32(threadsProxiesNumUpDown.Value) >= ProxyMgr.Count)
            {
                MessageBox.Show("Thread count greater than number of Proxies.", "Too Many Threads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clearProxyView();
            if (statusStrip2.Parent.InvokeRequired)
            {
                statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanProgBar.Maximum = ProxyMgr.Count; }));
                statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanPercentLbl.Text = "0%"; }));
            }
            else
            {
                scanProgBar.Maximum = ProxyMgr.Count;
                scanPercentLbl.Text = "0%";
            }
            scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Text = "Stop"));
            threadsProxiesNumUpDown.Invoke(new Action(() => threadsProxiesNumUpDown.Enabled = false));
            timeoutProxiesNumUpDown.Invoke(new Action(() => timeoutProxiesNumUpDown.Enabled = false));
            aliveLbl.Invoke(new Action(() => aliveLbl.Text = "Alive = 0"));
            deadLbl.Invoke(new Action(() => deadLbl.Text = "Dead = 0"));

            int TotalThreads = Convert.ToInt32(threadsProxiesNumUpDown.Value);
            MyProxy.Timeout = Convert.ToInt32(timeoutProxiesNumUpDown.Value) * 1000;
            calcTimeoutQuartiles();

            uiTimer.Elapsed += async (sender, e) => await UpdateScannerUI();
            uiTimer.Start();

            //Create the Threads
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "FormThread";

            ProxyMgr.Initialize(null); //reference not a new copy

            Scanner.TerminateThreads = false;
            Scanner.PauseThreads = false;

            //Create the Threads
            Thread[] threads = new Thread[TotalThreads];
            for (int t = 0; t < TotalThreads; ++t)
            {
                Scanner scanner = new Scanner(ProxyMgr);
                Thread thread = new Thread(new ThreadStart(scanner.Start));
                thread.IsBackground = true; //imp so all auto terminate on formClosing()
                thread.Name = string.Concat("Scanner_#", t.ToString());
                threads[t] = thread;
                Thread.Sleep(10);
            }

            //Execute the Threads ALL @ once (better flow)
            for (int t = 0; t < TotalThreads; ++t)
            {
                threads[t].Start();
                Thread.Sleep(10);
            }

            ScanStart = DateTime.Now;
        }

        private void scanProxiesBtn_Click(object sender, EventArgs e)
        {
            if (!HasInternet())
            {
                statusLbl.Text = "Status: No Internet";
                MessageBox.Show("You do NOT have access to the internet.", "No Internet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Scan();
        }

        private void calcTimeoutQuartiles()
        {
            timeout50 = MyProxy.Timeout / 2;
            timeout25 = MyProxy.Timeout / 4;
            timeout75 = timeout25 + timeout50;
        }

        private void timeoutProxiesNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MyProxy.Timeout = Convert.ToInt32(timeoutNumUpDown.Value) * 1000;
            calcTimeoutQuartiles();
        }

        private void proxyJudgesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyProxy.Judge = proxyJudgesComboBox.SelectedItem.ToString();
        }

        private void httpCheck_CheckedChanged(object sender, EventArgs e)
        {
            MyProxy.ScanHTTP = httpCheck.Checked;
            scanProxiesBtn.Enabled = !(!httpCheck.Checked && !socksCheck.Checked || ProxyMgr.Count <= 0);
        }

        private void socksCheck_CheckedChanged(object sender, EventArgs e)
        {
            MyProxy.ScanSOCKS = socksCheck.Checked;
            scanProxiesBtn.Enabled = !(!httpCheck.Checked && !socksCheck.Checked || ProxyMgr.Count <= 0);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyView.Items.Clear();
            aliveLbl.Text = "Alive = 0";
            deadLbl.Text = "Dead = 0";
        }

        private void toClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 outputForm = new Form2(true, false, "To Clipboard", ProxyMgr);
            outputForm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 outputForm = new Form2(false, true, "Save", ProxyMgr);
            outputForm.Show();
        }

        private void questionScraperBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("This tab is used to scrape proxies off a given list of URLs.{0}Just hit the 'Import URLs' button and click the 'Scrape' button!", Environment.NewLine),
                "?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void harvestBtn_Click(object sender, EventArgs e)
        {
            if (!HasInternet())
            {
                MessageBox.Show("You do NOT have access to the internet.", "No Internet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> queries = queryRTBox.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if(queries.Count>0)
            {
                harvestProgBar.Visible = true;
                harvestProgBar.Maximum = queries.Count;
                harvestStatusLbl.Text = "Searching...";
                harvestBtn.Enabled = false;
                Harvester harvester = new Harvester(queries, Convert.ToInt32(pagesNumUpDown.Value), false, Convert.ToInt32(timeoutNumUpDown.Value*1000));
                Thread thread = new Thread(new ThreadStart(harvester.GetURLs));
                thread.IsBackground = true;
                thread.Name = string.Concat("HarvesterThread");
                Thread.Sleep(10);

                thread.Start();
            }
        }

        private void clearHarvestBtn_Click(object sender, EventArgs e)
        {
            harvestBox.Items.Clear();
            queriesLeftLbl.Text = "";
            urlsHarvestedLbl.Text = "URLs: 0";
            harvestProgBar.Value = 0;
            harvestProgBar.Visible = false;
            harvestStatusLbl.Text = "Status: Idle";
        }

        #region Thread Safe UI Calls [+]

        public void ReportHarvest()
        {
            harvestBtn.Invoke(new Action(() => harvestBtn.Enabled = true));

            MessageBox.Show(string.Format("URL harvesting has completed!{0}Obtained a total of {1} URLs.", Environment.NewLine, harvestBox.Items.Count.ToString()),
                "Harvesting Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            queriesLeftLbl.Invoke(new Action(() => queriesLeftLbl.Text = ""));

            if (statusStrip3.Parent.InvokeRequired)
            {
                statusStrip3.Parent.Invoke(new MethodInvoker(delegate { harvestProgBar.Value = 0; }));
                statusStrip3.Parent.Invoke(new MethodInvoker(delegate { harvestProgBar.Visible = false; }));
                statusStrip3.Parent.Invoke(new MethodInvoker(delegate { harvestStatusLbl.Text = "Complete!"; }));
            }
        }

        private void UpdateHarvestUI(int queryNo, int totalQueries, int pageNo, string query)
        {
            queriesLeftLbl.Invoke(new Action(() => queriesLeftLbl.Text = string.Concat("Queries: ", queryNo.ToString(), "/", totalQueries.ToString(), Environment.NewLine,
                "Page: ", pageNo.ToString())));
            urlsHarvestedLbl.Invoke(new Action(() => urlsHarvestedLbl.Text = string.Concat("URLs: ", harvestBox.Items.Count.ToString())));

            if (statusStrip3.Parent.InvokeRequired)
            {
                statusStrip3.Parent.Invoke(new MethodInvoker(delegate { harvestProgBar.Value = queryNo; }));
                statusStrip3.Parent.Invoke(new MethodInvoker(delegate { harvestStatusLbl.Text = string.Concat(query, "  "); }));
            }
        }

        public void AddURL(string url, int queryNo, int totalQueries, int pageNo, string query)
        {
            harvestBox.Invoke(new Action(() => harvestBox.Items.Add(url)));
            harvestBox.Invoke(new Action(() => harvestBox.SelectedIndex = harvestBox.Items.Count - 1));
            UpdateHarvestUI(queryNo, totalQueries, pageNo, query);
        }

        public void AddProxy(MyProxy proxy)
        {
            if (ProxiesScraped.Add(proxy.ToString())) //if added to hashset and not a duplicate
            {
                scrapedListBox.Invoke(new Action(() => scrapedListBox.Items.Add(proxy.ToString()))); //add to listbox UI
                UpdateScraperUI();
            }
        }

        public void UpdateScrapeBtns()
        {
            if (Scraper.Threads == 0)
            {
                UpdateScraperUI(); //call this first before modifying other controls
                statusLbl.Text = "Finished Scraping!";
                scrapeBtn.Invoke(new Action(() => scrapeBtn.Text = "Scrape"));
                scrapeProgBar.Invoke(new Action(() => scrapeProgBar.Value = 0));

                scrapeBtn.Invoke(new Action(() => scrapeBtn.Enabled = true));
                if (!autoScanCheck.Checked)
                {
                    MessageBox.Show(string.Format("Scraping Finished!!!{0}Scraped a total of {1} proxies!!!{2}{3} were invalid/errorsome URLs and {4} contained no proxies...",
                        Environment.NewLine, ProxiesScraped.Count.ToString(), Environment.NewLine, Scraper.BadURLs.ToString(), Scraper.EmptyURLs.ToString()),
                        "Scraper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //AUTO-SCAN
                    scrapedToScanner();
                    Scan();
                }
            }
            else
                scrapeBtn.Invoke(new Action(() => scrapeBtn.Text = Scraper.TerminateThreads ? "Stopping..." : "Stop"));
        }

        int timeout50 = MyProxy.Timeout / 2;
        int timeout25 = MyProxy.Timeout / 4;
        int timeout75 = Convert.ToInt32((float)MyProxy.Timeout / (float)1.333334);
        public void AddToListView(MyProxy p)
        {
            //0=Proxy 1=Latency 2=Type 3=Level
            string type = p.Type == xNet.ProxyType.Http ? "HTTP" : "SOCKS";
            string[] row = { p.ToString(), p.Latency.ToString(),
                type, p.AnonLevel.ToString() };
            ListViewItem item = new ListViewItem(row);
            item.UseItemStyleForSubItems = false;

            Color col = Color.Black;
            if (p.Latency > MyProxy.Timeout)
                col = Color.DarkGray;
            else if (p.Latency <= MyProxy.Timeout && p.Latency > timeout75)
                col = Color.Red;
            else if (p.Latency < timeout75 && p.Latency > timeout50)
                col = Color.Orange;
            else if (p.Latency < timeout50 && p.Latency > timeout25)
                col = Color.Blue;
            else if (p.Latency < timeout25)
                col = Color.Green;

            item.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular); ;
            item.SubItems[1].ForeColor = col;
            item.SubItems[1].Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Italic);
            item.SubItems[2].Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);
            item.SubItems[2].Font = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold);
            item.SubItems[3].Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);

            proxyView.Invoke(new Action(() => proxyView.Columns[1].TextAlign = HorizontalAlignment.Center)); //centre latency
            proxyView.Invoke(new Action(() => proxyView.Columns[2].TextAlign = HorizontalAlignment.Center)); //centre type

            if (p.AnonLevel == Anonymity.Transparent)
            {
                item.SubItems[3].Font = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold);
                item.SubItems[3].ForeColor = Color.DarkGray;
            }
            else if (p.AnonLevel == Anonymity.High)
                item.SubItems[3].ForeColor = Color.Blue;
            if (p.AnonLevel == Anonymity.Elite)
                item.SubItems[3].ForeColor = Color.Purple;

            if (type == "HTTP")
                item.SubItems[2].ForeColor = Color.Cyan;
            else if (type == "SOCKS")
                item.SubItems[2].ForeColor = Color.Lime;

            proxyView.Invoke(new Action(() => proxyView.Items.Add(item)));
            proxyView.Invoke(new Action(() => proxyView.Items[proxyView.Items.Count - 1].EnsureVisible()));
            // proxyView.Invoke(new Action(() => proxyView.Items[proxyView.Items.Count - 1].Selected = true));
            //proxyView.Invoke(new Action(() => proxyView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)));
            //proxyView.Invoke(new Action(() => proxyView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)));
        }

        System.Timers.Timer uiTimer = new System.Timers.Timer(500);
        private Task UpdateScannerUI() //This is updated periodically (on separate thread/timer) rather than potentially hundreds of threads calling this
        {
            if (Scanner.TerminateThreads)
                scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Text = string.Concat("Threads = ", Scanner.Threads.ToString())));

            aliveLbl.Invoke(new Action(() => aliveLbl.Text = string.Concat("Alive = ", Scanner.Alive.ToString(), "   |   Anonymous = ", (Scanner.High + Scanner.Elite).ToString())));
            deadLbl.Invoke(new Action(() => deadLbl.Text = string.Concat("Dead = ", Scanner.Dead.ToString())));

            if (statusStrip2.Parent.InvokeRequired)
            {
                statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanProgBar.Value = Scanner.Scanned; }));
                float percent = ((float)Scanner.Scanned * 100.0f) / (float)ProxyMgr.Count;

                double seconds = (DateTime.Now - ScanStart).TotalSeconds; //use double coz of DivByZero Exc
                int leftToScan = ProxyMgr.Count - Scanner.Scanned;
                double secondsLeft = ((double)leftToScan * seconds) / (double)Scanner.Scanned;
                TimeSpan ts = TimeSpan.FromSeconds(secondsLeft);
                statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanPercentLbl.Text = string.Concat("ETA: ", ts.ToString(@"hh\:mm\:ss"), "  [", percent.ToString("0.00"), "%]"); }));
            }

            if (Scanner.Threads == 0)
            {
                uiTimer.Stop();
                scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Text = "Scan"));
                scanProxiesBtn.Invoke(new Action(() => scanProxiesBtn.Enabled = true));
                threadsProxiesNumUpDown.Invoke(new Action(() => threadsProxiesNumUpDown.Enabled = true));
                timeoutProxiesNumUpDown.Invoke(new Action(() => timeoutProxiesNumUpDown.Enabled = true));

                MessageBox.Show(string.Format("Found {0} working proxies!{1}{2}", Scanner.Alive.ToString(),
                    Scanner.Https > 0 ? string.Concat(Environment.NewLine, "HTTP working = ", Scanner.Https.ToString()) : "",
                    Scanner.Socks > 0 ? string.Concat(Environment.NewLine, "SOCKS working = ", Scanner.Socks.ToString()) : ""),
                    "Scanner", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (statusStrip2.Parent.InvokeRequired)
                {
                    statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanProgBar.Value = 0; }));
                    statusStrip2.Parent.Invoke(new MethodInvoker(delegate { scanPercentLbl.Text = "Complete"; }));
                }
            }

            return Task.CompletedTask;
        }
        #endregion

        private void deleteHarvestItemBtn_Click(object sender, EventArgs e)
        {
            harvestBox.Items.RemoveAt(harvestBox.SelectedIndex);
            urlsHarvestedLbl.Invoke(new Action(() => urlsHarvestedLbl.Text = string.Concat("URLs: ", harvestBox.Items.Count.ToString())));
        }

        private void saveHarvestBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "URLs.txt";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (object url in harvestBox.Items)
                        sw.WriteLine(url.ToString());
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://msdn.microsoft.com/en-us/library/ff795620.aspx");
        }

        private void toScraperBtn_Click(object sender, EventArgs e)
        {
            URLMgr.Clear();
            foreach (object o in harvestBox.Items)
                URLMgr.Add(o.ToString());

            ScapePanelUI();
            tabControl1.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime today = DateTime.Now;
            MessageBox.Show(string.Concat("{d} = ", today.ToString("d"), Environment.NewLine,
            "{dd} = ", today.ToString("dd"), Environment.NewLine,
            "{mm} = ", today.ToString("MM"), Environment.NewLine,
            "{mmm} = ", today.ToString("MMM"), Environment.NewLine,
            "{mmmm} = ", today.ToString("MMMM"), Environment.NewLine,
            "{yy} = ", today.ToString("yy"), Environment.NewLine,
            "{yyyy} = ", today.ToString("yyyy")), "Operators", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel5.Text);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel3.Text);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel4.Text);
        }

        private Regex highlightRegex = new Regex("{d}|{dd}|{mm}|{mmm}|{mmmm}|{yy}|{yyyy}"); // {(./?)}
        private void HighlightQueryBox()
        {
            int currIndex = queryRTBox.SelectionStart;

            //Recolor back to normal
            queryRTBox.SelectAll();
            queryRTBox.SelectionColor = Color.Teal;
            queryRTBox.SelectionFont = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);

            MatchCollection matches = highlightRegex.Matches(queryRTBox.Text);
            //Highlight
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    queryRTBox.Select(match.Index, match.Length);
                    queryRTBox.SelectionColor = Color.Blue;
                    queryRTBox.SelectionFont = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);
                }
            }

            queryRTBox.Select(currIndex, 0);
            queryRTBox.DeselectAll();
        }
        private void queryRTBox_TextChanged(object sender, EventArgs e)
        {
            if (queryRTBox.Text.Contains("{"))
                HighlightQueryBox();
        }
    }
}
