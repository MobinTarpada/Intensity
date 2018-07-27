using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;

namespace FitnessCenter
{
    public partial class ManageUserScheme : System.Web.UI.Page
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

        public long UserSchemeID
        {
            get
            {
                var obj = ViewState["UserSchemeID"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserSchemeID"] = value;
            }
        }
        public long ClubId
        {
            get
            {
                var obj = ViewState["ClubId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ClubId"] = value;
            }
        }
        public long UserSchemeTransID
        {
            get
            {
                var obj = ViewState["UserSchemeTransID"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserSchemeTransID"] = value;
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
        public string TransMode
        {
            get
            {
                var obj = ViewState["TransMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["TransMode"] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser == null)
                Response.Redirect("~/frmLogin.aspx");

            try
            {
                if (!IsPostBack)
                {
                    PanelVisibility(true, false, false);
                    pnlCancellation.Visible = false;
                    BindGrid();
                    BindPackages();
                    BindUserType();

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

        protected void btnAddUserScheme_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                PanelVisibility(false, true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUserScheme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUserScheme.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUserScheme_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdUserScheme_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditUserScheme")
                {
                    UserSchemeID = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindUserSchemeValues();
                    PanelVisibility(false, true, false);
                }
                else if (e.CommandName == "DeleteUserScheme")
                {
                    try
                    {
                        int userSchemeId = Convert.ToInt32(e.CommandArgument);
                        new UserSchemeMasterController().DeleteUserScheme(userSchemeId);
                        BindGrid();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (e.CommandName == "DetailUserScheme")
                {
                    UserSchemeID = Convert.ToInt64(e.CommandArgument);
                    BindUserSchemeDetails();
                    PanelVisibility(false, false, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlPackageS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPackageS.SelectedIndex == 0)
                lblAdmin.Text = lblJoin.Text = lblMember.Text = lblPTP.Text = lblSerTax.Text = "";
            else
            {
                PackageMaster objPckg = UserSchemeMasterController.GetPackagesByID(Convert.ToInt64(ddlPackageS.SelectedValue));
                //lblJoin.Text = Convert.ToString(objPckg.joiningFee);
                //lblAdmin.Text = Convert.ToString(objPckg.adminFee);
                //lblMember.Text = Convert.ToString(objPckg.membershipFee);
                //lblPTP.Text = Convert.ToString(objPckg.personalTrainingPack);
                //lblSerTax.Text = Convert.ToString(objPckg.serviceTaxInPercentage);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAllowCancelation.Checked && txtCanclDays.Text.Equals(""))
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Please Enter Cancel Days');", true);
                else
                {
                    if (Mode == "Insert")
                        InsertUserScheme();

                    else
                        UpdateUserScheme();

                    ClearValues();
                    PanelVisibility(true, false, false);
                    pnlCancellation.Visible = false;
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                PanelVisibility(true, false, false);
                pnlCancellation.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSaveUserSchemeDetail_Click(object sender, EventArgs e)
        {
            if (TransMode == "Insert")
                InsertUserSchemeTrans();
            else
                UpdateUserSchemeTrans();
            ClearTransValues();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearTransValues();
        }

        protected void btnAddTransactions_Click(object sender, EventArgs e)
        {
            TransMode = "Insert";
            PanelTransactionVisibility(false, true);
            btnDetailBack.Visible = false;
        }

        protected void grdUserSchemeTrans_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditUserSchemeTrans")
                {
                    UserSchemeTransID = Convert.ToInt32(e.CommandArgument);
                    TransMode = "Update";
                    BindUserSchemeTransValues();
                }
                else if (e.CommandName == "DeleteUserSchemeTrans")
                {
                    int transId = Convert.ToInt32(e.CommandArgument);
                    new UserSchemeMasterController().DeleteUserSchemeTransaction(transId);
                    BindTransGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDetailBack_Click(object sender, EventArgs e)
        {
            PanelVisibility(true, false, false);
        }

        protected void grdUserSchemeTrans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUserSchemeTrans.PageIndex = e.NewPageIndex;
                BindTransGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtService_TextChanged(object sender, EventArgs e)
        {
            decimal amt = 0;

            decimal joinFee = 0, adminFee = 0, MemFee = 0, PTFee = 0, tax = 0;

            if (txtJoinFee.Text.Trim() == "")
                joinFee = 0;
            else
                joinFee = Convert.ToDecimal(txtJoinFee.Text.Trim());
            if (txtAdminFee.Text.Trim() == "")
                adminFee = 0;
            else
                adminFee = Convert.ToDecimal(txtAdminFee.Text.Trim());
            if (txtPersTraining.Text == "")
                PTFee = 0;
            else
                PTFee = Convert.ToDecimal(txtPersTraining.Text.Trim());
            if (txtMemFee.Text == "")
                MemFee = 0;
            else
                MemFee = Convert.ToDecimal(txtMemFee.Text.Trim());
            if (txtService.Text == "")
                tax = 0;
            else
                tax = Convert.ToDecimal(txtService.Text.Trim());


            amt = joinFee + adminFee + PTFee + MemFee;
            txtTotAmt.Text = Convert.ToString(((amt * tax) / 100) + amt);
        }

        protected void txtSTax_TextChanged(object sender, EventArgs e)
        {
            decimal amt = 0;
            amt = Convert.ToDecimal(txtJFee.Text) + Convert.ToDecimal(txtAFee.Text) + Convert.ToDecimal(txtMmbrFee.Text) + Convert.ToDecimal(txtPTFee.Text);
            txtTAmt.Text = Convert.ToString(((amt * Convert.ToDecimal(txtSTax.Text)) / 100) + amt);
        }

        protected void chkAllowCancelation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowCancelation.Checked)
                pnlCancellation.Visible = true;
            else
                pnlCancellation.Visible = false;
        }
        #endregion

        #region Methods

        private void BindGrid()
        {
            try
            {
                grdUserScheme.DataSource = UserSchemeMasterController.GetUserSchemeMaster(txtSearchText.Text, txtSearchSchmName.Text, SortField, SortDir, LoginUser.ClubId);
                grdUserScheme.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindTransGrid()
        {
            try
            {
                grdUserSchemeTrans.DataSource = UserSchemeMasterController.GetTransactionBySchemeID(UserSchemeID);
                grdUserSchemeTrans.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void PanelVisibility(bool View, bool Edit, bool Details)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
                pnlDetail.Visible = Details;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void PanelTransactionVisibility(bool View, bool Edit)
        {
            pnlTransView.Visible = View;
            pnlTransEdit.Visible = Edit;
        }
        private void BindPackages()
        {
            try
            {
                ClubId = LoginUser.ClubId;
                ddlPackageS.DataSource = UserSchemeMasterController.GetPackages(ClubId);
                ddlPackageS.DataTextField = "packageName";
                ddlPackageS.DataValueField = "ID";
                ddlPackageS.DataBind();
                ddlPackageS.Items.Insert(0, new ListItem("Select Packages", "0"));

                ddlPckgName.DataSource = UserSchemeMasterController.GetPackages(ClubId);
                ddlPckgName.DataTextField = "packageName";
                ddlPckgName.DataValueField = "ID";
                ddlPckgName.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindUserType()
        {
            try
            {
                ddlUsers.DataSource = UserSchemeMasterController.GetUserTypes();
                ddlUsers.DataTextField = "type";
                ddlUsers.DataValueField = "ID";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, new ListItem("Select Users", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void InsertUserScheme()
        {
            try
            {
                SchemeMaster objUserScheme = new SchemeMaster();

                objUserScheme.PackageId = Convert.ToInt64(ddlPackageS.SelectedValue);
                objUserScheme.SchemeName = txtUserschemeName.Text;
                objUserScheme.JoiningFee = Convert.ToDecimal(txtJoinFee.Text);
                objUserScheme.AdminFee = Convert.ToDecimal(txtAdminFee.Text);
                objUserScheme.MemberFee = Convert.ToDecimal(txtMemFee.Text);
                objUserScheme.PTFee = Convert.ToDecimal(txtPersTraining.Text);
                objUserScheme.SGST = Convert.ToDecimal(txtService.Text);
                objUserScheme.CGST = Convert.ToDecimal(txtService.Text);
                objUserScheme.TotalAmount = Convert.ToDecimal(txtTotAmt.Text);
                objUserScheme.AdditionalExpense = Convert.ToDecimal(0);
                objUserScheme.StartDate = UtillController.ConvertDateTime(txtStrDate.Text);
                objUserScheme.EndDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objUserScheme.StartTime = ddlStartTime.SelectedValue;
                objUserScheme.EndTime = ddlEndTime.SelectedValue;
                if (txtCanclDays.Text.Equals(""))
                    objUserScheme.CancelDays = null;
                else
                    objUserScheme.CancelDays = Convert.ToInt32(txtCanclDays.Text);
                if (txtDwnGrdDays.Text.Equals(""))
                    objUserScheme.DowngradeDays = null;
                else
                    objUserScheme.DowngradeDays = Convert.ToInt32(txtDwnGrdDays.Text);
                if (txtUpgrdDays.Text.Equals(""))
                    objUserScheme.UpgradeDays = null;
                else
                    objUserScheme.UpgradeDays = Convert.ToInt32(txtUpgrdDays.Text);
                objUserScheme = new UserSchemeMasterController().InsertUserScheme(objUserScheme);

                if (chkAllowCancelation.Checked)
                {
                    CancellationMaster objCancel = new CancellationMaster();
                    objCancel.schemeId = objUserScheme.ID;
                    objCancel.joiningFee = chkJoining.Checked;
                    objCancel.adminFee = chkAdmin.Checked;
                    objCancel.membershipFee = chkMembership.Checked;
                    objCancel.personalTrainingPack = chkPTP.Checked;
                    objCancel = new UserSchemeMasterController().InsertCancelMaster(objCancel);
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Saved');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateUserScheme()
        {
            try
            {
                SchemeMaster objUserScheme = UserSchemeMasterController.GetUserSchemeMasterByID(UserSchemeID);
                objUserScheme.PackageId = Convert.ToInt64(ddlPackageS.SelectedValue);
                objUserScheme.SchemeName = txtUserschemeName.Text;
                objUserScheme.JoiningFee = Convert.ToDecimal(txtJoinFee.Text);
                objUserScheme.AdminFee = Convert.ToDecimal(txtAdminFee.Text);
                objUserScheme.MemberFee = Convert.ToDecimal(txtMemFee.Text);
                objUserScheme.PTFee = Convert.ToDecimal(txtPersTraining.Text);
                objUserScheme.SGST = Convert.ToDecimal(txtService.Text);
                objUserScheme.CGST = Convert.ToDecimal(txtService.Text);
                objUserScheme.TotalAmount = Convert.ToDecimal(txtTotAmt.Text);
                objUserScheme.AdditionalExpense = Convert.ToDecimal(0);
                objUserScheme.StartDate = UtillController.ConvertDateTime(txtStrDate.Text);
                objUserScheme.EndDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objUserScheme.StartTime = ddlStartTime.SelectedValue;
                objUserScheme.EndTime = ddlEndTime.SelectedValue;
                if (txtCanclDays.Text.Equals(""))
                    objUserScheme.CancelDays = null;
                else
                    objUserScheme.CancelDays = Convert.ToInt32(txtCanclDays.Text);
                objUserScheme.DowngradeDays = Convert.ToInt32(txtDwnGrdDays.Text);
                objUserScheme.UpgradeDays = Convert.ToInt32(txtUpgrdDays.Text);
                new UserSchemeMasterController().UpdateUserScheme(objUserScheme);

                if (chkAllowCancelation.Checked)
                {
                    CancellationMaster objCancel = UserSchemeMasterController.GetCancellationBySchemeId(UserSchemeID);
                    if (objCancel != null)
                    {
                        objCancel.schemeId = UserSchemeID;
                        objCancel.joiningFee = chkJoining.Checked;
                        objCancel.adminFee = chkAdmin.Checked;
                        objCancel.membershipFee = chkMembership.Checked;
                        objCancel.personalTrainingPack = chkPTP.Checked;
                        new UserSchemeMasterController().UpdateCancelMaster(objCancel);
                    }
                    else
                    {
                        objCancel = new CancellationMaster();
                        objCancel.schemeId = UserSchemeID;
                        objCancel.joiningFee = chkJoining.Checked;
                        objCancel.adminFee = chkAdmin.Checked;
                        objCancel.membershipFee = chkMembership.Checked;
                        objCancel.personalTrainingPack = chkPTP.Checked;
                        new UserSchemeMasterController().InsertCancelMaster(objCancel);
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Updated');", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void InsertUserSchemeTrans()
        {
            try
            {
                int valid = 0;
                valid = UserSchemeMasterController.GetTransactionBySchemeIDAndUserType(UserSchemeID, Convert.ToInt64(ddlUsers.SelectedValue)).Count;
                if (valid > 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Transaction of same UserType Already Exists.');", true);
                else
                {
                    UserSchemeTransaction objscmTran = new UserSchemeTransaction();
                    objscmTran.userSchemeId = UserSchemeID;
                    objscmTran.joiningFee = Convert.ToDecimal(txtJFee.Text);
                    objscmTran.adminFee = Convert.ToDecimal(txtAFee.Text);
                    objscmTran.membershipFee = Convert.ToDecimal(txtMmbrFee.Text);
                    objscmTran.personalTrainingPack = Convert.ToDecimal(txtPTFee.Text);
                    objscmTran.serviceTaxInPercentage = Convert.ToDecimal(txtSTax.Text);
                    objscmTran.totalAmount = Convert.ToDecimal(txtTAmt.Text);
                    objscmTran.userTypeId = Convert.ToInt32(ddlUsers.SelectedValue);
                    objscmTran = new UserSchemeMasterController().InsertUserSchemeTransaction(objscmTran);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateUserSchemeTrans()
        {
            try
            {
                UserSchemeTransaction objUserSchTrans = UserSchemeMasterController.GetUserSchemeTransactionByID(UserSchemeTransID);
                objUserSchTrans.userSchemeId = UserSchemeID;
                objUserSchTrans.joiningFee = Convert.ToDecimal(txtJFee.Text);
                objUserSchTrans.adminFee = Convert.ToDecimal(txtAFee.Text);
                objUserSchTrans.membershipFee = Convert.ToDecimal(txtMmbrFee.Text);
                objUserSchTrans.personalTrainingPack = Convert.ToDecimal(txtPTFee.Text);
                objUserSchTrans.serviceTaxInPercentage = Convert.ToDecimal(txtSTax.Text);
                objUserSchTrans.totalAmount = Convert.ToDecimal(txtTAmt.Text);
                objUserSchTrans.userTypeId = Convert.ToInt32(ddlUsers.SelectedValue);
                objUserSchTrans = new UserSchemeMasterController().UpdateUserSchemeTransaction(objUserSchTrans);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ClearValues()
        {
            ddlPackageS.SelectedIndex = 0;
            chkAllowCancelation.Checked = false;
            // txtUserschemeName.Text = txtAdditionalExpense.Text = string.Empty;
            foreach (Control ctrl in pnlEdit.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
            }
        }
        private void ClearTransValues()
        {
            ddlUsers.SelectedIndex = 0;
            txtJFee.Text = "";
            txtAFee.Text = "";
            txtMmbrFee.Text = "";
            txtPTFee.Text = "";
            txtSTax.Text = "";
            PanelTransactionVisibility(true, false);
            BindTransGrid();
            btnDetailBack.Visible = true;
        }
        private void BindUserSchemeValues()
        {
            try
            {
                SchemeMaster objUserScheme = UserSchemeMasterController.GetUserSchemeMasterByID(UserSchemeID);
                ddlPackageS.SelectedValue = objUserScheme.PackageId.ToString();
                txtUserschemeName.Text = objUserScheme.SchemeName;
                txtJoinFee.Text = Convert.ToString(objUserScheme.JoiningFee);
                txtMemFee.Text = Convert.ToString(objUserScheme.MemberFee);
                txtAdminFee.Text = Convert.ToString(objUserScheme.AdminFee);
                txtPersTraining.Text = Convert.ToString(objUserScheme.PTFee);
                txtService.Text = Convert.ToString(objUserScheme.SGST);
                txtService.Text = Convert.ToString(objUserScheme.CGST);
                txtTotAmt.Text = Convert.ToString(objUserScheme.TotalAmount);
                txtAdditionalExpense.Text = Convert.ToString(objUserScheme.AdditionalExpense);
                txtDwnGrdDays.Text = Convert.ToString(objUserScheme.DowngradeDays);
                txtUpgrdDays.Text = Convert.ToString(objUserScheme.UpgradeDays);
                txtStrDate.Text = ((DateTime)objUserScheme.StartDate).ToString("dd/MM/yyyy");
                txtEndDate.Text = ((DateTime)objUserScheme.EndDate).ToString("dd/MM/yyyy");
                ddlStartTime.SelectedValue = Convert.ToString(objUserScheme.StartTime);
                ddlEndTime.SelectedValue = Convert.ToString(objUserScheme.EndTime);
                if (chkAllowCancelation.Checked)
                {
                    pnlCancellation.Visible = true;
                    txtCanclDays.Text = Convert.ToString(objUserScheme.CancelDays);
                    CancellationMaster objCancel = UserSchemeMasterController.GetCancellationBySchemeId(UserSchemeID);
                    chkJoining.Checked = (bool)objCancel.joiningFee;
                    chkAdmin.Checked = (bool)objCancel.adminFee;
                    chkMembership.Checked = (bool)objCancel.membershipFee;
                    chkPTP.Checked = (bool)objCancel.personalTrainingPack;
                }
                else
                {
                    pnlCancellation.Visible = false;
                    txtCanclDays.Text = "";
                    chkJoining.Checked = chkAdmin.Checked = chkMembership.Checked = chkPTP.Checked = false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindUserSchemeTransValues()
        {
            PanelTransactionVisibility(false, true);
            UserSchemeTransaction objUserSchTrans = UserSchemeMasterController.GetUserSchemeTransactionByID(UserSchemeTransID);
            ddlUsers.SelectedValue = Convert.ToString(objUserSchTrans.userTypeId);
            txtJFee.Text = Convert.ToString(objUserSchTrans.joiningFee);
            txtAFee.Text = Convert.ToString(objUserSchTrans.adminFee);
            txtMmbrFee.Text = Convert.ToString(objUserSchTrans.membershipFee);
            txtPTFee.Text = Convert.ToString(objUserSchTrans.personalTrainingPack);
            txtSTax.Text = Convert.ToString(objUserSchTrans.serviceTaxInPercentage);
            txtTAmt.Text = Convert.ToString(objUserSchTrans.totalAmount);
        }
        private void BindUserSchemeDetails()
        {
            try
            {
                PanelTransactionVisibility(true, false);
                #region UserScheme
                SchemeMaster objUserScheme = UserSchemeMasterController.GetUserSchemeMasterByID(UserSchemeID);
                ddlPckgName.SelectedValue = Convert.ToString(objUserScheme.PackageId);
                txtSchemeName.Text = objUserScheme.SchemeName;
                lblSchJoin.Text = "Joining Fee:- " + Convert.ToString(objUserScheme.JoiningFee);
                lblSchAdmin.Text = "Admin Fee:- " + Convert.ToString(objUserScheme.AdminFee);
                lblSchMem.Text = "Membership Fee:- " + Convert.ToString(objUserScheme.MemberFee);
                lblSchPers.Text = "Personal Traning Fee:- " + Convert.ToString(objUserScheme.PTFee);
                lblSchService.Text = "ServiceTax:- " + Convert.ToString(objUserScheme.SGST);
                lblSchService.Text = "ServiceTax:- " + Convert.ToString(objUserScheme.CGST);
                #endregion

                #region Packages
                PackageMaster objPckMst = UserSchemeMasterController.GetPackagesByID(Convert.ToInt64(ddlPckgName.SelectedValue));
                //lblAdminFee.Text = "Admin Fee:- " + Convert.ToString(objPckMst.adminFee);
                //lblJoinFee.Text = "Joining Fee:- " + Convert.ToString(objPckMst.joiningFee);
                //lblMembrFee.Text = "Membership Fee:- " + Convert.ToString(objPckMst.membershipFee);
                //lblPrsnltrngFee.Text = "Personal Traning Fee:- " + Convert.ToString(objPckMst.personalTrainingPack);
                //lblSrvcTax.Text = "ServiceTax:- " + Convert.ToString(objPckMst.serviceTaxInPercentage);
                #endregion
                BindTransGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        protected void grdUserScheme_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            var Details = (LinkButton)e.Row.FindControl("lnkBtnDetail");
            var Delete = (LinkButton)e.Row.FindControl("lnkBtnDelete");

            if (Edit != null && Details != null && Delete != null)
            {
                if (LoginUser.UserTypeId != 2 && LoginUser.UserTypeId != 8)
                {
                    Edit.Visible = false;
                    Details.Visible = false;
                    Delete.Visible = false;
                }
            }
        }

        protected void txtTotAmt_TextChanged(object sender, EventArgs e)
        {
            decimal amt = 0;


            decimal joinFee = 0, adminFee = 0, MemFee = 0, PTFee = 0, tax = 0, TaxAmt = 0;

            if (txtService.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Please Enter ServiceTax First or Atleast '0' ');", true);
                txtTotAmt.Text = "";
                return;
            }
            else
            {
                if (txtJoinFee.Text.Trim() == "")
                    joinFee = 0;
                else
                    joinFee = Convert.ToDecimal(txtJoinFee.Text.Trim());
                if (txtAdminFee.Text.Trim() == "")
                    adminFee = 0;
                else
                    adminFee = Convert.ToDecimal(txtAdminFee.Text.Trim());
                if (txtPersTraining.Text == "")
                    PTFee = 0;
                else
                    PTFee = Convert.ToDecimal(txtPersTraining.Text.Trim());
                amt = Convert.ToDecimal(txtTotAmt.Text.Trim());

                if (txtService.Text == "")
                    tax = 0;
                else
                    tax = Convert.ToDecimal(txtService.Text.Trim());

                TaxAmt = Math.Round((amt * tax) / (tax + 100));
                taxAmt.Text = "CGST: " + Convert.ToString(Math.Round(TaxAmt / 2));
                taxAmt1.Text = "SGST: " + Convert.ToString(Math.Round(TaxAmt / 2));
                MemFee = Math.Round((amt) - (TaxAmt));
                txtMemFee.Text = Convert.ToString(MemFee - joinFee - adminFee - PTFee);
            }
        }

    }
}





