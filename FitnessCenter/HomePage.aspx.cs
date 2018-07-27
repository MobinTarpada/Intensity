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
    public partial class HomePage : System.Web.UI.Page
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

        public long SliderId
        {
            get
            {
                var obj = ViewState["SliderId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["SliderId"] = value;
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

        protected void grdHomeSlider_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditFacility")
                {
                    SliderId = Convert.ToInt64(e.CommandArgument);
                    Mode = "Update";
                    BindValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteFacility")
                {
                    SliderId = Convert.ToInt64(e.CommandArgument);
                    new HomeSliderImageController().DeleteSliderImages(SliderId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','SliderImage Deleted Successfully');", true);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdHomeSlider_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdHomeSlider.PageIndex = e.NewPageIndex;
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
                    InsertSliderImages();
                else
                    UpdateSliderImages();

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
                grdHomeSlider.DataSource = HomeSliderImageController.GetSliderImages();
                grdHomeSlider.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertSliderImages()
        {
            try
            {
                HomepageSlider objSlider = new HomepageSlider();

                if (fileUpldImg.HasFile)
                {
                    string fileName = "", path = "", ext = "";

                    ext = Path.GetExtension(fileUpldImg.PostedFile.FileName);

                    if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".PNG") || ext.Equals(".gif") || ext.Equals(".jpeg"))
                    {
                        fileName = Path.GetFileName(fileUpldImg.PostedFile.FileName);
                        path = "SliderImages/" + fileName;
                        // ResizeImage(fileUpldImg.PostedFile.InputStream, Server.MapPath(path));
                        fileUpldImg.SaveAs(Server.MapPath(path));
                        objSlider.imagePath = path;
                        objSlider.imageName = txtName.Text;
                        objSlider.isDisplayed = chkDisplay.Checked;
                        //objSlider.description = txtDescp.Text;
                        objSlider = new HomeSliderImageController().InsertSliderImages(objSlider);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','SliderImage Saved Successfully');", true);
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

        public void UpdateSliderImages()
        {
            try
            {
                try
                {
                    HomepageSlider objSlider = HomeSliderImageController.GetSliderImagesById(SliderId);
                    objSlider.imageName = txtName.Text;
                    objSlider.isDisplayed = chkDisplay.Checked;
                    // objFaciliy.description = txtDescp.Text;
                    if (fileUpldImg.HasFile)
                    {
                        string fileName = "", path = "", ext = "";

                        ext = Path.GetExtension(fileUpldImg.PostedFile.FileName);

                        if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".PNG") || ext.Equals(".gif") || ext.Equals(".jpeg"))
                        {
                            fileName = Path.GetFileName(fileUpldImg.PostedFile.FileName);
                            path = "SliderImages/" + fileName;
                            //ResizeImage(fileUpldImg.PostedFile.InputStream, Server.MapPath(path));
                            fileUpldImg.SaveAs(Server.MapPath(path));
                            objSlider.imagePath = path;
                            serImg.ImageUrl = objSlider.imagePath;
                            //if (fileUpldImg.HasFile)
                            //    objSlider.imagePath = "~/SliderImages/" + Path.GetFileName(fileUpldImg.FileName);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Image file Only');", true);
                    }
                    objSlider = new HomeSliderImageController().UpdateSliderImages(objSlider);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "suc_msg", "MessageBox('Success','SliderImage Updated Successfully');", true);
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
            txtName.Text = serImg.ImageUrl = string.Empty;
            chkDisplay.Checked = false;
        }

        public void BindValues()
        {
            try
            {
                HomepageSlider objSlider = HomeSliderImageController.GetSliderImagesById(SliderId);
                //txtDescp.Text = objFaciliy.description;
                txtName.Text = objSlider.imageName;
                serImg.ImageUrl = objSlider.imagePath;
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