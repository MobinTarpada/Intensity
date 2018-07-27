using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using System.IO;


namespace FitnessCenter
{
    public partial class frmProfile : System.Web.UI.Page
    {
        #region Properties

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }

        public string SortField
        {
            get
            {
                var obj = ViewState["SortField"];
                return obj == null ? "ID" : (string)obj;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        public string SortDir
        {
            get
            {
                var obj = ViewState["SortDir"];
                return obj == null ? "DSC" : (string)obj;
            }
            set
            {
                ViewState["SortDir"] = value;
            }
        }

        public long UserId
        {
            get
            {
                var obj = ViewState["UserId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserId"] = value;
            }
        }

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

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser == null)
                Response.Redirect("~/frmLogin.aspx");
            try
            {
                if (!IsPostBack)
                {
                    BindUserValues();

                    if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.SuperAdmin))
                        lnkhome.HRef = "frmManageClub.aspx";
                    else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.Admin))
                        lnkhome.HRef = "frmManageUsers.aspx";
                    else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.Executive))
                        lnkhome.HRef = "frmManageLead.aspx";
                    else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.ClubManager))
                        lnkhome.HRef = "frmManageLead.aspx";
                }

                if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
                {
                    txtPassword.Attributes["value"] = txtPassword.Text;
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
                string filename = "";
                if (FileUploadControl.HasFile && FileUploadControl.PostedFile.ContentType == "image/jpeg")
                {
                    filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/ProfileImage/" + filename));
                }
                else
                    StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                UpdateUser();
                if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.SuperAdmin))
                    Response.Redirect("~/frmManageClub.aspx", false);
                else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.Admin))
                    Response.Redirect("~/frmManageUsers.aspx", false);
                else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.Executive))
                    Response.Redirect("~/frmManageLead.aspx", false);
                else if (LoginUser.userTypeId == Convert.ToInt32(EnumUserTypeMaster.ClubManager))
                    Response.Redirect("~/frmManageLead.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Methods

        private void UpdateUser()
        {
            try
            {
                User objUser = UserProfileController.GetUserByID(LoginUser.ID);
                objUser.firstName = txtFirstName.Text;
                objUser.lastName = txtLastName.Text;
                objUser.username = txtUsername.Text;
                objUser.email = txtEmail.Text;
                objUser.password = txtPassword.Text;
                if (FileUploadControl.HasFile)
                    objUser.profilePicture = "~/ProfileImage/" + Path.GetFileName(FileUploadControl.FileName);

                new UsersController().UpdateUser(objUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindUserValues()
        {
            try
            {
                User objUser = UserProfileController.GetUserByID(LoginUser.ID);
                imgProfileImageChange.ImageUrl = objUser.profilePicture;
                txtFirstName.Text = objUser.firstName;
                txtLastName.Text = objUser.lastName;
                txtUsername.Text = objUser.username;
                txtEmail.Text = objUser.email;
                txtPassword.Text = objUser.password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        protected void UploadButton_Click(object sender, EventArgs e)
        {

        }

    }
}