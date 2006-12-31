using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace iazmoon
{
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
        }

        public bool allowClosed = false;
        private string cErr;
        private string msgTitle = "http://www.iazmoon.ir/";
        public string legal = "elpaso1111";
        public DataTable dtGlobal = new DataTable();

        public string qtyMessage = " ⁄œ«œ Õ«÷—Ì‰ ‘—ﬂ  ﬂ‰‰œÂ œ— ﬂ· ﬂ‘Ê—";

        private void frmStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClosed)
                e.Cancel = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            allowClosed = true;
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofdTxt.Filter = "Å—Ê‰œÂ Â«Ì „ ‰Ì (*.txt)|*.txt";
            if (ofdTxt.ShowDialog() == DialogResult.OK)
            {
                txtOpendFile.Text = ofdTxt.FileName;
                try
                {
                    string path = ofdTxt.FileName;
                    string str = string.Empty;
                    string examName = string.Empty;
                    int countTotal = -1;
                    int count = 0;
                    int columnsCount = 5;
                    int pos = -1;
                    bool canAddColumns = true;
                    bool isValidFileType = false;
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add("—œÌ›");
                    dt.Columns.Add("‰«„ ¬“„Ê‰");
                    dt.Columns.Add("‘„«—Â œ«Êÿ·»");
                    dt.Columns.Add("‰«„ Ê ‰«„ Œ«‰Ê«œêÌ");
                    dt.Columns.Add("ﬂ·«”");
                    dr = dt.NewRow();

                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            str = sr.ReadLine();
                            pos = str.IndexOf(":");
                            if (pos != -1)
                                switch (str.Substring(0, pos))
                                {
                                    case "Result for Student No":
                                        dr[0] = ++count;
                                        dr[1] = examName;
                                        dr[2] = str.Substring(23);
                                        int qRangeStart = 1;
                                        int qRangeStop = 0;
                                        while (str != string.Empty)
                                        {
                                            str = sr.ReadLine();
                                            pos = str.IndexOf(":");
                                            if (pos != -1)
                                                switch (str.Substring(0, pos))
                                                {
                                                    case "Student Name":
                                                        string n = str.Substring(pos + 2);
                                                        while (n.IndexOf("  ") != -1) {
                                                            n = n.Replace("  ", " ");
                                                        }
                                                        dr[3] = n;
                                                        break;
                                                    case "Student Class Name":
                                                        dr[4] = str.Substring(pos + 3);
                                                        break;
                                                    case "Subject Name":
                                                        string subjectName = str.Substring(pos + 2);
                                                        bool canInsert = subjectName.IndexOf(" —«“") == -1;
                                                        if (canAddColumns)
                                                        {
                                                            dt.Columns.Add(str.Substring(pos + 2) + " / ⁄„·ﬂ—œ");
                                                            dt.Columns.Add(str.Substring(pos + 2) + " / „ÕœÊœÂ ”Ê«·« ");
                                                            dt.Columns.Add(str.Substring(pos + 2) + " / ”Ê«·«  ’ÕÌÕ");
                                                            dt.Columns.Add(str.Substring(pos + 2) + " / ”Ê«·«  €·ÿ");
                                                            dt.Columns.Add(str.Substring(pos + 2) + " / ”Ê«·«  ‰“œÂ");
                                                            dt.Columns.Add(str.Substring(pos + 2) + " /  —«“ ⁄„·ﬂ—œ");
                                                        }
                                                        str = sr.ReadLine();
                                                        pos = str.IndexOf(":");
                                                        dr[columnsCount++] = str.Substring(pos + 2);
                                                        str = sr.ReadLine();
                                                        pos = str.IndexOf(":");
                                                        if (canInsert)
                                                            qRangeStop += Convert.ToInt32(str.Substring(pos + 2));
                                                        string range = canInsert ? qRangeStart.ToString() + "  « " + qRangeStop.ToString() : string.Empty;
                                                        dr[columnsCount++] = range;
                                                        if (canInsert)
                                                            qRangeStart = qRangeStop + 1;
                                                        str = sr.ReadLine();
                                                        pos = str.IndexOf(":");
                                                        dr[columnsCount++] = str.Substring(pos + 2);
                                                        str = sr.ReadLine();
                                                        pos = str.IndexOf(":");
                                                        dr[columnsCount++] = str.Substring(pos + 2);
                                                        str = sr.ReadLine();
                                                        pos = str.IndexOf(":");
                                                        dr[columnsCount++] = str.Substring(pos + 2);
                                                        sr.ReadLine();
                                                        if (canInsert)
                                                        {
                                                            str = sr.ReadLine();
                                                            pos = str.IndexOf(":");
                                                            dr[columnsCount] = str.Substring(pos + 2);
                                                        }
                                                        columnsCount++;
                                                        break;
                                                    default:
                                                        break;
                                                }
                                        }
                                        dt.Rows.Add(dr);
                                        dr = dt.NewRow();
                                        canAddColumns = false;
                                        columnsCount = 5;
                                        break;
                                    case "Results For ExamNo":
                                        examName = str.Substring(38);
                                        isValidFileType = true;
                                        break;
                                    case "No of Students":
                                        countTotal = Convert.ToInt32(str.Substring(pos + 2));
                                        break;
                                    default:
                                        break;
                                }
                        }
                    }
                    if (isValidFileType)
                    {
                        dt.Columns.Add("— »Â ﬂ· œ— ‰„«Ì‰œêÌ");
                        int max = -1;
                        int maxx = 2147483647;
                        int level;
                        int wh = -1;
                        int cnt = 0;

                        while (dt.Rows.Count != cnt)
                        {
                            if (dt.Rows.Count == 0)
                                break;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dr = dt.Rows[i];
                                level = Convert.ToInt32(dr[dt.Columns.Count - 7]);
                                if (level > max && level < maxx)
                                {
                                    max = level;
                                    wh = i;
                                }
                            }
                            dr = dt.Rows[wh];
                            dr.BeginEdit();
                            dr[dt.Columns.Count - 1] = ++cnt;
                            dr.EndEdit();
                            maxx = max;
                            max = -1;
                        }
                        dt.AcceptChanges();
                        dgvStudentsResult.DataSource = dt;
