using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Data;
using System.Data.OleDb;
using MSBabaei;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Master : System.Web.Services.WebService
{

    private string path;
    private string dBpw = "Og2lNuOW3NWWkd4PTVT6";
    private string fileDb;
    private string cnnStr;

    public Master()
    {
        path = Server.MapPath("~");
        path += path.EndsWith("\\") ? "" : "\\";
        fileDb = String.Concat(path, "master.mdb");
        cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", fileDb, dBpw);

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    private string formatNumsToUnicode(string numstr)
    {
        int len = numstr.Length;
        string outstr = String.Empty;
        string num;
        for (int i = 0; i < len; i++)
        {
            num = numstr.Substring(i, 1);
            switch (num)
            {
                case "0":
                    outstr += "\u0660";
                    break;
                case "1":
                    outstr += "\u0661";
                    break;
                case "2":
                    outstr += "\u0662";
                    break;
                case "3":
                    outstr += "\u0663";
                    break;
                case "4":
                    outstr += "\u0664";
                    break;
                case "5":
                    outstr += "\u0665";
                    break;
                case "6":
                    outstr += "\u0666";
                    break;
                case "7":
                    outstr += "\u0667";
                    break;
                case "8":
                    outstr += "\u0668";
                    break;
                case "9":
                    outstr += "\u0669";
                    break;
                default:
                    outstr += num;
                    break;
            }
        }
        return outstr;
    }

    private string formatNumsToUnicode(int numint)
    {
        return formatNumsToUnicode(numint.ToString());
    }

    [WebMethod]
    public string fetchGetResultsForm()
    {
        string tbl = "students";
        string sqlStr = "SELECT * FROM " + tbl;

        OleDbConnection cnn = new OleDbConnection(cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        string start = "<center style=\"line-height: 23px;\"><div style=\"position:relative; width: 333px; font-size: 12px;\"><br /><h6 style=\"color: #0000FF; text-align: right; font-size: 11px;\">دريافت كارنامه:</h6><div style=\"position:relative; width: 244px; text-align: right;\"><form name=\"frmGetResults\" id=\"frmGetResults\">نام آزمون:&nbsp;<select name=\"cmbExamName\" onChange=\"setInputStatus(this.value);\" class=\"frmStyle\" style=\"width: 138px;\"><option value=\"NotSetYet\">.:: نام آزمون ::.</option>";
        string stop = "</select><br />شماره داوطلب:&nbsp;<input type=\"text\" class=\"frmStyle\" id=\"txtStudentNo\" disabled=\"disabled\" /><br />نام داوطلب:&nbsp;<input type=\"text\" class=\"frmStyle\" id=\"txtStudentName\" disabled=\"disabled\" /><br /><div id=\"divErrVerify\"></div><br /><input type=\"button\" value=\"تائيد\" style=\"position: absolute; left: 0px; font-family: Tahoma; width: 111px; text-align: center;\" disabled=\"disabled\" onclick=\"sendStudent();\" id=\"btnSend\" /><br /></form></div></div></center>";
        string frmResult = string.Empty;
        string examName = string.Empty;

        try
        {
            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                examName = drr["examtype"].ToString().Trim();
                frmResult += (frmResult.IndexOf(examName) == -1) ? String.Format("<option value=\"{0}\">{1}</option>", examName, examName) : string.Empty;
            }
            frmResult = start + frmResult + stop;
        }
        catch (Exception e)
        {
            return e.Message;
        }
        finally
        {
            sqlStr = null;
            start = null;
            stop = null;
            examName = null;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }

        frmResult += "<center><br /><br /><br /><div style='direction: ltr; width: 900px; text-align: center; font-family: Verdana, \"Times New Roman\", Arial, \"MS Sans Serif\"; font-size: 11px; color: #000000;'>{PlaceHolder}Copyright © 2007 iAzmoon.com<br />Designed By <a href=\"mailto:ace.of.zerosync@gmail.com\" target=\"_blank\">M.S. Babaei</a> [<a href=\"http://www.13x17.com/\" target=\"_blank\">13x17.com</a>]</div><br /></center>";
        return frmResult;
    }

    [WebMethod]
    public string fetchGetStudentResult(string examType, string studentNo, string studentName)
    {
        string tbl = "students";
        string sqlStr = "SELECT * FROM " + tbl;

        OleDbConnection cnn = new OleDbConnection(cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        string start = "<center style=\"line-height: 23px; font-size: 12px;\"><div style=\"position: relative; width: 85%;\">";
        string stop = "</div></center><br />";
        string logo = "<div style=\"position: relative; width: 85%;\"><pre><em><strong><center style=\"text-align: left; direction: ltr\">http://www.iazmoon.ir/</center></em></strong></pre></div>";
        string prn = "<div id=\"prn\" style=\"position: relative; width: 85%; text-align: center\"><input type=\"button\" value=\"چاپ\" style=\"position: absolute; left: 13px; font-family: Tahoma; width: 111px; text-align: center;\" onclick=\"doPrint();\" id=\"btnPrint\" /></div><br /><br />";
        string stdResult = string.Empty;

        string eT;
        string sNo;
        string sNm;
        examType = examType.Trim();
        studentNo = studentNo.Trim();
        studentName = studentName.Trim();

        bool found = false;
        try
        {
            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                eT = drr["examtype"].ToString().Trim();
                sNo = drr["studentno"].ToString().Trim();
                sNm = drr["studentname"].ToString().Trim();
                if (eT == examType && sNo == studentNo && sNm == studentName)
                {
                    stdResult += "<br /><center style=\"text-align: right\">" + "نام آزمون: " + formatNumsToUnicode(eT) + "<br />" + "شماره داوطلب: " + formatNumsToUnicode(sNo) + "<br />" + "نام داوطلب: " + sNm + "<br />" + "كلاس: " + drr["class"].ToString().Trim() + "</center><br /><br /><table style=\"text-align: center;\" width=\"85%\" border=\"1\" style=\"border: solid 1px #000000\" cellspacing=\"0\" cellpadding=\"0\">";

                    string subjects = drr["subject"].ToString().Trim();
                    int pos1;
                    int pos2;
                    int len = subjects.Length;
                    string sb;
                    string sbp;
                    string colorType = " bgcolor=\"#666666\"";
                    stdResult += String.Format("<tr style=\"color: #FFFFFF\"><td {0} {8}>{1}</td><td {0} {8}>{2}</td><td {0} {8}>{3}</td><td {0} {8}>{4}</td><td {0} {8}>{5}</td><td {0} {8}>{6}</td><td {0} {8}>{7}</td></tr>", colorType, "موضوع", "عملكرد", "محدوده سوالات", "سوالات صحيح", "سوالات غلط", "سوالات نزده", "تراز عملكرد", "width=\"111\"");
                    string r1 = "bgcolor=\"#CCCCCC\"";
                    string r2 = "bgcolor=\"#999999\"";
                    string sbHeader = string.Empty;

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

                        if (colorType == r1)
                            colorType = r2;
                        else
                            colorType = r1;

                        if (sb.IndexOf(sbHeader) == -1)
                        {
                            stdResult += "</tr>";
                        }

                        if (sb.IndexOf(" / ") != -1)
                        {
                            sbHeader = sb.Remove(sb.IndexOf(" / "));
                        }
                        else if (sb == "رتبه كل در نمايندگي")
                        {
                            sbHeader = "رتبه كل در نمايندگي";
                        }

                        if (sb != "تعداد حاضرين شركت كننده در كل كشور")
                        {
                            if (stdResult.IndexOf(sbHeader) == -1)
                                stdResult += String.Format("<td bgcolor=\"#666666\" style=\"color: #FFFFFF\">{1}</td><td {0}>{2}</td>", colorType, sbHeader, (sbp != string.Empty) ? formatNumsToUnicode(sbp) : "---");
                            else
                                stdResult += String.Format("<td {0}>{1}</td>", colorType, (sbp != string.Empty) ? formatNumsToUnicode(sbp) : "---");
                        }
                        else
                        {
                            stdResult = stdResult.Remove(stdResult.LastIndexOf("</tr>"));
                            stdResult += String.Format("<td colspan=\"4\" bgcolor=\"#999999\">{0}</td><td bgcolor=\"#CCCCCC\">{1}</td>", sb, formatNumsToUnicode(sbp));
                        }
                    }
                    stdResult += "</table>";
                    stdResult += "<p style=\"text-align: right;\">توجه: لطفا جهت دريافت كارنامه ي كامل به دفتر نمايندگي شهر خود مراجعه نمائيد.</p>";

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                stdResult = "<br /><br />كارنامه اي يافت نشد<br /><br /><input type=\"button\" value=\"بازگشت\" style=\"font-family: Tahoma; width: 111px; text-align: center;\" onclick=\"notFound();\" /><br />";
                logo = string.Empty;
                prn = string.Empty;
            }

            //stdResult = start + stdResult + stop + prn + logo;
            stdResult = start + stdResult + stop + prn;
        }
        catch (Exception e)
        {
//            return e.Message;
            return e.ToString();
        }
        finally
        {
            sqlStr = null;
            start = null;
            stop = null;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }

        stdResult += "<center><br /><br /><br /><div style='direction: ltr; width: 900px; text-align: center; font-family: Verdana, \"Times New Roman\", Arial, \"MS Sans Serif\"; font-size: 11px; color: #000000;'>{PlaceHolder}Copyright © 2007 iAzmoon.com<br />Designed By <a href=\"mailto:ace.of.zerosync@gmail.com\" target=\"_blank\">M.S. Babaei</a> [<a href=\"http://www.13x17.com/\" target=\"_blank\">13x17.com</a>]</div><br /></center>";
        return stdResult;
    }
}