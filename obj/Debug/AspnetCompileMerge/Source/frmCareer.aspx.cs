using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using FitnessCenter.DAL;

namespace FitnessCenter
{
    public partial class frmCareer : System.Web.UI.Page
    {
        #region Properties
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

        public long CareerId
        {
            get
            {
                var obj = ViewState["CareerId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["CareerId"] = value;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                PanelVisibility(false, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdCareer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCareer.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdCareer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="EditCareer")
                {
                    CareerId = Convert.ToInt64(e.CommandArgument);
                    PanelVisibility(false, true);
                    Mode = "Update";
                    BindValues();
                }
                else if (e.CommandName == "DeleteCareer")
                {
                    CareerId = Convert.ToInt64(e.CommandArgument);
                    new CareerController().DeletePosition(CareerId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Deleted');", true);
                    BindGrid();
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
                    InsertCareer();
                else
                    UpdateCareer();
                txtName.Text = string.Empty;
                PanelVisibility(true, false);
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            PanelVisibility(true, false);
            BindGrid();
        }
        #endregion

        #region Methods
        public void BindGrid()
        {
            try
            {
                grdCareer.DataSource = CareerController.GetCareerPositions();
                grdCareer.DataBind();
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
                Career objCareer = CareerController.GetCareerPositionsById(CareerId);
                txtName.Text = objCareer.positionName;
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

        public void InsertCareer()
        {
            try
            {
                Career objCareer = new Career();
                objCareer.positionName = txtName.Text;
                objCareer = new CareerController().InsertPosition(objCareer);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Saved');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateCareer()
        {
            try
            {
                Career objCareer = CareerController.GetCareerPositionsById(CareerId);
                objCareer.positionName = txtName.Text;
                objCareer = new CareerController().UpdatePosition(objCareer);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Saved');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}