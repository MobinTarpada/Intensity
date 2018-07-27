using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessCenter
{
    public partial class FreeTrial : System.Web.UI.Page
    {
        MailModule.MailModule mail = new MailModule.MailModule();
        string msg = "", sub = "", script = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sub = "Website Contact Form: " + txtName.Text;
        //        msg = "You have received a new message from your website contact form.<br/><br/>";
        //        msg += "Here are the details:<br/><br/>Name: " + txtName.Text + "<br/><br/>Email: " + txtEmail.Text +
        //            "<br/><br/>Contact: " + txtContact.Text + "<br/><br/>FitnessGoal:" + rdoGoalList.SelectedItem + "<br/><br/>Message:<br/>" + txtMessage.Text;
        //        mail.MailGmail("newwaytest15@gmail.com", "Newway@123", "info@intensity.net.in", sub, msg);
        //        lblMsg.Text = "Thank You ! Your email has been delivered.";
        //        script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsg.Text = "Error ! Your Email has not been delivered";
        //        script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
        //        throw ex;
        //    }
        //}

        protected void btnSend_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ManageMemberShip.CheckForInternetConnection())
                {
                    sub = "Website Contact Form: " + txtName.Text;
                    msg = "You have received a new message from your website free trial form.<br/><br/>";
                    msg += "Here are the details:<br/><br/>Name: " + txtName.Text + "<br/><br/>Email: " + txtEmail.Text +
                        "<br/><br/>Contact: " + txtContact.Text + "<br/><br/>FitnessGoal:" + rdoGoalList.SelectedItem + "<br/><br/>Message:<br/>" + txtMessage.Text;

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



                    lblMsg.Text = "Thank You ! Your email has been delivered.";
                    script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
                    //Response.Redirect("./FreeTrialReceipt.aspx?contact=" + txtContact.Text);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Check Youur Internet Connection')", true);
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error ! Your Email has not been delivered";
                script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
                throw ex;
            }
        }
    }
}
