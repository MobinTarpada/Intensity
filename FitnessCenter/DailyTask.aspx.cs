using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter
{
    public partial class DailyTask : System.Web.UI.Page
    {

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }
        public string Dates
        {
            get
            {
                var obj = ViewState["Dates"];
                return obj == null ? Convert.ToString(DateTime.Now.ToString("MM-dd-yyyy")) : (string)obj;
            }
            set
            {
                ViewState["Dates"] = value;
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
                lblUserName.Text = "WELCOME " + LoginUser.FirstName + " " + LoginUser.LastName;

                User objUser = UserProfileController.GetUserByID(LoginUser.ID);
                imgProfileImage.ImageUrl = objUser.ProfilePicture;
                //LiVisibility();
                BindAppoinments();
                BindBirthday();
                BindAnniversary();
                //     BindPresentation();
                BindFollowup();
                //Calendar1.SelectedDate = DateTime.Now;
            }

        }

        public void BindAnniversary()
        {
            try
            {
                grdAnniversary.DataSource = LeadController.GetAnniversary(LoginUser.ClubId, txtSearchName.Text, Dates, LoginUser.ID);
                grdAnniversary.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindBirthday()
        {
            try
            {
                grdBirhtDay.DataSource = LeadController.GetBirthDay(LoginUser.ClubId, txtSearchName.Text, Dates, LoginUser.ID);
                grdBirhtDay.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
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

        public void BindAppoinments()
        {
            try
            {

                grdLeadAppointment.DataSource = LeadController.GetLeadAppointmentByDate(LoginUser.ClubId, txtSearchName.Text, Dates, LoginUser.ID);
                grdLeadAppointment.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void BindPresentation()
        //{
        //    try
        //    {
        //        grdLeadPresentation.DataSource = LeadController.GetLeadPresentationByDate(LoginUser.ClubId, txtSearchName.Text, Dates);
        //        grdLeadPresentation.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public void BindFollowup()
        {
            try
            {
                grdLeadFollowup.DataSource = LeadController.GetLeadFollowupByDate(LoginUser.ClubId, txtSearchName.Text, Dates, LoginUser.ID);
                grdLeadFollowup.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void BindLeadHistory()
        //{
        //    try
        //    {
        //        grdLeadHistory.DataSource = LeadController.GetLeadHistoryByDate(txtSearchName.Text, Dates);
        //        grdLeadHistory.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Dates = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            BindAppoinments();
            //BindPresentation();
            BindFollowup();
            BindBirthday();
            BindAnniversary();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAppoinments();
            // BindPresentation();
            BindFollowup();
            BindBirthday();
            BindAnniversary();
            //if (txtSearchName.Text == "")
            //{
            //    grdLeadHistory.DataSource = null;
            //    grdLeadHistory.DataBind();
            //}
            //else
            //    BindLeadHistory();
        }

        protected void grdLeadAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLeadAppointment.PageIndex = e.NewPageIndex;
            BindAppoinments();
        }

        protected void grdLeadFollowup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLeadFollowup.PageIndex = e.NewPageIndex;
            BindFollowup();
        }

        protected void grdBirhtDay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBirhtDay.PageIndex = e.NewPageIndex;
            BindBirthday();
        }

        protected void grdAnniversary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAnniversary.PageIndex = e.NewPageIndex;
            BindAnniversary();
        }

        protected void grdBirhtDay_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBirhtDay.EditIndex = e.NewEditIndex;
            BindBirthday();

            grdBirhtDay.Focus();
        }

        protected void grdBirhtDay_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdBirhtDay.Rows[e.RowIndex];
            int LeadID = Convert.ToInt32(grdBirhtDay.DataKeys[e.RowIndex].Values[0]);
            string remarks = (row.FindControl("txtBirthDayRemarks") as TextBox).Text;
            using (FitnessCenterEntities entities = new FitnessCenterEntities())
            {
                Lead lead = (from c in entities.Leads
                             where c.ID == LeadID
                             select c).FirstOrDefault();
                lead.BirthDayRemarks = remarks;
                lead.updateDate = DateTime.Now;
                entities.SaveChanges();
            }
            grdBirhtDay.EditIndex = -1;
            this.BindBirthday();
            grdBirhtDay.Focus();
        }

        protected void grdBirhtDay_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBirhtDay.EditIndex = -1;
            BindBirthday();
        }

        protected void grdAnniversary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAnniversary.EditIndex = -1;
            BindAnniversary();
        }

        protected void grdAnniversary_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdAnniversary.Rows[e.RowIndex];
            int LeadID = Convert.ToInt32(grdAnniversary.DataKeys[e.RowIndex].Values[0]);
            string remarks = (row.FindControl("txtAnniversaryRemarks") as TextBox).Text;
            using (FitnessCenterEntities entites = new FitnessCenterEntities())
            {
                Lead lead = (from c in entites.Leads
                             where c.ID == LeadID
                             select c).FirstOrDefault();
                lead.AnniversaryRemarks = remarks;
                lead.updateDate = DateTime.Now;
                entites.SaveChanges();
            }
            grdAnniversary.EditIndex = -1;
            this.BindAnniversary();
            grdAnniversary.Focus();
        }

        protected void grdAnniversary_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAnniversary.EditIndex = e.NewEditIndex;
            BindAnniversary();
            grdAnniversary.Focus();
        }

        protected void grdLeadFollowup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdLeadFollowup.EditIndex = -1;
            BindFollowup();
        }

        protected void grdLeadFollowup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdLeadFollowup.Rows[e.RowIndex];
            int FollowupId = Convert.ToInt32(grdLeadFollowup.DataKeys[e.RowIndex].Values[0]);
            string remarks = (row.FindControl("txtFolowupRemarks") as TextBox).Text;
            string followupDate = (row.FindControl("followupDate") as TextBox).Text;
            using (FitnessCenterEntities entities = new FitnessCenterEntities())
            {
                LeadFollowup leadfollowup = (from c in entities.LeadFollowups
                                             where c.ID == FollowupId
                                             select c).FirstOrDefault();
                leadfollowup.Remarks = remarks;
                leadfollowup.followupDateTime = UtillController.ConvertDateTime(followupDate);
                leadfollowup.updateDate = DateTime.Now;
                entities.SaveChanges();
            }
            grdLeadFollowup.EditIndex = -1;
            this.BindFollowup();
            grdLeadFollowup.Focus();
        }

        protected void grdLeadFollowup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdLeadFollowup.EditIndex = e.NewEditIndex;
            BindFollowup();
            grdLeadFollowup.Focus();
        }

        protected void grdLeadAppointment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdLeadAppointment.EditIndex = -1;
            BindFollowup();
        }

        protected void grdLeadAppointment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdLeadAppointment.EditIndex = e.NewEditIndex;
            BindAppoinments();
            grdLeadAppointment.Focus();
        }

        protected void grdLeadAppointment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdLeadAppointment.Rows[e.RowIndex];
            int AppointId = Convert.ToInt32(grdLeadAppointment.DataKeys[e.RowIndex].Values[0]);
            string remarks = (row.FindControl("txtAppointRemarks") as TextBox).Text;
            string AppointDate = (row.FindControl("appointDate") as TextBox).Text;
            using (FitnessCenterEntities entities = new FitnessCenterEntities())
            {

                LeadAppointment leadAppoint = (from c in entities.LeadAppointments
                                               where c.ID == AppointId
                                               select c).FirstOrDefault();
                leadAppoint.reasonForNotAttend = remarks;
                leadAppoint.appointmentDate = UtillController.ConvertDateTime(AppointDate);
                leadAppoint.updateDate = DateTime.Now;
                entities.SaveChanges();
            }
            grdLeadAppointment.EditIndex = -1;
            this.BindAppoinments();
            grdLeadAppointment.Focus();
        }
    }
}