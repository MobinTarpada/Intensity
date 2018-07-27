using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace FitnessCenter
{
    public partial class Carrer : System.Web.UI.Page
    {
        MailModule.MailModule mail = new MailModule.MailModule();
        string script = "";
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                script = "$('.mail-message').removeClass('visible-message').addClass('not-visible-message');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "vis_msg", script, true);
                BindPositions();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (drpPosition.SelectedIndex == 0)
            {
                script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", script, true);
                lblMsg.Text = "Please select Position First";
                script = "$('.mail-message').removeClass('alert-success').addClass('alert-danger');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dng_msg", script, true);
            }
            else
                if (ManageMemberShip.CheckForInternetConnection())
                    SendMessage();
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Check Youur Internet Connection')", true);


        }
        #endregion

        #region Methods
        public void BindPositions()
        {
            try
            {
                drpPosition.DataSource = CareerController.GetCareerPositions();
                drpPosition.DataTextField = "positionName";
                drpPosition.DataValueField = "ID";
                drpPosition.DataBind();
                drpPosition.Items.Insert(0, new ListItem("Select Position", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SendMessage()
        {
            string fileName = "", path = "", ext = "", sub = "", msg = "";
            try
            {

                if (fuResume.HasFile)
                {
                    ext = Path.GetExtension(fuResume.FileName).ToLower();
                    if (ext.Trim() == ".doc" || ext.Trim() == ".docx")
                    {
                        fileName = Path.GetFileName(fuResume.FileName);
                        path = Server.MapPath("~/Resumes/" + fileName);
                        fuResume.SaveAs(path);
                        sub = "Website Career Form: " + txtName.Text;
                        msg = "You have received a new Enquiry from your career form.<br/><br/>";
                        msg += "Here are the Details<br/>";
                        msg += "Name: " + txtName.Text + "<br/>";
                        msg += "Email: " + txtEmail.Text + "<br/>";
                        msg += "Mobile No.: " + txtMobileNo.Text + "<br/>";
                        msg += "Position Applied for.: " + drpPosition.SelectedItem.Text + "<br/>";
                        msg += "<br/><br/>";
                        msg += "Resume is in Attachment. Pls check it out.";
                        string from = "info@intensity.net.in"; //example:- sourabh9303@gmail.com
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(from);
                        mail.To.Add(from);
                        mail.Subject = sub;
                        mail.Body = msg;

                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient("intensity.net.in", 587);
                        smtp.EnableSsl = false;
                        smtp.Credentials = new System.Net.NetworkCredential("info@intensity.net.in", "info@123");
                        smtp.Send(mail);
                        // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);




                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
                        lblMsg.Text = "Thank You ! Your email has been delivered.";
                        script = "$('.mail-message').removeClass('alert-danger').addClass('alert-success');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "cls_msg", script, true);
                        ClearValues();
                    }
                    else
                    {
                        script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", script, true);
                        lblMsg.Text = "Please select only Word Documents file";
                        script = "$('.mail-message').removeClass('alert-success').addClass('alert-danger');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dng_msg", script, true);
                    }
                }
                else
                {
                    script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", script, true);
                    lblMsg.Text = "Please select file";
                    script = "$('.mail-message').removeClass('alert-success').addClass('alert-danger');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dng_msg", script, true);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            try
            {
                txtEmail.Text = txtMobileNo.Text = txtName.Text = string.Empty;
                drpPosition.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}