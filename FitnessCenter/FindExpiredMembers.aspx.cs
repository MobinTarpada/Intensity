using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.Net;



namespace FitnessCenter
{
    public partial class FindExpiredMembers : System.Web.UI.Page
    {

        #region Properties

        public string SortField
        {
            get
            {
                var obj = ViewState["SortField"];
                return obj == null ? "expiryDate" : (string)obj;
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
                return obj == null ? "ASC" : (string)obj;
            }
            set
            {
                ViewState["SortDir"] = value;
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
        public long MembershipId
        {
            get
            {
                var obj = ViewState["MembershipId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["MembershipId"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid();
            BindSrchPckg();
            BindSrchSchm(0);
        }
        public void BindSrchPckg()
        {
            try
            {
                ddlSrchPkg.DataSource = MembershipController.GetPackageTypes();
                ddlSrchPkg.DataTextField = "packageName";
                ddlSrchPkg.DataValueField = "ID";
                ddlSrchPkg.DataBind();
                ddlSrchPkg.Items.Insert(0, new ListItem("Select Package Type", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSrchSchm(long PackageId)
        {
            try
            {
                if (PackageId == 0)
                {
                    ddlSrchScheme.DataSource = MembershipController.GetSchemes();
                    ddlSrchScheme.DataTextField = "schemeName";
                    ddlSrchScheme.DataValueField = "ID";
                    ddlSrchScheme.DataBind();
                }
                else
                {
                    ddlSrchScheme.DataSource = MembershipController.GetSchemesByPackageId(PackageId);
                    ddlSrchScheme.DataTextField = "schemeName";
                    ddlSrchScheme.DataValueField = "ID";
                    ddlSrchScheme.DataBind();
                }
                ddlSrchScheme.Items.Insert(0, new ListItem("Select Scheme", "0"));
                ddlSrchScheme.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindGrid()
        {
            try
            {
                grdExpiredMembers.DataSource = ExpiredMemberHistory.GetExpiredMember(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, ddlSrchPkg.SelectedValue, ddlSrchScheme.SelectedValue, ddlGender.SelectedValue, txtSrchAddress.Text);
                grdExpiredMembers.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFullSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdExpiredMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdExpiredMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdExpiredMembers_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortField = e.SortExpression;
                if (SortDir == "ASC")
                    SortDir = "DESC";
                else
                    SortDir = "ASC";
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlSrchPkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSrchPkg.SelectedIndex == 0)
                {
                    BindSrchSchm(0);
                }
                else
                {
                    BindSrchSchm(Convert.ToInt64(ddlSrchPkg.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdExpiredMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "SMSLead")
                {
                    txtMsgSMS.Text = "";
                    MembershipId = Convert.ToInt64(e.CommandArgument.ToString());
                    string jScript = "";
                    jScript = "$('#MsgBoxModal5').removeClass('hide');";
                    jScript += "$('#masteroverlay5').removeClass('hide');";
                    jScript += "$('#MsgBoxModal5').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_SMS", jScript, true);

                    var objMember = new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.ID == MembershipId);
                    long LeadId = objMember.LeadId;
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    txtSmS.Text = objLead.mobileNumber;
                    txtMsgSMS.Text = "YOUR EXPIRY DATE IS: " + objMember.ExpiryDate;
                    txtMsgSMS.Text += "\nPLEASE RENEW YOUR MEMBERSHIP BEFORE YOUR MEMBERSHIP EXPIRED";
                }
            }
            catch (Exception ex)
            {
                throw ex;
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