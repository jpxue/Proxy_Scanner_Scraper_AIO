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
using System.Windows.Forms;

using CS_Proxy.Lists;
using CS_Proxy.Classes.Multithreaded;

namespace CS_Proxy
{
    public partial class Form2 : Form
    {
        ProxyManager ProxyMgr;
        bool ToClip = false;
        bool ToFile = false;

        public Form2(bool toClip, bool toFile, string wndName, ProxyManager pmgr)
        {
            ToClip = toClip;
            ToFile = toFile;
            InitializeComponent();
            this.Text = wndName;
            ProxyMgr = pmgr;
        }

        private string GetSaveLocation()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Proxies.txt";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
                return sfd.FileName;

            return string.Empty;
        }

        private void Output(ProxyManager.ProxyGeneralType type)
        {
            if (ToFile)
            {
                string file = GetSaveLocation();
                if (file != string.Empty)
                    ProxyMgr.Output(type, false, file, eliteCheck.Checked, highCheck.Checked, transCheck.Checked);
            }
            if (ToClip)
                ProxyMgr.Output(type, true, string.Empty, eliteCheck.Checked, highCheck.Checked, transCheck.Checked);

            System.Media.SystemSounds.Beep.Play();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = string.Concat("ALL = ", Scanner.Alive.ToString(), "   |   HTTP = ", Scanner.Https.ToString(), "   |   SOCKS = ", Scanner.Socks.ToString());
            label2.Text = string.Concat("L3 = ", Scanner.Elite.ToString(), "   |   L2 = ", Scanner.High.ToString(), "   |   L1 = ", Scanner.Trans.ToString());
            allBtn.Enabled = Scanner.Https + Scanner.Socks > 0;
            httpBtn.Enabled = Scanner.Https > 0;
            socksBtn.Enabled = Scanner.Socks > 0;
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            Output(ProxyManager.ProxyGeneralType.ALL);
        }

        private void httpBtn_Click(object sender, EventArgs e)
        {
            Output(ProxyManager.ProxyGeneralType.HTTP);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Output(ProxyManager.ProxyGeneralType.SOCKS);
        }
    }
}
