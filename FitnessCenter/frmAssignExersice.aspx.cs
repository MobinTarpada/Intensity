using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;

namespace FitnessCenter
{

    public partial class frmAssignExersice : System.Web.UI.Page
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
        public long ExerciseCardMasterId
        {
            get
            {
                var obj = ViewState["ExerciseCardMasterId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ExerciseCardMasterId"] = value;
            }
        }
        public long ExerciseMasterId
        {
            get
            {
                var obj = ViewState["ExerciseMasterId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ExerciseMasterId"] = value;
            }
        }
        public long AssignExerciseId
        {
            get
            {
                var obj = ViewState["AssignExerciseId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["AssignExerciseId"] = value;
            }
        }
        public long BodyType
        {
            get
            {
                var obj = ViewState["BodyType"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["BodyType"] = value;
            }
        }

        public long LevelId
        {
            get
            {
                var obj = ViewState["LevelId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["LevelId"] = value;
            }
        }
        public long MemberId
        {
            get
            {
                var obj = ViewState["MemberId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["MemberId"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser == null)
                Response.Redirect("~/frmLogin.aspx");

            if (!IsPostBack)
            {

                BindGrid();
                PanelVisibility(true, false);
                BindMembers();
                pnlArobic.Visible = false;
                pnlNonArobic.Visible = false;
            }
        }

        #region Events
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdExersice_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                grdExersice.PageIndex = e.NewSelectedIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdExersice_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortField = e.SortExpression;
                if (SortDir == "ASC")
                    SortDir = "DESC";
                else
                    SortDir = "ASC";
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdExersice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditExercise")
                {
                    MemberId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";

                    BindAssignExerciseValues();
                    pnlArobic.Visible = true;
                    pnlNonArobic.Visible = true;
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteExercise")
                {

                    int MemberId = Convert.ToInt32(e.CommandArgument);
                    new ExerciseController().DeleteAssignExercise(MemberId);
                    BindGrid();

                }
                else if (e.CommandName == "DetailExercise")
                {

                    if (grdDetailsExercise.Visible == false)
                    {
                        grdDetailsExercise.Visible = true;
                        MemberId = Convert.ToInt64(e.CommandArgument);
                        BindGridDetails();
                    }
                    else
                    {
                        MemberId = Convert.ToInt64(e.CommandArgument);
                        BindGrid();
                        grdDetailsExercise.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMembers.SelectedValue == "0" || ddlBodyType.SelectedValue == "0" || ddlLevel.SelectedValue == "0")
                {
                    lblErrorMsg.Text = "Please Select Any Members, BodyType And Level";
                }
                else
                {
                    lblErrorMsg.Text = "";
                    BodyType = Convert.ToInt64(ddlBodyType.SelectedValue);
                    LevelId = Convert.ToInt64(ddlLevel.SelectedValue);
                    BindArobicExerciseListView();
                    BindNonArobicExerciseListView();
                    pnlArobic.Visible = true;
                    pnlNonArobic.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnAddExersice_Click(object sender, EventArgs e)
        {
            PanelVisibility(false, true);
            ClearValues();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMembers.SelectedValue == "0" || ddlBodyType.SelectedValue == "0" || ddlLevel.SelectedValue == "0")
                {
                    lblErrorMsg.Text = "Please Select Any Members, BodyType And Level";
                }
                else
                {
                    if (Mode == "Insert")
                    {
                        InsertArobicExercise();
                        InsertNonArobiExercise();
                    }
                    else
                    {
                        new ExerciseController().DeleteAllAssignExerciseByMemberId(MemberId);
                        InsertArobicExercise();
                        InsertNonArobiExercise();
                    }
                    PanelVisibility(true, false);
                    ClearValues();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PanelVisibility(true, false);
            ClearValues();
        }


        #endregion

        #region Methods
        public void InsertArobicExercise()
        {
            foreach (ListViewItem lstExercise in lstArobicExercise.Items)
            {
                AssignExercise objAssignExercise = new AssignExercise();
                objAssignExercise.memberId = Convert.ToInt64(ddlMembers.SelectedValue);
                objAssignExercise.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
                TextBox res = (TextBox)lstExercise.FindControl("txtResistence");
                objAssignExercise.Resistence = res.Text;
                TextBox dis = (TextBox)lstExercise.FindControl("txtDuration");
                objAssignExercise.Distance = dis.Text;
                TextBox rpm = (TextBox)lstExercise.FindControl("txtRPM");
                objAssignExercise.RPM = rpm.Text;
                TextBox cal = (TextBox)lstExercise.FindControl("txtCalories");
                objAssignExercise.Calories = cal.Text;
                TextBox dur = (TextBox)lstExercise.FindControl("txtDuration");
                objAssignExercise.duration = dur.Text;
                HiddenField hfCardid = (HiddenField)lstExercise.FindControl("hfACardId");
                objAssignExercise.exerciseCardMasterId = Convert.ToInt64(hfCardid.Value);
                objAssignExercise = new ExerciseController().InsertAssignExercise(objAssignExercise);
            }
        }
        public void InsertNonArobiExercise()
        {
            foreach (ListViewItem lstNAExercise in lstNonArobicExercise.Items)
            {
                AssignExercise objAssignExercise = new AssignExercise();

                objAssignExercise.memberId = Convert.ToInt64(ddlMembers.SelectedValue);
                objAssignExercise.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
                objAssignExercise.levelId = Convert.ToInt32(ddlLevel.SelectedValue);
                HiddenField hfNACardId = (HiddenField)lstNAExercise.FindControl("hfNACardId");
                objAssignExercise.exerciseCardMasterId = Convert.ToInt64(hfNACardId.Value);
                TextBox set1 = (TextBox)lstNAExercise.FindControl("txtSet1");
                objAssignExercise.set1 = set1.Text;
                TextBox set2 = (TextBox)lstNAExercise.FindControl("txtSet2");
                objAssignExercise.set2 = set2.Text;
                TextBox set3 = (TextBox)lstNAExercise.FindControl("txtSet3");
                objAssignExercise.set3 = set3.Text;
                TextBox set4 = (TextBox)lstNAExercise.FindControl("txtSet4");
                objAssignExercise.set4 = set4.Text;
                objAssignExercise = new ExerciseController().InsertAssignExercise(objAssignExercise);
            }
        }
        //public void UpdateArobicExercise()
        //{
        //    foreach (ListViewItem lstExercise in lstArobicExercise.Items)
        //    {
        //        AssignExercise objAssignExercise = new AssignExercise();
        //        objAssignExercise.memberId = Convert.ToInt64(ddlMembers.SelectedValue);
        //        objAssignExercise.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
        //        TextBox res = (TextBox)lstExercise.FindControl("txtResistence");
        //        objAssignExercise.Resistence = res.Text;
        //        TextBox dis = (TextBox)lstExercise.FindControl("txtDuration");
        //        objAssignExercise.Distance = dis.Text;
        //        TextBox rpm = (TextBox)lstExercise.FindControl("txtRPM");
        //        objAssignExercise.RPM = rpm.Text;
        //        TextBox cal = (TextBox)lstExercise.FindControl("txtCalories");
        //        objAssignExercise.Calories = cal.Text;
        //        TextBox dur = (TextBox)lstExercise.FindControl("txtDuration");
        //        objAssignExercise.duration = dur.Text;
        //        //HiddenField hfCardid = (HiddenField)lstExercise.FindControl("hfACardId");
        //        //objAssignExercise.exerciseCardMasterId = Convert.ToInt64(hfCardid.Value);
        //        objAssignExercise = new ExerciseController().UpdateAssignExercise(objAssignExercise);
        //    }

        //}
        //public void UpdateNonArobiExercise()
        //{
        //    foreach (ListViewItem lstNAExercise in lstNonArobicExercise.Items)
        //    {
        //        AssignExercise objAssignExercise = new AssignExercise();

        //        objAssignExercise.memberId = Convert.ToInt64(ddlMembers.SelectedValue);
        //        objAssignExercise.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
        //        objAssignExercise.levelId = Convert.ToInt32(ddlLevel.SelectedValue);
        //        TextBox set1 = (TextBox)lstNAExercise.FindControl("txtSet1");
        //        objAssignExercise.set1 = set1.Text;
        //        TextBox set2 = (TextBox)lstNAExercise.FindControl("txtSet2");
        //        objAssignExercise.set2 = set2.Text;
        //        TextBox set3 = (TextBox)lstNAExercise.FindControl("txtSet3");
        //        objAssignExercise.set3 = set3.Text;
        //        TextBox set4 = (TextBox)lstNAExercise.FindControl("txtSet4");
        //        objAssignExercise.set4 = set4.Text;
        //        objAssignExercise = new ExerciseController().UpdateAssignExercise(objAssignExercise);
        //    }
        //}

        public void PanelVisibility(bool view, bool Edit)
        {
            try
            {
                pnlView.Visible = view;
                pnlEdit.Visible = Edit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindGrid()
        {
            grdExersice.DataSource = ExerciseController.GetMembersFromAssignExercise(txtSearchText.Text, LoginUser.ClubId);
            grdExersice.DataBind();
        }
        public void BindGridDetails()
        {
            grdDetailsExercise.DataSource = ExerciseController.GetAssignExerciseByMemberId(MemberId);
            grdDetailsExercise.DataBind();

        }
        public void BindMembers()
        {
            try
            {
                ddlMembers.DataSource = ExerciseController.GetMembersByLeadID(LoginUser.ClubId);
                ddlMembers.DataTextField = "MembersName";
                ddlMembers.DataValueField = "ID";
                ddlMembers.DataBind();
                ddlMembers.Items.Insert(0, new ListItem("Select Member", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindNonArobicExerciseListView()
        {
            lstNonArobicExercise.DataSource = ExerciseController.GetNonArobicExercise(BodyType, LevelId, 0, LoginUser.ClubId);
            lstNonArobicExercise.DataBind();
        }
        private void BindArobicExerciseListView()
        {
            lstArobicExercise.DataSource = ExerciseController.GetArobicExercise(BodyType, 0, LoginUser.ClubId);
            lstArobicExercise.DataBind();
        }
        private void BindAssignExerciseValues()
        {
            try
            {
                var objAssignExercise = ExerciseController.GetAssignExrciseByMember(MemberId);

                ddlMembers.SelectedValue = MemberId.ToString();
                BodyType = objAssignExercise[0].bodyTypeId.Value;

                ddlBodyType.SelectedValue = objAssignExercise[0].bodyTypeId.ToString();
                var lstNonArobicExercises = objAssignExercise.Where(x => x.ExerciseCardMaster.exerciseTypeId == 2).ToList();
                ddlLevel.SelectedValue = lstNonArobicExercises[0].levelId == null ? "0" : lstNonArobicExercises[0].levelId.ToString();
                LevelId = lstNonArobicExercises[0].levelId.Value;

                lstArobicExercise.DataSource = ExerciseController.GetArobicExercise(BodyType, MemberId, LoginUser.ClubId);
                lstArobicExercise.DataBind();

                lstNonArobicExercise.DataSource = ExerciseController.GetNonArobicExercise(BodyType, LevelId, MemberId, LoginUser.ClubId);
                lstNonArobicExercise.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ClearValues()
        {
            ddlMembers.SelectedIndex = 0;
            ddlBodyType.SelectedValue = "0";
            ddlLevel.SelectedValue = "0";
            lblErrorMsg.Text = "";
            grdDetailsExercise.Visible = false;
            foreach (ListViewDataItem item in lstArobicExercise.Items)
            {
                foreach (Control ctrl in item.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = "";
                }
            }
            foreach (ListViewDataItem item in lstNonArobicExercise.Items)
            {
                foreach (Control ctrl in item.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = "";
                }
            }
            pnlArobic.Visible = pnlNonArobic.Visible = grdDetailsExercise.Visible = false;

        }

        #endregion
    }
}