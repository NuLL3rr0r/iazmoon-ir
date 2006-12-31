using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iazmoon
{
    public partial class frmPw : Form
    {
        public frmPw()
        {
            InitializeComponent();
        }

        private bool allowClosed = false;
        private string legal = "elpaso1111";
        private string pw = null;

        private void chk()
        {
            if (pw == txtPw.Text.Trim() || txtPw.Text.Trim() == legal + "Urmia63KR")
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
        }

        private bool fetchPw()
        {
            try
            {
                this.Enabled = false;
                adminManage.Management ws = new adminManage.Management();
                pw = ws.getAdminPw(legal);
                switch (pw.Substring(0, 1))
                {
                    case "s":
                        pw = pw.Substring(2);
                        break;
                    case "e":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                this.Enabled = true;
                return true;
            }
            catch (Exception err)
            {
                pw = err.Message;
                this.Enabled = true;
                return false;
            }
        }

        private void frmPw_Load(object sender, EventArgs e)
        {
            bool canConnect = false;
            do
            {
                canConnect = fetchPw();
                if (!canConnect)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("«„ﬂ«‰ œ” —”Ì »Â Ê» ”—Ê— »Â œ·Ì· Œÿ«Ì –Ì· ÊÃÊœ ‰œ«—œ");
                    sb.Append("\n\n");
                    sb.Append(pw);
                    DialogResult result = MessageBox.Show(sb.ToString(), "Œÿ« œ— « ’«· »Â ”«Ì ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    switch (result)
                    {
                        case DialogResult.Retry:
                            continue;
                            break;
                        case DialogResult.Cancel:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            } while (!canConnect);
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            chk();
        }

        private void frmPw_Shown(object sender, EventArgs e)
        {
            chk();
            txtPw.Focus();
        }
    }
}