
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using System.Data;

namespace FitnessCenter
{
    public partial class ManageMemberShip : System.Web.UI.Page
    {

        #region Properties

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }
        public string CLUBID
        {
            get
            {
                var obj = ViewState["CLUBID"];
                return obj == null ? "ID" : (string)obj;
            }
            set
            {
                ViewState["CLUBID"] = value;
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
        //public String TempAgreementNumber
        //{
        //    get
        //    {
        //        var obj = ViewState["TempAgreementNumber"];
        //        return obj == null ? "" : (String)obj;

        //    }
        //    set
        //    {
        //        ViewState["TempAgreementNumber"] = value;
        //    }
        //}

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

        public int MemberCount
        {
            get
            {
                var obj = ViewState["MemberCount"];
                return obj == null ? 0 : (int)obj;

            }
            set
            {
                ViewState["MemberCount"] = value;
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


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PanelVisibility(true, false, false);
                    pnlActPayment.Visible = false;
                    BindGrid();
                    BindPackageType();
                    BindSchemesType(0);
                    PanelPaymentVisibility(false, false, false);
                    pnlGuardian.Visible = false;
                    pnlCorporate.Visible = false;
                    pnlRfidNo.Visible = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Events
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMembership_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdMembership.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMembership_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdMembership_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditMember")
                {
                    LeadId = Convert.ToInt32(e.CommandArgument);
                    MemberCount = MembershipController.GetMembersByLeadId(LeadId).Count;
                    if (MemberCount > 0)
                        Mode = "Update";
                    else
                        Mode = "Insert";

                    BindMembersValues();
                    PanelVisibility(false, true, true);
                }
                else if (e.CommandName == "DeleteMember")
                {
                    try
                    {
                        int LeadId = Convert.ToInt32(e.CommandArgument);
                        new MembershipController().DeleteMember(LeadId);
                        BindGrid();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlGuardian.Visible)
                {
                    txtGuardianName.CssClass = "form-control pnl1text-input";
                    txtRelationshipOfGuardian.CssClass = "form-control pnl1text-input";
                }
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Enter Guardian Details')", true);
                if (ddlPkgtype.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Select Package')", true);
                if (ddlSchemeType.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Select Scheme')", true);
                if ((chkChqPaid.Checked || chkIsPaid.Checked) && txtRFIDNo.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Enter RFID Number')", true);

                if (Mode == "Insert")
                {
                    UpdateLead();
                    InsertMember();
                }
                else
                {
                    UpdateLead();
                    UpdateMember();
                }

                BindGrid();
                ClearValues(sender, e);
                PanelVisibility(true, false, false);
                PanelPaymentVisibility(false, false, false);

                Response.Redirect("./frmAgreementReceipt.aspx?agreementNo=" + txtAgreementNumber.Text);


            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCheckGuardian_Click(object sender, EventArgs e)
        {
            if (txtDOB.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Insert Date of Birth Please ')", true);
                PanelVisibility(false, true, false);
            }
            else
            {
                DateTime dt = (DateTime)Convert.ToDateTime(txtDOB.Text);
                int leadYear = dt.Year;
                int curYear = DateTime.Now.Year;
                if ((curYear - leadYear) < 18)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg_valid", "MessageBox('Message', 'Yes HE/SHE is a Guardian Please Fill The Guardian Details Below... ')", true);
                    pnlGuardian.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg_valid", "MessageBox('Message', 'No, HE/SHE is not Guardia Please GO Ahead.... ')", true);
                    pnlGuardian.Visible = false;
                }
                TimeSpan ts;
                ts = DateTime.Now.Subtract(dt);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    ClearValues(sender, e);
                    PanelVisibility(true, false, false);
                    PanelPaymentVisibility(false, false, false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void Backbutton_Click(object sender, EventArgs e)
        {
            BindMembersValues();
            PanelVisibility(false, true, true);
            PanelPaymentVisibility(false, false, false);
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            if (rdoPayBy.SelectedValue == "1")
            {
                PanelPaymentVisibility(true, true, false);
                PanelVisibility(false, false, false);
                txtBillAmount.Text = txtAmtPyb.Text;

            }
            else if (rdoPayBy.SelectedValue == "2")
            {
                PanelPaymentVisibility(true, false, true);
                PanelVisibility(false, false, false);
                txtAmount.Text = txtAmtPyb.Text;
            }
        }

        protected void ddlSchemeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSchemeType.SelectedIndex != 0)
                {
                    UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
                    lblSchName.Text = "Scheme Name: " + objScheme.schemeName;
                    txtSchJoin.Text = txtActJoin.Text = Convert.ToString(objScheme.joiningFee);
                    txtSchMem.Text = txtActMem.Text = Convert.ToString(objScheme.membershipFee);
                    txtSchAdmin.Text = txtActAdmin.Text = Convert.ToString(objScheme.adminFee);
                    txtSchPTP.Text = txtActPTP.Text = Convert.ToString(objScheme.personalTrainingPack);
                    txtSchSerTax.Text = txtActSerTax.Text = Convert.ToString(objScheme.serviceTaxInPercentage);
                    txtSchTotAmt.Text = txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(objScheme.totalAmount);
                    pnlActPayment.Visible = true;
                }
                else
                {
                    pnlActPayment.Visible = false;
                    foreach (Control ctrl in pnlActPayment.Controls)
                    {
                        if (ctrl is TextBox)
                            ((TextBox)ctrl).Text = "";
                    }
                    lblSchName.Text = txtSchJoin.Text = txtSchMem.Text = txtSchAdmin.Text = txtSchPTP.Text = txtSchTotAmt.Text = txtSchSerTax.Text = "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtActJoin_TextChanged(object sender, EventArgs e)
        {
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
            UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActJoin.Text = Convert.ToString(
                    (objUserTrans.joiningFee > Convert.ToDecimal(txtActJoin.Text))
                    ? objUserTrans.joiningFee : Convert.ToDecimal(txtActJoin.Text)
                    );
            else
                txtActJoin.Text = Convert.ToString(
                    (objScheme.joiningFee > Convert.ToDecimal(txtActJoin.Text))
                    ? objScheme.joiningFee : Convert.ToDecimal(txtActJoin.Text)
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
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
            UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActAdmin.Text = Convert.ToString(
                    (objUserTrans.adminFee > Convert.ToDecimal(txtActAdmin.Text))
                    ? objUserTrans.adminFee : Convert.ToDecimal(txtActAdmin.Text)
                    );
            else
                txtActAdmin.Text = Convert.ToString(
                    (objScheme.adminFee > Convert.ToDecimal(txtActAdmin.Text))
                    ? objScheme.adminFee : Convert.ToDecimal(txtActAdmin.Text)
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
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
            UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActMem.Text = Convert.ToString(
                    (objUserTrans.membershipFee > Convert.ToDecimal(txtActMem.Text))
                    ? objUserTrans.membershipFee : Convert.ToDecimal(txtActMem.Text)
                    );
            else
                txtActMem.Text = Convert.ToString(
                    (objScheme.membershipFee > Convert.ToDecimal(txtActMem.Text))
                    ? objScheme.membershipFee : Convert.ToDecimal(txtActMem.Text)
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
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
            UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            if (objUserTrans != null)
                txtActPTP.Text = Convert.ToString(
                    (objUserTrans.personalTrainingPack > Convert.ToDecimal(txtActPTP.Text))
                    ? objUserTrans.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text)
                    );
            else
                txtActPTP.Text = Convert.ToString(
                    (objScheme.personalTrainingPack > Convert.ToDecimal(txtActPTP.Text))
                    ? objScheme.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text)
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
            UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
            UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
            decimal amt = 0;

            if (objUserTrans != null)
                txtActSerTax.Text = Convert.ToString(
                    (objUserTrans.serviceTaxInPercentage > Convert.ToDecimal(txtActSerTax.Text))
                    ? objUserTrans.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text)
                    );
            else
                txtActSerTax.Text = Convert.ToString(
                    (objScheme.serviceTaxInPercentage > Convert.ToDecimal(txtActSerTax.Text))
                    ? objScheme.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text)
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
                    PackAmt = objPckg.finalAmount;
                    if (ddlSchemeType.Items.Count <= 1)
                        txtAmtPyb.Text = Convert.ToString(objPckg.finalAmount);
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

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            pnlPayment.Visible = true;
            PanelVisibility(false, false, false);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        protected void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            decimal bill = 0;
            bill = Convert.ToDecimal(txtBillAmount.Text) - Convert.ToDecimal(txtAmountPaid.Text);
            txtRemainingAmount.Text = bill.ToString();
        }

        protected void txtADate_TextChanged(object sender, EventArgs e)
        {
            DateTime ac, jn, ed;
            jn = UtillController.ConvertDateTime(txtJDate.Text);
            ac = UtillController.ConvertDateTime(txtADate.Text);
            TimeSpan ts = new TimeSpan(0, 0, 0, 0);
            ts = ac.Subtract(jn);
            int days = 0;
            days = ts.Days;
            if (days > 30)
            {
                ac = jn.AddDays(30);
                txtADate.Text = ac.ToString("dd/MM/yyyy");
            }
            PackageMaster objPckg = PackageMasterController.GetPackageById(Convert.ToInt64(ddlPkgtype.SelectedValue));
            int edate = objPckg.durationInMonths;
            ed = ac.AddMonths(edate);
            ts = new TimeSpan(1, 0, 0, 0);
            ed = ed.Subtract(ts);
            txtEDate.Text = ed.ToString("dd/MM/yyyy");
        }

        protected void rdoPayBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlRfidNo.Visible = false;
            if (rdoPayBy.SelectedValue == "1")
            {
                PanelPaymentVisibility(true, true, false);
                txtBillAmount.Text = txtAmtPyb.Text;
            }
            else if (rdoPayBy.SelectedValue == "2")
            {
                PanelPaymentVisibility(true, false, true);
                txtAmount.Text = txtAmtPyb.Text;
            }
            else
                PanelPaymentVisibility(true, false, false);
        }

        protected void chkIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsPaid.Checked || chkChqPaid.Checked)
                pnlRfidNo.Visible = true;
            else
                pnlRfidNo.Visible = false;
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            try
            {
                grdMembership.DataSource = MembershipController.GetSalesLeads(LoginUser.clubId, txtSearchFirstName.Text, txtSearchLastName.Text, txtSearchMobileNo.Text, txtSearchAgreementNo.Text, SortField, SortDir);
                grdMembership.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PanelVisibility(bool View, bool Edit, bool Detail)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
                pnlDetail.Visible = Detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindMembersValues()
        {
            try
            {
                Lead objMembr = LeadController.GetLeadById(LeadId);
                Club objClub = MembershipController.GetClubsByID(LoginUser.clubId);
                Membership objMember = MembershipController.GetMembersByLeadId(Convert.ToString(LeadId));
                rdoGender.SelectedValue = objMembr.gender;
                txtLName.Text = objMembr.lastName;
                if (objMembr.dateOfBirth == null)
                {
                    txtDOB.Text = "";
                }
                else
                {
                    txtDOB.Text = Convert.ToString(objMembr.dateOfBirth).Substring(0, 10);
                }
                txtBranchName.Text = objClub.clubName;
                txtConsultant.Text = LoginUser.firstName;
                txtFName.Text = objMembr.firstName;
                txtLName.Text = objMembr.lastName;
                txtCity.Text = objMembr.city;
                txtAddress.Text = objMembr.address;
                txtPincode.Text = objMembr.pincode;
                txtMobileNumber.Text = objMembr.mobileNumber;
                txtOtherContact.Text = objMembr.otherContactNumber;
                txtEmail.Text = objMembr.Email;
                txtJDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                pnlCorporate.Visible = (objMembr.leadTypeId == 4) ? true : false;
                if (MemberCount > 0)
                {
                    foreach (Control ctrl in pnlEdit.Controls)
                    {
                        if (LoginUser.userTypeId == 2 || LoginUser.userTypeId == 8 || LoginUser.userTypeId == 6)
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
                    ddlTitle.SelectedValue = objMember.Title;
                    txtMembrNmbr.Text = objMember.membershipUniqueId; ;
                    txtAgreementNumber.Text = objMember.agreementNumber;
                    txtBranchName.Text = objMember.branchName;
                    txtConsultant.Text = objMember.consult;
                    ddlPkgtype.SelectedValue = Convert.ToString(objMember.packageTypeId);
                    
                    if (LoginUser.userTypeId == 2 || LoginUser.userTypeId == 8)
                        ddlPkgtype.Enabled = true;
                    else
                        ddlPkgtype.Enabled = false;
                    BindSchemesType(Convert.ToInt64(ddlPkgtype.SelectedValue));
                    #region Packages
                    PackageMaster objPckg = PackageMasterController.GetPackageById(Convert.ToInt64(ddlPkgtype.SelectedValue));
                    PackAmt = objPckg.finalAmount;

                    #endregion  `
                    #region Schemes
                    ddlSchemeType.SelectedValue = Convert.ToString(objMember.schemeID);
                    if (LoginUser.userTypeId == 2 || LoginUser.userTypeId == 8)
                        ddlSchemeType.Enabled = true;
                    else
                        ddlSchemeType.Enabled = false;
                    pnlActPayment.Visible = true;
                    UserSchemeMaster objScheme = UserSchemeMasterController.GetUserSchemeMasterByID(Convert.ToInt64(ddlSchemeType.SelectedValue));
                    txtSchJoin.Text = Convert.ToString(objScheme.joiningFee);
                    txtSchAdmin.Text = Convert.ToString(objScheme.adminFee);
                    txtSchMem.Text = Convert.ToString(objScheme.membershipFee);
                    txtSchPTP.Text = Convert.ToString(objScheme.personalTrainingPack);
                    txtSchSerTax.Text = Convert.ToString(objScheme.serviceTaxInPercentage);
                    txtSchTotAmt.Text = Convert.ToString(objScheme.totalAmount);
                    #endregion
                    #region Actual
                    lblSchName.Text = ddlSchemeType.SelectedItem.Text;
                    txtActJoin.Text = Convert.ToString(objMember.joiningFee);
                    txtActAdmin.Text = Convert.ToString(objMember.adminFee);
                    txtActMem.Text = Convert.ToString(objMember.membershipFee);
                    txtActPTP.Text = Convert.ToString(objMember.personalTrainingPack);
                    txtActSerTax.Text = Convert.ToString(objMember.serviceTaxInPercentage);
                    txtActTotAmt.Text = txtAmtPyb.Text = Convert.ToString(objMember.finalAmount);
                    foreach (Control ctrl in pnlActPayment.Controls)
                    {
                        if (LoginUser.userTypeId == 2 || LoginUser.userTypeId == 8)
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
                    #endregion
                    DateTime jdate, adate, edate;
                    jdate = (DateTime)objMember.registrationDate;
                    adate = (DateTime)objMember.activationDate;
                    edate = (DateTime)objMember.expiryDate;
                    txtJDate.Text = jdate.ToString("dd/MM/yyyy");
                    txtADate.Text = adate.ToString("dd/MM/yyyy");
                    txtEDate.Text = edate.ToString("dd/MM/yyyy");
                    if (LoginUser.userTypeId == 2 || LoginUser.userTypeId == 8)
                        txtJDate.ReadOnly = txtADate.ReadOnly = false;
                    else
                        txtJDate.ReadOnly = txtADate.ReadOnly = true;
                    string[] sendItems = objMember.sendMaterialsBy.Split(',');
                    for (int i = 0; i < sendItems.Length; i++)
                    {
                        foreach (ListItem item in chkbox1.Items)
                        {
                            if (sendItems[i].Equals(item.Value))
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                    }
                    if ((bool)objMember.isPaid)
                    {
                        rdoPayBy.SelectedValue = Convert.ToString(objMember.payMode);
                        rdoPayBy.Enabled = false;
                        //NextButton.Visible = Backbutton.Visible = false;
                        // btnPayment.Visible = false;

                        if (rdoPayBy.SelectedValue == "1")
                        {
                            PanelPaymentVisibility(true, true, false);
                            txtAmountPaid.Text = Convert.ToString(objMember.amountPaid);
                            txtAmountPaid.ReadOnly = (bool)objMember.isPaid;
                            txtRemainingAmount.Text = Convert.ToString(objMember.remainingAmount);
                            txtBillAmount.Text = Convert.ToString(objMember.finalAmount);
                            btnSubmit.Visible = false;
                            chkIsPaid.Checked = true;
                            chkIsPaid.Enabled = false;
                        }

                        else if (rdoPayBy.SelectedValue == "2")
                        {
                            PanelPaymentVisibility(true, false, true);
                            txtBranchDetails.Text = objMember.Branch;
                            txtBankName.Text = objMember.BankName;
                            txtChkNo.Text = objMember.chequeNumber;
                            //txtAmount.Text = Convert.ToString(objMember.amountPaid);
                            DateTime chqdt = (DateTime)objMember.chequeDate;
                            txtChkDate.Text = chqdt.ToString("dd/MM/yyyy");
                            txtAmount.Text = Convert.ToString(objMember.finalAmount);
                            chkChqPaid.Checked = txtAmount.ReadOnly = true;
                            chkChqPaid.Enabled = false;
                            //btnChqSubmit.Visible = false;
                        }
                        txtRFIDNo.Text = objMember.RFIDCardNumber;
                    }
                    else
                    {
                        rdoPayBy.Enabled = true;
                        Backbutton.Visible = true;
                        //btnPayment.Visible = true;
                        chkIsPaid.Checked = chkChqPaid.Checked = false;
                        chkIsPaid.Enabled = chkChqPaid.Enabled = true;
                    }
                    txtGuardianName.Text = objMember.guardianName;
                    txtRelationshipOfGuardian.Text = objMember.relationshipOfGuardian;
                    txtCorporateId.Text = objMember.corporateId;
                    txtCompanyName.Text = objMember.corporateName;
                    txtEmergencyContact.Text = objMember.emergencyContactNumber;
                    txtEmrgncyCntcNm.Text = objMember.emergencyContactName;
                }
                else
                {
                    txtMembrNmbr.Text = "";
                    txtAgreementNumber.Text = AgreementNumber();
                    foreach (Control ctrl in pnlActPayment.Controls)
                    {
                        if (ctrl is TextBox)
                            ((TextBox)ctrl).ReadOnly = false;
                    }
                    Control[] ctrls = { btnSubmit, Backbutton };
                    ControlsVisible(ctrls, true);
                    txtActTotAmt.ReadOnly = true;
                    ddlSchemeType.Enabled = true;
                    ddlPkgtype.Enabled = true;
                    pnlPayment.Visible = false;
                    ctrls = new Control[] { txtAmountPaid, txtADate, txtJDate };
                    ControlsReadonly(ctrls, false);
                    rdoPayBy.Enabled = true;
                    //txtAmountPaid.ReadOnly = false;
                    //btnSubmit.Visible = true;
                    //btnChqSubmit.Visible = true;
                    //btnPayment.Visible = true;
                }
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

        private void ClearValues(object sender, EventArgs e)
        {
            //txtLName.Text = txtDOB.Text = txtFName.Text =
            // txtLName.Text = txtAddress.Text = txtPincode.Text = txtMobileNumber.Text =
            // txtOtherContact.Text = txtEmail.Text = string.Empty;
            //rdoGender.SelectedValue = "0";

            //txtEmergencyContact.Text = txtEmrgncyCntcNm.Text = txtActJoin.Text = txtActAdmin.Text = txtActMem.Text =
            //    txtActPTP.Text = txtActSerTax.Text = txtActTotAmt.Text = txtDisApply.Text = txtAmtPyb.Text =
            //    txtADate.Text = txtEDate.Text = 
            Control[] ctrls = { pnlPayment, pnlRfidNo, pnlCashPayment, pnlChequePayment, pnlCorporate, pnlEdit, pnlGuardian, pnlJoinDetails };
            ControlsClear(ctrls);
            //txtGuardianName.Text = txtRelationshipOfGuardian.Text = txtGuardianSignature.Text =
            //    txtCorporateId.Text = txtCompanyName.Text = txtADate.Text = txtEDate.Text = "";
            foreach (ListItem item in chkbox1.Items)
                item.Selected = false;
            foreach (ListItem item in rdoPayBy.Items)
                item.Selected = false;
            ddlPkgtype.SelectedIndex = ddlSchemeType.SelectedIndex = 0;
            ddlPkgtype_SelectedIndexChanged(sender, e);
            ddlSchemeType_SelectedIndexChanged(sender, e);
            pnlGuardian.Visible = pnlCorporate.Visible = false;
            chkChqPaid.Checked = chkIsPaid.Checked = false;

        }

        //private void InsertMember()
        //{
        //    try
        //    {
        //        Membership objMember = new Membership();
        //        Club objClub = new Club();
        //        UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
        //        UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
        //        bool paid = false;
        //        objMember.Title = txtTITLE.Text;
        //        objMember.leadId = LeadId;
        //        objMember.clubId = LoginUser.clubId;
        //        objMember.packageTypeId = Convert.ToInt32(ddlPkgtype.SelectedValue);
        //        objMember.packageAmount = PackAmt;
        //        objMember.schemeID = Convert.ToInt32(ddlSchemeType.SelectedValue);
        //        objMember.schemeAmount = Convert.ToDecimal(txtSchTotAmt.Text);
        //        objMember.joiningFee = Convert.ToDecimal((txtActJoin.Text == "") ? objScheme.joiningFee : Convert.ToDecimal(txtActJoin.Text));
        //        objMember.adminFee = Convert.ToDecimal((txtActAdmin.Text == "") ? objScheme.adminFee : Convert.ToDecimal(txtActAdmin.Text));
        //        objMember.membershipFee = Convert.ToDecimal((txtActMem.Text == "") ? objScheme.membershipFee : Convert.ToDecimal(txtActMem.Text));
        //        objMember.personalTrainingPack = Convert.ToDecimal((txtActPTP.Text == "") ? objScheme.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text));
        //        objMember.serviceTaxInPercentage = Convert.ToDecimal((txtActSerTax.Text == "") ? objScheme.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text));
        //        objMember.discountGivenBy = LoginUser.userTypeId;
        //        objMember.finalAmount = Convert.ToDecimal(txtAmtPyb.Text);
        //        objMember.activationDate = UtillController.ConvertDateTime(txtADate.Text);
        //        objMember.registrationDate = UtillController.ConvertDateTime(txtJDate.Text);
        //        objMember.agreementNumber = txtAgreementNumber.Text;
        //        objMember.consult = txtConsultant.Text;
        //        objMember.branchName = txtBranchName.Text;
        //        objMember.expiryDate = UtillController.ConvertDateTime(txtEDate.Text);
        //        string senditems = "";
        //        foreach (ListItem item in chkbox1.Items)
        //        {
        //            if (item.Selected)
        //            {
        //                if (senditems.Equals(""))
        //                {
        //                    senditems = item.Value;
        //                }
        //                else
        //                {
        //                    senditems += "," + item.Value;
        //                }
        //            }
        //        }
        //        objMember.sendMaterialsBy = senditems;
        //        if (rdoPayBy.SelectedValue == "1")
        //        {
        //            objMember.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
        //            objMember.remainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
        //            objMember.chequeDate = null;
        //            objMember.chequeNumber = null;
        //            objMember.BankName = null;
        //            objMember.Branch = null;
        //            paid = chkIsPaid.Checked;
        //            objMember.payMode = (int)EnumPayMode.Cash;
        //        }

        //        else if (rdoPayBy.SelectedValue == "2")
        //        {
        //            objMember.amountPaid = Convert.ToDecimal(txtAmount.Text);
        //            objMember.remainingAmount = 0;
        //            objMember.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
        //            objMember.chequeNumber = txtChkNo.Text;
        //            objMember.BankName = txtBankName.Text;
        //            objMember.Branch = txtBranchDetails.Text;
        //            paid = chkChqPaid.Checked;
        //            objMember.payMode = (int)EnumPayMode.Cheque;
        //        }
        //        else
        //        {
        //            objMember.amountPaid = Convert.ToDecimal(txtAmtPyb.Text);
        //            objMember.remainingAmount = 0;
        //            objMember.chequeDate = null;
        //            objMember.chequeNumber = null;
        //            objMember.BankName = null;
        //            objMember.Branch = null;
        //            objMember.payMode = (int)EnumPayMode.CreditCard;
        //        }

        //        objMember.guardianName = txtGuardianName.Text;
        //        objMember.relationshipOfGuardian = txtRelationshipOfGuardian.Text;
        //        objMember.corporateName = txtCompanyName.Text;
        //        objMember.corporateId = txtCorporateId.Text;
        //        objMember.emergencyContactName = txtEmrgncyCntcNm.Text;
        //        objMember.emergencyContactNumber = txtEmergencyContact.Text;
        //        objMember.isPaid = paid;
        //        objMember.membershipUniqueId = (paid) ? txtMembrNmbr.Text : null;
        //        //objMember.guardianSignature = txtGuardianSignature.Text;
        //        objMember = new MembershipController().InsertMember(objMember);
        //        //Response.Redirect("ManageMembership.aspx");
        //        PanelVisibility(true, false, false);
        //        BindGrid();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        private void InsertMember()
        {
            try
            {
                if (!MembershipController.IsMemberExists(txtAgreementNumber.Text.Trim()))
                {
                    Membership objMember = new Membership();
                    Club objClub = new Club();
                    UserSchemeTransaction objUserTrans = MembershipController.GetTransBySchemeAndUserType(Convert.ToInt64(ddlSchemeType.SelectedValue), LoginUser.userTypeId);
                    UserSchemeMaster objScheme = MembershipController.GetSchemesById(Convert.ToInt64(ddlSchemeType.SelectedValue));
                    bool paid = false;
                    objMember.Title = ddlTitle.SelectedValue;
                    objMember.leadId = LeadId;
                    objMember.clubId = LoginUser.clubId;
                    objMember.packageTypeId = Convert.ToInt32(ddlPkgtype.SelectedValue);
                    objMember.packageAmount = PackAmt;
                    objMember.schemeID = Convert.ToInt32(ddlSchemeType.SelectedValue);
                    objMember.schemeAmount = Convert.ToDecimal(txtSchTotAmt.Text);
                    objMember.joiningFee = Convert.ToDecimal((txtActJoin.Text == "") ? objScheme.joiningFee : Convert.ToDecimal(txtActJoin.Text));
                    objMember.adminFee = Convert.ToDecimal((txtActAdmin.Text == "") ? objScheme.adminFee : Convert.ToDecimal(txtActAdmin.Text));
                    objMember.membershipFee = Convert.ToDecimal((txtActMem.Text == "") ? objScheme.membershipFee : Convert.ToDecimal(txtActMem.Text));
                    objMember.personalTrainingPack = Convert.ToDecimal((txtActPTP.Text == "") ? objScheme.personalTrainingPack : Convert.ToDecimal(txtActPTP.Text));
                    objMember.serviceTaxInPercentage = Convert.ToDecimal((txtActSerTax.Text == "") ? objScheme.serviceTaxInPercentage : Convert.ToDecimal(txtActSerTax.Text));
                    objMember.discountGivenBy = LoginUser.userTypeId;
                    objMember.finalAmount = Convert.ToDecimal(txtAmtPyb.Text);
                    objMember.activationDate = UtillController.ConvertDateTime(txtADate.Text);
                    objMember.registrationDate = UtillController.ConvertDateTime(txtJDate.Text);
                    objMember.agreementNumber = txtAgreementNumber.Text;
                    objMember.consult = txtConsultant.Text;
                    objMember.branchName = txtBranchName.Text;
                    objMember.expiryDate = UtillController.ConvertDateTime(txtEDate.Text);
                    string senditems = "";
                    foreach (ListItem item in chkbox1.Items)
                    {
                        if (item.Selected)
                        {
                            if (senditems.Equals(""))
                            {
                                senditems = item.Value;
                            }
                            else
                            {
                                senditems += "," + item.Value;
                            }
                        }
                    }
                    objMember.sendMaterialsBy = senditems;
                    objMember.amountPaid = objMember.remainingAmount = null;
                    objMember.payMode = null;

                    objMember.guardianName = txtGuardianName.Text;
                    objMember.relationshipOfGuardian = txtRelationshipOfGuardian.Text;
                    objMember.corporateName = txtCompanyName.Text;
                    objMember.corporateId = txtCorporateId.Text;
                    objMember.emergencyContactName = txtEmrgncyCntcNm.Text;
                    objMember.emergencyContactNumber = txtEmergencyContact.Text;
                    objMember.isPaid = paid;
                    objMember.membershipUniqueId = (paid) ? txtMembrNmbr.Text : null;
                    objMember.RFIDCardNumber = paid ? txtRFIDNo.Text : null;
                    objMember = new MembershipController().InsertMember(objMember);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Success', 'Member Added Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Agreement Number Already Exists');", true);
                    PanelVisibility(false, true, true);
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //private void UpdateMember()
        //{
        //    Membership objMember = MembershipController.GetMembersByLeadId(Convert.ToString(LeadId));
        //    bool paid = false;
        //    objMember.Title = txtTITLE.Text;
        //    //objMember.leadId = LeadId;
        //    objMember.clubId = LoginUser.clubId;
        //    objMember.packageTypeId = Convert.ToInt32(ddlPkgtype.SelectedValue);
        //    objMember.packageAmount = PackAmt;
        //    objMember.schemeID = Convert.ToInt32(ddlSchemeType.SelectedValue);
        //    objMember.schemeAmount = Convert.ToDecimal(txtSchTotAmt.Text);
        //    objMember.joiningFee = Convert.ToDecimal(txtActJoin.Text);
        //    objMember.adminFee = Convert.ToDecimal(txtActAdmin.Text);
        //    objMember.membershipFee = Convert.ToDecimal(txtActMem.Text);
        //    objMember.personalTrainingPack = Convert.ToDecimal(txtActPTP.Text);
        //    objMember.discountGivenBy = LoginUser.userTypeId;
        //    objMember.finalAmount = Convert.ToDecimal(txtAmtPyb.Text);
        //    objMember.activationDate = UtillController.ConvertDateTime(txtADate.Text);
        //    objMember.registrationDate = UtillController.ConvertDateTime(txtJDate.Text);
        //    objMember.agreementNumber = txtAgreementNumber.Text;
        //    objMember.consult = txtConsultant.Text;
        //    objMember.branchName = txtBranchName.Text;
        //    objMember.expiryDate = UtillController.ConvertDateTime(txtEDate.Text);
        //    string senditems = "";
        //    foreach (ListItem item in chkbox1.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            if (senditems.Equals(""))
        //            {
        //                senditems = item.Value;
        //            }
        //            else
        //            {
        //                senditems += "," + item.Value;
        //            }
        //        }
        //    }
        //    objMember.sendMaterialsBy = senditems;
        //    if (rdoPayBy.SelectedValue == "1")
        //    {
        //        objMember.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
        //        objMember.remainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
        //        objMember.chequeDate = null;
        //        objMember.chequeNumber = null;
        //        objMember.BankName = null;
        //        objMember.Branch = null;
        //        paid = chkIsPaid.Checked;
        //        objMember.payMode = (int)EnumPayMode.Cash;
        //    }

        //    else if (rdoPayBy.SelectedValue == "2")
        //    {
        //        objMember.amountPaid = Convert.ToDecimal(txtAmount.Text);
        //        objMember.remainingAmount = 0;
        //        objMember.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
        //        objMember.chequeNumber = txtChkNo.Text;
        //        objMember.BankName = txtBankName.Text;
        //        objMember.Branch = txtBranchDetails.Text;
        //        paid = chkChqPaid.Checked;
        //        objMember.payMode = (int)EnumPayMode.Cheque;
        //    }
        //    else
        //    {
        //        objMember.amountPaid = Convert.ToDecimal(txtAmtPyb.Text);
        //        objMember.remainingAmount = 0;
        //        objMember.chequeDate = null;
        //        objMember.chequeNumber = null;
        //        objMember.BankName = null;
        //        objMember.Branch = null;
        //        objMember.payMode = (int)EnumPayMode.CreditCard;
        //    }

        //    objMember.guardianName = txtGuardianName.Text;
        //    objMember.relationshipOfGuardian = txtRelationshipOfGuardian.Text;
        //    objMember.corporateName = txtCompanyName.Text;
        //    objMember.corporateId = txtCorporateId.Text;
        //    objMember.emergencyContactName = txtEmrgncyCntcNm.Text;
        //    objMember.emergencyContactNumber = txtEmergencyContact.Text;
        //    objMember.isPaid = paid;
        //    objMember.membershipUniqueId = (paid) ? txtMembrNmbr.Text : null;
        //    objMember = new MembershipController().UpdateMember(objMember);

        //}
        private void UpdateMember()
        {
            Membership objMember = MembershipController.GetMembersByLeadId(Convert.ToString(LeadId));
            bool paid = false;
            objMember.Title = ddlTitle.SelectedValue;
            //objMember.leadId = LeadId;
            objMember.clubId = LoginUser.clubId;
            objMember.packageTypeId = Convert.ToInt32(ddlPkgtype.SelectedValue);
            objMember.packageAmount = PackAmt;
            objMember.schemeID = Convert.ToInt32(ddlSchemeType.SelectedValue);
            objMember.schemeAmount = Convert.ToDecimal(txtSchTotAmt.Text);
            objMember.joiningFee = Convert.ToDecimal(txtActJoin.Text);
            objMember.adminFee = Convert.ToDecimal(txtActAdmin.Text);
            objMember.membershipFee = Convert.ToDecimal(txtActMem.Text);
            objMember.personalTrainingPack = Convert.ToDecimal(txtActPTP.Text);
            objMember.discountGivenBy = LoginUser.userTypeId;
            objMember.finalAmount = Convert.ToDecimal(txtAmtPyb.Text);
            objMember.activationDate = UtillController.ConvertDateTime(txtADate.Text);
            objMember.registrationDate = UtillController.ConvertDateTime(txtJDate.Text);
            objMember.agreementNumber = txtAgreementNumber.Text;
            objMember.consult = txtConsultant.Text;
            objMember.branchName = txtBranchName.Text;
            objMember.expiryDate = UtillController.ConvertDateTime(txtEDate.Text);
            string senditems = "";
            foreach (ListItem item in chkbox1.Items)
            {
                if (item.Selected)
                {
                    if (senditems.Equals(""))
                    {
                        senditems = item.Value;
                    }
                    else
                    {
                        senditems += "," + item.Value;
                    }
                }
            }
            objMember.sendMaterialsBy = senditems;
            objMember.amountPaid = objMember.remainingAmount = null;
            objMember.payMode = null;
            //if (rdoPayBy.SelectedValue == "1")
            //{
            //    objMember.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
            //    objMember.remainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            //    objMember.chequeDate = null;
            //    objMember.chequeNumber = null;
            //    objMember.BankName = null;
            //    objMember.Branch = null;
            //    paid = chkIsPaid.Checked;
            //    objMember.payMode = (int)EnumPayMode.Cash;
            //}

            //else if (rdoPayBy.SelectedValue == "2")
            //{
            //    objMember.amountPaid = Convert.ToDecimal(txtAmount.Text);
            //    objMember.remainingAmount = 0;
            //    objMember.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
            //    objMember.chequeNumber = txtChkNo.Text;
            //    objMember.BankName = txtBankName.Text;
            //    objMember.Branch = txtBranchDetails.Text;
            //    paid = chkChqPaid.Checked;
            //    objMember.payMode = (int)EnumPayMode.Cheque;
            //}
            //else
            //{
            //    objMember.amountPaid = Convert.ToDecimal(txtAmtPyb.Text);
            //    objMember.remainingAmount = 0;
            //    objMember.chequeDate = null;
            //    objMember.chequeNumber = null;
            //    objMember.BankName = null;
            //    objMember.Branch = null;
            //    objMember.payMode = (int)EnumPayMode.CreditCard;
            //}

            objMember.guardianName = txtGuardianName.Text;
            objMember.relationshipOfGuardian = txtRelationshipOfGuardian.Text;
            objMember.corporateName = txtCompanyName.Text;
            objMember.corporateId = txtCorporateId.Text;
            objMember.emergencyContactName = txtEmrgncyCntcNm.Text;
            objMember.emergencyContactNumber = txtEmergencyContact.Text;
            objMember.isPaid = paid;
            objMember.RFIDCardNumber = paid ? txtRFIDNo.Text : null;
            objMember.membershipUniqueId = (paid) ? txtMembrNmbr.Text : null;

            objMember = new MembershipController().UpdateMember(objMember);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Success', 'Member Updated Successfully')", true);
        }

        private void UpdateLead()
        {
            try
            {
                Lead objLead = LeadController.GetLeadById(LeadId);
                objLead.firstName = txtFName.Text;
                objLead.lastName = txtLName.Text;
                objLead.gender = rdoGender.SelectedValue;
                objLead.dateOfBirth = UtillController.ConvertDateTime(txtDOB.Text);
                objLead.address = txtAddress.Text;
                objLead.pincode = txtPincode.Text;
                objLead.mobileNumber = txtMobileNumber.Text;
                objLead.otherContactNumber = txtOtherContact.Text;
                objLead.Email = txtEmail.Text;
                objLead.city = txtCity.Text;
                objLead.agreementNumber = txtAgreementNumber.Text;
                objLead = new LeadController().UpdateLead(objLead);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //protected void txtDisApply_TextChanged(object sender, EventArgs e)
        //{
        //    //UserSchemeMaster objUsrScm = MembershipController.GetDiscountByUserTypeId(LoginUser.userTypeId);

        //    decimal TotalAmount = 0, maxDiscount = 0;
        //    maxDiscount = (decimal)objUsrScm.discountUpToInPercentage;
        //    if (Convert.ToDecimal(txtDisApply.Text) > maxDiscount)
        //    {
        //        txtDisApply.Text = Convert.ToString(maxDiscount);
        //    }
        //    TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
        //    Decimal discountAmount = 0;
        //    discountAmount = (TotalAmount * Convert.ToDecimal(txtDisApply.Text)) / 100;
        //    txtAmtPyb.Text = (TotalAmount - discountAmount).ToString();

        //}

        public string MembershipNumber()
        {
            //Membership objMembership = MembershipController.GetMemberById(MemberId);
            Membership objMembership = CustomerController.GetMembersByID(MemberId);

            string MNumber = "INT", MemberNo = "";
            MNumber += LoginUser.clubId.ToString().PadLeft(3, '0');
            long i = objMembership.ID;
            MemberNo = i.ToString().PadLeft(6, '0');
            MemberNo = MemberNo.Substring(MemberNo.Length - 6, 6);
            MNumber += MNumber;
            return MNumber;

        }

        public string AgreementNumber()
        {
            Lead objMembr = LeadController.GetLeadById(LeadId);
            string ANumber = "INT", AgrNO = "";
            ANumber += LoginUser.clubId.ToString().PadLeft(3, '0');
            ANumber += DateTime.Now.ToString("yyMM");
            long i = objMembr.ID;
            //i = MembershipController.GetMembersByAgreementNumber().Count + 1;
            AgrNO = i.ToString().PadLeft(4, '0');
            AgrNO = AgrNO.Substring(AgrNO.Length - 4, 4);
            ANumber += AgrNO;
            return ANumber;
        }

        public void PanelPaymentVisibility(bool Payment, bool Cash, bool Cheque)
        {
            pnlPayment.Visible = Payment;
            pnlCashPayment.Visible = Cash;
            pnlChequePayment.Visible = Cheque;
        }

        public void ControlsVisible(Control[] ctrls, bool value)
        {
            foreach (Control ctrl in ctrls)
                ctrl.Visible = value;

        }

        public void ControlsReadonly(Control[] ctrls, bool value)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).ReadOnly = value;
            }
        }

        public void ControlsClear(Control[] ctrls)
        {
            try
            {
                foreach (Control ctrl in ctrls)
                {
                    foreach (Control ctr in ctrl.Controls)
                    {
                        if (ctr is TextBox)
                            ((TextBox)ctr).Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        protected void grdMembership_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Delete = (LinkButton)e.Row.FindControl("lnkBtnDelete");

            if (Delete != null)
            {
                if (LoginUser.userTypeId != 2 || LoginUser.userTypeId != 8)
                {
                    Delete.Visible = false;
                }
            }


        }





    }
}