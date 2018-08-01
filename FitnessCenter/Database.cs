using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;

namespace ConnectionDb
{
    public class Database
    {
        public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["IntensityConnectionString"].ConnectionString);
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public String st;
        public Database()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void dmlop(string str)
        {
            con.Open();
            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Object SelectScalar(string str)
        {
            Object result = null;
            con.Open();
            cmd = new SqlCommand(str, con);
            result = cmd.ExecuteScalar();
            con.Close();
            return result;
        }
        public void bound_control(String str, string tblnm)
        {
            ds = new DataSet();
            da = new SqlDataAdapter(str, con);
            da.Fill(ds, tblnm);
        }
        public DataTable bound_control(String str)
        {
            DataTable tbl = new DataTable();
            ds = new DataSet();
            da = new SqlDataAdapter(str, con);
            da.Fill(tbl);
            return tbl;
        }
        public void bound_control(String str, string tblnm, DataSet ds1)
        {
            da = new SqlDataAdapter(str, con);
            da.Fill(ds1, tblnm);
        }
        public SqlDataReader read_data(String str)
        {
            con.Open();
            cmd = new System.Data.SqlClient.SqlCommand(str, con);
            dr = cmd.ExecuteReader();
            return dr;
        }
        public Object get_Lid(String tblName, String field)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new System.Data.SqlClient.SqlCommand("select max(" + field + ") from " + tblName, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr.IsDBNull(0))
                {
                    con.Close();
                    return 0;
                }
                else
                {
                    Object max = dr.GetValue(0);
                    con.Close();
                    return max;
                }
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        public int get_Lid(String tblName, String field, String condStr, int cmpStr)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            if (dr.IsClosed == false)
            {
                dr.Close();
            }
            cmd = new System.Data.SqlClient.SqlCommand("select max(" + field + ") from " + tblName + " where " + condStr + "=" + cmpStr, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr.IsDBNull(0))
                {
                    con.Close();
                    return 0;
                }
                else
                {
                    int max = dr.GetInt32(0);
                    con.Close();
                    return max;
                }
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        public int get_Lid(String tblName, String field, String condStr, int cmpStr, String condStr1, int cmpStr1)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new System.Data.SqlClient.SqlCommand("select max(" + field + ") from " + tblName + " where (" + condStr + "=" + cmpStr + " )AND (" + condStr1 + "=" + cmpStr1 + ")", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr.IsDBNull(0))
                {
                    con.Close();
                    return 0;
                }
                else
                {
                    int max = dr.GetInt32(0);
                    con.Close();
                    return max;
                }
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        public int Check_Availability(String tblnm, String str, String cmpstr)
        {
            st = "SELECT COUNT(" + str + ") FROM " + tblnm + " WHERE (" + str + " = '" + cmpstr + "')";
            con.Open();
            cmd = new System.Data.SqlClient.SqlCommand(st, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            int cnt = dr.GetInt32(0);
            dr.Close();
            con.Close();
            return cnt;
        }
        public int Check_Availability(String tblnm, String str, String str1, String cmpstr, String cmpstr1)
        {
            st = "SELECT COUNT(" + str + ") FROM " + tblnm + " WHERE (" + str + " = '" + cmpstr + "' AND " + str1 + " = '" + cmpstr1 + "')";
            con.Open();
            cmd = new System.Data.SqlClient.SqlCommand(st, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            int cnt = dr.GetInt32(0);
            dr.Close();
            con.Close();
            return cnt;
        }
        public void ExportToTextFile(String path, String tblname)
        {
            DataSet ExportDs = new DataSet();
            StreamWriter fs = new StreamWriter(path + "\\" + tblname);
            bound_control("Select * from " + tblname, tblname, ExportDs);
            String row1 = "";
            int i, j;
            for (i = 0; i < ExportDs.Tables[tblname].Rows.Count; i++)
            {
                for (j = 0; j < ExportDs.Tables[tblname].Columns.Count - 1; j++)
                {
                    row1 = row1 + ExportDs.Tables[tblname].Rows[i][j].ToString() + "|";
                }
                row1 = row1 + ExportDs.Tables[tblname].Rows[i][j].ToString();
                if (i == 0)
                    fs.Write(row1);
                else
                    fs.Write("\n" + row1);
                row1 = "";
            }
            fs.Close();
        }
        public DataRow SelectRowScaler(String str)
        {
            DataTable tblnm = new DataTable();
            da = new SqlDataAdapter(str, con);
            da.Fill(tblnm);
            if (tblnm.Rows.Count > 0)
                return tblnm.Rows[0];
            else
                return null;
        }
        public string get_name(string name, string id, string tblnm)
        {
            if (id.Equals("0"))
            {
                return "All";
            }
            else
            {
                string st = "SELECT " + name + " FROM " + tblnm + " WHERE Id=" + id;
                DataTable dt = bound_control(st);
                if (dt.Rows.Count > 0)
                {
                    string nm = dt.Rows[0][name].ToString();
                    return nm;
                }
                else
                {
                    return "";
                }
            }
        }
        public void OpenWindow(string url)
        {
            //string url = "RideZone.aspx";
            //string s = "window.open('" + url + "', 'popup_window', 'width=800,height=430,left=100,top=100,resizable=yes');";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            int intId = 100;

            string strPopup = "<script language='javascript' ID='script1'>"

            // Passing intId to popup window.
            + "window.open('" + url + "?data=" + HttpUtility.UrlEncode(intId.ToString())

            + "','new window', 'top=100, left=100, width=800, height=430, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"

            + "</script>";

            ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopup, false);
        }

        public DateTime ConvertDateTime(object objDate)
        {
            try
            {
                System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                dateInfo.ShortDatePattern = "dd/MM/yyyy";
                return Convert.ToDateTime(objDate, dateInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}