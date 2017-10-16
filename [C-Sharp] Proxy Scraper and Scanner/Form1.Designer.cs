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

namespace CS_Proxy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.questionScraperBtn = new System.Windows.Forms.Button();
            this.autoScanCheck = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.scrapeProgBar = new System.Windows.Forms.ProgressBar();
            this.timeoutNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.scrapeBtn = new System.Windows.Forms.Button();
            this.threadCountNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.scrapedPanel = new System.Windows.Forms.Panel();
            this.toScannerBtn = new System.Windows.Forms.Button();
            this.clearScrapedBtn = new System.Windows.Forms.Button();
            this.saveScrapedBtn = new System.Windows.Forms.Button();
            this.scrapedLbl = new System.Windows.Forms.Label();
            this.scrapedListBox = new System.Windows.Forms.ListBox();
            this.urlsToScrapeLbl = new System.Windows.Forms.Label();
            this.importURLsBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.removeDangCheck = new System.Windows.Forms.CheckBox();
            this.socksCheck = new System.Windows.Forms.CheckBox();
            this.httpCheck = new System.Windows.Forms.CheckBox();
            this.proxyJudgesComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deadLbl = new System.Windows.Forms.Label();
            this.aliveLbl = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.scanProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.scanPercentLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeoutProxiesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.scanProxiesBtn = new System.Windows.Forms.Button();
            this.threadsProxiesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proxyView = new System.Windows.Forms.ListView();
            this.proxyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.latencyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.levelHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proxiesToScanLbl = new System.Windows.Forms.Label();
            this.importProxiesBtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.harvestProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.harvestStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toScraperBtn = new System.Windows.Forms.Button();
            this.queriesLeftLbl = new System.Windows.Forms.Label();
            this.deleteHarvestItemBtn = new System.Windows.Forms.Button();
            this.saveHarvestBtn = new System.Windows.Forms.Button();
            this.clearHarvestBtn = new System.Windows.Forms.Button();
            this.urlsHarvestedLbl = new System.Windows.Forms.Label();
            this.harvestBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.harvestBtn = new System.Windows.Forms.Button();
            this.pagesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.queryRTBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumUpDown)).BeginInit();
            this.scrapedPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutProxiesNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsProxiesNumUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagesNumUpDown)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 398);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.questionScraperBtn);
            this.tabPage1.Controls.Add(this.autoScanCheck);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.scrapeProgBar);
            this.tabPage1.Controls.Add(this.timeoutNumUpDown);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.scrapeBtn);
            this.tabPage1.Controls.Add(this.threadCountNumUpDown);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.scrapedPanel);
            this.tabPage1.Controls.Add(this.scrapedLbl);
            this.tabPage1.Controls.Add(this.scrapedListBox);
            this.tabPage1.Controls.Add(this.urlsToScrapeLbl);
            this.tabPage1.Controls.Add(this.importURLsBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scraper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // questionScraperBtn
            // 
            this.questionScraperBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionScraperBtn.Location = new System.Drawing.Point(10, 7);
            this.questionScraperBtn.Name = "questionScraperBtn";
            this.questionScraperBtn.Size = new System.Drawing.Size(23, 23);
            this.questionScraperBtn.TabIndex = 16;
            this.questionScraperBtn.Text = "?";
            this.questionScraperBtn.UseVisualStyleBackColor = true;
            this.questionScraperBtn.Click += new System.EventHandler(this.questionScraperBtn_Click);
            // 
            // autoScanCheck
            // 
            this.autoScanCheck.AutoSize = true;
            this.autoScanCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoScanCheck.Location = new System.Drawing.Point(124, 34);
            this.autoScanCheck.Name = "autoScanCheck";
            this.autoScanCheck.Size = new System.Drawing.Size(82, 19);
            this.autoScanCheck.TabIndex = 15;
            this.autoScanCheck.Text = "Auto-Scan";
            this.autoScanCheck.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(3, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(368, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(49, 17);
            this.statusLbl.Text = "hehe xD";
            // 
            // scrapeProgBar
            // 
            this.scrapeProgBar.Location = new System.Drawing.Point(7, 309);
            this.scrapeProgBar.Name = "scrapeProgBar";
            this.scrapeProgBar.Size = new System.Drawing.Size(228, 23);
            this.scrapeProgBar.TabIndex = 13;
            // 
            // timeoutNumUpDown
            // 
            this.timeoutNumUpDown.Location = new System.Drawing.Point(306, 309);
            this.timeoutNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutNumUpDown.Name = "timeoutNumUpDown";
            this.timeoutNumUpDown.Size = new System.Drawing.Size(61, 22);
            this.timeoutNumUpDown.TabIndex = 12;
            this.timeoutNumUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Timeout:";
            // 
            // scrapeBtn
            // 
            this.scrapeBtn.Location = new System.Drawing.Point(7, 278);
            this.scrapeBtn.Name = "scrapeBtn";
            this.scrapeBtn.Size = new System.Drawing.Size(228, 26);
            this.scrapeBtn.TabIndex = 10;
            this.scrapeBtn.Text = "Scrape";
            this.scrapeBtn.UseVisualStyleBackColor = true;
            this.scrapeBtn.Click += new System.EventHandler(this.scrapeBtn_Click);
            // 
            // threadCountNumUpDown
            // 
            this.threadCountNumUpDown.Location = new System.Drawing.Point(306, 281);
            this.threadCountNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCountNumUpDown.Name = "threadCountNumUpDown";
            this.threadCountNumUpDown.Size = new System.Drawing.Size(61, 22);
            this.threadCountNumUpDown.TabIndex = 9;
            this.threadCountNumUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Threads:";
            // 
            // scrapedPanel
            // 
            this.scrapedPanel.Controls.Add(this.toScannerBtn);
            this.scrapedPanel.Controls.Add(this.clearScrapedBtn);
            this.scrapedPanel.Controls.Add(this.saveScrapedBtn);
            this.scrapedPanel.Location = new System.Drawing.Point(238, 62);
            this.scrapedPanel.Name = "scrapedPanel";
            this.scrapedPanel.Size = new System.Drawing.Size(109, 81);
            this.scrapedPanel.TabIndex = 7;
            // 
            // toScannerBtn
            // 
            this.toScannerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toScannerBtn.Location = new System.Drawing.Point(1, 1);
            this.toScannerBtn.Name = "toScannerBtn";
            this.toScannerBtn.Size = new System.Drawing.Size(107, 26);
            this.toScannerBtn.TabIndex = 5;
            this.toScannerBtn.Text = "To Scanner";
            this.toScannerBtn.UseVisualStyleBackColor = true;
            this.toScannerBtn.Click += new System.EventHandler(this.toScannerBtn_Click);
            // 
            // clearScrapedBtn
            // 
            this.clearScrapedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearScrapedBtn.Location = new System.Drawing.Point(1, 53);
            this.clearScrapedBtn.Name = "clearScrapedBtn";
            this.clearScrapedBtn.Size = new System.Drawing.Size(107, 26);
            this.clearScrapedBtn.TabIndex = 6;
            this.clearScrapedBtn.Text = "Clear";
            this.clearScrapedBtn.UseVisualStyleBackColor = true;
            this.clearScrapedBtn.Click += new System.EventHandler(this.clearScrapedBtn_Click);
            // 
            // saveScrapedBtn
            // 
            this.saveScrapedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveScrapedBtn.Location = new System.Drawing.Point(1, 27);
            this.saveScrapedBtn.Name = "saveScrapedBtn";
            this.saveScrapedBtn.Size = new System.Drawing.Size(107, 26);
            this.saveScrapedBtn.TabIndex = 4;
            this.saveScrapedBtn.Text = "Save";
            this.saveScrapedBtn.UseVisualStyleBackColor = true;
            this.saveScrapedBtn.Click += new System.EventHandler(this.saveScrapedBtn_Click);
            // 
            // scrapedLbl
            // 
            this.scrapedLbl.AutoSize = true;
            this.scrapedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrapedLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.scrapedLbl.Location = new System.Drawing.Point(7, 40);
            this.scrapedLbl.Name = "scrapedLbl";
            this.scrapedLbl.Size = new System.Drawing.Size(73, 16);
            this.scrapedLbl.TabIndex = 3;
            this.scrapedLbl.Text = "Scraped: 0";
            // 
            // scrapedListBox
            // 
            this.scrapedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrapedListBox.FormattingEnabled = true;
            this.scrapedListBox.Location = new System.Drawing.Point(7, 59);
            this.scrapedListBox.Name = "scrapedListBox";
            this.scrapedListBox.Size = new System.Drawing.Size(361, 212);
            this.scrapedListBox.TabIndex = 2;
            // 
            // urlsToScrapeLbl
            // 
            this.urlsToScrapeLbl.AutoSize = true;
            this.urlsToScrapeLbl.Location = new System.Drawing.Point(103, 17);
            this.urlsToScrapeLbl.Name = "urlsToScrapeLbl";
            this.urlsToScrapeLbl.Size = new System.Drawing.Size(122, 16);
            this.urlsToScrapeLbl.TabIndex = 1;
            this.urlsToScrapeLbl.Text = "URLs To Scrape: 0";
            // 
            // importURLsBtn
            // 
            this.importURLsBtn.Location = new System.Drawing.Point(241, 11);
            this.importURLsBtn.Name = "importURLsBtn";
            this.importURLsBtn.Size = new System.Drawing.Size(126, 26);
            this.importURLsBtn.TabIndex = 0;
            this.importURLsBtn.Text = "Import URLs";
            this.importURLsBtn.UseVisualStyleBackColor = true;
            this.importURLsBtn.Click += new System.EventHandler(this.importURLsBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.removeDangCheck);
            this.tabPage2.Controls.Add(this.socksCheck);
            this.tabPage2.Controls.Add(this.httpCheck);
            this.tabPage2.Controls.Add(this.proxyJudgesComboBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.deadLbl);
            this.tabPage2.Controls.Add(this.aliveLbl);
            this.tabPage2.Controls.Add(this.statusStrip2);
            this.tabPage2.Controls.Add(this.timeoutProxiesNumUpDown);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.scanProxiesBtn);
            this.tabPage2.Controls.Add(this.threadsProxiesNumUpDown);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.proxiesToScanLbl);
            this.tabPage2.Controls.Add(this.importProxiesBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(374, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scanner";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // removeDangCheck
            // 
            this.removeDangCheck.AutoSize = true;
            this.removeDangCheck.Checked = true;
            this.removeDangCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removeDangCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeDangCheck.Location = new System.Drawing.Point(243, 54);
            this.removeDangCheck.Name = "removeDangCheck";
            this.removeDangCheck.Size = new System.Drawing.Size(121, 17);
            this.removeDangCheck.TabIndex = 28;
            this.removeDangCheck.Text = "Remove Dangerous";
            this.removeDangCheck.UseVisualStyleBackColor = true;
            // 
            // socksCheck
            // 
            this.socksCheck.AutoSize = true;
            this.socksCheck.Checked = true;
            this.socksCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.socksCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socksCheck.Location = new System.Drawing.Point(299, 324);
            this.socksCheck.Name = "socksCheck";
            this.socksCheck.Size = new System.Drawing.Size(62, 17);
            this.socksCheck.TabIndex = 26;
            this.socksCheck.Text = "SOCKS";
            this.socksCheck.UseVisualStyleBackColor = true;
            this.socksCheck.CheckedChanged += new System.EventHandler(this.socksCheck_CheckedChanged);
            // 
            // httpCheck
            // 
            this.httpCheck.AutoSize = true;
            this.httpCheck.Checked = true;
            this.httpCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.httpCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.httpCheck.Location = new System.Drawing.Point(238, 324);
            this.httpCheck.Name = "httpCheck";
            this.httpCheck.Size = new System.Drawing.Size(55, 17);
            this.httpCheck.TabIndex = 25;
            this.httpCheck.Text = "HTTP";
            this.httpCheck.UseVisualStyleBackColor = true;
            this.httpCheck.CheckedChanged += new System.EventHandler(this.httpCheck_CheckedChanged);
            // 
            // proxyJudgesComboBox
            // 
            this.proxyJudgesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.proxyJudgesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyJudgesComboBox.FormattingEnabled = true;
            this.proxyJudgesComboBox.Items.AddRange(new object[] {
            "http://proxyjudge.info/azenv.php",
            "http://pascal.hoez.free.fr/azenv.php",
            "http://www.proxy-listen.de/azenv.php",
            "http://proxyjudge.info/",
            "http://birdingonthe.net/cgi-bin/env.pl",
            "http://www.omgwallhack.org/toys/env.cgi",
            "http://www.nucleoproducoes.com.br/1/azenv.php",
            "http://users.on.net/~emerson/env/env.pl",
            "http://www2t.biglobe.ne.jp/~take52/test/env.cgi",
            "http://www.e-cotton.jp/env.cgi"});
            this.proxyJudgesComboBox.Location = new System.Drawing.Point(13, 29);
            this.proxyJudgesComboBox.Name = "proxyJudgesComboBox";
            this.proxyJudgesComboBox.Size = new System.Drawing.Size(206, 21);
            this.proxyJudgesComboBox.TabIndex = 24;
            this.proxyJudgesComboBox.SelectedIndexChanged += new System.EventHandler(this.proxyJudgesComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Proxy Judge: ";
            // 
            // deadLbl
            // 
            this.deadLbl.AutoSize = true;
            this.deadLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deadLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deadLbl.Location = new System.Drawing.Point(10, 317);
            this.deadLbl.Name = "deadLbl";
            this.deadLbl.Size = new System.Drawing.Size(57, 15);
            this.deadLbl.TabIndex = 22;
            this.deadLbl.Text = "Dead = 0";
            // 
            // aliveLbl
            // 
            this.aliveLbl.AutoSize = true;
            this.aliveLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliveLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.aliveLbl.Location = new System.Drawing.Point(10, 302);
            this.aliveLbl.Name = "aliveLbl";
            this.aliveLbl.Size = new System.Drawing.Size(52, 15);
            this.aliveLbl.TabIndex = 21;
            this.aliveLbl.Text = "Alive = 0";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanProgBar,
            this.scanPercentLbl});
            this.statusStrip2.Location = new System.Drawing.Point(3, 344);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(368, 22);
            this.statusStrip2.TabIndex = 20;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // scanProgBar
            // 
            this.scanProgBar.Name = "scanProgBar";
            this.scanProgBar.Size = new System.Drawing.Size(200, 16);
            // 
            // scanPercentLbl
            // 
            this.scanPercentLbl.Name = "scanPercentLbl";
            this.scanPercentLbl.Size = new System.Drawing.Size(35, 17);
            this.scanPercentLbl.Text = "100%";
            // 
            // timeoutProxiesNumUpDown
            // 
            this.timeoutProxiesNumUpDown.Location = new System.Drawing.Point(300, 296);
            this.timeoutProxiesNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutProxiesNumUpDown.Name = "timeoutProxiesNumUpDown";
            this.timeoutProxiesNumUpDown.Size = new System.Drawing.Size(61, 22);
            this.timeoutProxiesNumUpDown.TabIndex = 18;
            this.timeoutProxiesNumUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.timeoutProxiesNumUpDown.ValueChanged += new System.EventHandler(this.timeoutProxiesNumUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Timeout:";
            // 
            // scanProxiesBtn
            // 
            this.scanProxiesBtn.Enabled = false;
            this.scanProxiesBtn.Location = new System.Drawing.Point(7, 273);
            this.scanProxiesBtn.Name = "scanProxiesBtn";
            this.scanProxiesBtn.Size = new System.Drawing.Size(222, 26);
            this.scanProxiesBtn.TabIndex = 16;
            this.scanProxiesBtn.Text = "Scan";
            this.scanProxiesBtn.UseVisualStyleBackColor = true;
            this.scanProxiesBtn.Click += new System.EventHandler(this.scanProxiesBtn_Click);
            // 
            // threadsProxiesNumUpDown
            // 
            this.threadsProxiesNumUpDown.Location = new System.Drawing.Point(300, 272);
            this.threadsProxiesNumUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.threadsProxiesNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadsProxiesNumUpDown.Name = "threadsProxiesNumUpDown";
            this.threadsProxiesNumUpDown.Size = new System.Drawing.Size(61, 22);
            this.threadsProxiesNumUpDown.TabIndex = 15;
            this.threadsProxiesNumUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Threads:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proxyView);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 196);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxies:";
            // 
            // proxyView
            // 
            this.proxyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.proxyHeader,
            this.latencyHeader,
            this.typeHeader,
            this.levelHeader});
            this.proxyView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyView.FullRowSelect = true;
            this.proxyView.GridLines = true;
            this.proxyView.Location = new System.Drawing.Point(6, 21);
            this.proxyView.Name = "proxyView";
            this.proxyView.Size = new System.Drawing.Size(348, 167);
            this.proxyView.TabIndex = 0;
            this.proxyView.UseCompatibleStateImageBehavior = false;
            this.proxyView.View = System.Windows.Forms.View.Details;
            // 
            // proxyHeader
            // 
            this.proxyHeader.Text = "Proxy";
            this.proxyHeader.Width = 125;
            // 
            // latencyHeader
            // 
            this.latencyHeader.Text = "Latency";
            this.latencyHeader.Width = 62;
            // 
            // typeHeader
            // 
            this.typeHeader.Text = "Type";
            this.typeHeader.Width = 65;
            // 
            // levelHeader
            // 
            this.levelHeader.Text = "Level";
            this.levelHeader.Width = 75;
            // 
            // proxiesToScanLbl
            // 
            this.proxiesToScanLbl.AutoSize = true;
            this.proxiesToScanLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxiesToScanLbl.Location = new System.Drawing.Point(250, 7);
            this.proxiesToScanLbl.Name = "proxiesToScanLbl";
            this.proxiesToScanLbl.Size = new System.Drawing.Size(105, 15);
            this.proxiesToScanLbl.TabIndex = 3;
            this.proxiesToScanLbl.Text = "Proxies to Scan: 0";
            // 
            // importProxiesBtn
            // 
            this.importProxiesBtn.Location = new System.Drawing.Point(238, 25);
            this.importProxiesBtn.Name = "importProxiesBtn";
            this.importProxiesBtn.Size = new System.Drawing.Size(129, 26);
            this.importProxiesBtn.TabIndex = 2;
            this.importProxiesBtn.Text = "Import Proxies";
            this.importProxiesBtn.UseVisualStyleBackColor = true;
            this.importProxiesBtn.Click += new System.EventHandler(this.importProxiesBtn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.statusStrip3);
            this.tabPage3.Controls.Add(this.toScraperBtn);
            this.tabPage3.Controls.Add(this.queriesLeftLbl);
            this.tabPage3.Controls.Add(this.deleteHarvestItemBtn);
            this.tabPage3.Controls.Add(this.saveHarvestBtn);
            this.tabPage3.Controls.Add(this.clearHarvestBtn);
            this.tabPage3.Controls.Add(this.urlsHarvestedLbl);
            this.tabPage3.Controls.Add(this.harvestBox);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(374, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "URL Harvester";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.harvestProgBar,
            this.harvestStatusLbl});
            this.statusStrip3.Location = new System.Drawing.Point(3, 344);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(368, 22);
            this.statusStrip3.TabIndex = 8;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // harvestProgBar
            // 
            this.harvestProgBar.Name = "harvestProgBar";
            this.harvestProgBar.Size = new System.Drawing.Size(121, 16);
            this.harvestProgBar.Visible = false;
            // 
            // harvestStatusLbl
            // 
            this.harvestStatusLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.harvestStatusLbl.Name = "harvestStatusLbl";
            this.harvestStatusLbl.Size = new System.Drawing.Size(64, 17);
            this.harvestStatusLbl.Text = "Status: Idle";
            // 
            // toScraperBtn
            // 
            this.toScraperBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toScraperBtn.Location = new System.Drawing.Point(271, 285);
            this.toScraperBtn.Name = "toScraperBtn";
            this.toScraperBtn.Size = new System.Drawing.Size(98, 25);
            this.toScraperBtn.TabIndex = 7;
            this.toScraperBtn.Text = "To Scraper";
            this.toScraperBtn.UseVisualStyleBackColor = true;
            this.toScraperBtn.Click += new System.EventHandler(this.toScraperBtn_Click);
            // 
            // queriesLeftLbl
            // 
            this.queriesLeftLbl.AutoSize = true;
            this.queriesLeftLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queriesLeftLbl.Location = new System.Drawing.Point(272, 201);
            this.queriesLeftLbl.Name = "queriesLeftLbl";
            this.queriesLeftLbl.Size = new System.Drawing.Size(90, 13);
            this.queriesLeftLbl.TabIndex = 6;
            this.queriesLeftLbl.Text = "Queries: 100/100";
            // 
            // deleteHarvestItemBtn
            // 
            this.deleteHarvestItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteHarvestItemBtn.Location = new System.Drawing.Point(271, 258);
            this.deleteHarvestItemBtn.Name = "deleteHarvestItemBtn";
            this.deleteHarvestItemBtn.Size = new System.Drawing.Size(98, 25);
            this.deleteHarvestItemBtn.TabIndex = 5;
            this.deleteHarvestItemBtn.Text = "Delete";
            this.deleteHarvestItemBtn.UseVisualStyleBackColor = true;
            this.deleteHarvestItemBtn.Click += new System.EventHandler(this.deleteHarvestItemBtn_Click);
            // 
            // saveHarvestBtn
            // 
            this.saveHarvestBtn.Location = new System.Drawing.Point(270, 316);
            this.saveHarvestBtn.Name = "saveHarvestBtn";
            this.saveHarvestBtn.Size = new System.Drawing.Size(98, 25);
            this.saveHarvestBtn.TabIndex = 4;
            this.saveHarvestBtn.Text = "&Save";
            this.saveHarvestBtn.UseVisualStyleBackColor = true;
            this.saveHarvestBtn.Click += new System.EventHandler(this.saveHarvestBtn_Click);
            // 
            // clearHarvestBtn
            // 
            this.clearHarvestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHarvestBtn.Location = new System.Drawing.Point(271, 231);
            this.clearHarvestBtn.Name = "clearHarvestBtn";
            this.clearHarvestBtn.Size = new System.Drawing.Size(98, 25);
            this.clearHarvestBtn.TabIndex = 3;
            this.clearHarvestBtn.Text = "Clear";
            this.clearHarvestBtn.UseVisualStyleBackColor = true;
            this.clearHarvestBtn.Click += new System.EventHandler(this.clearHarvestBtn_Click);
            // 
            // urlsHarvestedLbl
            // 
            this.urlsHarvestedLbl.AutoSize = true;
            this.urlsHarvestedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlsHarvestedLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.urlsHarvestedLbl.Location = new System.Drawing.Point(271, 185);
            this.urlsHarvestedLbl.Name = "urlsHarvestedLbl";
            this.urlsHarvestedLbl.Size = new System.Drawing.Size(55, 16);
            this.urlsHarvestedLbl.TabIndex = 2;
            this.urlsHarvestedLbl.Text = "URLs: 0";
            // 
            // harvestBox
            // 
            this.harvestBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.harvestBox.FormattingEnabled = true;
            this.harvestBox.Location = new System.Drawing.Point(13, 181);
            this.harvestBox.Name = "harvestBox";
            this.harvestBox.Size = new System.Drawing.Size(251, 160);
            this.harvestBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.harvestBtn);
            this.groupBox2.Controls.Add(this.pagesNumUpDown);
            this.groupBox2.Controls.Add(this.queryRTBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BING Queries:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(289, 40);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(61, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "{DateTime}";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(268, 25);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "BING Operators";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // harvestBtn
            // 
            this.harvestBtn.ForeColor = System.Drawing.Color.Black;
            this.harvestBtn.Location = new System.Drawing.Point(6, 132);
            this.harvestBtn.Name = "harvestBtn";
            this.harvestBtn.Size = new System.Drawing.Size(240, 25);
            this.harvestBtn.TabIndex = 3;
            this.harvestBtn.Text = "Harvest";
            this.harvestBtn.UseVisualStyleBackColor = true;
            this.harvestBtn.Click += new System.EventHandler(this.harvestBtn_Click);
            // 
            // pagesNumUpDown
            // 
            this.pagesNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagesNumUpDown.ForeColor = System.Drawing.Color.Black;
            this.pagesNumUpDown.Location = new System.Drawing.Point(298, 134);
            this.pagesNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pagesNumUpDown.Name = "pagesNumUpDown";
            this.pagesNumUpDown.Size = new System.Drawing.Size(57, 21);
            this.pagesNumUpDown.TabIndex = 2;
            this.pagesNumUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // queryRTBox
            // 
            this.queryRTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.queryRTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryRTBox.ForeColor = System.Drawing.Color.Teal;
            this.queryRTBox.Location = new System.Drawing.Point(6, 21);
            this.queryRTBox.Name = "queryRTBox";
            this.queryRTBox.Size = new System.Drawing.Size(348, 106);
            this.queryRTBox.TabIndex = 0;
            this.queryRTBox.Text = "proxies inbody:{dd}-{mmm}-{yyyy}\nproxies inbody:{dd} {mmm} {yyyy}\nproxies inbody:" +
    "{d}\nsocks proxies inbody:{d}\nhttp proxies inbody:{d}";
            this.queryRTBox.TextChanged += new System.EventHandler(this.queryRTBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(252, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pages:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.linkLabel5);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.linkLabel4);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.linkLabel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(374, 369);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(105, 75);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(148, 16);
            this.linkLabel5.TabIndex = 7;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "https://github.com/jpxue";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(254, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "You can find the source of this program at:";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(97, 294);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(168, 16);
            this.linkLabel4.TabIndex = 5;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "http://www.iconarchive.com";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "- Artist of this ugly ass icon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "- Ruslan Khuduev (X-Net)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(77, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Credits:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CS_Proxy.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(94, 243);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(177, 16);
            this.linkLabel3.TabIndex = 0;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://github.com/X-rus/xNet";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 76);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toClipboardToolStripMenuItem
            // 
            this.toClipboardToolStripMenuItem.Name = "toClipboardToolStripMenuItem";
            this.toClipboardToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.toClipboardToolStripMenuItem.Text = "To Clipboard";
            this.toClipboardToolStripMenuItem.Click += new System.EventHandler(this.toClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "[C#] Proxy Toolkit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumUpDown)).EndInit();
            this.scrapedPanel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutProxiesNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsProxiesNumUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagesNumUpDown)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown threadCountNumUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel scrapedPanel;
        private System.Windows.Forms.Button toScannerBtn;
        private System.Windows.Forms.Button clearScrapedBtn;
        private System.Windows.Forms.Button saveScrapedBtn;
        private System.Windows.Forms.Label urlsToScrapeLbl;
        private System.Windows.Forms.Button importURLsBtn;
        private System.Windows.Forms.NumericUpDown timeoutNumUpDown;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label scrapedLbl;
        public System.Windows.Forms.ListBox scrapedListBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.Button scrapeBtn;
        private System.Windows.Forms.ProgressBar scrapeProgBar;
        private System.Windows.Forms.Label proxiesToScanLbl;
        private System.Windows.Forms.Button importProxiesBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView proxyView;
        private System.Windows.Forms.ColumnHeader proxyHeader;
        private System.Windows.Forms.ColumnHeader latencyHeader;
        private System.Windows.Forms.ColumnHeader typeHeader;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar scanProgBar;
        private System.Windows.Forms.NumericUpDown timeoutProxiesNumUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button scanProxiesBtn;
        private System.Windows.Forms.NumericUpDown threadsProxiesNumUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel scanPercentLbl;
        private System.Windows.Forms.Label deadLbl;
        private System.Windows.Forms.Label aliveLbl;
        private System.Windows.Forms.ComboBox proxyJudgesComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox autoScanCheck;
        private System.Windows.Forms.ColumnHeader levelHeader;
        private System.Windows.Forms.CheckBox socksCheck;
        private System.Windows.Forms.CheckBox httpCheck;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toClipboardToolStripMenuItem;
        private System.Windows.Forms.Button questionScraperBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox harvestBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown pagesNumUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox queryRTBox;
        private System.Windows.Forms.Button harvestBtn;
        private System.Windows.Forms.CheckBox removeDangCheck;
        private System.Windows.Forms.Button deleteHarvestItemBtn;
        private System.Windows.Forms.Button saveHarvestBtn;
        private System.Windows.Forms.Button clearHarvestBtn;
        private System.Windows.Forms.Label urlsHarvestedLbl;
        private System.Windows.Forms.Label queriesLeftLbl;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button toScraperBtn;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ToolStripStatusLabel harvestStatusLbl;
        private System.Windows.Forms.ToolStripProgressBar harvestProgBar;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel4;
    }
}

