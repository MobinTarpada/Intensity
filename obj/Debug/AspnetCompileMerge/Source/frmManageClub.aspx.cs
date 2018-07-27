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
    public partial class frmManageClub : System.Web.UI.Page
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
                var obj = ViewState["ClubId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ClubId"] = value;
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
            try
            {
                if (!IsPostBack)
                {
                    PanelVisibility(true, false);
                    BindGrid();
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

        protected void btnAddClub_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                txtEmail.Enabled = txtUserName.Enabled = true;
                PanelVisibility(false, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdClubs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdClubs.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdClubs_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdClubs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditClub")
                {
                    UserId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindUserValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteClub")
                {
                    try
                    {
                        int clubId = Convert.ToInt32(e.CommandArgument);
                        new ClubController().DeleteClub(clubId);
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
                if (Mode == "Insert")
                {
                    //if (!UsersController.IsEmailExists(txtEmail.Text.Trim()))
                    //{
                        if (!UsersController.IsUserNameExists(txtUserName.Text.Trim()))
                        {
                            InsertClub();
                            ClearValues();
                            PanelVisibility(true, false);
                            BindGrid();
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','Username already exists..!');", true);
                    }
                    //else
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','Email already exists..!');", true);
                //}

                else
                {
                    UpdateClub();
                    ClearValues();
                    PanelVisibility(true, false);
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
                grdClubs.DataSource = ClubController.GetClubs(txtSearchText.Text, SortField, SortDir);
                grdClubs.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void InsertClub()
        {
            try
            {
                Club objClub = new Club();
                objClub.clubName = txtClubName.Text;
                objClub.isActive = chkIsActive.Checked;
                objClub = new ClubController().InsertClub(objClub);

                User objUser = new User();
                
                objUser.firstName = txtFirstName.Text;
                objUser.lastName = txtLastName.Text;
                objUser.mobileNumber = txtMobileNumber.Text;
                objUser.clubId = objClub.ID;
                objUser.userTypeId = (int)EnumUserTypeMaster.Admin;
                objUser.email = txtEmail.Text;
                objUser.username = txtUserName.Text;
                objUser.password = txtPassword.Text;
                objUser.address = txtAdress.Text;
                objUser.isActive = chkIsActive.Checked;
                objUser = new ClubController().InsertUser(objUser);

                var lstPageMaster = UsersController.GetPagePermissions_Result(0);
                foreach (var objPageMaster in lstPageMaster)
                {
                    AccessMaster objAccessMaster = new AccessMaster();
                    objAccessMaster.userId = objUser.ID;
                    objAccessMaster.clubId = objClub.ID;
                    objAccessMaster.pageId = objPageMaster.ID;
                    objAccessMaster.updateBy = LoginUser.ID;
                    new UsersController().InsertAccessMaster(objAccessMaster);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateClub()
        {
            try
            {
                User objUser = UsersController.GetUserByIDForClubs(UserId);

                // update Club detail
                Club objClub = ClubController.GetClubsByID(objUser.clubId);
                objClub.clubName = txtClubName.Text;
                objClub.isActive = chkIsActive.Checked;
                new ClubController().UpdateClub(objClub);

                //update User details
                objUser.firstName = txtFirstName.Text;
                objUser.lastName = txtLastName.Text;
                objUser.mobileNumber = txtMobileNumber.Text;
                objUser.email = txtEmail.Text;
                objUser.username = txtUserName.Text;
                objUser.password = txtPassword.Text;
                objUser.address = txtAdress.Text;
                objUser.isActive = chkIsActive.Checked;
                
                new UsersController().UpdateUser(objUser);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValues()
        {
            txtFirstName.Text = txtLastName.Text = txtClubName.Text = txtEmail.Text = txtAdress.Text = txtMobileNumber.Text = txtUserName.Text = string.Empty;
            txtPassword.Attributes.Add("Value", string.Empty);

        }
        private void BindUserValues()
        {
            try
            {
                User objUser = UsersController.GetUserByIDForClubs(UserId);
                //Club objClub = ClubController.GetClubsByID(objUser.clubId);
                
                txtFirstName.Text = objUser.firstName;
                txtLastName.Text = objUser.lastName;
                txtEmail.Text = objUser.email;
                txtMobileNumber.Text = objUser.mobileNumber;
                txtUserName.Text = objUser.username;
                txtEmail.Enabled = txtUserName.Enabled = false;
                txtAdress.Text = objUser.address;
                txtPassword.Attributes.Add("Value", objUser.password);
                txtClubName.Text = objUser.Club.clubName;
                chkIsActive.Checked = objUser.isActive;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}