using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using System.Net;

namespace FitnessCenter
{
    public partial class frmManageCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSrchPckg();
                BindSrchSchm(0);
                BindGrid();
                PanelVisibility(true, false);
                PanelVisibility(false, false, false, false, false);
                pnlRenew.Visible = false;
                pnlUnFreeze.Visible = false;
                pnlActPayment.Visible = false;
                pnlChqDetails.Visible = false;
                BindSchemes(0, drpSchemes);
                BindPackages(drpCurPack);
                pnlAsignCard.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                BindPackageType();

            }
        }

        #region Properties
        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }

        public decimal PackAmt
        {
            get
            {
                var obj = ViewState["PackAmt"];
                return obj == null ? 0 : (decimal)obj;

            }
            set
            {
                ViewState["PackAmt"] = value;
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

        public int TransMode
        {
            get
            {
                var obj = ViewState["TransMode"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                ViewState["TransMode"] = value;
            }
        }

        public string Message
        {
            get
            {
                var obj = ViewState["Message"];
                return obj == null ? "Message" : (string)obj;
            }
            set
            {
                ViewState["Message"] = value;
            }
        }

        public string RAgreeMentNumber
        {
            get
            {
                var obj = ViewState["RAgreeMentNumber"];
                return obj == null ? "RAgreeMentNumber" : (string)obj;
            }
            set
            {
                ViewState["RAgreeMentNumber"] = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                var obj = ViewState["MobileNumber"];
                return obj == null ? "MobileNumber" : (string)obj;
            }
            set
            {
                ViewState["MobileNumber"] = value;
            }
        }
        #endregion

        #region Events
        protected void grdMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditCustomer")
                {
                    MemberId = Convert.ToInt64(e.CommandArgument);
                    Membership objMember = CustomerController.GetMembersByID(MemberId);
                    LeadId = objMember.LeadId;
                    PanelVisibility(false, true);
                    BindValues();
                }
                else if (e.CommandName == "SMSLead")
                {
                    string jScript = "";
                    jScript = "$('#MsgBoxModal5').removeClass('hide');";
                    jScript += "$('#masteroverlay5').removeClass('hide');";
                    jScript += "$('#MsgBoxModal5').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_SMS", jScript, true);
                    MemberId = Convert.ToInt64(e.CommandArgument);
                    Membership objMember = CustomerController.GetMembersByID(MemberId);
                    LeadId = objMember.LeadId;
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    txtSmS.Text = objLead.mobileNumber;
                    txtMsgSMS.Text = "HELLO SIR...\nPLEASE GIVE REFERENCE TO YOUR FRIENDS AND RELATIVE TO JOIN INTENSITY BEYOND FITNEES ";

                }
                else if (e.CommandName == "TransferLead")
                {
                    LeadId = Convert.ToInt64(e.CommandArgument);
                    string jScript = "";
                    jScript = "$('#MsgBoxModal1').removeClass('hide');";
                    jScript += "$('#masteroverlay1').removeClass('hide');";
                    jScript += "$('#MsgBoxModal1').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_lead", jScript, true);
                    BindTransferMember();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdMembers_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void drpOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TransMode = drpOptions.SelectedIndex;
                CheckDays(TransMode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnShowFees_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                decimal amt = 0, joinFee = 0, memberFee = 0, adminFee = 0, PTP = 0;

                SchemeMaster objScheme = UserSchemeMasterController.GetUserSchemeMasterByID(Convert.ToInt64(drpSchemes.SelectedValue));
                CancellationMaster objCancel = UserSchemeMasterController.GetCancellationBySchemeId(Convert.ToInt64(drpSchemes.SelectedValue));
                Membership objMember = CustomerController.GetMembersByID(MemberId);

                joinFee = Convert.ToDecimal((objCancel.joiningFee) ? objMember.JoiningFee : joinFee);
                memberFee = Convert.ToDecimal((objCancel.membershipFee) ? objMember.MemberFee : memberFee);
                adminFee = Convert.ToDecimal((objCancel.adminFee) ? objMember.AdminFee : adminFee);
                PTP = Convert.ToDecimal((objCancel.personalTrainingPack) ? objMember.PTFee : PTP);

                amt = joinFee + memberFee + adminFee + PTP;
                msg = "Joining Fee: " + joinFee + "Admin Fee: " + adminFee + "Member Fee: " + memberFee
                    + "Personal Training Pack: " + PTP + "Total Amount: " + amt;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "ShowFees('Information','" + joinFee + "','" + adminFee + "','" + memberFee + "','" + PTP + "');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearValues();
            PanelVisibility(true, false);
            PanelVisibility(false, false, false, false, false);
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (TransMode)
                {
                    case 1:
                        InsertCancelTrans();
                        break;
                    case 2:
                        if (txtDwnPaidAmt.Text.Equals(""))
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Paid Amount');", true);
                        else if (drpSchemesDwn.SelectedIndex == 0)
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Scheme');", true);
                        else
                            InsertDowngradeTrans();
                        break;
                    case 3:
                        if (txtUpPaidAmt.Text.Equals(""))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Paid Amount');", true);
                            return;
                        }
                        else if (drpUpSchemes.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Scheme');", true);
                            return;
                        }

                        else if (txtUpRemAmt.Text != "0.00" && txtDueDate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Scheme');", true);
                            txtDueDate.Focus();
                            return;
                        }
                        else
                        {
                            InsertUpgradeTrans();
                            Response.Redirect("./frmUpgradePaymentReceipt.aspx?agreementNo=" + RAgreeMentNumber);
                        }
                        break;
                    case 4:
                        if (txtStDate.Text == "")
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Start Date');", true);
                        else
                            InsertTimeTrans();
                        break;
                    case 5:
                        if (ddlPkgtype.SelectedIndex == 0 || ddlSchemeType.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Select Package and Scheme');", true);
                        }
                        else if (txtADate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Activation Date');", true);
                        }
                        else
                        {
                            InsertRenewMembers();
                        }

                        break;
                }
                ClearValues();
                PanelVisibility(true, false);
                PanelVisibility(false, false, false, false, false);
                pnlRenew.Visible = false;
                pnlUnFreeze.Visible = false;
                BindGrid();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpPackages.SelectedIndex == 0)
                {
                    BindSchemes(0, drpSchemesDwn);
                    drpSchemesDwn.Enabled = btnDwnShowFees.Enabled = false;
                }
                else
                {
                    BindSchemes(Convert.ToInt64(drpPackages.SelectedValue), drpSchemesDwn);
                    drpSchemesDwn.Enabled = true;
                }
                txtSelSchAmt.Text = txtDwnRemAmt.Text = txtDwnPaidAmt.Text = txtDiffAmt.Text = "";
                btnDwnShowFees.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblPayMode.SelectedValue == "2")
                pnlChqDetails.Visible = true;

            else
                pnlChqDetails.Visible = false;
        }
        protected void drpUpSchemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpUpSchemes.SelectedIndex == 0)
                {
                    btnUpShowFees.Enabled = false;
                    txtUpSelScheme.Text = txtUpRemAmt.Text = txtUpPaidAmt.Text = txtUpDiffAmt.Text = "";
                }
                else if (drpUpSchemes.SelectedValue.Equals(drpSchemes.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Selected Scheme is the current Scheme of member Please select Another Scheme');", true);
                    drpUpSchemes.SelectedIndex = 0;
                }
                else
                {
                    SchemeMaster objScheme = UserSchemeMasterController.GetUserSchemeMasterByID(Convert.ToInt64(drpUpSchemes.SelectedValue));
                    decimal diffAmt = 0, remAmt = 0;

                    txtUpSelScheme.Text = Convert.ToString(objScheme.TotalAmount);
                    diffAmt = Convert.ToDecimal(Convert.ToDecimal(txtUpSelScheme.Text) - Convert.ToDecimal(txtPaidAmt.Text));

                    if (diffAmt <= 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Selected Scheme is not Valid Scheme');", true);
                        drpUpSchemes.SelectedIndex = 0;
                    }
                    else
                    {
                        btnUpShowFees.Enabled = true;
                        txtUpDiffAmt.Text = txtUpPaidAmt.Text = Convert.ToString(diffAmt);
                        remAmt = Convert.ToDecimal(diffAmt - Convert.ToDecimal(txtUpPaidAmt.Text));
                        txtUpRemAmt.Text = Convert.ToString(remAmt);
                        if (diffAmt == 0)
                            PanelVisibility(false, false, true, false, false);
                        else
                            PanelVisibility(false, false, true, false, true);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpSchemesDwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (drpSchemesDwn.SelectedIndex == 0)
                //{
                //    btnDwnShowFees.Enabled = false;
                //    txtSelSchAmt.Text = txtDwnRemAmt.Text = txtDwnPaidAmt.Text = txtDiffAmt.Text = "";
                //}
                //else if (drpSchemesDwn.SelectedValue.Equals(drpSchemes.SelectedValue))
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Selected Scheme is the current Scheme of member Please select Another Scheme');", true);
                //    drpSchemesDwn.SelectedIndex = 0;
                //}
                //else
                //{
                //    SchemeMaster objScheme = SchemeMasterController.GetSchemeMasterByID(Convert.ToInt64(drpSchemesDwn.SelectedValue));
                //    SchemeMaster objScheme1 = SchemeMasterController.GetSchemeMasterByID(Convert.ToInt64(drpSchemes.SelectedValue));
                //    PackageMaster objPackage = PackageMasterController.GetPackageById(Convert.ToInt64(drpPackages.SelectedValue));
                //    decimal diffAmt = 0, remAmt = 0;

                //    txtSelSchAmt.Text = Convert.ToString(objScheme.totalAmount);
                //    diffAmt = Convert.ToDecimal(Convert.ToDecimal(txtDownPaidAmt.Text) - Convert.ToDecimal(txtSelSchAmt.Text));

                //    if (diffAmt < 0)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Selected Scheme is not Valid Scheme');", true);
                //        drpSchemesDwn.SelectedIndex = 0;
                //    }
                //    else
                //    {
                //        btnDwnShowFees.Enabled = true;
                //        txtDiffAmt.Text = Convert.ToString(diffAmt);
                //        txtDwnPaidAmt.Text = Convert.ToString(diffAmt);
                //        remAmt = Convert.ToDecimal(diffAmt - Convert.ToDecimal(txtDwnPaidAmt.Text));
                //        txtDwnRemAmt.Text = Convert.ToString(remAmt);
                //        if (diffAmt == 0)
                //            PanelVisibility(false, false, false, true, false);
                //        else
                //            PanelVisibility(false, false, false, true, true);
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDwnShowFees_Click(object sender, EventArgs e)
        {
            try
            {
                //SchemeMaster objScheme = SchemeMasterController.GetSchemeMasterByID(Convert.ToInt64(drpSchemesDwn.SelectedValue));
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "ShowFees('Information','" + objScheme.joiningFee + "','" + objScheme.adminFee + "','" + objScheme.membershipFee + "','" + objScheme.personalTrainingPack + "');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtDwnPaidAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Paid = 0, diff = 0;
                Paid = Convert.ToDecimal(txtDwnPaidAmt.Text);
                diff = Convert.ToDecimal(txtDiffAmt.Text);
                if (txtDwnPaidAmt.Text == "")
                {
                    btnSave.Enabled = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Paid Amount');", true);
                }
                else if (Paid > diff)
                {
                    txtDwnPaidAmt.Text = "";
                    btnSave.Enabled = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Less Than Diffrence Amount');", true);
                }
                else
                {
                    btnSave.Enabled = true;
                    txtDwnRemAmt.Text = Convert.ToString(Convert.ToDecimal(txtDiffAmt.Text) - Convert.ToDecimal(txtDwnPaidAmt.Text));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpUpPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpUpPack.SelectedIndex == 0)
                {
                    BindSchemes(0, drpUpSchemes);
                    drpUpSchemes.Enabled = false;
                }
                else
                {
                    BindSchemes(Convert.ToInt64(drpUpPack.SelectedValue), drpUpSchemes);
                    drpUpSchemes.Enabled = true;
                }
                txtUpSelScheme.Text = txtUpRemAmt.Text = txtUpPaidAmt.Text = txtUpDiffAmt.Text = "";
                btnUpShowFees.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnUpShowFees_Click(object sender, EventArgs e)
        {
            try
            {
                //SchemeMaster objScheme = SchemeMasterController.GetSchemeMasterByID(Convert.ToInt64(drpUpSchemes.SelectedValue));
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "ShowFees('Information','" + objScheme.joiningFee + "','" + objScheme.adminFee + "','" + objScheme.membershipFee + "','" + objScheme.personalTrainingPack + "');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtUpPaidAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUpPaidAmt.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Paid Amount');", true);
                else
                    txtUpRemAmt.Text = Convert.ToString(Convert.ToDecimal(txtUpDiffAmt.Text) - Convert.ToDecimal(txtUpPaidAmt.Text));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtStDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                DateTime endDate, stDate, expDate;
                if (txtStDate.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Start Date');", true);
                else if (txtDays.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Days');", true);
                else
                {
                    stDate = UtillController.ConvertDateTime(txtStDate.Text);
                    endDate = stDate.AddDays(Convert.ToInt64(txtDays.Text));
                    txtEndDate.Text = endDate.ToString("dd/MM/yyyy");
                    //expDate = ((DateTime)objMember.expiryDate).AddDays(Convert.ToInt64(txtDays.Text));
                    //txtNewExpDate.Text = expDate.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlPkgtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPkgtype.SelectedIndex == 0)
                {
                    //txtJoiningFee.Text = "";
                    //txtAdminFee.Text = "";
                    //txtMembershipFee.Text = "";
                    //txtPersonalTrainingPack.Text = "";
                    //txtTotalAmount.Text = "";
                    txtAmtPyb.Text = "";
                    BindSchemesType(0);

                }
                else
                {
                    BindSchemesType(Convert.ToInt64(ddlPkgtype.SelectedValue));
                    PackageMaster objPckg = PackageMasterController.GetPackageById(Convert.ToInt64(ddlPkgtype.SelectedValue));
                    //txtJoiningFee.Text = Convert.ToString(objPckg.joiningFee);
                    //txtAdminFee.Text = Convert.ToString(objPckg.adminFee);
                    //txtMembershipFee.Text = Convert.ToString(objPckg.membershipFee);
                    //txtPersonalTrainingPack.Text = Convert.ToString(objPckg.personalTrainingPack);
                    //txtSerTax.Text = Convert.ToString(objPckg.serviceTaxInPercentage);
                    //PackAmt = objPckg.finalAmount;
                    //if (ddlSchemeType.Items.Count <= 1)
                    //    txtAmtPyb.Text = Convert.ToString(objPckg.finalAmount);
                    //txtDisApply.Text = Convert.ToString(objPckg.)
                }
                ddlSchemeType_SelectedIndexChanged(sender, e);

                //txtDisApply_TextChanged(sender, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ddlSchemeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSchemeType.SelectedIndex != 0)
                {
                    //SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
                    //lblSchName.Text = "Scheme Name: " + objScheme.schemeName;
                    //txtSchJoin.Text = txtActJoin.Text = Convert.ToString(objScheme.joiningFee);
                    //txtSchMem.Text = txtActMem.Text = Convert.ToString(objScheme.membershipFee);
                    //txtSchAdmin.Text = txtActAdmin.Text = Convert.ToString(objScheme.adminFee);
                    //txtSchPTP.Text = txtActPTP.Text = Convert.ToString(objScheme.personalTrainingPack);
                    //txtSchSerTax.Text = txtActSerTax.Text = Convert.ToString(objScheme.serviceTaxInPercentage);
                    //txtSchTotAmt.Text = txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(objScheme.totalAmount);
                    //pnlActPayment.Visible = true;
                }
                else
                {
                    //pnlActPayment.Visible = false;
                    //foreach (Control ctrl in pnlActPayment.Controls)
                    //{
                    //    if (ctrl is TextBox)
                    //        ((TextBox)ctrl).Text = "";
                    //}
                    //lblSchName.Text = txtSchJoin.Text = txtSchMem.Text = txtSchAdmin.Text = txtSchPTP.Text = txtSchTotAmt.Text = txtSchSerTax.Text = "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Methods

        public void BindTransferMember()
        {
            try
            {

                drpTransferMember.DataSource = MembershipController.GetLeadForTransfer(LoginUser.ClubId);
                drpTransferMember.DataTextField = "firstName";
                drpTransferMember.DataValueField = "ID";
                drpTransferMember.DataBind();

                drpTransferMember.Items.Insert(0, new ListItem("Select Member", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void SendSmS()
        {
            try
            {
                string msg = Message;
                string Actype = "1";
                string Msgtype = "0";
                string SenderId = "INTNST";
                string ozSURL = "http://sms.infisms.co.in/API/SendSMS.aspx"; //where the SMS Gateway is running
                //string ozSPort = "9501"; //port number where the SMS Gateway is listening
                string ozUser = HttpUtility.UrlEncode("inten51ty"); //username for successful login
                string ozPassw = HttpUtility.UrlEncode("f1tn3ss"); //user's password
                //string ozMessageType = "SMS:TEXT"; //type of message
                string ozRecipients = HttpUtility.UrlEncode(MobileNumber); //who will get the message
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
        public void BindGrid()
        {
            try
            {
                grdMembers.DataSource = CustomerController.GetCustomers(txtSearchFName.Text, txtSearchLastName.Text, txtSearchDateOfBirth.Text, txtSearchMobileNo.Text, txtSearchRfidNo.Text, txtSearchMembershipNo.Text, SortField, SortDir, LoginUser.ClubId, ddlSrchPkg.SelectedValue, ddlSrchScheme.SelectedValue);
                grdMembers.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit)
        {
            pnlView.Visible = View;
            pnlEdit.Visible = Edit;
        }

        public void BindValues()
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                Lead objLead = CustomerController.GetLeadByID(LeadId);
                foreach (Control ctrl in pnlEdit.Controls)
                {
                    if (LoginUser.UserTypeId == 2)
                    {
                        if (ctrl is TextBox)
                            ((TextBox)ctrl).ReadOnly = false;
                    }
                    else
                    {
                        if (ctrl is TextBox)
                            ((TextBox)ctrl).ReadOnly = true;
                    }
                }
                txtFirstName.Text = objLead.firstName;
                txtLastName.Text = objLead.lastName;
                txtContact.Text = objLead.mobileNumber;
                txtDOB.Text = ((DateTime)objLead.dateOfBirth).ToString("dd/MM/yyyy");
                txtagrNumber.Text = objMember.AgreementNo;
                txtMembershipNo.Text = objMember.MembershipNo;
                drpCurPack.SelectedValue = Convert.ToString(objMember.PackageId);
                drpSchemes.SelectedValue = Convert.ToString(objMember.SchemeId);
                txtActDate.Text = ((DateTime)objMember.ActivationDate).ToString("dd/MM/yyyy");
                txtExpDate.Text = ((DateTime)objMember.ExpiryDate).ToString("dd/MM/yyyy");
                txtPaidAmt.Text = Convert.ToString(objMember.FinalAmount);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindSchemes(long PackageId, DropDownList drpSch)
        {
            try
            {
                if (PackageId == 0)
                {
                    drpSch.DataSource = CustomerController.GetSchemes();
                    ddlSrchScheme.DataSource = CustomerController.GetSchemes();
                }
                else
                {
                    drpSch.DataSource = CustomerController.GetSchemesByPackageId(PackageId);
                    ddlSrchScheme.DataSource = CustomerController.GetSchemesByPackageId(PackageId);
                }

                drpSch.DataTextField = "schemeName";
                drpSch.DataValueField = "ID";
                drpSch.DataBind();

                drpSch.Items.Insert(0, new ListItem("Select Scheme", "0"));
                drpSch.SelectedIndex = 0;
                drpSch.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void BindPackages(int mode, DropDownList drpPackage)
        //{
        //    try
        //    {

        //        switch (mode)
        //        {
        //            case 1: //Bind all packages
        //                drpPackage.DataSource = CustomerController.GetPackageTypes();
        //                break;
        //            case 2: //For Downgrade
        //                PackageMaster objPackage = PackageMasterController.GetPackageById(Convert.ToInt64(drpCurPack.SelectedValue));
        //                drpPackage.DataSource = CustomerController.GetPackageTypesForDowngrade(objPackage);
        //                break;
        //            case 3: //For Upgrade
        //                objPackage = PackageMasterController.GetPackageById(Convert.ToInt64(drpCurPack.SelectedValue));
        //                drpPackage.DataSource = CustomerController.GetPackageTypesForUpgrade(objPackage);
        //                break;
        //        }

        //        drpPackage.DataTextField = "packageName";
        //        drpPackage.DataValueField = "ID";
        //        drpPackage.DataBind();
        //        drpPackage.Items.Insert(0, new ListItem("Select Package", "0"));
        //        drpPackage.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public void PanelVisibility(bool Cancel, bool Time, bool Upgrade, bool Downgrade, bool Payment)
        {
            pnlCancel.Visible = Cancel;
            pnlDowngrade.Visible = Downgrade;
            pnlTime.Visible = Time;
            pnlUpgrade.Visible = Upgrade;
            pnlPayment.Visible = Payment;
        }

        public void BindPayMode(bool online)
        {
            try
            {
                rblPayMode.Items.Clear();
                foreach (ListItem item in rblPayMode.Items)
                    item.Selected = false;

                rblPayMode.Items.Add(new ListItem("Cash", "1"));
                rblPayMode.Items.Add(new ListItem("Cheque", "2"));
                if (online)
                    rblPayMode.Items.Add(new ListItem("CreditCard", "3"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckDays(int Mode)
        {
            try
            {
                bool valid = false;
                SchemeMaster objScheme = UserSchemeMasterController.GetUserSchemeMasterByID(Convert.ToInt64(drpSchemes.SelectedValue));
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                TimeSpan ts;
                DateTime actDate = (DateTime)objMember.ActivationDate;
                ts = DateTime.Now.Subtract(actDate);
                switch (Mode)
                {
                    case 0:
                        PanelVisibility(false, false, false, false, false);
                        break;
                    case 1: //Cancellation
                        #region Cancellation
                        pnlAsignCard.Visible = false;
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                        //if ((bool)objScheme.isAllowCancelation)
                        //{
                        //    if (objScheme.CancelDays > ts.Days)
                        //    {
                        //        decimal amt = 0, joinFee = 0, memberFee = 0, adminFee = 0, PTP = 0;

                        //        CancellationMaster objCancel = SchemeMasterController.GetCancellationBySchemeId(Convert.ToInt64(drpSchemes.SelectedValue));
                        //        Membership objMmbr = SchemeMasterController.GetCancellationByMemberId(txtMembershipNo.Text.Trim());
                        //        SchemeMaster objSchem = null;
                        //        if(objCancel!=null)
                        //            objSchem = SchemeMasterController.GetCancelBySchemeId(objCancel.schemeId);

                        //        txtCancPaidAmt.Text = Convert.ToString(objMmbr.amountPaid);
                        //        txtCancBalanceDue.Text = Convert.ToString(objMmbr.remainingAmount);

                        //        if (objSchem != null)
                        //        {
                        //            joinFee = Convert.ToDecimal((objCancel.joiningFee) ? objSchem.joiningFee : joinFee);
                        //            memberFee = Convert.ToDecimal((objCancel.membershipFee) ? objSchem.membershipFee : memberFee);
                        //            adminFee = Convert.ToDecimal((objCancel.adminFee) ? objSchem.adminFee : adminFee);
                        //            PTP = Convert.ToDecimal((objCancel.personalTrainingPack) ? objSchem.personalTrainingPack : PTP);
                        //        }

                        //        hfJoinFee.Value = joinFee.ToString();
                        //        hfAdminFee.Value = adminFee.ToString();
                        //        hfMemberFee.Value = memberFee.ToString();
                        //        hfPTP.Value = PTP.ToString();


                        //        amt = joinFee + memberFee + adminFee;
                        //        txtCancGst.Text = Convert.ToString(objMmbr.serviceTaxInPercentage + "%");
                        //        txtCancStartup.Text = Convert.ToString(joinFee + adminFee);
                        //        txtCancMember.Text = Convert.ToString(memberFee);
                        //        valid = true;
                        //        PanelVisibility(true, false, false, false, true);
                        //        if (LoginUser.UserTypeId == 2)
                        //            txtReturnAmt.ReadOnly = false;
                        //        else
                        //            txtReturnAmt.ReadOnly = true;
                        //        txtReturnAmt.Text = amt.ToString();
                        //        BindPayMode(false);
                        //        chkPaidRet.Text = "IsReturn";
                        //    }
                        //    else
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Cancel Days Over  You cannot cancel this member');", true);
                        //        drpOptions.SelectedIndex = 0;
                        //    }
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Cancellation not Allowed for this Scheme');", true);
                        //    drpOptions.SelectedIndex = 0;
                        //}
                        #endregion
                        break;
                    case 2: //Downgrade
                        #region Downgrade
                        pnlAsignCard.Visible = false;
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                        if (objScheme.DowngradeDays > ts.Days)
                        {

                            valid = true;
                            PanelVisibility(false, false, false, true, false);
                            Membership objMmbr = UserSchemeMasterController.GetCancellationByMemberId(txtMembershipNo.Text.Trim());

                            //txtDownPaidAmt.Text = Convert.ToString(objMmbr.amountPaid);
                            //txtDownBalDue.Text = Convert.ToString(objMmbr.remainingAmount);

                            BindPackages(drpPackages);
                            BindSchemes(0, drpSchemesDwn);
                            BindPayMode(false);
                            chkPaidRet.Text = "IsReturn";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Downgrade Days Over You cannot Downgrade this member');", true);
                            drpOptions.SelectedIndex = 0;
                        }
                        #endregion
                        break;
                    case 3: //Upgrade
                        #region Upgrade
                        pnlAsignCard.Visible = false;
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                        if (objScheme.UpgradeDays > ts.Days)
                        {
                            PanelVisibility(false, false, true, false, false);
                            valid = true;
                            BindPackages(drpUpPack);
                            BindSchemes(0, drpUpSchemes);
                            BindPayMode(true);
                            chkPaidRet.Text = "IsPaid";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Upgrade Days Over You cannot Upgrade this member');", true);
                            drpOptions.SelectedIndex = 0;
                        }
                        #endregion
                        break;
                    case 4: //Time
                        #region Time
                        pnlAsignCard.Visible = false;
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                        PanelVisibility(false, true, false, false, true);
                        BindPayMode(true);
                        chkPaidRet.Text = "IsPaid";
                        txtAddExp.Text = Convert.ToString(objScheme.AdditionalExpense);
                        if (objScheme.AdditionalExpense == 0)
                            PanelVisibility(false, true, false, false, false);
                        else
                            PanelVisibility(false, true, false, false, true);
                        #endregion
                        break;
                    case 5:
                        #region Renew
                        pnlAsignCard.Visible = false;
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                        pnlRenew.Visible = true;
                        pnlUnFreeze.Visible = false;
                        txtMembrNmbr.Text = objMember.MembershipNo;
                        txtAgreementNumber.Text = AgreementNumber();
                        PanelVisibility(false, false, false, false, false);
                        BindPackageType();
                        BindSchemesType(0);
                        //chkPaidRet.Text = "IsPaid";
                        //txtAddExp.Text = Convert.ToString(objScheme.additionalExpense);
                        #endregion
                        break;
                    case 6:
                        #region AsignCard
                        PanelVisibility(false, false, false, false, false);
                        pnlAsignCard.Visible = true;
                        btnSave.Visible = false;
                        btnCancel.Visible = false;
                        pnlRenew.Visible = false;
                        pnlUnFreeze.Visible = false;
                        txtAsignRFID.Text = objMember.RFIDCardNumber;
                        #endregion
                        break;
                    case 7:
                        #region UnFreeze
                        TimeTransaction objTransaction = CustomerController.GetFreezeByMemberId(MemberId);
                        if (objTransaction == null)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'You Are Not Freeze Thanks.. ')", true);
                            PanelVisibility(true, false);
                            pnlRenew.Visible = false;
                            pnlUnFreeze.Visible = false;
                            pnlAsignCard.Visible = false;
                            PanelVisibility(false, false, false, false, false);
                        }
                        else
                        {
                            txtUfrzDate.Text = objTransaction.startDate.ToString("dd/MM/yyyy");
                            txtUFEndDate.Text = objTransaction.endDate.ToString("dd/MM/yyyy");
                            double Days = 0;
                            //TimeSpan ts = new TimeSpan();
                            Days = (objTransaction.endDate - DateTime.Now).Days;
                            txtUFRemainingDays.Text = Days.ToString();

                            pnlAsignCard.Visible = false;
                            btnSave.Visible = false;
                            btnCancel.Visible = false;
                            pnlRenew.Visible = false;
                            pnlUnFreeze.Visible = true;
                            txtMembrNmbr.Text = objMember.MembershipNo;
                            txtAgreementNumber.Text = AgreementNumber();
                            PanelVisibility(false, false, false, false, false);
                        }
                        break;
                        #endregion
                }
                return valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindPackageType()
        {
            try
            {
                ddlPkgtype.DataSource = MembershipController.GetPackageTypes();
                ddlPkgtype.DataTextField = "packageName";
                ddlPkgtype.DataValueField = "ID";
                ddlPkgtype.DataBind();

                ddlPkgtype.Items.Insert(0, new ListItem("Select Package Type", "0"));

            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        private void BindSchemesType(long packageId)
        {
            if (packageId != 0)
            {
                ddlSchemeType.DataSource = MembershipController.GetSchemesByPackageId(packageId);
                ddlSchemeType.DataTextField = "schemeName";
                ddlSchemeType.DataValueField = "ID";
                ddlSchemeType.DataBind();
            }
            ddlSchemeType.Enabled = (packageId != 0) ? true : false;
            ddlSchemeType.Items.Insert(0, new ListItem("Select Scheme", "0"));
            ddlSchemeType.SelectedIndex = 0;

        }

        public void InsertCancelTrans()
        {
            try
            {
                CancellationTransaction objCancelTrans = new CancellationTransaction();
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                Lead objLead = LeadController.GetLeadById(objMember.LeadId);

                objCancelTrans.joiningFee = Convert.ToDecimal(hfJoinFee.Value);
                objCancelTrans.adminFee = Convert.ToDecimal(hfAdminFee.Value);
                objCancelTrans.membershipFee = Convert.ToDecimal(hfMemberFee.Value);
                objCancelTrans.personalTrainingPack = Convert.ToDecimal(hfPTP.Value);
                objCancelTrans.payMode = Convert.ToInt64((rblPayMode.SelectedValue.Equals("")) ? null : rblPayMode.SelectedValue);
                objCancelTrans.schemeId = Convert.ToInt64(drpSchemes.SelectedValue);
                objCancelTrans.membershipId = objMember.ID;
                objCancelTrans.chequeDate = null;
                objCancelTrans.chequeNo = objCancelTrans.bankName = objCancelTrans.branchDetails = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objCancelTrans.chequeDate = UtillController.ConvertDateTime(txtChqDate.Text);
                    objCancelTrans.chequeNo = txtChqNo.Text;
                    objCancelTrans.bankName = txtBankName.Text;
                    objCancelTrans.branchDetails = txtBranchDetails.Text;
                }
                objCancelTrans.isReturn = chkPaidRet.Checked;
                objCancelTrans = new CustomerController().InsertCancelTrans(objCancelTrans);
                new CustomerController().DeleteMember(objMember);

                objLead.leadStatusId = 8;

                new LeadController().UpdateLead(objLead);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Member Cancelled Successfully');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Member Cancelled Failed');", true);
                throw ex;
            }
        }

        public void InsertDowngradeTrans()
        {
            try
            {
                DowngradeTransaction objDownTrans = new DowngradeTransaction();
                Membership objMember = CustomerController.GetMembersByID(MemberId);

                objDownTrans.memberId = objMember.ID;
                objDownTrans.schemeId = Convert.ToInt64(drpSchemesDwn.SelectedValue);
                objDownTrans.payMode = Convert.ToInt64((rblPayMode.SelectedValue.Equals("")) ? null : rblPayMode.SelectedValue);
                objDownTrans.diffAmt = Convert.ToDecimal(txtDiffAmt.Text);
                objDownTrans.paidAmt = Convert.ToDecimal(txtDwnPaidAmt.Text);
                objDownTrans.remAmt = Convert.ToDecimal(txtDwnRemAmt.Text);
                objDownTrans.chequeDate = null;
                objDownTrans.bankName = objDownTrans.branchDetails = objDownTrans.chequeNo = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objDownTrans.chequeDate = UtillController.ConvertDateTime(txtChqDate.Text);
                    objDownTrans.chequeNo = txtChqNo.Text;
                    objDownTrans.bankName = txtBankName.Text;
                    objDownTrans.branchDetails = txtBranchDetails.Text;
                }
                objDownTrans.isReturn = chkPaidRet.Checked;
                objDownTrans = new CustomerController().InsertDownTrans(objDownTrans);
                UpdateMembers();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Member Downgraded Successfully');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Member Downgraded Failed');", true);
                throw ex;
            }
        }

        public void InsertUpgradeTrans()
        {
            try
            {
                UpgradeTransaction objUpTrans = new UpgradeTransaction();
                Membership objMember = CustomerController.GetMembersByID(MemberId);

                RAgreeMentNumber = objMember.AgreementNo;
                objUpTrans.memberId = objMember.ID;
                objUpTrans.schemeId = Convert.ToInt64(drpUpSchemes.SelectedValue);
                objUpTrans.payMode = Convert.ToInt64((rblPayMode.SelectedValue.Equals("")) ? null : rblPayMode.SelectedValue);
                objUpTrans.diffAmt = Convert.ToDecimal(txtUpDiffAmt.Text);
                objUpTrans.paidAmt = Convert.ToDecimal(txtUpPaidAmt.Text);
                objUpTrans.remAmt = Convert.ToDecimal(txtUpRemAmt.Text);

                objUpTrans.chequeDate = null;
                objUpTrans.chequeNo = objUpTrans.branchDetails = objUpTrans.bankName = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objUpTrans.chequeDate = UtillController.ConvertDateTime(txtChqDate.Text);
                    objUpTrans.chequeNo = txtChqNo.Text;
                    objUpTrans.bankName = txtBankName.Text;
                    objUpTrans.branchDetails = txtBranchDetails.Text;
                }
                objUpTrans.isPaid = chkPaidRet.Checked;
                objUpTrans = new CustomerController().InsertUpgradeTrans(objUpTrans);
                UpdateMembers();
                InsertPaymentHistory();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Member Upgraded Successfully');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Member Upgraded Failed');", true);
                throw ex;
            }
        }

        public void InsertTimeTrans()
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                TimeTransaction objTimeTrans = new TimeTransaction();
                objTimeTrans.memberId = objMember.ID;
                objTimeTrans.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objTimeTrans.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objTimeTrans.days = Convert.ToInt64(txtDays.Text);
                objTimeTrans.amtPaid = Convert.ToDecimal(txtAddExp.Text);
                objTimeTrans.payMode = Convert.ToInt64((rblPayMode.SelectedValue.Equals("")) ? null : rblPayMode.SelectedValue);
                objTimeTrans.chequeDate = null;
                objTimeTrans.bankName = objTimeTrans.branchDetails = objTimeTrans.chequeNo = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objTimeTrans.chequeDate = UtillController.ConvertDateTime(txtChqDate.Text);
                    objTimeTrans.chequeNo = txtChqNo.Text;
                    objTimeTrans.bankName = txtBankName.Text;
                    objTimeTrans.branchDetails = txtBranchDetails.Text;
                }
                objTimeTrans.isPaid = chkPaidRet.Checked;
                objTimeTrans = new CustomerController().InsertTimeTrans(objTimeTrans);
                objMember.ExpiryDate = UtillController.ConvertDateTime(txtNewExpDate.Text);
                new CustomerController().UpdateMembers(objMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Member Freeze Successfully');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Member Freeze Failed');", true);
                throw ex;
            }
        }

        public void InsertRenewMembers()
        {
            try
            {
                //Membership objMember = new Membership();
                //Membership objMembers = CustomerController.GetMembersByID(MemberId);
                //Club objClub = new Club();
                //UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
                //SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
                //bool paid = false;
                //objMember.Title = objMembers.Title;
                //objMember.leadId = objMembers.leadId;
                //objMember.clubId = LoginUser.ClubId;
                //objMember.packageTypeId = Convert.ToInt32(ddlPkgtype.SelectedValue);
                //objMember.packageAmount = PackAmt;
                //objMember.schemeID = Convert.ToInt32(ddlSchemeType.SelectedValue);
                //objMember.schemeAmount = Convert.ToDecimal(txtSchTotAmt.Text);
                //objMember.joiningFee = Convert.ToDecimal((txtActJoin.Text == "") ? objScheme.joiningFee : Convert.ToDecimal(txtActJoin.Text));
                //objMember.adminFee = Convert.ToDecimal((txtActAdmin.Text == "") ? objScheme.adminFee : Convert.ToDecimal(txtActAdmin.Text));
                //objMember.membershipFee = Convert.ToDecimal((txtActMem.Text == "") ? objScheme.membershipFee : Convert.ToDecimal(txtActMem.Text));
                //objMember.personalTrainingPack = Convert.ToDecimal((txtActPTP.Text == "") ? objScheme.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text));
                //objMember.serviceTaxInPercentage = Convert.ToDecimal((txtActSerTax.Text == "") ? objScheme.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text));
                //objMember.discountGivenBy = LoginUser.UserTypeId;
                //objMember.finalAmount = Convert.ToDecimal(txtAmtPyb.Text);
                //objMember.activationDate = UtillController.ConvertDateTime(txtADate.Text);
                //objMember.registrationDate = objMembers.registrationDate;
                //objMember.agreementNumber = txtAgreementNumber.Text;
                //objMember.consult = objMembers.consult;
                //objMember.branchName = objMembers.branchName;
                //objMember.expiryDate = UtillController.ConvertDateTime(txtEDate.Text);

                //objMember.sendMaterialsBy = objMembers.sendMaterialsBy; ;
                //objMember.amountPaid = objMember.remainingAmount = null;
                //objMember.payMode = null;

                //objMembers.isActive = Convert.ToBoolean("False");
                //objMember.guardianName = objMembers.guardianName;
                //objMember.relationshipOfGuardian = objMembers.relationshipOfGuardian;
                //objMember.corporateName = objMembers.corporateName;
                //objMember.corporateId = objMembers.corporateId;
                //objMember.emergencyContactName = objMembers.emergencyContactName;
                //objMember.emergencyContactNumber = objMembers.emergencyContactNumber;
                //objMember.isPaid = Convert.ToBoolean("False");
                //objMember.MembershipNo = txtMembershipNo.Text;
                //objMember.RFIDCardNumber = objMembers.RFIDCardNumber;
                //objMember = new MembershipController().InsertMember(objMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Success', 'Member Added Successfully')", true);
                Response.Redirect("./frmAgreementReceipt.aspx?agreementNo=" + txtAgreementNumber.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            Control[] ctrls = { pnlCancel, pnlChqDetails, pnlDowngrade, pnlEdit, pnlTime, pnlUpgrade };
            foreach (Control ctrl in ctrls)
            {
                foreach (Control ctr in ctrl.Controls)
                {
                    if (ctr is TextBox)
                        ((TextBox)ctr).Text = "";
                }
            }
            drpOptions.SelectedIndex = 0;
            chkPaidRet.Checked = pnlChqDetails.Visible = false;
        }

        public void UpdateMembers()
        {
            try
            {
                //Membership objMember = CustomerController.GetMembersByID(MemberId);
                //Lead objLead = LeadController.GetLeadById(objMember.leadId);

                //long PackageId = 0, SchemeId = 0, Status = 0;
                //Decimal AmountPaid = 0, Paid = 0, RemainAmt = 0;
                //DateTime actDate, expDate;
                //AmountPaid = Convert.ToDecimal(objMember.amountPaid);

                //switch (TransMode)
                //{
                //    case 2:
                //        PackageId = Convert.ToInt64(drpPackages.SelectedValue);
                //        SchemeId = Convert.ToInt64(drpSchemesDwn.SelectedValue);
                //        Paid = Convert.ToDecimal(txtDwnPaidAmt.Text);
                //        RemainAmt = Convert.ToDecimal(txtDwnRemAmt.Text);
                //        objMember.amountPaid = AmountPaid - Paid;
                //        Status = 10;
                //        break;
                //    case 3:
                //        PackageId = Convert.ToInt64(drpUpPack.SelectedValue);
                //        SchemeId = Convert.ToInt64(drpUpSchemes.SelectedValue);
                //        Paid = Convert.ToDecimal(txtUpPaidAmt.Text);
                //        RemainAmt = Convert.ToDecimal(txtUpRemAmt.Text);
                //        objMember.amountPaid = AmountPaid + Paid;
                //        Status = 9;
                //        break;

                //}

                //PackageMaster objPackage = PackageMasterController.GetPackageById(PackageId);
                //SchemeMaster objScheme = UserSchemeMasterController.GetSchemeMasterByID(SchemeId);
                //TimeSpan ts = new TimeSpan(1, 0, 0, 0);


                //actDate = (DateTime)objMember.activationDate;
                //expDate = actDate.AddMonths(objPackage.durationInMonths);
                //objMember.packageTypeId = objPackage.ID;
                //objMember.packageAmount = objPackage.finalAmount;
                //objMember.schemeID = objScheme.ID;
                //objMember.schemeAmount = objScheme.totalAmount;
                //objMember.joiningFee = objScheme.joiningFee;
                //objMember.adminFee = objScheme.adminFee;
                //objMember.membershipFee = objScheme.membershipFee;
                //objMember.personalTrainingPack = objScheme.personalTrainingPack;
                //objMember.serviceTaxInPercentage = objScheme.serviceTaxInPercentage;
                //objMember.finalAmount = objScheme.totalAmount;

                //objMember.remainingAmount = RemainAmt;
                //expDate = expDate.Subtract(ts);
                //objMember.expiryDate = expDate;
                //objMember.updateDate = DateTime.Now;
                //objLead.leadStatusId = Status;

                //new CustomerController().UpdateMembers(objMember);
                //new LeadController().UpdateLead(objLead);

                //MobileNumber = objLead.mobileNumber;
                //Message = "HELLO DEAR MEMBER YOUR MEBERSHIP IS UPGRADE SUCCESSFULLY JOIN WITH INTENSITY BEYOND FITNESS \nYOUR AGREEMENT NUMBER IS : " + txtagrNumber.Text + "\nYOUR REGISTRATION DATE IS : " + objMember.registrationDate + "\nYOUR ACTIVATION DATE IS : " + objMember.activationDate + "\nYOUR NEW EXPIRY DATE IS : " + expDate; ;
                //SendSmS();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void InsertPaymentHistory()
        {
            try
            {
                //Membership objMember = CustomerController.GetMembersByID(MemberId);
                //Payment objReceipt = PaymentController.GetLastReceiptNumber(LoginUser.ClubId);

                //Payment objPayment = new Payment();
                //objPayment.payMode = Convert.ToInt32(rblPayMode.SelectedValue);

                //Payment objPay = new Payment();

                //Decimal AmountPaid = 0, Paid = 0;
                //AmountPaid = Convert.ToDecimal(objMember.amountPaid);
                //Paid = AmountPaid;

                //objPayment.leadId = objMember.leadId;
                //objPayment.clubId = LoginUser.ClubId;
                //objPayment.packageTypeId = objMember.packageTypeId;
                //objPayment.packageAmount = objMember.packageAmount;
                //objPayment.schemeID = objMember.schemeID;
                //objPayment.schemeAmount = objMember.schemeAmount;
                //objPayment.joiningFee = objMember.joiningFee;
                //objPayment.adminFee = objMember.adminFee;
                //objPayment.membershipFee = objMember.membershipFee;
                //objPayment.personalTrainingPack = objMember.personalTrainingPack;
                //objPayment.serviceTaxInPercentage = objMember.serviceTaxInPercentage;
                //objPayment.discountGivenBy = objMember.discountGivenBy;

                //objPayment.registrationDate = objMember.registrationDate;
                //objPayment.activationDate = objMember.activationDate;
                //objPayment.agreementNumber = objMember.agreementNumber;
                //objPayment.RFIDCardNumber = objMember.RFIDCardNumber;
                //objPayment.MembershipNo = objMember.MembershipNo;
                //objPayment.consult = objMember.consult;
                //objPayment.branchName = objMember.branchName;
                //objPayment.expiryDate = objMember.expiryDate;


                //if (rblPayMode.SelectedValue == "1")
                //{
                //    objPayment.finalAmount = objMember.finalAmount;
                //    objPayment.amountPaid = Convert.ToDecimal(txtUpPaidAmt.Text);
                //    objPayment.remainingAmount = Convert.ToDecimal(txtUpRemAmt.Text);

                //    if (txtUpRemAmt.Text == "0.00")
                //    {
                //        objPayment.DueAmountDate = null;
                //        objPayment.isFullPaid = Convert.ToBoolean("True");
                //    }
                //    else
                //    {
                //        objPayment.DueAmountDate = UtillController.ConvertDateTime(txtDueDate.Text);
                //        objPayment.isFullPaid = Convert.ToBoolean("False");
                //        objPay.isFullPaid = Convert.ToBoolean("False");

                //    }
                //    objPayment.isPaid = chkPaidRet.Checked;
                //    objPayment.ReceiptNumber = objReceipt.ReceiptNumber + 1;
                //}
                //else if (rblPayMode.SelectedValue == "2")
                //{
                //    objPayment.finalAmount = objMember.finalAmount;

                //    objPayment.isPaid = chkPaidRet.Checked;
                //    if (txtUpRemAmt.Text == "0.00")
                //    {
                //        objPayment.DueAmountDate = null;
                //        objPayment.isFullPaid = Convert.ToBoolean("True");
                //    }
                //    else
                //    {
                //        objPayment.DueAmountDate = UtillController.ConvertDateTime(txtDueDate.Text);
                //        objPayment.isFullPaid = Convert.ToBoolean("False");
                //        objPay.isFullPaid = Convert.ToBoolean("False");
                //    }
                //    objPayment.amountPaid = Convert.ToDecimal(txtUpPaidAmt.Text); ;
                //    objPayment.remainingAmount = Convert.ToDecimal(txtUpRemAmt.Text);
                //    objPayment.chequeDate = UtillController.ConvertDateTime(txtChqDate.Text);
                //    objPayment.chequeNumber = txtChqNo.Text;
                //    objPayment.BankName = txtBankName.Text;
                //    objPayment.Branch = txtBranchDetails.Text;
                //}
                //objMember.MembershipNo = objMember.MembershipNo;
                //objMember.RFIDCardNumber = objMember.RFIDCardNumber;

                //new PaymentController().InsertPaymentHistory(objPayment);
                //if (txtUpRemAmt.Text != "0.00")
                //    new PaymentController().UpdateOldPayment(objPay);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Member Payment Recieved Successfully')", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

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

        public void BindPackages(DropDownList drpPackage)
        {
            try
            {
                drpPackage.DataSource = CustomerController.GetPackageTypes();
                drpPackage.DataTextField = "packageName";
                drpPackage.DataValueField = "ID";
                drpPackage.DataBind();
                drpPackage.Items.Insert(0, new ListItem("Select Package", "0"));
                drpPackage.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtActJoin_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
            SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActJoin.Text = Convert.ToString(
                    (objUserTrans.joiningFee > Convert.ToDecimal(txtActJoin.Text))
                    ? objUserTrans.joiningFee : Convert.ToDecimal(txtActJoin.Text)
                    );
            else
                txtActJoin.Text = Convert.ToString(
                    (objScheme.JoiningFee > Convert.ToDecimal(txtActJoin.Text))
                    ? objScheme.JoiningFee : Convert.ToDecimal(txtActJoin.Text)
                    );
            decimal amt = 0;
            amt =
                ((txtActJoin.Text == "") ? 0 : Convert.ToDecimal(txtActJoin.Text)) +
                ((txtActAdmin.Text == "") ? 0 : Convert.ToDecimal(txtActAdmin.Text)) +
                ((txtActMem.Text == "") ? 0 : Convert.ToDecimal(txtActMem.Text)) +
                ((txtActPTP.Text == "") ? 0 : Convert.ToDecimal(txtActPTP.Text))
                ;
            amt += (amt * Convert.ToDecimal((txtActSerTax.Text == "") ? 0 : Convert.ToDecimal(txtActSerTax.Text)) / 100);
            txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(amt);
        }

        protected void txtActAdmin_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
            SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActAdmin.Text = Convert.ToString(
                    (objUserTrans.adminFee > Convert.ToDecimal(txtActAdmin.Text))
                    ? objUserTrans.adminFee : Convert.ToDecimal(txtActAdmin.Text)
                    );
            else
                txtActAdmin.Text = Convert.ToString(
                    (objScheme.AdminFee > Convert.ToDecimal(txtActAdmin.Text))
                    ? objScheme.AdminFee : Convert.ToDecimal(txtActAdmin.Text)
                    );
            decimal amt = 0;
            amt =
                ((txtActJoin.Text == "") ? 0 : Convert.ToDecimal(txtActJoin.Text)) +
                ((txtActAdmin.Text == "") ? 0 : Convert.ToDecimal(txtActAdmin.Text)) +
                ((txtActMem.Text == "") ? 0 : Convert.ToDecimal(txtActMem.Text)) +
                ((txtActPTP.Text == "") ? 0 : Convert.ToDecimal(txtActPTP.Text))
                ;
            amt += (amt * Convert.ToDecimal((txtActSerTax.Text == "") ? 0 : Convert.ToDecimal(txtActSerTax.Text)) / 100);
            txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(amt);
            txtActMem.Focus();
        }

        protected void txtActMem_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
            SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActMem.Text = Convert.ToString(
                    (objUserTrans.membershipFee > Convert.ToDecimal(txtActMem.Text))
                    ? objUserTrans.membershipFee : Convert.ToDecimal(txtActMem.Text)
                    );
            else
                txtActMem.Text = Convert.ToString(
                    (objScheme.MemberFee > Convert.ToDecimal(txtActMem.Text))
                    ? objScheme.MemberFee : Convert.ToDecimal(txtActMem.Text)
                    );
            decimal amt = 0;
            amt =
                ((txtActJoin.Text == "") ? 0 : Convert.ToDecimal(txtActJoin.Text)) +
                ((txtActAdmin.Text == "") ? 0 : Convert.ToDecimal(txtActAdmin.Text)) +
                ((txtActMem.Text == "") ? 0 : Convert.ToDecimal(txtActMem.Text)) +
                ((txtActPTP.Text == "") ? 0 : Convert.ToDecimal(txtActPTP.Text))
                ;
            amt += (amt * Convert.ToDecimal((txtActSerTax.Text == "") ? 0 : Convert.ToDecimal(txtActSerTax.Text)) / 100);
            txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(amt);
            txtActPTP.Focus();
        }

        protected void txtActPTP_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
            SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActPTP.Text = Convert.ToString(
                    (objUserTrans.personalTrainingPack > Convert.ToDecimal(txtActPTP.Text))
                    ? objUserTrans.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text)
                    );
            else
                txtActPTP.Text = Convert.ToString(
                    (objScheme.PTFee > Convert.ToDecimal(txtActPTP.Text))
                    ? objScheme.PTFee : Convert.ToDecimal(txtActPTP.Text)
                    );
            decimal amt = 0;
            amt =
                ((txtActJoin.Text == "") ? 0 : Convert.ToDecimal(txtActJoin.Text)) +
                ((txtActAdmin.Text == "") ? 0 : Convert.ToDecimal(txtActAdmin.Text)) +
                ((txtActMem.Text == "") ? 0 : Convert.ToDecimal(txtActMem.Text)) +
                ((txtActPTP.Text == "") ? 0 : Convert.ToDecimal(txtActPTP.Text))
                ;
            amt += (amt * Convert.ToDecimal((txtActSerTax.Text == "") ? 0 : Convert.ToDecimal(txtActSerTax.Text)) / 100);
            txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(amt);
            txtActSerTax.Focus();
        }

        protected void txtActSerTax_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.UserTypeId);
            SchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            decimal amt = 0;

            if (objUserTrans != null)
                txtActSerTax.Text = Convert.ToString(
                    (objUserTrans.serviceTaxInPercentage > Convert.ToDecimal(txtActSerTax.Text))
                    ? objUserTrans.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text)
                    );
            else
                txtActSerTax.Text = Convert.ToString(
                    (objScheme.SGST > Convert.ToDecimal(txtActSerTax.Text))
                    ? objScheme.SGST : Convert.ToDecimal(txtActSerTax.Text)
                    );

            amt =
                ((txtActJoin.Text == "") ? 0 : Convert.ToDecimal(txtActJoin.Text)) +
                ((txtActAdmin.Text == "") ? 0 : Convert.ToDecimal(txtActAdmin.Text)) +
                ((txtActMem.Text == "") ? 0 : Convert.ToDecimal(txtActMem.Text)) +
                ((txtActPTP.Text == "") ? 0 : Convert.ToDecimal(txtActPTP.Text))
                ;
            amt += (amt * Convert.ToDecimal((txtActSerTax.Text == "") ? 0 : Convert.ToDecimal(txtActSerTax.Text)) / 100);
            txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(amt);
        }

        protected void txtADate_TextChanged(object sender, EventArgs e)
        {
            Membership objMember = CustomerController.GetMembersByID(MemberId);
            DateTime ac, jn, ed;
            //jn = UtillController.ConvertDateTime(objMember.expiryDate);
            ac = UtillController.ConvertDateTime(txtADate.Text);
            TimeSpan ts = new TimeSpan(0, 0, 0, 0);
            ///ts = ac.Subtract(jn);
            ////int days = 0;
            ////days = ts.Days;
            //if (ac.Date <= jn.Date)
            //{
            //    ac = jn.AddDays(1);
            //    txtADate.Text = ac.ToString("dd/MM/yyyy");
            //}
            PackageMaster objPckg = PackageMasterController.GetPackageById(Convert.ToInt64(ddlPkgtype.SelectedValue));
            //int edate = objPckg.durationInMonths;
            //ed = ac.AddMonths(edate);
            //ts = new TimeSpan(1, 0, 0, 0);
            //ed = ed.Subtract(ts);
            //txtEDate.Text = ed.ToString("dd/MM/yyyy");
        }

        public string AgreementNumber()
        {
            Lead objMembr = LeadController.GetLeadById(LeadId);
            string ANumber = "INT", AgrNO = "";
            ANumber += LoginUser.ClubId.ToString().PadLeft(3, '0');
            ANumber += DateTime.Now.ToString("yyMM");
            long i = objMembr.ID;
            //i = MembershipController.GetMembersByAgreementNumber().Count + 1;
            AgrNO = i.ToString().PadLeft(4, '0');
            AgrNO = AgrNO.Substring(AgrNO.Length - 4, 4);
            ANumber += AgrNO;
            return ANumber;
        }

        protected void btAsignRFID_Click(object sender, EventArgs e)
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                objMember.RFIDCardNumber = txtAsignRFID.Text;
                new CustomerController().UpdateMembers(objMember);
                ClearValues();
                pnlAsignCard.Visible = false;
                PanelVisibility(true, false);
                PanelVisibility(false, false, false, false, false);
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnTransferLeads_Click(object sender, EventArgs e)
        {
            try
            {

                //Lead objLead = LeadController.GetLeadById(Convert.ToInt64(drpTransferMember.SelectedValue));
                //Membership objmember = MembershipController.GetmembersById(LeadId);
                //Membership objNewmember = new Membership();
                //if (drpTransferMember.SelectedIndex == 0)
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Member To Transfer Membership');", true);
                //else
                //{
                //    //objmember.isTransfer = true;
                //    //objmember.transferBy = objmember.leadId;
                //    //objmember.transferTo = objLead.ID;

                //    objNewmember.Title = objmember.Title;
                //    objNewmember.leadId = objLead.ID;
                //    objNewmember.clubId = objmember.clubId;
                //    objNewmember.packageTypeId = objmember.packageTypeId;
                //    objNewmember.packageAmount = objmember.packageAmount;
                //    objNewmember.schemeID = objmember.schemeID;
                //    objNewmember.schemeAmount = objmember.schemeAmount;
                //    objNewmember.joiningFee = objmember.joiningFee;
                //    objNewmember.adminFee = objmember.adminFee;
                //    objNewmember.membershipFee = objmember.membershipFee;
                //    objNewmember.personalTrainingPack = objmember.personalTrainingPack;

                //    objNewmember.serviceTaxInPercentage = objmember.serviceTaxInPercentage;
                //    objNewmember.discountGivenBy = objmember.discountGivenBy;
                //    objNewmember.finalAmount = objmember.finalAmount;
                //    objNewmember.chequeNumber = objmember.chequeNumber;
                //    objNewmember.BankName = objmember.BankName;
                //    objNewmember.Branch = objmember.Branch;
                //    objNewmember.chequeDate = objmember.chequeDate;
                //    objNewmember.activationDate = objmember.activationDate;

                //    objNewmember.registrationDate = objmember.registrationDate;
                //    objNewmember.RFIDCardNumber = objmember.RFIDCardNumber;
                //    objNewmember.MembershipNo = objmember.MembershipNo;
                //    objNewmember.agreementNumber = objmember.agreementNumber;
                //    objNewmember.consult = objmember.consult;
                //    objNewmember.branchName = objmember.branchName;
                //    objNewmember.profilePhoto = "";
                //    objNewmember.expiryDate = objmember.expiryDate;
                //    objNewmember.sendMaterialsBy = objmember.sendMaterialsBy;
                //    objNewmember.payMode = objmember.payMode;
                //    objNewmember.guardianName = objmember.guardianName;
                //    objNewmember.relationshipOfGuardian = objmember.relationshipOfGuardian;
                //    objNewmember.guardianSignature = objmember.guardianSignature;
                //    objNewmember.companySignature = objmember.companySignature;
                //    objNewmember.memberSiganture = objmember.memberSiganture;
                //    objNewmember.corporateId = objmember.corporateId;
                //    objNewmember.corporationSignature = objmember.corporationSignature;
                //    objNewmember.corporateName = objmember.corporateName;
                //    objNewmember.emergencyContactName = objmember.emergencyContactName;
                //    objNewmember.emergencyContactNumber = objmember.emergencyContactNumber;
                //    objNewmember.amountPaid = objmember.amountPaid;
                //    objNewmember.remainingAmount = objmember.remainingAmount;
                //    objNewmember.isPaid = objmember.isPaid;


                //    objmember.isActive = false;
                //    objmember.isDeleted = true;

                //    objLead.leadStatusId = 7;

                //    //objmember = new MembershipController().UpdateMember(objmember);
                //    //objNewmember = new MembershipController().InsertMember(objNewmember);

                //    Session["objmember"] = objmember;
                //    Session["objNewMember"] = objNewmember;
                //    Session["objLead"] = objLead;

                //    Response.Redirect("./ManageMembership.aspx?pnlEdit=pnlEdit");

                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Lead Transfered Successfully');", true);
                //    BindGrid();
                //}
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

        protected void btnUnFreeze_Click(object sender, EventArgs e)
        {
            Membership objMember = CustomerController.GetMembersByID(MemberId);
            TimeTransaction objTransaction = CustomerController.GetFreezeByMemberId(MemberId);
            DateTime ExprDate;
            double UnfDays;
            //UnfDays = Convert.ToDouble(txtUFRemainingDays.Text);
            //ExprDate = Convert.ToDateTime(objMember.expiryDate);
            //objMember.expiryDate = ExprDate.AddDays(-(UnfDays));
            //new CustomerController().UpdateMembers(objMember);
            //new CustomerController().UpdateTimeTransaction(objTransaction);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Member Un Freeze Successfully')", true);
            PanelVisibility(true, false);
            PanelVisibility(false, false, false, false, false);
            pnlUnFreeze.Visible = false;
        }

        protected void btnUCancel_Click(object sender, EventArgs e)
        {
            PanelVisibility(true, false);
            PanelVisibility(false, false, false, false, false);
            pnlUnFreeze.Visible = false;
        }

        protected void txtReturnAmt_TextChanged(object sender, EventArgs e)
        {
            decimal membrFee = 0, AdminFee = 0, ReturnFee = 0, GivenFee = 0;
            if (txtCancMember.Text == "")
                membrFee = 0;
            else
                membrFee = Convert.ToDecimal(txtCancMember.Text);
            if (txtCancMember.Text == "")
                AdminFee = 0;
            else
                AdminFee = Convert.ToDecimal(txtCancStartup.Text);
            ReturnFee = membrFee + AdminFee;
            if (txtReturnAmt.Text == "")
                GivenFee = 0;
            else
                GivenFee = Convert.ToDecimal(txtReturnAmt.Text);
            if (GivenFee > ReturnFee)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Return Amount is Not Greater Than :- " + ReturnFee + "')", true);
                return;
            }
        }
        //decimal amt = 0, joinFee = 0, memberFee = 0, adminFee = 0, PTP = 0;

        //SchemeMaster objScheme = UserSchemeMasterController.GetSchemeMasterByID(Convert.ToInt64(drpSchemes.SelectedValue));
        //CancellationMaster objCancel = UserSchemeMasterController.GetCancellationBySchemeId(Convert.ToInt64(drpSchemes.SelectedValue));
        //Membership objMember = CustomerController.GetMembersByID(MemberId);

        //joinFee = Convert.ToDecimal((objCancel.joiningFee) ? objMember.joiningFee : joinFee);
        //memberFee = Convert.ToDecimal((objCancel.membershipFee) ? objMember.membershipFee : memberFee);
        //adminFee = Convert.ToDecimal((objCancel.adminFee) ? objMember.adminFee : adminFee);
        //PTP = Convert.ToDecimal((objCancel.personalTrainingPack) ? objMember.personalTrainingPack : PTP);

        //amt = joinFee + memberFee + adminFee + PTP;

        //if (TransMode == 0)
        //{
        //    PanelVisibility(false, false, false, false, false);
        //}
        //#region Cancellation
        ////else if (drpOptions.SelectedIndex == 1)
        ////{
        ////    if ((bool)objScheme.isAllowCancelation)
        ////    {
        ////        //if (CheckDays(drpOptions.SelectedIndex))
        ////        //{
        ////        //    PanelVisibility(true, false, false, false, true);
        ////        //    txtReturnAmt.Text = amt.ToString();
        ////        //    BindPayMode(false);
        ////        //    chkPaidRet.Text = "IsReturn";
        ////        //}
        ////        //else
        ////        //{
        ////        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Cancel Days Over\n You cannot cancel this member');", true);
        ////        //    drpOptions.SelectedIndex = 0;
        ////        //}
        ////    }
        ////    else
        ////    {
        ////        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Cancellation not Allowed for this Scheme');", true);
        ////        drpOptions.SelectedIndex = 0;
        ////    }
        ////}
        //#endregion
        //#region Downgradation
        //else if (drpOptions.SelectedIndex == 2)
        //{

        //    if (CheckDays(drpOptions.SelectedIndex))
        //    {
        //        PanelVisibility(false, false, false, true, true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Downgrade Days Over\n You cannot Downgrade this member');", true);
        //        drpOptions.SelectedIndex = 0;
        //    }
        //}
        //#endregion
        //#region Upgradation
        //else if (drpOptions.SelectedIndex == 3)
        //{

        //    if (CheckDays(drpOptions.SelectedIndex))
        //    {
        //        PanelVisibility(false, false, true, false, true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Upgrade Days Over\n You cannot Upgrade this member');", true);
        //        drpOptions.SelectedIndex = 0;
        //    }
        //}
        //#endregion
        //#region Time
        //else if (drpOptions.SelectedIndex == 4)
        //{
        //    PanelVisibility(false, true, false, false, true);
        //}
        //#endregion
    }
}