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
    public partial class ManagePackage : System.Web.UI.Page
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

        public long PackageId
        {
            get
            {
                var obj = ViewState["PackageId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["PackageId"] = value;
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
        protected void btnAddPackage_Click(object sender, EventArgs e)
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
        protected void grdPackages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdPackages.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void grdPackages_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void grdPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditPackage")
                {
                    PackageId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindPackageValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeletePackage")
                {
                    try
                    {
                        int PackageId = Convert.ToInt32(e.CommandArgument);
                        new PackageMasterController().DeletePackage(PackageId);
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
                    if (!PackageMasterController.IsPackageName(txtPackagName.Text.Trim()))
                    {
                        InsertPackage();
                        ClearValues();
                        PanelVisibility(true, false);
                        BindGrid();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','This Package Name already exists..!');", true);
                }
                else
                {
                    UpdatePackage();
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
                grdPackages.DataSource = PackageMasterController.GetPackageMaster(LoginUser.ClubId, txtSearchText.Text, SortField, SortDir);
                grdPackages.DataBind();
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
        private void InsertPackage()
        {
            PackageMaster objPackage = new PackageMaster();
            objPackage.ClubId = LoginUser.ClubId;
            objPackage.PackageName = txtPackagName.Text;
            objPackage = new PackageMasterController().InsertPackage(objPackage);
        }
        private void UpdatePackage()
        {
            try
            {
                PackageMaster objPackage = PackageMasterController.GetPackageById(PackageId);
                objPackage.PackageName = txtPackagName.Text;
                new PackageMasterController().UpdatePackage(objPackage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ClearValues()
        {
            txtPackagName.Text = string.Empty;

        }
        private void BindPackageValues()
        {
            try
            {
                PackageMaster objPackage = PackageMasterController.GetPackageById(PackageId);
                txtPackagName.Text = objPackage.PackageName;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}