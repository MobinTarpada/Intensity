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
    public partial class frmVirtualTour : System.Web.UI.Page
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

        public long VirtualId
        {
            get
            {
                var obj = ViewState["VirtualId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["VirtualId"] = value;
            }
        }
        public FileUpload VideoFile
        {
            get
            {
                var obj = Session["VideoFile"];
                return obj == null ? null : (FileUpload)obj;
            }
            set
            {
                Session["VideoFile"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindGrid();
                    PanelVisibility(true, false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
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

        protected void grdVirtual_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdVirtual.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdVirtual_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditVideo")
                {
                    VirtualId = Convert.ToInt64(e.CommandArgument);
                    Mode = "Update";
                    BindValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteVideo")
                {
                    VirtualId = Convert.ToInt64(e.CommandArgument);
                    new VirtualTourController().DeleteVideo(VirtualId);
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Success','Video Deleted');", true);
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
                    InsertVideo();
                else
                    UpdateVideo();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Success','Video Saved');", true);
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
            try
            {
                txtName.Text = "";
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
                grdVirtual.DataSource = VirtualTourController.GetVirtualVideos();
                grdVirtual.DataBind();
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
                VirtualVideo objVideo = VirtualTourController.GetVirtualVideosById(VirtualId);
                txtName.Text = objVideo.name;
                editVideo.Src = objVideo.path;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit)
        {
            pnlEdit.Visible = Edit;
            pnlView.Visible = View;
        }

        public void InsertVideo()
        {
            try
            {
                VideoFile = fileUpldVideo;
                if (VideoFile.HasFile)
                {
                    if (VideoFile.PostedFile.ContentType == "video/mp4")
                    {
                        VirtualVideo objVideo = new VirtualVideo();
                        string fileName = Path.GetFileName(VideoFile.FileName);
                        string path = "~/Videos/" + fileName;
                        VideoFile.SaveAs(Server.MapPath(path));
                        objVideo.name = txtName.Text;
                        //using (BinaryReader br = new BinaryReader(fileUpldVideo.PostedFile.InputStream))
                        //{
                        //byte[] data = br.ReadBytes((int)fileUpldVideo.PostedFile.InputStream.Length);
                        objVideo.path = path;
                        objVideo.ContentType = "video/mp4";
                        //}
                        objVideo = new VirtualTourController().InsertVideos(objVideo);

                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select MP4 Video File');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Video File');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateVideo()
        {
            try
            {
                VirtualVideo objVideo = VirtualTourController.GetVirtualVideosById(VirtualId);
                VideoFile = fileUpldVideo;
                objVideo.name = txtName.Text;
                if (VideoFile.HasFile)
                {
                    if (VideoFile.PostedFile.ContentType == "video/mp4")
                    {
                        string fileName = Path.GetFileName(VideoFile.FileName);
                        string path = "~/Videos/" + fileName;
                        VideoFile.SaveAs(Server.MapPath(path));
                        objVideo.path = path;
                        objVideo.ContentType = "video/mp4";
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select MP4 Video File');", true);
                }
                objVideo = new VirtualTourController().UpdateVideos(objVideo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}