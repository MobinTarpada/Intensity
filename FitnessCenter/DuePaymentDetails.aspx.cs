using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using FitnessCenter.DAL;
using System.Net;

namespace FitnessCenter
{
    public partial class DuePaymentDetails : System.Web.UI.Page
    {

        #region Properties

        public long LeadId
        {
            get
            {
                var obj = ViewState["LeadId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["LeadId"] = value;
            }
        }

        public long MemberId
        {
            get
            {
                var obj = ViewState["MemberId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["MemberId"] = value;
            }
        }

        public String AgreementNumber
        {
            get
            {
                var obj = ViewState["AgreementNumber"];
                return obj == null ? null : (String)obj;
            }
            set
            {
                ViewState["AgreementNumber"] = value;
            }
        }

        public String RFIDNO
        {
            get
            {
                var obj = ViewState["RFIDNO"];
                return obj == null ? null : (String)obj;
            }
            set
            {
                ViewState["RFIDNO"] = value;
            }
        }

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }

        public string SortField
        {
            get
            {
                var obj = ViewState["SortField"];
                return obj == null ? "ID" : (string)obj;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        public string SortDir
        {
            get
            {
                var obj = ViewState["SortDir"];
                return obj == null ? "DSC" : (string)obj;
            }
            set
            {
                ViewState["SortDir"] = value;
            }
        }

        public long UserId
        {
            get
            {
                var obj = ViewState["UserId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserId"] = value;
            }
        }

        public string Mode
        {
            get
            {
                var obj = ViewState["Mode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            PannelVisibility(false, false, true, false);
        }

        #region Methods

        private void BindGrid()
        {
            try
            {
                grdDuePayment.DataSource = PaymentController.GetPaymentHistory(txtSearchText.Text, AgreementNumber, LoginUser.ClubId);
                grdDuePayment.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindPartPaymentDetails()
        {
            try
            {
                grdMain.DataSource = PaymentController.GetPartPayment(txtSrchTxt.Text, LoginUser.ClubId);
                grdMain.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindFullPaymentDetails()
        {
            try
            {
                grdFullPaidMember.DataSource = PaymentController.GetFullPayment(txtFullSearch.Text, LoginUser.ClubId);
                grdFullPaidMember.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PannelVisibility(bool Detail, bool View, bool Option, bool FullPiad)
        {
            try
            {
                pnlDetails.Visible = Detail;
                pnlView.Visible = View;
                pnlOptions.Visible = Option;
                pnlFullPaid.Visible = FullPiad;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PannelVisibility(false, false, true, true);
                if (pnlFullPaid.Visible == true)
                {
                    BindFullPaymentDetails();
                }
                if (pnlDetails.Visible == true)
                {
                    BindPartPaymentDetails();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMain.PageIndex = e.NewPageIndex;
            PannelVisibility(true, false, true, false);
            BindPartPaymentDetails();
        }

        protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailPayment")
            {
                AgreementNumber = Convert.ToString(e.CommandArgument);
                //pnlDisclaimerDetails.Visible = true;
                PannelVisibility(true, true, true, false);
                BindGrid();
            }
            else if (e.CommandName == "SMSLead")
            {
                txtMsgSMS.Text = "";
                AgreementNumber = Convert.ToString(e.CommandArgument);
                string jScript = "";
                jScript = "$('#MsgBoxModal5').removeClass('hide');";
                jScript += "$('#masteroverlay5').removeClass('hide');";
                jScript += "$('#MsgBoxModal5').fadeIn(300);";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_SMS", jScript, true);

                var objPayment = new FitnessCenterEntities().Payments.FirstOrDefault(x => x.MembershipId == M);
                long LeadId = objPayment.LeadId;
                Lead objLead = LeadController.GetLeadById(LeadId);
                txtSmS.Text = objLead.mobileNumber;
                txtMsgSMS.Text = "Your Due Amount is: " + Convert.ToString(objPayment.remainingAmount);
                txtMsgSMS.Text += "\nPlease Paid Before This Date: "+ objPayment.DueAmountDate;
            }
        }

        protected void grdDuePayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDuePayment.PageIndex = e.NewPageIndex;
            PannelVisibility(true, true, true, false);
            BindGrid();
        }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            try
            {
                BindPartPaymentDetails();
                PannelVisibility(true, false, true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedValue == "1")
            {
                BindFullPaymentDetails();
                PannelVisibility(false, false, true, true);
            }
            if (ddlOptions.SelectedValue == "2")
            {
                BindPartPaymentDetails();
                PannelVisibility(true, false, true, false);
            }

        }

        protected void btnFullSearch_Click(object sender, EventArgs e)
        {
            PannelVisibility(false, false, true, true);
            BindFullPaymentDetails();
        }

        protected void grdFullPaidMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFullPaidMember.PageIndex = e.NewPageIndex;
            BindFullPaymentDetails();
            PannelVisibility(false, false, true, true);
        }

        protected void grdFullPaidMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailPayment")
            {
                AgreementNumber = Convert.ToString(e.CommandArgument);
                //pnlDisclaimerDetails.Visible = true;
                PannelVisibility(false, true, true, true);
                BindGrid();
            }
        }

        protected void btnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = txtMsgSMS.Text;
                string Actype = "1";
                string Msgtype = "0";
                string SenderId = "INTNST";
                string ozSURL = "http://sms.infisms.co.in/API/SendSMS.aspx"; //where the SMS Gateway is running
                //string ozSPort = "9501"; //port number where the SMS Gateway is listening
                string ozUser = HttpUtility.UrlEncode("inten51ty"); //username for successful login
                string ozPassw = HttpUtility.UrlEncode("f1tn3ss"); //user's password
                //string ozMessageType = "SMS:TEXT"; //type of message
                string ozRecipients = HttpUtility.UrlEncode(txtSmS.Text); //who will get the message
                string ozMessageData = HttpUtility.UrlEncode(msg); //body of message
                string createdURL = ozSURL +
                    "?UserID=" + ozUser +
                    "&UserPassword=" + ozPassw +
                    "&PhoneNumber=" + ozRecipients +
                    "&Text=" + msg +
                    "&SenderId=" + SenderId +
                    "&AccountType=" + Actype +
                    "&MessageType=" + Msgtype;

                //Create the request and send data to the SMS Gateway Server by HTTP connection
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                //Get response from the SMS Gateway Server and read the answer
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}