using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //aboutUs.InnerHtml += GetABoutUs();
            //aboutImg.InnerHtml = GetABoutUsImages();
            if (!IsPostBack)
                AddPanes();
        }

        //public string GetABoutUs()
        //{
        //    try
        //    {
        //        List<AboutU> lstAboutUs = AboutUsController.GetAboutUs();
        //        string abtUs = "";
        //        foreach (var obj in lstAboutUs)
        //        {
        //            abtUs += "<p class='h-desc gray4'>";
        //            abtUs += "         <span class='colored uppercase extrabold condensed'>" + obj.heading + "</span>";
        //            abtUs += "<br />";
        //            abtUs += "        <br />";
        //            abtUs += obj.Description;
        //            abtUs += "</p>";
        //        }
        //        return abtUs;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public string GetABoutUsImages()
        //{
        //    try
        //    {
        //        List<AboutU> lstAboutUs = AboutUsController.GetAboutUs();
        //        string abtUs = "";
        //        foreach (var obj in lstAboutUs)
        //        {
        //            if (obj.image != "")
        //                abtUs += "<img src='" + obj.image + "' style='height: 100%; width: 100%;' /><br />";
        //        }
        //        return abtUs;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public void AddPanes()
        {
            try
            {
                //HtmlGenericControl h3 = new HtmlGenericControl();
                //h3 = header3;
                accAboutUs.DataSource = AboutUsController.GetAboutUs();
                accAboutUs.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}