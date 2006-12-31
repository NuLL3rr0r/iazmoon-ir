using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iazmoon
{
    public partial class frmPwChange : Form
    {
        public frmPwChange()
        {
            InitializeComponent();
        }

        public bool allowClosed = false;
        private string legal = "elpaso1111";
        private string msgTitle = "http://www.iazmoon.ir/";
        private string cErr;

        private bool fetchPw()
        {
            try
            {
                this.Enabled = false;
                adminManage.Management ws = new adminManage.Management();
                string result = ws.setAdminPw(txtCurrentPw.Text, txtNewPw.Text, legal);
                switch (result)
                {
                    case "ok":
                        MessageBox.Show("���� � ���� ���� �� ������ ������ ��", msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case "invalid":
                        MessageBox.Show("���� ���� ���� ���� �� ���� ������", msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtCurrentPw.Focus();
                        txtCurrentPw.SelectAll();
                        break;
                    case "illegal":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                return true;
                this.Enabled = true;
            }
            catch (Exception err)
            {
                cErr = err.Message;
                this.Enabled = true;
                return false;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool canConnect = false;
            if (txtNewPw.Text == txtConfirmPw.Text)
                do
                {
                    canConnect = fetchPw();
                    if (!canConnect)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("����� ������ �� �� ���� �� ���� ���� ��� ���� �����");
                        sb.Append("\n\n");
                        sb.Append(cErr);
                        DialogResult result = MessageBox.Show(sb.ToString(), "��� �� ����� �� ����", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        switch (result)
                        {
                            case DialogResult.Retry:
                                continue;
                                break;
                            case DialogResult.Cancel:
                                canConnect = true;
                                break;
                            default:
                                break;
                        }
                    }
                } while (!canConnect);
            else
            {
                MessageBox.Show("���� ���� � ���� ���� �� ����� ������", msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPw.Focus();
                txtConfirmPw.SelectAll();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            allowClosed = true;
            this.Close();
        }
    }
}