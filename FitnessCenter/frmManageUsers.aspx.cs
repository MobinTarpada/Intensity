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
    public partial class frmManageUsers : System.Web.UI.Page
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
            if (LoginUser == null)
                Response.Redirect("~/frmLogin.aspx");

            try
            {

                if (!IsPostBack)
                {
                    PanelVisibility(true, false);
                    BindGrid();
                    BindRoles();
                }
                else
                {
                    if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
                    {
                        txtPassword.Attributes["value"] = txtPassword.Text;
                    }
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                txtUsername.ReadOnly = false;
                Mode = "Insert";
                ClearValues();
                PanelVisibility(false, true);
                BindPagePermissions(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUsers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUsers_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditUser")
                {
                    txtUsername.ReadOnly = true;
                    UserId = Convert.ToInt32(e.CommandArgument);
                    BindPagePermissions(UserId);
                    Mode = "Update";
                    BindUserValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteUser")
                {
                    try
                    {
                        int userId = Convert.ToInt32(e.CommandArgument);
                        new UsersController().DeleteUser(userId);
                        BindGrid();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "MessageBox('Message','User Deleted Successfully');", true);
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
                if (ddlRole.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Role For User');", true);
                }
                else
                {
                    if (Mode == "Insert")
                    {
                        if (!UsersController.IsUserNameExists(txtUsername.Text.Trim(),txtMobileNumber.Text.Trim()))
                        {
                            InsertUser();
                            ClearValues();
                            PanelVisibility(true, false);
                            BindGrid();
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "MessageBox('Message','User Saved Successfully');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','Username already exists..!');", true);
                            //PanelVisibility(false, true);
                        }
                    }
                    else
                    {

                        UpdateUser();
                        ClearValues();
                        PanelVisibility(true, false);
                        BindGrid();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "MessageBox('Message','User Updated Successfully');", true);
                    }


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
                PanelVisibility(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Methods

        private void BindGrid()
        {
            try
            {
                grdUsers.DataSource = UsersController.GetUsers(LoginUser.ClubId, LoginUser.ID, LoginUser.UserTypeId, txtSearchText.Text, SortField, SortDir);
                grdUsers.DataBind();
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindPagePermissions(long UserIds)
        {
            try
            {
                grdManagePermissions.DataSource = UsersController.GetPagePermissions_Result(UserIds);
                grdManagePermissions.DataBind();
                int a = 0, b = 0;
                a = grdManagePermissions.Rows.Count;
                CheckBox chkBoxHeader = (CheckBox)grdManagePermissions.HeaderRow.FindControl("chkboxSelectAll");
                foreach (GridViewRow row in grdManagePermissions.Rows)
                {
                    CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkPermissions");
                    if (ChkBoxRows.Checked)
                        b++;
                }
                if (a == b)
                {
                    chkBoxHeader.Checked = true;
                }
                else
                    chkBoxHeader.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void PanelVisibility(bool View, bool Edit)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void BindRoles()
        {
            try
            {
                ddlRole.DataSource = UsersController.GetUserTypesWithoutAdmin();
                ddlRole.DataTextField = "TypeName";
                ddlRole.DataValueField = "ID";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem("Select Role", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertUser()
        {
            try
            {
                User objUser = new User();
                objUser.ClubId = LoginUser.ClubId;
                objUser.FirstName = txtFirstName.Text;
                objUser.LastName = txtLastName.Text;
                objUser.UserTypeId = Convert.ToInt64(ddlRole.SelectedValue);
                objUser.UserName = txtUsername.Text;
                objUser.Email = txtEmail.Text;
                objUser.Password = txtPassword.Text;
                objUser.Address1 = txtAddress.Text;
                objUser.Mobile = txtMobileNumber.Text;
                objUser.isActive = chkIsActive.Checked;
                objUser = new UsersController().InsertUser(objUser);

                foreach (GridViewRow gr in grdManagePermissions.Rows)
                {
                    //hdnFldPageId,chkPermissions
                    HiddenField hdnFldPageId = (HiddenField)gr.FindControl("hdnFldPageId");
                    CheckBox chkPermissions = (CheckBox)gr.FindControl("chkPermissions");

                    if (chkPermissions.Checked)
                    {
                        AccessMaster objAccessMaster = new AccessMaster();
                        objAccessMaster.clubId = LoginUser.ClubId;
                        objAccessMaster.userId = objUser.ID;
                        objAccessMaster.updateBy = LoginUser.ID;
                        objAccessMaster.pageId = Convert.ToInt64(hdnFldPageId.Value);
                        new UsersController().InsertAccessMaster(objAccessMaster);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateUser()
        {
            try
            {
                User objUser = UsersController.GetUserByID(UserId);
                Lead objLead = LeadController.GetLeadByMobile(objUser.Mobile);



                if (objUser.UserTypeId == 7)
                {
                    objLead.mobileNumber = txtMobileNumber.Text;
                    objLead.firstName = txtFirstName.Text;
                    objLead.lastName = txtLastName.Text;
                    objLead.Email = txtEmail.Text;
                    objLead.address = txtAddress.Text;
                }
                objUser.FirstName = txtFirstName.Text;
                objUser.LastName = txtLastName.Text;
                objUser.UserTypeId = Convert.ToInt64(ddlRole.SelectedValue);
                //objUser.username = txtUsername.Text;
                objUser.Email = txtEmail.Text;
                objUser.Mobile = txtMobileNumber.Text;
                objUser.Password = txtPassword.Text;
                objUser.Address1 = txtAddress.Text;
                objUser.isActive = chkIsActive.Checked;

                objUser = new UsersController().UpdateUser(objUser);

                new UsersController().DeleteAccessMasterByUser(UserId);

                foreach (GridViewRow gr in grdManagePermissions.Rows)
                {
                    //hdnFldPageId,chkPermissions
                    HiddenField hdnFldPageId = (HiddenField)gr.FindControl("hdnFldPageId");
                    CheckBox chkPermissions = (CheckBox)gr.FindControl("chkPermissions");

                    if (chkPermissions.Checked)
                    {
                        AccessMaster objAccessMaster = new AccessMaster();
                        objAccessMaster.clubId = LoginUser.ClubId;
                        objAccessMaster.userId = objUser.ID;
                        objAccessMaster.updateBy = LoginUser.ID;
                        objAccessMaster.pageId = Convert.ToInt64(hdnFldPageId.Value);
                        objAccessMaster = new UsersController().InsertAccessMaster(objAccessMaster);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValues()
        {
            txtFirstName.Text = txtLastName.Text = txtPassword.Text = txtEmail.Text = txtUsername.Text = txtMobileNumber.Text = txtAddress.Text = string.Empty;
            ddlRole.SelectedValue = "0"; chkIsActive.Checked = false;
            txtPassword.Attributes["value"] = txtPassword.Text;
            msg.Text = "";
        }
        private void BindUserValues()
        {
            try
            {
                User objUser = UsersController.GetUserByID(UserId);
                txtFirstName.Text = objUser.FirstName;
                txtLastName.Text = objUser.LastName;
                ddlRole.SelectedValue = objUser.UserTypeId.ToString();
                txtUsername.Text = objUser.UserName;
                txtPassword.Attributes.Add("Value", objUser.Password);
                txtEmail.Text = objUser.Email;
                txtMobileNumber.Text = objUser.Mobile;
                txtAddress.Text = objUser.Address1;
                chkIsActive.Checked = objUser.isActive;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBoxHeader = (CheckBox)grdManagePermissions.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow row in grdManagePermissions.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkPermissions");
                if (chkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void chkPermissions_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int a = 0, b = 0;
                a = grdManagePermissions.Rows.Count;
                CheckBox chkBoxHeader = (CheckBox)grdManagePermissions.HeaderRow.FindControl("chkboxSelectAll");
                foreach (GridViewRow row in grdManagePermissions.Rows)
                {
                    CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkPermissions");
                    if (ChkBoxRows.Checked)
                        b++;
                }
                if (a == b)
                {
                    chkBoxHeader.Checked = true;
                }
                else
                    chkBoxHeader.Checked = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}