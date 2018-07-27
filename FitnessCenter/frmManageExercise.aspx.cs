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
    public partial class frmManageExercise : System.Web.UI.Page
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
        //public long ExerciseId
        //{
        //    get
        //    {
        //        var obj = ViewState["ExerciseId"];
        //        return obj == null ? 0 : (long)obj;
        //    }
        //    set
        //    {
        //        ViewState["ExerciseId"] = value;
        //    }
        //}
        public List<ExrciseCardLevelSet> lstExrciseCardLevelSet
        {
            get
            {
                var obj = Session["lstExrciseCardLevelSet"];
                return obj == null ? null : (List<ExrciseCardLevelSet>)obj;
            }
            set
            {
                Session["lstExrciseCardLevelSet"] = value;
            }
        }

        public string SetLevelMode
        {
            get
            {
                var obj = ViewState["SetLevelMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["SetLevelMode"] = value;
            }
        }

        public string SetExerciseMode
        {
            get
            {
                var obj = ViewState["SetExerciseMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["SetExerciseMode"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser == null)
                Response.Redirect("~/frmLogin.aspx");

            if (!IsPostBack)
            {
                BindExercise();
                ArobicNonArobicVisibility(false, false, false);
                NonArobicPanelVisibility(false, false);
                PanelVisibility(true, false);
            }
        }

        #region Events

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindExercise();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlExerciseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.SelectExerciseType)
            {
                pnlArobic.Visible = false;
                pnlNonArobic.Visible = false;
                PanelVisibility(false, true);
            }
            else if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.ArobicExercise)
            {
                ArobicNonArobicVisibility(true, false, false);
            }
            else
                ArobicNonArobicVisibility(false, true, false);
        }

        protected void btnAddExercise_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                BindTempLevels();
                SetExerciseMode = "Insert";
                PanelVisibility(false, true);
                pnlArobic.Visible = false;
                pnlNonArobic.Visible = false;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNonArobicExercise_Click(object sender, EventArgs e)
        {
            try
            {

                txtSet1.Text = "";
                txtSet2.Text = "";
                txtSet3.Text = "";
                txtSet4.Text = "";
                ArobicNonArobicVisibility(false, false, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void grdExercise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdExercise.PageIndex = e.NewPageIndex;
                BindExercise();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdExercise_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditExercise")
                {
                    SetExerciseMode = "Update";
                    PanelVisibility(false, true);
                    ExerciseCardMasterId = Convert.ToInt64(e.CommandArgument);
                    BindExerciseCardValues();
                }
                else if (e.CommandName == "DeleteExercise")
                {
                    int ExerciseMasterId = Convert.ToInt32(e.CommandArgument);
                    new ExerciseController().DeleteExerciseMaster(ExerciseMasterId);
                    int ExerciseCardMasterId = Convert.ToInt32(e.CommandArgument);
                    new ExerciseController().DeleteExerciseCardMaster(ExerciseCardMasterId);
                    BindExercise();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdLevelSets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteLevel")
                {
                    int ExrciseCardLevelSetId = Convert.ToInt32(e.CommandArgument);

                    //new ExerciseController().DeleteExrciseCardLevelSet(ExrciseCardLevelSetId, ExerciseCardMasterId);

                    var obj = lstExrciseCardLevelSet.FirstOrDefault(x => x.levelId == ExrciseCardLevelSetId);
                    lstExrciseCardLevelSet.Remove(obj);
                    BindTempLevels();
                    //BindExerciseCardValues();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSaveNonArobicExercise_Click(object sender, EventArgs e)
        {
            try
            {
                InsertNonArobicExercise();
                BindTempLevels();
                ArobicNonArobicVisibility(false, true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelNonArobicExercise_Click(object sender, EventArgs e)
        {
            try
            {
                ArobicNonArobicVisibility(false, true, false);
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
                if (SetExerciseMode == "Insert")
                {
                    InsertExerciseCard();
                }
                else
                    UpdateExerciseCard();
                ClearValues();
                BindExercise();
                PanelVisibility(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateExerciseCard()
        {
            try
            {
                // Update Logic Pending Need to write by mobin
                ExerciseMaster objExerciseMaster = ExerciseController.GetExerciseMastersByID(ExerciseMasterId);
                objExerciseMaster.exerciseName = txtExerciseName.Text;
                objExerciseMaster.exerciseTypeId = Convert.ToInt32(ddlExerciseType.SelectedValue);
                objExerciseMaster.isPersonalTrainingPackAllow = chkIsPTP.Checked;
                objExerciseMaster = new ExerciseController().UpdateExerciseMaster(objExerciseMaster);

                ExerciseCardMaster objExerciseCardMaster = ExerciseController.GetExerciseCardMastersByID(ExerciseCardMasterId);
                objExerciseCardMaster.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
                objExerciseMaster.exerciseTypeId = Convert.ToInt32(ddlExerciseType.SelectedValue);
                objExerciseCardMaster.isActive = true;
                objExerciseCardMaster.exerciseId = objExerciseMaster.ID;
                if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.ArobicExercise)
                {
                    objExerciseCardMaster.RPM = txtRPM.Text;
                    objExerciseCardMaster.duration = txtDuration.Text;
                    objExerciseCardMaster.Calories = txtCalories.Text;
                    objExerciseCardMaster.Resistence = txtResistence.Text;
                    objExerciseCardMaster.Distance = txtDistance.Text;
                }
                objExerciseCardMaster = new ExerciseController().UpdateExerciseCardMaster(objExerciseCardMaster);

                if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.NonArobicExercise)
                {
                    // delete old ExerciseCardLevelSets
                    new ExerciseController().DeleteAllExrciseCardLevelSets(ExerciseCardMasterId);

                    foreach (var obj in lstExrciseCardLevelSet)
                    {

                        ExrciseCardLevelSet objE = new ExrciseCardLevelSet(); //ExerciseController.GetExrciseCardLevelSetsByCardID(ExerciseCardMasterId);
                        objE.levelId = obj.levelId;
                        objE.set1 = obj.set1;
                        objE.set2 = obj.set2;
                        objE.set3 = obj.set3;
                        objE.set4 = obj.set4;
                        objE.exrciseCardId = objExerciseCardMaster.ID;
                        new ExerciseController().InsertExrciseCardLevelSet(objE);



                        // insert new updated ExerciseCardLevelSets
                        //  InsertExerciseCard();
                    }
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void InsertExerciseCard()
        {
            try
            {
                if (SetExerciseMode == "Insert")
                {
                    ExerciseMaster objExerciseMaster = new ExerciseMaster();
                    objExerciseMaster.exerciseName = txtExerciseName.Text;
                    objExerciseMaster.exerciseTypeId = Convert.ToInt32(ddlExerciseType.SelectedValue);
                    objExerciseMaster.isPersonalTrainingPackAllow = chkIsPTP.Checked;
                    objExerciseMaster.clubId = LoginUser.ClubId;
                    objExerciseMaster = new ExerciseController().InsertExerciseMaster(objExerciseMaster);

                    ExerciseCardMaster objExerciseCardMaster = new ExerciseCardMaster();
                    objExerciseCardMaster.bodyTypeId = Convert.ToInt32(ddlBodyType.SelectedValue);
                    objExerciseCardMaster.exerciseTypeId = Convert.ToInt32(ddlExerciseType.SelectedValue);
                    objExerciseCardMaster.isActive = true;
                    objExerciseCardMaster.exerciseId = objExerciseMaster.ID;
                    if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.ArobicExercise)
                    {
                        objExerciseCardMaster.RPM = txtRPM.Text;
                        objExerciseCardMaster.duration = txtDuration.Text;
                        objExerciseCardMaster.Calories = txtCalories.Text;
                        objExerciseCardMaster.Resistence = txtResistence.Text;
                        objExerciseCardMaster.Distance = txtDistance.Text;
                    }
                    objExerciseCardMaster = new ExerciseController().InsertExerciseCardMaster(objExerciseCardMaster);

                    if (Convert.ToInt32(ddlExerciseType.SelectedValue) == (int)EnumExerciseType.NonArobicExercise)
                    {
                        foreach (var obj in lstExrciseCardLevelSet)
                        {
                            ExrciseCardLevelSet objE = new ExrciseCardLevelSet();
                            objE.levelId = obj.levelId;
                            objE.set1 = obj.set1;
                            objE.set2 = obj.set2;
                            objE.set3 = obj.set3;
                            objE.set4 = obj.set4;
                            objE.exrciseCardId = objExerciseCardMaster.ID;
                            new ExerciseController().InsertExrciseCardLevelSet(objE);

                        }
                    }
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
        }

        #endregion

        #region Methods

        private void BindExercise()
        {
            try
            {
                grdExercise.DataSource = ExerciseController.GetExerciseMaster_Result(txtSearchText.Text, LoginUser.ClubId);
                grdExercise.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindTempLevels()
        {
            try
            {
                grdLevelSets.DataSource = lstExrciseCardLevelSet;
                grdLevelSets.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValues()
        {
            try
            {
                txtCalories.Text = txtDuration.Text = txtExerciseName.Text = txtResistence.Text = txtRPM.Text = txtDistance.Text = string.Empty;
                ddlExerciseType.SelectedValue = "0";
                lstExrciseCardLevelSet = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PanelVisibility(bool View, bool Edit)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ArobicNonArobicVisibility(bool Arobic, bool NonErobicView, bool NonArobicEdit)
        {
            try
            {
                if (Arobic)
                {
                    pnlArobic.Visible = true;
                    pnlNonArobic.Visible = false;
                }
                else
                {
                    pnlArobic.Visible = false;
                    pnlNonArobic.Visible = true;
                    if (NonErobicView)
                    {
                        pnlNonArobicView.Visible = true;
                        pnlNonArobicEdit.Visible = false;
                    }
                    else if (NonArobicEdit)
                    {
                        pnlNonArobicView.Visible = false;
                        pnlNonArobicEdit.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NonArobicPanelVisibility(bool NonArobicView, bool NonArobicEdit)
        {
            try
            {
                pnlNonArobicView.Visible = NonArobicView;
                pnlNonArobicEdit.Visible = NonArobicEdit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InsertNonArobicExercise()
        {
            try
            {
                var obj = lstExrciseCardLevelSet;
                ExrciseCardLevelSet temp = new ExrciseCardLevelSet();
                if (obj == null)
                    obj = new List<ExrciseCardLevelSet>();

                // For checking same level record exists or not
                if (lstExrciseCardLevelSet != null && lstExrciseCardLevelSet.Count > 0)
                {
                    var objIsRecordExistForSameLevel = lstExrciseCardLevelSet.FirstOrDefault(x => x.levelId == Convert.ToInt32(ddlLevels.SelectedValue) && x.isDeleted == false);
                    if (objIsRecordExistForSameLevel == null)
                    {

                        temp.levelId = Convert.ToInt32(ddlLevels.SelectedValue);
                        temp.set1 = txtSet1.Text;
                        temp.set2 = txtSet2.Text;
                        temp.set3 = txtSet3.Text;
                        temp.set4 = txtSet4.Text;
                        obj.Add(temp);
                        lstExrciseCardLevelSet = obj;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','This Level Set Already Exist')", true);
                }
                else
                {
                    temp.levelId = Convert.ToInt32(ddlLevels.SelectedValue);
                    temp.set1 = txtSet1.Text;
                    temp.set2 = txtSet2.Text;
                    temp.set3 = txtSet3.Text;
                    temp.set4 = txtSet4.Text;
                    obj.Add(temp);
                    lstExrciseCardLevelSet = obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindExerciseCardValues()
        {
            try
            {
                ExerciseCardMaster objExerciseCardMaster = ExerciseController.GetExerciseCardMastersByID(ExerciseCardMasterId);
                var lstSetLevels = ExerciseController.GetExrciseCardLevelSetsByExerciseCardMaterId(ExerciseCardMasterId);
                List<ExrciseCardLevelSet> lstTemp = new List<ExrciseCardLevelSet>();

                foreach (var obj in lstSetLevels)
                {
                    ExrciseCardLevelSet objE = new ExrciseCardLevelSet();
                    objE.levelId = obj.levelId;
                    objE.set1 = obj.set1;
                    objE.set2 = obj.set2;
                    objE.set3 = obj.set3;
                    objE.set4 = obj.set4;
                    lstTemp.Add(objE);
                }
                lstExrciseCardLevelSet = lstTemp;

                BindTempLevels();


                txtCalories.Text = objExerciseCardMaster.Calories;
                txtDuration.Text = objExerciseCardMaster.duration;
                txtExerciseName.Text = objExerciseCardMaster.ExerciseMaster.exerciseName;
                txtResistence.Text = objExerciseCardMaster.Resistence;
                txtRPM.Text = objExerciseCardMaster.RPM;
                txtDistance.Text = objExerciseCardMaster.Distance;
                ddlBodyType.SelectedValue = objExerciseCardMaster.bodyTypeId == null ? "1" : objExerciseCardMaster.bodyTypeId.ToString();
                ddlExerciseType.SelectedValue = objExerciseCardMaster.exerciseTypeId == null ? "1" : objExerciseCardMaster.exerciseTypeId.ToString();
                ExerciseMasterId = (long)objExerciseCardMaster.exerciseId;
                if (objExerciseCardMaster.exerciseTypeId == (int)EnumExerciseType.ArobicExercise)
                {
                    pnlArobic.Visible = true;
                    pnlNonArobic.Visible = false;
                }

                else
                {
                    pnlNonArobic.Visible = true;
                    pnlArobic.Visible = false;
                    pnlNonArobicView.Visible = true;
                    pnlNonArobicEdit.Visible = false;

                }


                BindTempLevels();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}