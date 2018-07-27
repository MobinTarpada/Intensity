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
    public partial class DailyTaskMaster : System.Web.UI.MasterPage
    {

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", "9000");
            if (Session["LoginUser"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            if (!IsPostBack)
            {
                lblUserName.Text ="WELCOME " + LoginUser.FirstName + " " + LoginUser.LastName;

                User objUser = UserProfileController.GetUserByID(LoginUser.ID);
                imgProfileImage.ImageUrl = objUser.ProfilePicture;
                //LiVisibility();
            }
        }

        protected void lnkBtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmProfile.aspx");
        }

        protected void lnkBtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/frmLogin.aspx");

        }
    }
}