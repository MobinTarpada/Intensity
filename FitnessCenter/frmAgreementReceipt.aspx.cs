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
    public partial class frmAgreementReceipt : System.Web.UI.Page
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
                    cmd = new SqlCommand("GetAgreementReceipt", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("agreementNumber", agreementNo);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtAgreementReport = new DataTable();
                    da.Fill(dtAgreementReport);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rptDataSource = new ReportDataSource("AgreementReport", dtAgreementReport);
                    ReportViewer1.LocalReport.ReportPath = "./rptAgreementForm.rdlc";
                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                    string path = Server.MapPath("~/PDF/" + agreementNo + ".pdf");
                    //ReportViewer1.ExportToDisk(ExportFormatType.PortableDocFormat, path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}