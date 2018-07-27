using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using System.Data.SqlClient;
using System.Configuration;

namespace FitnessCenter
{
    public partial class FreeTrialReceipt : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    String contact = "";
                    if (Request.QueryString.Count > 0)
                        contact = Request.QueryString["contact"].ToString();

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntensityConnectionString"].ToString());
                    cmd = new SqlCommand("GetFreeTrial", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da = new SqlDataAdapter(cmd);
                    DataTable dtFreeTrial = new DataTable();
                    da.Fill(dtFreeTrial);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rptDataSource = new ReportDataSource("FreeTrial", dtFreeTrial);
                    ReportViewer1.LocalReport.ReportPath = "./rptFreeTrial.rdlc";
                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}