using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;

namespace FitnessCenter
{
    public partial class frmManagePTPPackages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelVisibility(true, false);
                BindGrid();
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
        #endregion

        #region Events
     
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditPackage")
                {
                    PackageId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    PanelVisibility(false, true);
                    BindValues();
                }
                else if (e.CommandName == "DeletePackage")
                {
                    PackageId = Convert.ToInt32(e.CommandArgument);
                    DeletePackages();
                    BindGrid();
                }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "Insert")
                {
                    InsertPackages();
                    ClearValues();
                    PanelVisibility(true, false);
                    BindGrid();
                }
                else
                {
                    UpdatePackages();
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
        public void BindGrid()
        {
            try
            {
                grdPackages.DataSource = PTPPackageController.GetPTPPackages(txtSearch.Text, SortField, SortDir, LoginUser.ClubId);
                grdPackages.DataBind();
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

        public void InsertPackages()
        {
            try
            {
                PTPPackageMaster objPTP = new PTPPackageMaster();
                objPTP.packageName = txtPackageName.Text;
                objPTP.fees = Convert.ToDecimal(txtFees.Text);
                objPTP.validDays = Convert.ToInt64(txtDays.Text);
                objPTP.noOfSessions = Convert.ToInt64(txtSessions.Text);
                objPTP.clubId = LoginUser.ClubId;
                objPTP = new PTPPackageController().InsertPackages(objPTP);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Added Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void UpdatePackages()
        {
            PTPPackageMaster objPTP = PTPPackageController.GetPTPPackagesByID(PackageId);
            objPTP.packageName = txtPackageName.Text;
            objPTP.fees = Convert.ToDecimal(txtFees.Text);
            objPTP.validDays = Convert.ToInt64(txtDays.Text);
            objPTP.noOfSessions = Convert.ToInt64(txtSessions.Text);
            new PTPPackageController().UpdatePackages(objPTP);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Updated Successfully');", true);
        }

        public void DeletePackages()
        {
            try
            {
                new PTPPackageController().DeletePackages(PackageId);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Deleted Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindValues()
        {
            try
            {
                PTPPackageMaster objPTP = PTPPackageController.GetPTPPackagesByID(PackageId);
                txtPackageName.Text = objPTP.packageName;
                txtFees.Text = Convert.ToString(objPTP.fees);
                txtDays.Text = Convert.ToString(objPTP.validDays);
                txtSessions.Text = Convert.ToString(objPTP.noOfSessions);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            foreach (Control ctrl in pnlEdit.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
            }
            txtSearch.Text = "";
        }
        #endregion
    }
}