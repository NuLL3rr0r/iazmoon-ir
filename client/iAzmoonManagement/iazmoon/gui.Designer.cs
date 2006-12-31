namespace iazmoon
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnF5 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnF1 = new System.Windows.Forms.Button();
            this.btnPw = new System.Windows.Forms.Button();
            this.ctxMinimize = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxTimeSinceReboot = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentOSVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxFrameworkVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentTimeZone = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tItmF5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tItmF9 = new System.Windows.Forms.ToolStripMenuItem();
            this.tItmF1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tItmF10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ntfyMinimize = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMinimize.SuspendLayout();
            this.ctxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF5
            // 
            this.btnF5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF5.Image = global::iazmoon.Properties.Resources.TOON_XP_Icons__V1c__Icon_76;
            this.btnF5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF5.Location = new System.Drawing.Point(13, 13);
            this.btnF5.Margin = new System.Windows.Forms.Padding(4);
            this.btnF5.Name = "btnF5";
            this.btnF5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnF5.Size = new System.Drawing.Size(291, 77);
            this.btnF5.TabIndex = 0;
            this.btnF5.Text = "œ«Êÿ·»   F5";
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::iazmoon.Properties.Resources.TOON_XP_Icons__V1c__Icon_20;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(13, 268);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(291, 77);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Œ—ÊÃ   F10";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnF1
            // 
            this.btnF1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF1.Image = global::iazmoon.Properties.Resources.TOON_XP_Icons__V1c__Icon_99;
            this.btnF1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF1.Location = new System.Drawing.Point(13, 183);
            this.btnF1.Margin = new System.Windows.Forms.Padding(4);
            this.btnF1.Name = "btnF1";
            this.btnF1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnF1.Size = new System.Drawing.Size(291, 77);
            this.btnF1.TabIndex = 2;
            this.btnF1.Text = "œ—»«—Â   F1";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // btnPw
            // 
            this.btnPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPw.Image = global::iazmoon.Properties.Resources.TOON_XP_Icons__V1c__Icon_18;
            this.btnPw.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPw.Location = new System.Drawing.Point(13, 98);
            this.btnPw.Margin = new System.Windows.Forms.Padding(4);
            this.btnPw.Name = "btnPw";
            this.btnPw.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPw.Size = new System.Drawing.Size(291, 77);
            this.btnPw.TabIndex = 1;
            this.btnPw.Text = "ﬂ·„Â Ì ⁄»Ê—   F9";
            this.btnPw.UseVisualStyleBackColor = true;
            this.btnPw.Click += new System.EventHandler(this.btnPw_Click);
            // 
            // ctxMinimize
            // 
            this.ctxMinimize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxReturn,
            this.toolStripMenuItem1,
            this.ctxTimeSinceReboot,
            this.ctxCurrentOSVersion,
            this.ctxFrameworkVersion,
            this.ctxCurrentTimeZone,
            this.ctxCurrentDate,
            this.toolStripMenuItem2,
            this.ctxExit});
            this.ctxMinimize.Name = "ctxMinimize";
            this.ctxMinimize.Size = new System.Drawing.Size(230, 170);
            // 
            // ctxReturn
            // 
            this.ctxReturn.Name = "ctxReturn";
            this.ctxReturn.Size = new System.Drawing.Size(229, 22);
            this.ctxReturn.Text = "»«“ê‘  »Â »—‰«„Â";
            this.ctxReturn.Click += new System.EventHandler(this.ctxReturn_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 6);
            // 
            // ctxTimeSinceReboot
            // 
            this.ctxTimeSinceReboot.Name = "ctxTimeSinceReboot";
            this.ctxTimeSinceReboot.Size = new System.Drawing.Size(229, 22);
            this.ctxTimeSinceReboot.Text = "„œ  “„«‰Ì ﬂÂ Ê«—œ ÊÌ‰œÊ“ ‘œÂ «Ìœ";
            this.ctxTimeSinceReboot.Click += new System.EventHandler(this.ctxTimeSinceReboot_Click);
            // 
            // ctxCurrentOSVersion
            // 
            this.ctxCurrentOSVersion.Name = "ctxCurrentOSVersion";
            this.ctxCurrentOSVersion.Size = new System.Drawing.Size(229, 22);
            this.ctxCurrentOSVersion.Text = "‰”ŒÂ ”Ì” „ ⁄«„· ›⁄·Ì ‘„«";
            this.ctxCurrentOSVersion.Click += new System.EventHandler(this.ctxCurrentOSVersion_Click);
            // 
            // ctxFrameworkVersion
            // 
            this.ctxFrameworkVersion.Name = "ctxFrameworkVersion";
            this.ctxFrameworkVersion.Size = new System.Drawing.Size(229, 22);
            this.ctxFrameworkVersion.Text = "‰”ŒÂ ›⁄·Ì dotNET Framework";
            this.ctxFrameworkVersion.Click += new System.EventHandler(this.ctxFrameworkVersion_Click);
            // 
            // ctxCurrentTimeZone
            // 
            this.ctxCurrentTimeZone.Name = "ctxCurrentTimeZone";
            this.ctxCurrentTimeZone.Size = new System.Drawing.Size(229, 22);
            this.ctxCurrentTimeZone.Text = "„‰ÿﬁÂ “„«‰Ì ›⁄·Ì";
            this.ctxCurrentTimeZone.Click += new System.EventHandler(this.ctxCurrentTimeZone_Click);
            // 
            // ctxCurrentDate
            // 
            this.ctxCurrentDate.Name = "ctxCurrentDate";
            this.ctxCurrentDate.Size = new System.Drawing.Size(229, 22);
            this.ctxCurrentDate.Text = " «—ÌŒ Ê ”«⁄  ›⁄·Ì";
            this.ctxCurrentDate.Click += new System.EventHandler(this.ctxCurrentDate_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 6);
            // 
            // ctxExit
            // 
            this.ctxExit.Name = "ctxExit";
            this.ctxExit.Size = new System.Drawing.Size(229, 22);
            this.ctxExit.Text = "Œ—ÊÃ";
            this.ctxExit.Click += new System.EventHandler(this.ctxExit_Click);
            // 
            // ctxMain
            // 
            this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tItmF5,
            this.tItmF9,
            this.tItmF1,
            this.tItmF10});
            this.ctxMain.Name = "ctxMain";
            this.ctxMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMain.Size = new System.Drawing.Size(152, 92);
            // 
            // tItmF5
            // 
            this.tItmF5.Name = "tItmF5";
            this.tItmF5.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tItmF5.Size = new System.Drawing.Size(151, 22);
            this.tItmF5.Text = "œ«Êÿ·»";
            this.tItmF5.Click += new System.EventHandler(this.tItmF5_Click);
            // 
            // tItmF9
            // 
            this.tItmF9.Name = "tItmF9";
            this.tItmF9.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.tItmF9.Size = new System.Drawing.Size(151, 22);
            this.tItmF9.Text = "ﬂ·„Â Ì ⁄»Ê—";
            this.tItmF9.Click += new System.EventHandler(this.tItmF9_Click);
            // 
            // tItmF1
            // 
            this.tItmF1.Name = "tItmF1";
            this.tItmF1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tItmF1.Size = new System.Drawing.Size(151, 22);
            this.tItmF1.Text = "œ—»«—Â";
            this.tItmF1.Click += new System.EventHandler(this.tItmF1_Click);
            // 
            // tItmF10
            // 
            this.tItmF10.Name = "tItmF10";
            this.tItmF10.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.tItmF10.Size = new System.Drawing.Size(151, 22);
            this.tItmF10.Text = "Œ—ÊÃ";
            this.tItmF10.Click += new System.EventHandler(this.tItmF10_Click);
            // 
            // ntfyMinimize
            // 
            this.ntfyMinimize.ContextMenuStrip = this.ctxMinimize;
            this.ntfyMinimize.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyMinimize.Icon")));
            this.ntfyMinimize.Text = "»—«Ì ‰„«Ì‘ „Ãœœ œ«»· ﬂ·Ìﬂ ﬂ‰Ìœ";
            this.ntfyMinimize.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfyMinimize_MouseDoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 362);
            this.ContextMenuStrip = this.ctxMain;
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnF1);
            this.Controls.Add(this.btnPw);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iazmoon.ir Management RC1 by: 13x17.com";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.ctxMinimize.ResumeLayout(false);
            this.ctxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Button btnPw;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.ContextMenuStrip ctxMinimize;
        private System.Windows.Forms.ToolStripMenuItem ctxReturn;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxTimeSinceReboot;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentOSVersion;
        private System.Windows.Forms.ToolStripMenuItem ctxFrameworkVersion;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentTimeZone;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentDate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ctxExit;
        private System.Windows.Forms.ContextMenuStrip ctxMain;
        private System.Windows.Forms.ToolStripMenuItem tItmF5;
        private System.Windows.Forms.ToolStripMenuItem tItmF9;
        private System.Windows.Forms.ToolStripMenuItem tItmF1;
        private System.Windows.Forms.ToolStripMenuItem tItmF10;
        private System.Windows.Forms.NotifyIcon ntfyMinimize;
    }
}

