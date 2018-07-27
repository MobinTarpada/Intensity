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
    public partial class frmUpgradePaymentReceipt : System.Web.UI.Page
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
                    String agreementNo = "";
                    if (Request.QueryString.Count > 0)
                        agreementNo = Request.QueryString["agreementNo"].ToString();

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntensityConnectionString"].ToString());
                    cmd = new SqlCommand("GetPaymentReciept", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("agreementNumber", agreementNo);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtPayment = new DataTable();
                    da.Fill(dtPayment);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rptDataSource = new ReportDataSource("Memberships", dtPayment);
                    ReportViewer1.LocalReport.ReportPath = "./rptUpgradeMemberPayment.rdlc";
                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}