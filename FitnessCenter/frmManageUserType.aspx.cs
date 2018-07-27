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
    public partial class frmManageUserType : System.Web.UI.Page
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

        public long UserTypeID
        {
            get
            {
                var obj = ViewState["UserTypeID"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserTypeID"] = value;
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

        protected void btnAddUserType_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                PanelVisibility(false, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUserType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUserType.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUserType_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdUserType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditUserType")
                {
                    UserTypeID = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindUserTypeValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteUserType")
                {
                    try
                    {
                        int UserTypeId = Convert.ToInt32(e.CommandArgument);
                        new UserTypeController().DeleteUserType(UserTypeId);
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
                    if (!UserTypeController.IsUserType(txtUserType.Text.Trim()))
                    {
                        InsertUserType();
                        ClearValues();
                        PanelVisibility(true, false);
                        BindGrid();
                    }

                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','UserType already exists..!');", true);
                }

                else
                {
                    UpdateUserType();
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
                grdUserType.DataSource = UserTypeController.GetUserTypes(txtSearchText.Text, SortField, SortDir);
                grdUserType.DataBind();
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

        private void InsertUserType()
        {
            try
            {
                UserTypeMaster objUserTypes = new UserTypeMaster();
                objUserTypes.TypeName = txtUserType.Text;
                objUserTypes = new UserTypeController().InsertUserType(objUserTypes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateUserType()
        {
            try
            {
                UserTypeMaster objUserTypeMaster = UserTypeController.GetUserTypeByID(UserTypeID);
                objUserTypeMaster.TypeName = txtUserType.Text;
                new UserTypeController().UpdateUserType(objUserTypeMaster);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValues()
        {
            txtUserType.Text = string.Empty;
        }
        private void BindUserTypeValues()
        {
            try
            {
                UserTypeMaster objUserTypeMaster = UserTypeController.GetUserTypeByID(UserTypeID);
                txtUserType.Text = objUserTypeMaster.TypeName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}