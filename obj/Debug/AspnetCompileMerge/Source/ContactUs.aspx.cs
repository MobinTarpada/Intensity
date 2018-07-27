using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessCenter
{
    public partial class ContactUs : System.Web.UI.Page
    {
        MailModule.MailModule mail = new MailModule.MailModule();
        string msg = "", sub = "", script = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                sub = "Website Contact Form: " + txtName.Text;
                msg = "You have received a new message from your website contact form.<br/><br/>";
                msg += "Here are the details:<br/><br/>Name: " + txtName.Text + "<br/><br/>Email: " + txtEmail.Text +
                    "<br/><br/>Subject: " + txtSubject.Text + "<br/><br/>Message:<br/>" + txtMessage.Text;
                mail.MailGmail("newwaytest15@gmail.com", "Newway@123", "info@intensity.net.in", sub, msg);
                lblMsg.Text = "Thank You ! Your email has been delivered.";
                script = "$('.mail-message').removeClass('not-visible-message').addClass('visible-message');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", script, true);
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