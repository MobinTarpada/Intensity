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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FitnessCenter
{
    public partial class frmFacilities : System.Web.UI.Page
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

        public long FacilityId
        {
            get
            {
                var obj = ViewState["FacilityId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["FacilityId"] = value;
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

        protected void grdFacillity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditFacility")
                {
                    FacilityId = Convert.ToInt64(e.CommandArgument);
                    Mode = "Update";
                    BindValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteFacility")
                {
                    FacilityId = Convert.ToInt64(e.CommandArgument);
                    new FacilityController().DeleteFacility(FacilityId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','Service Deleted Successfully');", true);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdFacillity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdFacillity.PageIndex = e.NewPageIndex;
                BindGrid();
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
                BindGrid();
                PanelVisibility(true, false);
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
                    InsertFacility();
                else
                    UpdateFacility();

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
                grdFacillity.DataSource = FacilityController.GetFacilities();
                grdFacillity.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertFacility()
        {
            try
            {
                Facility objFaciliy = new Facility();

                if (fileUpldImg.HasFile)
                {
                    string fileName = "", path = "", ext = "";

                    ext = Path.GetExtension(fileUpldImg.PostedFile.FileName);

                    if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".jpeg"))
                    {
                        fileName = Path.GetFileName(fileUpldImg.PostedFile.FileName);
                        path = "ServiceImages/" + fileName;
                        ResizeImage(fileUpldImg.PostedFile.InputStream, Server.MapPath(path));
                        //fileUpldImg.SaveAs(Server.MapPath(path));
                        objFaciliy.image = path;
                        objFaciliy.facilityName = txtName.Text;
                        objFaciliy.description = txtDescp.Text;
                        objFaciliy = new FacilityController().InsertFacility(objFaciliy);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','Service Saved Successfully');", true);
                        ClearValues();
                        BindGrid();
                        PanelVisibility(true, false);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Image file Only');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Image');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateFacility()
        {
            try
            {
                try
                {
                    Facility objFaciliy = FacilityController.GetFacilitiesById(FacilityId);
                    objFaciliy.facilityName = txtName.Text;
                    objFaciliy.description = txtDescp.Text;
                    if (fileUpldImg.HasFile)
                    {
                        string fileName = "", path = "", ext = "";

                        ext = Path.GetExtension(fileUpldImg.PostedFile.FileName);

                        if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".jpeg"))
                        {
                            fileName = Path.GetFileName(fileUpldImg.PostedFile.FileName);
                            path = "ServiceImages/" + fileName;
                            ResizeImage(fileUpldImg.PostedFile.InputStream, Server.MapPath(path));
                            //fileUpldImg.SaveAs(Server.MapPath(path));
                            objFaciliy.image = path;
                        }
                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Image file Only');", true);
                    }
                    objFaciliy = new FacilityController().UpdateFacility(objFaciliy);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','Service Updated Successfully');", true);
                    ClearValues();
                    BindGrid();
                    PanelVisibility(true, false);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            txtDescp.Text = txtName.Text = serImg.ImageUrl = string.Empty;
        }

        public void BindValues()
        {
            try
            {
                Facility objFaciliy = FacilityController.GetFacilitiesById(FacilityId);
                txtDescp.Text = objFaciliy.description;
                txtName.Text = objFaciliy.facilityName;
                serImg.ImageUrl = objFaciliy.image;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ResizeImage(Stream src, string target)
        {
            try
            {
                using (var img = System.Drawing.Image.FromStream(src))
                {
                    var image = new Bitmap(360, 360);
                    var graph = Graphics.FromImage(image);
                    graph.CompositingQuality = CompositingQuality.HighQuality;
                    graph.SmoothingMode = SmoothingMode.HighQuality;
                    graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, 360, 360);
                    graph.DrawImage(img, imageRectangle);
                    image.Save(target, img.RawFormat);
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