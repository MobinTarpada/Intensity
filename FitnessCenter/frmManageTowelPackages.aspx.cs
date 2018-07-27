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
    public partial class frmManageTowelPackages : System.Web.UI.Page
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

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                PanelVisibility(true, false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAddPackage_Click(object sender, EventArgs e)
        {
            PanelVisibility(false, true);
            Mode = "Insert";
            List<TowelHiringPackage> lstTowel = new List<TowelHiringPackage>();
            BindGrid();
            lstTowel = (List<TowelHiringPackage>)grdPackages.DataSource;
            if (lstTowel != null && lstTowel.Count > 0)
            {
                var obj = lstTowel.FirstOrDefault(x => x.isDeleted == false);
                txtDepositAmt.Text = Convert.ToString(obj.depositAmount);
            }
            else
                txtDepositAmt.Text = "";
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

        protected void grdPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditPackage")
                {
                    PackageId = Convert.ToInt64(e.CommandArgument);
                    PanelVisibility(false, true);
                    Mode = "Update";
                    BindValues();
                }
                else if (e.CommandName == "DeletePackage")
                {
                    PackageId = Convert.ToInt64(e.CommandArgument);
                    new TowelPackageController().DeletePackage(PackageId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Deleted Successfully');", true);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "Insert")
                {
                    if (!TowelPackageController.IsNameExists(txtPackageName.Text))
                    {
                        InsertPackages();
                        BindGrid();
                        UpdateDeposit();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Added Successfully');", true);
                        BindGrid();
                        ClearValues();
                        PanelVisibility(true, false);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Package Name Already Exists');", true);
                }
                else
                {
                    UpdatePackages();
                    BindGrid();
                    UpdateDeposit();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Updated Successfully');", true);
                    BindGrid();
                    ClearValues();
                    PanelVisibility(true, false);
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
                grdPackages.DataSource = TowelPackageController.GetTowelPackages(SortDir, SortField, txtSearch.Text, LoginUser.ClubId);
                grdPackages.DataBind();
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
                TowelHiringPackage objTowel = TowelPackageController.GetTowelPackageById(PackageId);
                txtPackageName.Text = objTowel.packageName;
                txtFees.Text = Convert.ToString(objTowel.amount);
                txtDays.Text = Convert.ToString(objTowel.numberOfDays);
                txtHiringTime.Text = Convert.ToString(objTowel.hiringTime);
                txtDepositAmt.Text = Convert.ToString(objTowel.depositAmount);
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

        public void ClearValues()
        {
            try
            {
                foreach (Control ctrl in pnlEdit.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertPackages()
        {
            try
            {
                TowelHiringPackage objTowel = new TowelHiringPackage();
                objTowel.packageName = txtPackageName.Text;
                objTowel.amount = Convert.ToDecimal(txtFees.Text);
                objTowel.depositAmount = Convert.ToDecimal(txtDepositAmt.Text);
                objTowel.numberOfDays = Convert.ToInt32(txtDays.Text);
                objTowel.hiringTime = Convert.ToInt32(txtHiringTime.Text);
                new TowelPackageController().InsertPackage(objTowel);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Added Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePackages()
        {
            try
            {
                TowelHiringPackage objTowel = TowelPackageController.GetTowelPackageById(PackageId);
                objTowel.packageName = txtPackageName.Text;
                objTowel.amount = Convert.ToDecimal(txtFees.Text);
                objTowel.depositAmount = Convert.ToDecimal(txtDepositAmt.Text);
                objTowel.numberOfDays = Convert.ToInt32(txtDays.Text);
                objTowel.hiringTime = Convert.ToInt32(txtHiringTime.Text);
                new TowelPackageController().UpdatePackage(objTowel);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Updated Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateDeposit()
        {
            try
            {
                List<TowelHiringPackage> lstTowel = new List<TowelHiringPackage>();
                lstTowel = (List<TowelHiringPackage>)grdPackages.DataSource;
                if (lstTowel != null && lstTowel.Count > 0)
                {
                    foreach (var obj in lstTowel)
                    {
                        TowelHiringPackage objTowel = TowelPackageController.GetTowelPackageById(obj.ID);
                        objTowel.depositAmount = Convert.ToDecimal(txtDepositAmt.Text);
                        new TowelPackageController().UpdatePackage(objTowel);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}