using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        public void BindGrid()
        {
            try
            {
                lstServices.DataSource = FacilityController.GetFacilities();
                lstServices.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}