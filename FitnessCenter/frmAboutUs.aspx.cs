using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.IO;

namespace FitnessCenter
{
    public partial class frmAboutUs : System.Web.UI.Page
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

        public long AboutUsId
        {
            get
            {
                var obj = ViewState["AboutUsId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["AboutUsId"] = value;
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
            PanelVisibility(false, true);
            Mode = "Insert";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == "Insert")
                InsertAboutUs();
            else
                UpdateAboutUs();
            ClearValues();
            PanelVisibility(true, false);
            BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearValues();
            PanelVisibility(true, false);
            BindGrid();
        }

        protected void grdAbout_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditAbout")
                {
                    AboutUsId = Convert.ToInt64(e.CommandArgument);
                    BindValues();
                    PanelVisibility(false, true);
                    Mode = "Update";
                }
                else if (e.CommandName == "DeleteAbout")
                {
                    AboutUsId = Convert.ToInt64(e.CommandArgument);
                    new AboutUsController().DeleteAboutUs(AboutUsId);
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Deleted');", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdAbout_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAbout.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Methods

        public void PanelVisibility(bool View, bool Edit)
        {
            pnlEdit.Visible = Edit;
            pnlView.Visible = View;
        }

        public void BindGrid()
        {
            try
            {
                grdAbout.DataSource = AboutUsController.GetAboutUs();
                grdAbout.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertAboutUs()
        {
            try
            {
                AboutU objAboutUs = new AboutU();
                objAboutUs.heading = txtHeading.Text;
                objAboutUs.Description = txtDescp.Text;
                //if(fileUpldImg.HasFile)
                //{
                //    string fileName = Path.GetFileName(fileUpldImg.FileName);
                //    string path = Server.MapPath("~/assets/assets/images/fitness/" + fileName);
                //    fileUpldImg.SaveAs(path);
                //    objAboutUs.image = "assets/assets/images/fitness/" + fileName;
                //}
                objAboutUs = new AboutUsController().InsertAboutUs(objAboutUs);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Saved');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateAboutUs()
        {
            try
            {
                AboutU objAbout = AboutUsController.GetAboutUsById(AboutUsId);
                objAbout.heading = txtHeading.Text;
                objAbout.Description = txtDescp.Text;
                //if (fileUpldImg.HasFile)
                //{
                //    string fileName = Path.GetFileName(fileUpldImg.FileName);
                //    string path = Server.MapPath("~/assets/assets/images/fitness/" + fileName);
                //    fileUpldImg.SaveAs(path);
                //    objAbout.image = "~/assets/assets/images/fitness/" + fileName;
                //}
                objAbout = new AboutUsController().UpdateAboutUs(objAbout);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Updated');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            txtDescp.Text = txtHeading.Text = string.Empty;
        }

        public void BindValues()
        {
            try
            {
                AboutU objAbout = AboutUsController.GetAboutUsById(AboutUsId);
                txtDescp.Text = objAbout.Description;
                txtHeading.Text = objAbout.heading;
                //if (objAbout.image != "")
                //    abtUsImg.ImageUrl = objAbout.image;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }
}