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
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.allBtn = new System.Windows.Forms.Button();
            this.httpBtn = new System.Windows.Forms.Button();
            this.socks4Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eliteCheck = new System.Windows.Forms.CheckBox();
            this.highCheck = new System.Windows.Forms.CheckBox();
            this.transCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.socks5Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // allBtn
            // 
            this.allBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allBtn.Location = new System.Drawing.Point(5, 5);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(68, 25);
            this.allBtn.TabIndex = 0;
            this.allBtn.Text = "ALL";
            this.allBtn.UseVisualStyleBackColor = true;
            this.allBtn.Click += new System.EventHandler(this.allBtn_Click);
            // 
            // httpBtn
            // 
            this.httpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.httpBtn.Location = new System.Drawing.Point(79, 5);
            this.httpBtn.Name = "httpBtn";
            this.httpBtn.Size = new System.Drawing.Size(68, 25);
            this.httpBtn.TabIndex = 1;
            this.httpBtn.Text = "HTTP";
            this.httpBtn.UseVisualStyleBackColor = true;
            this.httpBtn.Click += new System.EventHandler(this.httpBtn_Click);
            // 
            // socks4Btn
            // 
            this.socks4Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socks4Btn.Location = new System.Drawing.Point(153, 5);
            this.socks4Btn.Name = "socks4Btn";
            this.socks4Btn.Size = new System.Drawing.Size(68, 25);
            this.socks4Btn.TabIndex = 2;
            this.socks4Btn.Text = "SOCKS4";
            this.socks4Btn.UseVisualStyleBackColor = true;
            this.socks4Btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ALL = 0    |    HTTP = 0    |    SOCKS = 0";
            // 
            // eliteCheck
            // 
            this.eliteCheck.AutoSize = true;
            this.eliteCheck.Checked = true;
            this.eliteCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eliteCheck.Location = new System.Drawing.Point(12, 77);
            this.eliteCheck.Name = "eliteCheck";
            this.eliteCheck.Size = new System.Drawing.Size(67, 17);
            this.eliteCheck.TabIndex = 4;
            this.eliteCheck.Text = "Elite (L3)";
            this.eliteCheck.UseVisualStyleBackColor = true;
            // 
            // highCheck
            // 
            this.highCheck.AutoSize = true;
            this.highCheck.Checked = true;
            this.highCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highCheck.Location = new System.Drawing.Point(101, 77);
            this.highCheck.Name = "highCheck";
            this.highCheck.Size = new System.Drawing.Size(69, 17);
            this.highCheck.TabIndex = 5;
            this.highCheck.Text = "High (L2)";
            this.highCheck.UseVisualStyleBackColor = true;
            // 
            // transCheck
            // 
            this.transCheck.AutoSize = true;
            this.transCheck.Location = new System.Drawing.Point(188, 77);
            this.transCheck.Name = "transCheck";
            this.transCheck.Size = new System.Drawing.Size(104, 17);
            this.transCheck.TabIndex = 6;
            this.transCheck.Text = "Transparent (L1)";
            this.transCheck.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Elite = 0    |    High = 0    |    Transparent = 0";
            // 
            // socks5Btn
            // 
            this.socks5Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socks5Btn.Location = new System.Drawing.Point(227, 5);
            this.socks5Btn.Name = "socks5Btn";
            this.socks5Btn.Size = new System.Drawing.Size(68, 25);
            this.socks5Btn.TabIndex = 8;
            this.socks5Btn.Text = "SOCKS5";
            this.socks5Btn.UseVisualStyleBackColor = true;
            this.socks5Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 106);
            this.Controls.Add(this.socks5Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transCheck);
            this.Controls.Add(this.highCheck);
            this.Controls.Add(this.eliteCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.socks4Btn);
            this.Controls.Add(this.httpBtn);
            this.Controls.Add(this.allBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button allBtn;
        private System.Windows.Forms.Button httpBtn;
        private System.Windows.Forms.Button socks4Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eliteCheck;
        private System.Windows.Forms.CheckBox highCheck;
        private System.Windows.Forms.CheckBox transCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button socks5Btn;
    }
}