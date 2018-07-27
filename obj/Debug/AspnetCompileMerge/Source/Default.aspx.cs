using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.Web.UI.HtmlControls;

namespace FitnessCenter
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFacilities();
                BindSlider();
            }
        }


        public void BindFacilities()
        {
            try
            {
                lvServices.DataSource = lvServiceSlide.DataSource = FacilityController.GetFacilities();
                lvServiceSlide.DataBind();
                lvServices.DataBind();
                ProvideClass();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindSlider()
        {
            try
            {
                lstSlider.DataSource = HomeSliderImageController.GetSliderImagesForDisplay();
                lstSlider.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ProvideClass()
        {
            try
            {
                foreach (ListViewDataItem item in lvServices.Items)
                {
                    if (item.DataItemIndex == 0)
                    {
                        HtmlGenericControl service = (HtmlGenericControl)item.FindControl("divService");
                        service.Attributes.Add("class", "item active");
                    }
                }
                foreach (ListViewDataItem item in lvServiceSlide.Items)
                {
                    HtmlGenericControl liservice = (HtmlGenericControl)item.FindControl("liService");
                    liservice.Attributes.Add("data-slide-to", Convert.ToString(item.DataItemIndex));
                    if (item.DataItemIndex != 0)
                        liservice.Attributes.Remove("class");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}