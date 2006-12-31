using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iazmoon
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void doExit()
        {
            Application.Exit();
            Environment.Exit(0);
        }

        public void doPw()
        {
            frmPwChange frm = new frmPwChange();
            frm.ShowDialog();
        }

        public void doAbout()
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        public void doF5()
        {
            frmStudents frm = new frmStudents();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            doExit();
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            doAbout();
        }

        private void btnPw_Click(object sender, EventArgs e)
        {
            doPw();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            doF5();
        }

        private void tItmF5_Click(object sender, EventArgs e)
        {
            doF5();
        }

        private void tItmF9_Click(object sender, EventArgs e)
        {
            doPw();
        }

        private void tItmF1_Click(object sender, EventArgs e)
        {
            doAbout();
        }

        private void tItmF10_Click(object sender, EventArgs e)
        {
            doExit();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                ntfyMinimize.Visible = true;
            }
        }

        private void ntfyMinimize_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ntfyMinimize.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ctxReturn_Click(object sender, EventArgs e)
        {
            ntfyMinimize.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ctxTimeSinceReboot_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("ÕœÊœ« ", ((Int32)((Environment.TickCount / 1000) / 60)).ToString(), " œﬁÌﬁÂ «“ “„«‰ »Ê  ÊÌ‰œÊ“ „Ì ê–—œ"), "¬Œ—Ì‰ »Ê ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxCurrentOSVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("OS Version: ", Environment.OSVersion.ToString()), "Operating System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxFrameworkVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("Framework Version: ", Environment.Version.ToString()), ".NET Framework Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxCurrentTimeZone_Click(object sender, EventArgs e)
        {
            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now))
                MessageBox.Show(String.Concat(TimeZone.CurrentTimeZone.DaylightName, " :„‰ÿﬁÂ “„«‰Ì ›⁄·Ì ”Ì” „"), "„‰ÿﬁÂ “„«‰Ì", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(String.Concat(TimeZone.CurrentTimeZone.StandardName, " :„‰ÿﬁÂ “„«‰Ì ›⁄·Ì ”Ì” „"), "„‰ÿﬁÂ “„«‰Ì", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxCurrentDate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat(DateTime.Now.ToLongDateString(), "   ", DateTime.Now.ToLongTimeString(), "       ", MSBabaei.DateProvider.ToPersian(), " : «—ÌŒ ‘„”Ì"), " «—ÌŒ Ê ”«⁄ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxExit_Click(object sender, EventArgs e)
        {
            ntfyMinimize.Visible = false;
            doExit();
        }
    }
}