/*                        dgvStudentsResult.Sort(dgvStudentsResult.Columns[dgvStudentsResult.ColumnCount - 7], System.ComponentModel.ListSortDirection.Descending);
                        for (int i = 0; i < dgvStudentsResult.Rows.Count - 1; i++)
                            dgvStudentsResult.Rows[i].Cells[dgvStudentsResult.ColumnCount - 1].Value = i + 1;*/
/*                        dgvStudentsResult.Columns[0].Width = 39;
                        dgvStudentsResult.Columns[1].Width = 133;
                        dgvStudentsResult.Columns[2].Width = 66;
                        dgvStudentsResult.Columns[3].Width = 133;
                        dgvStudentsResult.Columns[4].Width = 173;*/
                        btnSend.Enabled = true;
                        dtGlobal = dt;
                        dtGlobal.AcceptChanges();
                        dgvStudentsResult.AutoResizeColumns();
                        txtQTY.Enabled = true;
                    }
                    else
                        MessageBox.Show("Å—Ê‰œÂ Ì «‰ Œ«»Ì „⁄ »— ‰„Ì »«‘œ", "Œÿ« œ— ŒÊ«‰œ‰ Å—Ê‰œÂ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                catch (Exception ex)
                {
                    btnSend.Enabled = false;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("«„ﬂ«‰ œ” —”Ì »Â Å—Ê‰œÂ »Â œ·Ì· Œÿ«Ì –Ì· ÊÃÊœ ‰œ«—œ");
                    sb.Append("\n\n");
                    sb.Append(ex.Message);
                    MessageBox.Show(sb.ToString(), "Œÿ« œ— ŒÊ«‰œ‰ Å—Ê‰œÂ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                finally
                {
                }
            }
        }

        private void chkConnetct(string action)
        {
            this.Enabled = false;
            bool canConnect = false;
            do
            {
                switch (action)
                {
                    case "setStudentsResult":
                        canConnect = setStudentsResult();
                        break;
                    case "getStudentsResult":
                        canConnect = getStudentsResult();
                        break;
                    case "eraseStudentsResult":
                        canConnect = eraseStudentsResult();
                        break;
                    default:
                        break;
                }
                if (!canConnect)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("«„ﬂ«‰ œ” —”Ì »Â Ê» ”—Ê— »Â œ·Ì· Œÿ«Ì –Ì· ÊÃÊœ ‰œ«—œ");
                    sb.Append("\n\n");
                    sb.Append(cErr);
                    DialogResult result = MessageBox.Show(sb.ToString(), "Œÿ« œ— « ’«· »Â ”«Ì ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
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
            this.Enabled = true;
        }

        private bool setStudentsResult()
        {
/*            btnSend.Enabled = false;
            DataRow dr;
            try
            {
//                dt.Columns.Add("Ê÷⁄Ì  «—”«·");
//                for (int i = 0; i < dtGlobal.Columns.Count; i++)
//                    dt.Columns.Add(dtGlobal.Columns[i]);

                for (int i = 0; i < dtGlobal.Rows.Count; i++)
                {
                    dr = dtGlobal.Rows[i];

                    string examType = dr[1].ToString().Trim();
                    string studentNo = dr[2].ToString().Trim();
                    string studentName = dr[3].ToString().Trim();
                    string className = dr[4].ToString().Trim();
                    string subject = string.Empty;
                    for (int j = 5; j < dtGlobal.Columns.Count; j++)
                        subject += (dtGlobal.Columns[j].ColumnName.ToString().Trim() + "<@>" + dr[j].ToString().Trim() + "<#>");

                    adminManage.Management ws = new adminManage.Management();
                    string result = ws.setStudentsResult(examType, studentNo, studentName, className, subject, legal);
                    switch (result)
                    {
                        case "Added":
                            dr[0] = "OK";
                            break;
                        case "illegal":
                            Environment.Exit(0);
                            break;
                        default:
                            dr[0] = "Err";
                            break;
                    }
                }
                dtGlobal.Columns[0].ColumnName = "Ê÷⁄Ì  «—”«·";
                dgvStudentsResult.DataSource = dtGlobal;
                return true;
            }
            catch (Exception err)
            {
                cErr = err.Message;
                return false;
            }*/
            try
            {
                txtQTY.ReadOnly = true;
                btnSend.Enabled = false;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("examType");
                dt.Columns.Add("studentNo");
                dt.Columns.Add("studentName");
                dt.Columns.Add("className");
                dt.Columns.Add("subject");
                DataRow dr;
                for (int i = 0; i < dtGlobal.Rows.Count; i++)
                {
                    dr = dtGlobal.Rows[i];

                    string examType = dr[1].ToString().Trim();
                    string studentNo = dr[2].ToString().Trim();
                    string studentName = dr[3].ToString().Trim();
                    string className = dr[4].ToString().Trim();
                    string subject = string.Empty;
                    for (int j = 5; j < dtGlobal.Columns.Count; j++)
                        subject += (dtGlobal.Columns[j].ColumnName.ToString().Trim() + "<@>" + dr[j].ToString().Trim() + "<#>");

                    subject += (qtyMessage + "<@>" + txtQTY.Text.Trim() + "<#>");
                    dr = dt.NewRow();
                    dr[0] = examType;
                    dr[1] = studentNo;
                    dr[2] = studentName;
                    dr[3] = className;
                    dr[4] = subject;

                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                adminManage.Management ws = new adminManage.Management();
                string result = ws.setStudentsResult(ds, legal);
                switch (result)
                {
                    case "Added":
                        MessageBox.Show("«—”«· ‰ «ÌÃ »« „Ê›ﬁÌ  «‰Ã«„ ‘œ", msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "illegal":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                dgvStudentsResult.DataSource = null;
                txtOpendFile.Clear();
                txtQTY.Text = qtyMessage;
                txtQTY.ReadOnly = false;
                txtQTY.Enabled = false;
                return true;
            }
            catch (Exception err)
            {
                cErr = err.Message;
                return false;
            }
       }

        private bool getStudentsResult()
        {
            try
            {
                dgvStudentsResultTotal.DataSource = null;
                adminManage.Management ws = new adminManage.Management();
                DataSet result = ws.getStudentsResult(legal);

                DataTable dtRS = new DataTable();
                DataRow drRS;

                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("—œÌ›");
                dt.Columns.Add("‰«„ ¬“„Ê‰");
                dt.Columns.Add("‘„«—Â œ«Êÿ·»");
                dt.Columns.Add("‰«„ Ê ‰«„ Œ«‰Ê«œêÌ");
                dt.Columns.Add("ﬂ·«”");

                dtRS = result.Tables[0];
                if (dtRS.Rows.Count != 0)
                {
                    drRS = dtRS.Rows[0];

                    string subjects = drRS["subject"].ToString().Trim();
                    int pos1;
                    int pos2;
                    int len = subjects.Length;
                    string sb;
                    string sbp;

                    while (len > 0)
                    {
                        pos1 = 0;
                        pos2 = subjects.IndexOf("<@>");
                        sb = subjects.Substring(pos1, pos2 - pos1);
                        pos1 = pos2 + 3;
                        pos2 = subjects.IndexOf("<#>");
                        sbp = subjects.Substring(pos1, pos2 - pos1);
                        subjects = subjects.Remove(0, pos2 + 3);
                        len = subjects.Length;
                        dt.Columns.Add(sb);
                    }

                    for (int i = 0; i < dtRS.Rows.Count; i++)
                    {
                        drRS = dtRS.Rows[i];
                        dr = dt.NewRow();

                        dr[0] = drRS[0].ToString().Trim();
                        dr[1] = drRS[1].ToString().Trim();
                        dr[2] = drRS[2].ToString().Trim();
                        dr[3] = drRS[3].ToString().Trim();
                        dr[4] = drRS[4].ToString().Trim();

                        subjects = drRS[5].ToString().Trim();
                        len = subjects.Length;
                        int j = 5;
                        while (len > 0)
                        {
                            pos1 = 0;
                            pos2 = subjects.IndexOf("<@>");
                            sb = subjects.Substring(pos1, pos2 - pos1);
                            pos1 = pos2 + 3;
                            pos2 = subjects.IndexOf("<#>");
                            sbp = subjects.Substring(pos1, pos2 - pos1);
                            subjects = subjects.Remove(0, pos2 + 3);
                            len = subjects.Length;
                            dr[j++] = sbp;
                        }
                        dt.Rows.Add(dr);
                    }

                    dgvStudentsResultTotal.DataSource = dt;
                    dgvStudentsResultTotal.Columns[0].Width = 39;
                    dgvStudentsResultTotal.Columns[1].Width = 133;
                    dgvStudentsResultTotal.Columns[2].Width = 66;
                    dgvStudentsResultTotal.Columns[3].Width = 133;
                    dgvStudentsResultTotal.Columns[4].Width = 173;
                    nudEraseFrom.Maximum = dt.Rows.Count;
                    nudEraseTo.Maximum = dt.Rows.Count;
                    nudEraseFrom.Enabled = true;
                    nudEraseTo.Enabled = true;
                }

                return true;
            }
            catch (Exception err)
            {
                cErr = err.Message;
                return false;
            }
        }

        private bool eraseStudentsResult()
        {
            try
            {
                DialogResult dlgResult = MessageBox.Show("¬Ì« „«Ì· »Â Õ–› ¬Ì „ Â«Ì „Ê—œ ‰Ÿ— „Ì »«‘Ìœø", msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlgResult == DialogResult.OK)
                {
                    adminManage.Management ws = new adminManage.Management();
                    string result = ws.eraseStudentsResult(Convert.ToInt32(nudEraseFrom.Value), Convert.ToInt32(nudEraseTo.Value), legal);
                    switch (result)
                    {
                        case "erased":
                            chkConnetct("getStudentsResult");
                            nudEraseFrom.Value = 0;
                            nudEraseTo.Value = 0;
                            MessageBox.Show("⁄„· Õ–› »« „Ê›ﬁÌ  «‰Ã«„ ‘œ", msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "illegal":
                            Environment.Exit(0);
                            break;
                        default:
                            MessageBox.Show(result);
                            break;
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                cErr = err.Message;
                return false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtQTY.Text != qtyMessage)
            {
                chkConnetct("setStudentsResult");
            }
            else
            {
                MessageBox.Show(String.Format("·ÿ›« {0} —« Ê«—œ ‰„«∆Ìœ", qtyMessage), msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQTY.Focus();
            }
        }

        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabsMain.SelectedTab.Name)
            {
                case "tabAddSR":
                    nudEraseFrom.Enabled = false;
                    nudEraseTo.Enabled = false;
                    btnErase.Enabled = false;
                    nudEraseFrom.Value = 0;
                    nudEraseTo.Value = 0;
                    dgvStudentsResultTotal.DataSource = null;
                    btnSend.Focus();
                    txtQTY.Text = qtyMessage;
                    txtQTY.Enabled = false;
                    break;
                case "tabViewSR":
                    btnSend.Enabled = false;
                    dgvStudentsResult.DataSource = null;
                    txtOpendFile.Clear();
                    dgvStudentsResultTotal.Focus();
                    chkConnetct("getStudentsResult");
                    break;
                default:
                    break;
            }
        }

        private void nudEraseFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudEraseFrom.Value > nudEraseTo.Value)
                nudEraseTo.Value = nudEraseFrom.Value;

            if (nudEraseFrom.Value != 0 && nudEraseTo.Value != 0)
                btnErase.Enabled = true;
            else
                btnErase.Enabled = false;
        }

        private void nudEraseTo_ValueChanged(object sender, EventArgs e)
        {
            if (nudEraseTo.Value < nudEraseFrom.Value)
                nudEraseTo.Value = nudEraseFrom.Value;

            if (nudEraseFrom.Value != 0 && nudEraseTo.Value != 0)
                btnErase.Enabled = true;
            else
                btnErase.Enabled = false;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            chkConnetct("eraseStudentsResult");
        }

        private void txtQTY_Enter(object sender, EventArgs e)
        {
            if (txtQTY.Text == qtyMessage)
                txtQTY.Clear();
        }

        private void txtQTY_Leave(object sender, EventArgs e)
        {
            if (txtQTY.Text.Trim() == string.Empty)
                txtQTY.Text = qtyMessage;
        }
    }
}