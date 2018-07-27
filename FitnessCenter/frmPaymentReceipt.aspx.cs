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
using System.IO;

namespace FitnessCenter
{
    public partial class frmPaymentReceipt : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        String Paths = "";
        String FileName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FileName = Request.QueryString["agreementNo"].ToString() + "_" + DateTime.Now.Ticks + ".PDF";
                Paths = Server.MapPath("~/PDF/" + FileName);
                string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string path = Path.Combine(dir, "Myproject.Application.DataExporter", "PDF");
                //Paths = @"~\PDF\";
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
                    ReportViewer1.LocalReport.ReportPath = "./rptMemberPayment.rdlc";
                    ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                    ReportViewer1.LocalReport.Refresh();
                }
                //SavePDF(ReportViewer1, Paths);
                
            }
            catch (Exception ex)
            {

            }
        }

        public void SavePDF(ReportViewer viewer, string savePath)
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            if (File.Exists(savePath))
                File.Delete(savePath);
            viewer.ProcessingMode = ProcessingMode.Local;

            byte[] Bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
            Response.Redirect("./frmManageCustomers.aspx", true);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
            Response.BinaryWrite(Bytes); // create the file
            Response.Flush();                                 
            
            return;
            //Response.SuppressContent = true;
           // HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}