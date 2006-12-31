using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Data;
using System.Data.OleDb;
using MSBabaei;

/// <summary>
/// Summary description for mnagement
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Management : System.Web.Services.WebService {

    private string path;
    private string dBpw = "Og2lNuOW3NWWkd4PTVT6";
    private string fileDb;
    private string cnnStr;
    private string errType = "e:";
    private string successType = "s:";
    private string tLegal;

    private void fillLegal()
    {
        string sqlStr = "SELECT * FROM admin";

        OleDbConnection cnn = new OleDbConnection(cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        string msg = string.Empty;

        try
        {
            oda.Fill(ds, "admin");

            while (drr.Read())
            {
                tLegal = drr["legal"].ToString().Trim();
                break;
            }
        }
        catch (Exception e)
        {
        }
        finally
        {
            sqlStr = null;

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
    }

    public Management()
    {
        path = Server.MapPath("~");
        path += path.EndsWith("\\") ? "" : "\\";
        fileDb = String.Concat(path, "master.mdb");
        cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", fileDb, dBpw);

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        fillLegal();
    }

    [WebMethod]
    public string getAdminPw(string legal)
    {
        string msg = string.Empty;
        if (tLegal == legal.Trim())
        {
            string sqlStr = "SELECT * FROM admin";

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            try
            {
                oda.Fill(ds, "admin");

                while (drr.Read())
                {
                    //                string tLegal = drr["legal"].ToString().Trim();
                    string tPw = drr["pw"].ToString().Trim();
                    msg = successType + tPw;
                    break;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                sqlStr = null;

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
        }
        else
            msg = errType + "illegal";

        return msg;
    }

    [WebMethod]
    public string setAdminPw(string pw, string npw, string legal)
    {
        string msg = string.Empty;
        if (tLegal == legal.Trim())
        {
            string sqlStr = "SELECT * FROM admin";

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, "admin");

                while (drr.Read())
                {
                    string tPw = drr["pw"].ToString().Trim();
                    if (tPw == pw.Trim())
                        msg = "ok";
                    else
                        msg = "invalid";
                    break;
                }

                if (msg == "ok")
                {
                    dt = ds.Tables["admin"];
                    dr = dt.Rows[0];
                    dr.BeginEdit();
                    dr["pw"] = npw.Trim();
                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, "admin") == 1)
                        ds.AcceptChanges();
                    else
                        ds.RejectChanges();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                sqlStr = null;

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
        }
        else
            msg = "illegal";

        return msg;
    }

/*    [WebMethod]
    public string setStudentsResult(string examType, string studentNo, string studentName, string className, string subject, string legal)
    {
        string msg = string.Empty;
        if (tLegal == legal.Trim())
        {
            string tbl = "students";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.NewRow();
                dr["id"] = dt.Rows.Count + 1;
                dr["examtype"] = examType.Trim();
                dr["studentno"] = studentNo.Trim();
                dr["studentname"] = studentName.Trim();
                dr["class"] = className.Trim();
                dr["subject"] = subject.Trim();
                dt.Rows.Add(dr);

                oda.InsertCommand = ocb.GetInsertCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                msg = "Added";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                sqlStr = null;

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
        }
        else
            msg = "illegal";

        return msg;
    }*/

    [WebMethod]
    public string setStudentsResult(DataSet dsSR, string legal)
    {
        string msg = string.Empty;
        if (tLegal == legal.Trim())
        {
            string tbl = "students";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];

                DataTable dtSR = new DataTable();
                dtSR = dsSR.Tables[0];

                for (int i = 0; i < dtSR.Rows.Count; i++)
                {
                    dr = dtSR.Rows[i];

                    string examType = dr[0].ToString().Trim();
                    string studentNo = dr[1].ToString().Trim();
                    string studentName = dr[2].ToString().Trim();
                    string className = dr[3].ToString().Trim();
                    string subject = dr[4].ToString().Trim();

                    dr = dt.NewRow();
                    dr["id"] = dt.Rows.Count + 1;
                    dr["examtype"] = examType.Trim();
                    dr["studentno"] = studentNo.Trim();
                    dr["studentname"] = studentName.Trim();
                    dr["class"] = className.Trim();
                    dr["subject"] = subject.Trim();
                    dt.Rows.Add(dr);
                }

                oda.InsertCommand = ocb.GetInsertCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                msg = "Added";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                sqlStr = null;

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    [WebMethod]
    public DataSet getStudentsResult(string legal)
    {
        DataSet ds = new DataSet();

        if (tLegal == legal.Trim())
        {
            string tbl = "students";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            cnn.Open();

            try
            {
                oda.Fill(ds, tbl);
            }
            catch (Exception e)
            {
            }
            finally
            {
                sqlStr = null;

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;
            }
        }

        return ds;
    }
    [WebMethod]
    public string eraseStudentsResult(int from, int to, string legal)
    {
        string msg = string.Empty;
        if (tLegal == legal.Trim())
        {
            string tbl = "students";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];

                bool isDeleted = false;
                for (int i = from - 1; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (isDeleted)
                    {
                        dr.BeginEdit();
                        dr["id"] = i - (to - from);
                        dr.EndEdit();
                    }
                    else
                        if (Convert.ToInt32(dr["id"]) >= from && Convert.ToInt32(dr["id"]) <= to)
                        {
                            if (Convert.ToInt32(dr["id"]) == to)
                                isDeleted = true;
                            dr.Delete();
                        }
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                msg = "erased";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                sqlStr = null;

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
        }
        else
            msg = "illegal";

        return msg;
    }
}