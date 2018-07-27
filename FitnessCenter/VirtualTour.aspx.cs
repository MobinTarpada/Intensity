using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FitnessCenter.DAL;
using FitnessCenter.BO;
using FitnessCenter.BAL;

namespace FitnessCenter
{
    public partial class VirtualTour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void lvVideo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                HtmlVideo video = (HtmlVideo)e.Item.FindControl("video");
                HiddenField Id = (HiddenField)e.Item.FindControl("hfId");
                video.Src = GetSource(Convert.ToInt64(Id.Value));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindGrid()
        {
            try
            {
                lvVideo.DataSource = VirtualTourController.GetVirtualVideos();
                lvVideo.DataBind();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetSource(long Id)
        {
            try
            {
                string src = "";
                VirtualVideo objVideo = VirtualTourController.GetVirtualVideosById(Id);
                src = objVideo.path;
                return src;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}