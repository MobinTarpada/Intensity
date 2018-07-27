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
    public partial class MstFitnessCenter : System.Web.UI.MasterPage
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

            if (Session["LoginUser"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            if (!IsPostBack)
            {
                lblUserName.Text = LoginUser.firstName + " " + LoginUser.lastName;
                MenuLIVisibility();
                User objUser = UserProfileController.GetUserByID(LoginUser.ID);
                imgProfileImage.ImageUrl = objUser.profilePicture;
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

        //private void LiVisibility()
        //{
        //    try
        //    {
        //        if (LoginUser.userTypeId == (int)EnumUserTypeMaster.SuperAdmin)
        //        {
        //            liManageClubs.Visible = true;
        //            liManageLeads.Visible = false;
        //            liManageTargets.Visible = false;
        //            liManageUsers.Visible = false;
        //            liProfile.Visible = false;
        //        }
        //        else if (LoginUser.userTypeId == (int)EnumUserTypeMaster.Admin)
        //        {
        //            liManageClubs.Visible = false;
        //            liManageLeads.Visible = true;
        //            liManageTargets.Visible = true;
        //            liManageUsers.Visible = true;
        //            liProfile.Visible = true;
        //        }
        //        else if (LoginUser.userTypeId == (int)EnumUserTypeMaster.ClubManager)
        //        {
        //            liManageClubs.Visible = false;
        //            liManageLeads.Visible = true;
        //            liManageTargets.Visible = true;
        //            liManageUsers.Visible = false;
        //            liProfile.Visible = true;
        //        }
        //        else if (LoginUser.userTypeId == (int)EnumUserTypeMaster.Executive)
        //        {
        //            liManageClubs.Visible = false;
        //            liManageLeads.Visible = true;
        //            liManageTargets.Visible = false;
        //            liManageUsers.Visible = false;
        //            liProfile.Visible = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void MenuLIVisibility()
        {
            if (LoginUser.userTypeId == (int)EnumUserTypeMaster.SuperAdmin)
            {
                //liManageClubs.Visible = true;
                //liManageLeadTypes.Visible = true;
                //liManageUserTypes.Visible = true;
                //liAboutUs.Visible = true;
                //liVirtualTour.Visible = true;
                string ltrAdminMenuLi = string.Empty;
                List<PageMaster> lstGetSuperAdmin = new FitnessCenterEntities().PageMasters.Where(x => x.isActive == true && x.isDeleted == false && x.pageCategoryId == 3).ToList();
                foreach (var item in lstGetSuperAdmin)
                {
                    ltrAdminMenuLi += "<li id='" + item.MenuLI + "'><a href='" + item.pageURL + "'><i class='" + item.MenuLICSSClass + "'></i><span class='title'>" + item.pageName + "</span> <span class='arrow'></span></a></li>";
                }
                ltrAdminLi.Text = ltrAdminMenuLi;
            }

            else
            {
                string ltrMenuLIString = string.Empty;
                var lstMenuLIVisibility = UsersController.GetPagePermissions_Result(LoginUser.ID);
                foreach (var objMenuLIVisibility in lstMenuLIVisibility)
                {
                    if (objMenuLIVisibility.isPermission == "TRUE")
                    {
                        ltrMenuLIString += "<li id='" + objMenuLIVisibility.MenuLI + "'><a href='" + objMenuLIVisibility.pageURL + "'><i class='" + objMenuLIVisibility.MenuLICSSClass + "'></i><span class='title'>" + objMenuLIVisibility.pageName + "</span> <span class='arrow'></span></a></li>";
                    }
                }
                ltrMenuLi.Text = ltrMenuLIString;
            }
        }
    }
}