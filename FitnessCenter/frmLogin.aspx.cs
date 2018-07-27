using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;

namespace FitnessCenter
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if (!IsPostBack)
            {
                HttpCookie objC = Request.Cookies["FC_Cred"];
                if (objC != null)
                {
                    txtUsername.Text = objC.Values["username"];
                    txtPassword.Attributes.Add("value", objC.Values["password"]);
                    //txtMemberid.Text = objC.Values["member"];
                }
            }
            if (Session["LoginUser"] != null)
            {
                User objUser;
                objUser = (User)Session["LoginUser"];
                if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.SuperAdmin))
                    Response.Redirect("~/frmManageClub.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Admin))
                    Response.Redirect("~/frmManageUsers.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Executive))
                    Response.Redirect("~/frmManageLead.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.ClubManager))
                    Response.Redirect("~/frmManageLead.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.SalesManager))
                    Response.Redirect("~/frmManageLead.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Receptionist))
                    Response.Redirect("~/frmPayment.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.PersonalTrainer))
                    Response.Redirect("~/Desclaimer.aspx", false);
                else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Member))
                    Response.Redirect("~/frmProfile.aspx", false);
            }
        }

        protected void lnkBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               // if (ddlUserType.SelectedValue == "1")
               // {
                    User objUser = UsersController.AuthanticateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    DoLogin(objUser);
                //}
               // if (ddlUserType.SelectedValue == "2")
              //  {
                 //   Membership objMember = UsersController.AuthanticateMmber(txtMemberid.Text.Trim());
                 //   DoMemberLogin(objMember);
                //}
            }
            catch (Exception ex)
            {
                //  new ExceptionLogController().InsertExceptionLog(ex.Message, ex.Source, ex.StackTrace, ex.InnerException.Message);
                throw ex;
            }
        }

        private void DoLogin(User objUser)
        {
            try
            {
                if (objUser != null)
                {
                    dvError.Visible = false;
                    if (chkBxRememberMe.Checked)
                    {
                        Request.Cookies.Remove("FC_Cred");

                        HttpCookie objC = new HttpCookie("FC_Cred");
                        objC.Values["username"] = objUser.UserName;
                        objC.Values["password"] = objUser.Password;
                       // objC.Values["member"] = "";
                        objC.Expires = DateTime.Now.AddDays(90);
                        Response.Cookies.Add(objC);
                    }
                    Session["LoginUser"] = objUser;
                    if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.SuperAdmin))
                        Response.Redirect("~/frmManageClub.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Admin))
                        Response.Redirect("~/frmManageUsers.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Executive))
                        Response.Redirect("~/frmManageLead.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.ClubManager))
                        Response.Redirect("~/frmManageLead.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.SalesManager))
                        Response.Redirect("~/frmManageLead.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Receptionist))
                        Response.Redirect("~/frmPayment.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.PersonalTrainer))
                        Response.Redirect("~/Desclaimer.aspx", false);
                    else if (objUser.UserTypeId == Convert.ToInt32(EnumUserTypeMaster.Member))
                        Response.Redirect("~/frmProfile.aspx", false);
                }
                else
                {
                    dvError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void DoMemberLogin(Membership objMember)
        //{
        //    try
        //    {

        //        if (objMember != null)
        //        {
        //            if (chkBxRememberMe.Checked)
        //            {
        //                Request.Cookies.Remove("FC_Cred");

        //                HttpCookie objC = new HttpCookie("FC_Cred");
        //                objC.Values["member"] = objMember.membershipUniqueId;
        //                objC.Values["username"] = "";
        //                objC.Values["password"] = "";
        //                objC.Expires = DateTime.Now.AddDays(90);
        //                Response.Cookies.Add(objC);
        //            }
        //            Session["LoginUser"] = objMember.User;
        //            dvError.Visible = false;
        //            Response.Redirect("~/frmProfile.aspx", false);
        //        }
        //        else
        //        {
        //            lblErrorMsg.Text = "MemberId Incorrect..!";
        //            dvError.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        protected void imgLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void lnkBtnSignup_Click(object sender, EventArgs e)
        {

        }

        //protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlUserType.SelectedValue == "1")
        //    {
        //        pnlLogin.Visible = true;
        //        pnlMemberLogin.Visible = false;
        //        txtMemberid.Text = "";
        //    }
        //    else if (ddlUserType.SelectedValue == "2")
        //    {
        //        HttpCookie objC = Request.Cookies["FC_Cred"];
        //        if (objC != null)
        //        {
        //            txtUsername.Text = objC.Values[""];
        //            txtPassword.Attributes.Add("value", objC.Values[""]);
        //        }

        //        pnlLogin.Visible = false;
        //        pnlMemberLogin.Visible = true;
        //        txtUsername.Text = txtPassword.Text = string.Empty;
        //    }

        //}
    }
}