using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.Net;
using System.Net.Mail;


namespace FitnessCenter
{
    public partial class Desclaimer : System.Web.UI.Page
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

        public string CLUBID
        {
            get
            {
                var obj = ViewState["CLUBID"];
                return obj == null ? "ID" : (string)obj;
            }
            set
            {
                ViewState["CLUBID"] = value;
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
        public long DisclaimerId
        {
            get
            {
                var obj = ViewState["DisclaimerId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["DisclaimerId"] = value;
            }
        }
        public int DisID
        {
            get
            {
                var obj = ViewState["DisID"];
                return obj == null ? 0 : (int)obj;

            }
            set
            {
                ViewState["DisID"] = value;
            }
        }

        public long MeasurementId
        {
            get
            {
                var obj = ViewState["MeasurementId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["MeasurementId"] = value;
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

        public long RFIDNum
        {
            get
            {
                var obj = ViewState["RFIDNum"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["RFIDNum"] = value;
            }
        }
        public long RFIDNumber
        {
            get
            {
                var obj = ViewState["RFIDNumber"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["RFIDNumber"] = value;
            }
        }

        public string MeasurementMode
        {
            get
            {
                var obj = ViewState["MeasurementMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["MeasurementMode"] = value;
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
            try
            {
                if (!IsPostBack)
                {
                    PanelVisibility(true, false, false);
                    MeasurementPanelVisibility(true, false);
                    pnlLeadsDetails.Visible = false;
                    BindQuestions();
                    //updtpnl1.Visible = false;
                    //Pnlnext1.Visible = true;
                    //pnlSave.Visible = false;
                    //pnlOffice.Visible = false;
                    BindGrid();
                    BindMeasurement();
                    //pnlDisclaimerDetails.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
        protected void btnEntrySearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindDiscalimersDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdDisclaimersForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                PanelVisibility(false, true, false);
                BindQuestions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //protected void btnNext1_Click(object sender, EventArgs e)

        protected void Details()
        {
            Membership objMember = DesclaimerController.GetDisclaimerByRFIDNo(MemberId);
            Lead objLead = LeadController.GetLeadById(objMember.LeadId);
            DateTime dob;
            int age = 0;
            txtRFIDCardNumber.Text = objMember.RFIDCardNumber;
            dob = (DateTime)objLead.dateOfBirth;
            age = DateTime.Now.Year;
            age = age - dob.Year;
            txtAge.Text = Convert.ToString(age);
            txtDate.Text = Convert.ToString(objLead.insertDate).Substring(0, 10);
            txtName.Text = objLead.firstName;
            txtRegNumber.Text = Convert.ToString(objMember.AgreementNo);
            txtAddress.Text = objLead.address;
            txtCity.Text = objLead.city;
            txtEmail.Text = objLead.Email;
            txtMobileNumber.Text = objLead.mobileNumber;
            txtSex.Text = objLead.gender;
            lblAgreeNum.Text = objMember.AgreementNo;
            lblTitle.Text = objMember.Title + " " + objLead.firstName + " " + objLead.lastName + " ";
            pnlLeadsDetails.Visible = true;
            updtpnl1.Visible = true;
            MeasurementPanelVisibility(true, false);
            pnlOffice.Visible = true;
            pnlLeadsDetails.Visible = true;
            updtpnl1.Visible = true;
            Pnlnext1.Visible = false;
            pnlSave.Visible = true;
            Disclaimer objDis = DesclaimerController.GetDisclaimerByMemberId(MemberId);
            txtRFIDCardNumber.Text = objMember.RFIDCardNumber;
            txtDate.Text = Convert.ToString(DateTime.Now).Substring(0, 10);
            if (objDis == null)
            {
                txtHeight.Text = "";
                txtWeight.Text = "";
                txtFrameSize.Text = "";
                txtName1.Text = "";
                txtRelation1.Text = "";
                txtMobileno1.Text = "";
                txtLandline1.Text = "";
                txtArea1.Text = "";
                txtName2.Text = "";
                txtRelation2.Text = "";
                txtMobileno2.Text = "";
                txtLandline2.Text = "";
                txtArea2.Text = "";
                txtName3.Text = "";
                txtRelation3.Text = "";
                txtMobileno3.Text = "";
                txtLandline3.Text = "";
                txtArea3.Text = "";
                txtFamDocName.Text = "";
                txtFamDocNo.Text = "";
            }
            else
            {
                txtHeight.Text = objDis.height;
                txtWeight.Text = objDis.weight;
                txtFrameSize.Text = objDis.frameSize;
                txtName1.Text = objDis.emergencyRefName1;
                txtRelation1.Text = objDis.emergencyRefRelationship1;
                txtMobileno1.Text = objDis.emergencyRefMobNo1;
                txtLandline1.Text = objDis.emergencyRefLandLineNo1;
                txtArea1.Text = objDis.emeregencyArea1;
                txtName2.Text = objDis.emergencyRefName2;
                txtRelation2.Text = objDis.emergencyRefRelationship2;
                txtMobileno2.Text = objDis.emergencyRefMobNo2;
                txtLandline2.Text = objDis.emergencyRefLandLineNo2;
                txtArea2.Text = objDis.emeregencyArea2;
                txtName3.Text = objDis.emergencyRefName3;
                txtRelation3.Text = objDis.emergencyRefRelationship3;
                txtMobileno3.Text = objDis.emergencyRefMobNo3;
                txtLandline3.Text = objDis.emergencyRefLandLineNo3;
                txtArea3.Text = objDis.emeregencyArea3;
                txtFamDocName.Text = objDis.familyDoctorName;
                txtFamDocNo.Text = objDis.familyDoctorMobileNumber;



                // new DesclaimerController().UpdateDisclaimer(objDis);

                //BindQuestions();
            }
        }

        protected void grdDisclaimerDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdDisclaimerDetails.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdDisclaimerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteDisclaimerEntry")
            {

                int DisID = Convert.ToInt32(e.CommandArgument);
                new DesclaimerController().DeleteDisclaimerEntry(DisID);
                BindDiscalimersDetails();

            }

        }

        protected void grdDisclaimerDetails_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdDisclaimersForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdDisclaimersForm.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdDisclaimersForm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditDisclaimerForm")
                {

                    MemberId = Convert.ToInt64(e.CommandArgument);
                    //BindDiscalimerValues();
                    Mode = "Update";
                    //BindDiscalimerValues();
                    Details();
                    pnlLeadsDetails.Visible = true;
                    MeasurementPanelVisibility(true, false);
                    updtpnl1.Visible = true;
                    pnlOffice.Visible = true;
                    pnlSave.Visible = true;
                    PanelVisibility(false, true, false);
                    BindMeasurement();

                    //DisclaimerId = Convert.ToInt32(e.CommandArgument);
                    //Mode = "Insert";
                    //BindDiscalimerValues();
                    //// Details();
                    //pnlLeadsDetails.Visible = true;
                    //MeasurementPanelVisibility(true, false);
                    //updtpnl1.Visible = true;
                    //pnlOffice.Visible = true;
                    //pnlSave.Visible = true;
                    //PanelVisibility(false, true);
                    //BindMeasurement();
                }
                if (e.CommandName == "DeleteDisclaimerForm")
                {

                    int memberId = Convert.ToInt32(e.CommandArgument);
                    new DesclaimerController().DeleteDisclaimer(MemberId);
                    BindGrid();

                }
                else if (e.CommandName == "DetailDesclaimerForm")
                {
                    MemberId = Convert.ToInt64(e.CommandArgument);
                    //pnlDisclaimerDetails.Visible = true;
                    PanelVisibility(true, false, true);
                    BindDiscalimersDetails();

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
                //if (Mode == "Insert")
                //{
                InsertDisclaimer();
                if (ManageMemberShip.CheckForInternetConnection())
                    SendEmail();
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Check Youur Internet Connection')", true);
                BindGrid();
                //}
                //else
                //    UpdateDisclaimer();
                ClearValues();
                pnlLeadsDetails.Visible = false;
                MeasurementPanelVisibility(false, false);
                updtpnl1.Visible = false;
                pnlOffice.Visible = false;
                pnlSave.Visible = false;
                PanelVisibility(true, false, false);
                //BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdDisclaimersForm_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                MeasurementPanelVisibility(false, false);
                updtpnl1.Visible = false;
                pnlLeadsDetails.Visible = false;
                pnlOffice.Visible = false;
                pnlSave.Visible = false;
                PanelVisibility(true, false, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BMIClick_Click(object sender, EventArgs e)
        {
            try
            {
                int mw;
                decimal mh, b;
                mw = Convert.ToInt32(txtMWeight.Text);
                mh = Convert.ToDecimal(txtMHeight.Text);

                mh = mh * mh;
                b = mw / mh;
                txtBMi.Text = b.ToString("#.##");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Methods

        public void SendEmail()
        {
            try
            {
                string from = "info@intensity.net.in"; //example:- sourabh9303@gmail.com
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Promotion Mail";
                mail.Body = "Your Disclaimer Details Here";

                List<MeasurementMaster> objMsr = DesclaimerController.GetMemberByMemberId(MemberId).ToList();

                foreach (var item in objMsr)
                {
                    mail.Body += "\nWEIGHT :- " + item.WEIGHT;
                    mail.Body += "\nHEIGHT :- " + item.HEIGHT;
                    mail.Body += "\nFAT :- " + item.FAT;
                    mail.Body += "\nBMI :- " + item.BMI;
                }

                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("intensity.net.in", 587);
                smtp.EnableSsl = false;
                smtp.Credentials = new System.Net.NetworkCredential("info@intensity.net.in", "info@123");
                smtp.Send(mail);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindGrid()
        {
            try
            {
                grdDisclaimersForm.DataSource = DesclaimerController.GetMembers(LoginUser.ClubId, txtSearchText.Text, SortField, SortDir);
                grdDisclaimersForm.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindDiscalimersDetails()
        {
            try
            {
                grdDisclaimerDetails.DataSource = DesclaimerController.GetDisclaimerEntry(LoginUser.ClubId, MemberId, SortField, SortDir);
                grdDisclaimerDetails.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void PanelVisibility(bool View, bool Edit, bool Details)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
                pnlDisclaimerDetails.Visible = Details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertDisclaimer()
        {
            try
            {
                Disclaimer objDis = new Disclaimer();
                Membership objMember = new Membership();

                objDis.memberId = MemberId;
                objDis.clubId = LoginUser.ClubId;
                objDis.RFIDNo = txtRFIDCardNumber.Text;
                objDis.date = DateTime.Now;
                objDis.height = txtHeight.Text;
                objDis.weight = txtWeight.Text;
                objDis.frameSize = txtFrameSize.Text;
                objDis.emergencyRefName1 = txtName1.Text;
                objDis.emergencyRefRelationship1 = txtRelation1.Text;
                objDis.emergencyRefMobNo1 = txtMobileno1.Text;
                objDis.emergencyRefLandLineNo1 = txtLandline1.Text;
                objDis.emeregencyArea1 = txtArea1.Text;
                objDis.emergencyRefName2 = txtName2.Text;
                objDis.emergencyRefRelationship2 = txtRelation2.Text;
                objDis.emergencyRefMobNo2 = txtMobileno2.Text;
                objDis.emergencyRefLandLineNo2 = txtLandline2.Text;
                objDis.emeregencyArea2 = txtArea2.Text;
                objDis.emergencyRefName3 = txtName3.Text;
                objDis.emergencyRefRelationship3 = txtRelation3.Text;
                objDis.emergencyRefMobNo3 = txtMobileno3.Text;
                objDis.emergencyRefLandLineNo3 = txtLandline3.Text;
                objDis.emeregencyArea3 = txtArea3.Text;
                objDis.familyDoctorName = txtFamDocName.Text;
                objDis.familyDoctorMobileNumber = txtFamDocNo.Text;

                objDis = new DesclaimerController().InsertDisclaimer(objDis);
                InsertDisclaimerQuestionAnswers(objDis);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateDisclaimer()
        {
            // Disclaimer objDisc = new Disclaimer();
            Disclaimer objDisc = DesclaimerController.GetDisclaimerByMemberId(MemberId);

            objDisc.clubId = LoginUser.ClubId;
            objDisc.memberId = MemberId;
            objDisc.RFIDNo = txtRFIDCardNumber.Text;
            objDisc.date = DateTime.Now;
            objDisc.height = txtHeight.Text;
            objDisc.weight = txtWeight.Text;
            objDisc.frameSize = txtFrameSize.Text;
            objDisc.emergencyRefName1 = txtName1.Text;
            objDisc.emergencyRefRelationship1 = txtRelation1.Text;
            objDisc.emergencyRefMobNo1 = txtMobileno1.Text;
            objDisc.emergencyRefLandLineNo1 = txtLandline1.Text;
            objDisc.emeregencyArea1 = txtArea1.Text;
            objDisc.emergencyRefName2 = txtName2.Text;
            objDisc.emergencyRefRelationship2 = txtRelation2.Text;
            objDisc.emergencyRefMobNo2 = txtMobileno2.Text;
            objDisc.emergencyRefLandLineNo2 = txtLandline2.Text;
            objDisc.emeregencyArea2 = txtArea2.Text;
            objDisc.emergencyRefName3 = txtName3.Text;
            objDisc.emergencyRefRelationship3 = txtRelation3.Text;
            objDisc.emergencyRefMobNo3 = txtMobileno3.Text;
            objDisc.emergencyRefLandLineNo3 = txtLandline3.Text;
            objDisc.emeregencyArea3 = txtArea3.Text;
            objDisc.familyDoctorName = txtFamDocName.Text;
            objDisc.familyDoctorMobileNumber = txtFamDocNo.Text;

            objDisc = new DesclaimerController().UpdateDisclaimer(objDisc);
            new DisclaimerQuestionController().DeleteAllDisclaimerQuestionAnswerByDisclaimerId(objDisc.ID);

            InsertDisclaimerQuestionAnswers(objDisc);
        }
        private void BindDiscalimerValues()
        {
            Membership objMember = DesclaimerController.GetDisclaimerByRFIDNo(RFIDNumber);
            Disclaimer objDis = DesclaimerController.GetDisclaimerByMemberId(MemberId);
            txtRFIDCardNumber.Text = objDis.RFIDNo;
            objDis.date = UtillController.ConvertDateTime(Convert.ToDateTime(txtDate.Text).ToString().Substring(0, 10));
            txtHeight.Text = objDis.height;
            txtWeight.Text = objDis.weight;
            txtFrameSize.Text = objDis.frameSize;
            txtName1.Text = objDis.emergencyRefName1;
            txtRelation1.Text = objDis.emergencyRefRelationship1;
            txtMobileno1.Text = objDis.emergencyRefMobNo1;
            txtLandline1.Text = objDis.emergencyRefLandLineNo1;
            txtArea1.Text = objDis.emeregencyArea1;
            txtName2.Text = objDis.emergencyRefName2;
            txtRelation2.Text = objDis.emergencyRefRelationship2;
            txtMobileno2.Text = objDis.emergencyRefMobNo2;
            txtLandline2.Text = objDis.emergencyRefLandLineNo2;
            txtArea2.Text = objDis.emeregencyArea2;
            txtName3.Text = objDis.emergencyRefName3;
            txtRelation3.Text = objDis.emergencyRefRelationship3;
            txtMobileno3.Text = objDis.emergencyRefMobNo3;
            txtLandline3.Text = objDis.emergencyRefLandLineNo3;
            txtArea3.Text = objDis.emeregencyArea3;
            txtFamDocName.Text = objDis.familyDoctorName;
            txtFamDocNo.Text = objDis.familyDoctorMobileNumber;
            new DesclaimerController().UpdateDisclaimer(objDis);
        }
        private void ClearValues()
        {
            txtHeight.Text = txtWeight.Text = txtFrameSize.Text = txtName1.Text =
                txtName2.Text = txtName3.Text = txtRelation1.Text = txtRelation2.Text =
                txtRelation3.Text = txtMobileno1.Text = txtMobileno2.Text = txtMobileno3.Text =
                txtLandline1.Text = txtLandline2.Text = txtLandline3.Text = txtArea1.Text =
                txtArea2.Text = txtArea3.Text = txtFamDocName.Text = txtFamDocNo.Text = string.Empty;
        }
        private void InsertDisclaimerQuestionAnswers(Disclaimer objDis)
        {
            try
            {
                //insert Question Answer....
                foreach (ListViewItem lstQuestionList in lstQuestions.Items)
                {
                    //hdnFldQuestionId,hdnFldQuestionTypeId,txtQuestionAnswer,lstQuestionOptions
                    HiddenField hdnFldQuestionId = (HiddenField)lstQuestionList.FindControl("hdnFldQuestionId");
                    HiddenField hdnFldQuestionTypeId = (HiddenField)lstQuestionList.FindControl("hdnFldQuestionTypeId");
                    TextBox txtQuestionAnswer = (TextBox)lstQuestionList.FindControl("txtQuestionAnswer");
                    ListView lstQuestionOptions = (ListView)lstQuestionList.FindControl("lstQuestionOptions");

                    if (Convert.ToInt32(hdnFldQuestionTypeId.Value) == 1) // single type
                    {
                        DisclaimerQuestionAnswer objDisQueAnswer = new DisclaimerQuestionAnswer();
                        objDisQueAnswer.disclaimerId = objDis.ID;
                        objDisQueAnswer.questionId = Convert.ToInt64(hdnFldQuestionId.Value);
                        objDisQueAnswer.answerText = txtQuestionAnswer.Text;
                        objDisQueAnswer = new DisclaimerQuestionController().InsertDisclaimerQuestionAnswer(objDisQueAnswer);
                    }
                    else if (Convert.ToInt32(hdnFldQuestionTypeId.Value) == 2)// multi type
                    {
                        foreach (ListViewItem lstOptionList in lstQuestionOptions.Items)
                        {
                            //hdnFldOptionId,chkOptions
                            HiddenField hdnFldOptionId = (HiddenField)lstOptionList.FindControl("hdnFldOptionId");
                            CheckBox chkOptions = (CheckBox)lstOptionList.FindControl("chkOptions");
                            if (chkOptions.Checked)
                            {
                                DisclaimerQuestionAnswer objDisQueAnswer = new DisclaimerQuestionAnswer();
                                objDisQueAnswer.disclaimerId = objDis.ID;
                                objDisQueAnswer.questionId = Convert.ToInt64(hdnFldQuestionId.Value);
                                objDisQueAnswer.optionId = Convert.ToInt64(hdnFldOptionId.Value);
                                objDisQueAnswer = new DisclaimerQuestionController().InsertDisclaimerQuestionAnswer(objDisQueAnswer);

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Questions

        protected void lstQuestions_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {

                HiddenField hdnFldQuestionTypeId = (HiddenField)e.Item.FindControl("hdnFldQuestionTypeId");
                HiddenField hdnFldQuestionId = (HiddenField)e.Item.FindControl("hdnFldQuestionId");
                HiddenField hdnFldSelfQuestionID = (HiddenField)e.Item.FindControl("hdnFldSelfQuestionID");
                TextBox txtQuestionAnswer = (TextBox)e.Item.FindControl("txtQuestionAnswer");
                Panel pnlSingleType = (Panel)e.Item.FindControl("pnlSingleType");
                Panel pnlMultipleType = (Panel)e.Item.FindControl("pnlMultipleType");
                Panel pnlMultipleTypeRadio = (Panel)e.Item.FindControl("pnlMultipleTypeRadio");
                ListView lstQuestionOptions = (ListView)e.Item.FindControl("lstQuestionOptions");
                RadioButtonList lstQuestionSingleOption = (RadioButtonList)e.Item.FindControl("lstQuestionSingleOption");



                if (hdnFldQuestionTypeId.Value == "1")//single type
                {
                    pnlSingleType.Visible = true;
                    pnlMultipleType.Visible = false;
                    pnlMultipleTypeRadio.Visible = false;
                    if (Mode == "Update")
                    {
                        DisclaimerQuestionAnswer objDisclaimerQuestionAnswer = DisclaimerQuestionController.GetDisclaimerQuestionAnswerByDisclaimerAndQuestionIDs(DisclaimerId, Convert.ToInt64(hdnFldQuestionId.Value));
                        if (objDisclaimerQuestionAnswer != null)
                            txtQuestionAnswer.Text = objDisclaimerQuestionAnswer.answerText;
                        else
                            txtQuestionAnswer.Text = string.Empty;
                    }
                }
                else if (hdnFldQuestionTypeId.Value == "2")//multitype
                {
                    pnlSingleType.Visible = false;
                    pnlMultipleType.Visible = true;
                    pnlMultipleTypeRadio.Visible = false;
                    BindQuestionOptions(Convert.ToInt64(hdnFldQuestionId.Value), lstQuestionOptions);
                }
                else if (hdnFldQuestionTypeId.Value == "3") //Single Selection
                {
                    pnlSingleType.Visible = false;
                    pnlMultipleType.Visible = false;
                    pnlMultipleTypeRadio.Visible = true;
                    BindRadioQuestionOptions(Convert.ToInt64(hdnFldQuestionId.Value), lstQuestionSingleOption);
                    if (Mode == "Update")
                    {
                        DisclaimerQuestionAnswer objDisclaimerQuestionAnswer = DisclaimerQuestionController.GetDisclaimerQuestionAnswerByDisclaimerAndQuestionIDs(DisclaimerId, hdnFldQuestionId.Value == "" ? 0 : Convert.ToInt64(hdnFldQuestionId.Value));
                        if (objDisclaimerQuestionAnswer != null)
                            lstQuestionSingleOption.SelectedValue = objDisclaimerQuestionAnswer.optionId == null ? null : objDisclaimerQuestionAnswer.optionId.Value.ToString();
                    }
                }
                else
                {
                    //pnlSingleType.Visible = false;
                    //pnlMultipleType.Visible = true;
                    //pnlMultipleTypeRadio.Visible = false;
                    //BindQuestionOptions(Convert.ToInt64(hdnFldQuestionId.Value), lstQuestionOptions);
                }

                if (hdnFldSelfQuestionID.Value != "")
                    e.Item.Visible = false;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindQuestions()
        {
            try
            {
                lstQuestions.DataSource = DisclaimerQuestionController.GetAllQuestions();
                lstQuestions.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindQuestionOptions(long QuestionId, ListView lstQuestionOptions)
        {
            try
            {
                var lstOptions = DisclaimerQuestionController.GetDisclaimerQuestionOptionByQuestionId(QuestionId);
                lstQuestionOptions.DataSource = lstOptions;
                lstQuestionOptions.DataBind();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindRadioQuestionOptions(long QuestionId, RadioButtonList lstQuestionOptions)
        {
            try
            {
                var lstOptions = DisclaimerQuestionController.GetDisclaimerQuestionOptionByQuestionId(QuestionId);
                lstQuestionOptions.DataSource = lstOptions;
                lstQuestionOptions.DataValueField = "Id";
                lstQuestionOptions.DataTextField = "options";
                lstQuestionOptions.DataBind();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void BindAnswers()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        protected void lstQuestionOptions_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (Mode == "Update")
                {
                    HiddenField hdnFldOptionId = (HiddenField)e.Item.FindControl("hdnFldOptionId");
                    CheckBox chkOptions = (CheckBox)e.Item.FindControl("chkOptions");
                    DisclaimerQuestionOption objDisclaimerQuestionOption = DisclaimerQuestionController.GetDisclaimerQuestionOption(Convert.ToInt64(hdnFldOptionId.Value));
                    DisclaimerQuestionAnswer objDisclaimerQuestionAnswer = DisclaimerQuestionController.GetDisclaimerQuestionAnswerByDisclaimerQuestionAndOptionIDs(DisclaimerId, objDisclaimerQuestionOption.questionId, objDisclaimerQuestionOption.ID);
                    if (objDisclaimerQuestionAnswer != null)
                        chkOptions.Checked = true;
                    else
                        chkOptions.Checked = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lstQuestionSingleOption_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (Mode == "Update")
                {
                    HiddenField hdnFldOptionId = (HiddenField)e.Item.FindControl("hdnFldOptionId");
                    CheckBox chkOptions = (CheckBox)e.Item.FindControl("chkOptions");
                    DisclaimerQuestionOption objDisclaimerQuestionOption = DisclaimerQuestionController.GetDisclaimerQuestionOption(Convert.ToInt64(hdnFldOptionId.Value));
                    DisclaimerQuestionAnswer objDisclaimerQuestionAnswer = DisclaimerQuestionController.GetDisclaimerQuestionAnswerByDisclaimerQuestionAndOptionIDs(DisclaimerId, objDisclaimerQuestionOption.questionId, objDisclaimerQuestionOption.ID);
                    if (objDisclaimerQuestionAnswer != null)
                        chkOptions.Checked = true;
                    else
                        chkOptions.Checked = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lstQuestionSingleOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbtnlist = (RadioButtonList)sender;
            rbtnlist.Enabled = true;
            long questionOpid = 0;
            if (rbtnlist.SelectedValue.ToString().Equals("") == false)
            {
                questionOpid = DisclaimerQuestionController.GetDisclaimerQuestionOptionByID(Convert.ToInt64(rbtnlist.SelectedValue.ToString())).questionId;
            }
            for (int i = 0; i < lstQuestions.Items.Count; i++)
            {
                if (((HiddenField)lstQuestions.Items[i].FindControl("hdnFldSelfQuestionID")).Value == questionOpid.ToString() && ((HiddenField)lstQuestions.Items[i].FindControl("hdnfldqestionOptionID")).Value == rbtnlist.SelectedValue.ToString())
                {
                    lstQuestions.Items[i].Visible = true;
                }
                else if (((HiddenField)lstQuestions.Items[i].FindControl("hdnFldSelfQuestionID")).Value == questionOpid.ToString() && ((HiddenField)lstQuestions.Items[i].FindControl("hdnfldqestionOptionID")).Value == (rbtnlist.SelectedIndex == 0 ? rbtnlist.Items[1].Value.ToString() : rbtnlist.Items[0].Value.ToString()))
                {

                    ((RadioButtonList)(lstQuestions.Items[i].FindControl("lstQuestionSingleOption"))).SelectedIndex = -1;
                    ((RadioButtonList)(lstQuestions.Items[i].FindControl("lstQuestionSingleOption"))).SelectedValue = null;
                    lstQuestions.Items[i].Visible = false;
                }
            }
        }

        protected void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #endregion


        //protected void CheckRFIDCardNo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Mode = "Insert";
        //        ClearValues();
        //        PanelVisibility(false, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        #region Measurement

        private void MeasurementPanelVisibility(bool View, bool Edit)
        {
            try
            {
                pnlMeasurementView.Visible = View;
                pnlMeasurementEdit.Visible = Edit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnAddMeasurement_Click(object sender, EventArgs e)
        {
            MeasurementMode = "Insert";
            MeasurementPanelVisibility(false, true);
        }
        protected void grdMeasurement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditMeasurement")
                {
                    MeasurementId = Convert.ToInt64(e.CommandArgument);
                    MeasurementMode = "Update";
                    BindMeasurementValues();
                    MeasurementPanelVisibility(false, true);
                    // MeasurementMaster objMeasurement = DesclaimerController.GetMeasurementById(MeasurementId);
                }
                else if (e.CommandName == "DeleteMeasurement")
                {
                    long MeasurementId = Convert.ToInt64(e.CommandArgument);
                    new DesclaimerController().DeleteMeasurement(MeasurementId);
                    BindMeasurement();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindMeasurement()
        {
            try
            {
                grdMeasurement.DataSource = DesclaimerController.GetMemberByMemberId(MemberId);
                grdMeasurement.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindMeasurementValues()
        {
            MeasurementMaster objMeasur = DesclaimerController.GetMeasurementById(MeasurementId);

            txtMWeight.Text = objMeasur.WEIGHT;
            txtMHeight.Text = Convert.ToString(objMeasur.HEIGHT);
            txtFat.Text = Convert.ToString(objMeasur.FAT);
            txtBMi.Text = Convert.ToString(objMeasur.BMI);
            txtBMR.Text = objMeasur.BMR;
            txtNeck.Text = objMeasur.NECK;
            txtShoulder.Text = objMeasur.SHOULDER;
            txtChest.Text = objMeasur.CHEST;
            txtArms.Text = objMeasur.ARMS;
            txtWaist.Text = objMeasur.WAIST;
            txtHips.Text = objMeasur.HIPS;
            txtThigh.Text = objMeasur.THIGH;
            txtCalf.Text = objMeasur.CALF;

            new DesclaimerController().UpdateMeasurement(objMeasur);
        }
        private void ClearMeasurementValues()
        {
            txtMWeight.Text = txtMHeight.Text = txtFat.Text = txtBMi.Text = txtBMR.Text = txtNeck.Text = txtShoulder.Text =
                txtChest.Text = txtArms.Text = txtWaist.Text = txtHips.Text = txtThigh.Text = txtCalf.Text = string.Empty;
        }
        protected void btnCancelMeasurement_Click(object sender, EventArgs e)
        {
            ClearMeasurementValues();
            MeasurementPanelVisibility(true, false);
        }
        protected void btnSaveMeasurement_Click(object sender, EventArgs e)
        {
            try
            {
                if (MeasurementMode == "Insert")
                {
                    MeasurementMaster objMesurement = new MeasurementMaster();

                    objMesurement.memberId = MemberId;
                    objMesurement.WEIGHT = txtMWeight.Text;
                    objMesurement.HEIGHT = Convert.ToDecimal(txtMHeight.Text);
                    objMesurement.FAT = Convert.ToDecimal(txtFat.Text);
                    objMesurement.BMI = Convert.ToDecimal(txtBMi.Text);
                    objMesurement.BMR = txtBMR.Text;
                    objMesurement.NECK = txtNeck.Text;
                    objMesurement.SHOULDER = txtShoulder.Text;
                    objMesurement.CHEST = txtChest.Text;
                    objMesurement.ARMS = txtArms.Text;
                    objMesurement.WAIST = txtWaist.Text;
                    objMesurement.HIPS = txtHips.Text;
                    objMesurement.THIGH = txtThigh.Text;
                    objMesurement.CALF = txtCalf.Text;

                    objMesurement = new DesclaimerController().InsertMeasurement(objMesurement);
                }
                else
                {
                    MeasurementMaster objMesurement = DesclaimerController.GetMeasurementById(MeasurementId);

                    objMesurement.memberId = MemberId;
                    objMesurement.WEIGHT = txtMWeight.Text;
                    objMesurement.HEIGHT = Convert.ToDecimal(txtMHeight.Text);
                    objMesurement.FAT = Convert.ToDecimal(txtFat.Text);
                    objMesurement.BMI = Convert.ToDecimal(txtBMi.Text);
                    objMesurement.BMR = txtBMR.Text;
                    objMesurement.NECK = txtNeck.Text;
                    objMesurement.SHOULDER = txtShoulder.Text;
                    objMesurement.CHEST = txtChest.Text;
                    objMesurement.ARMS = txtArms.Text;
                    objMesurement.WAIST = txtWaist.Text;
                    objMesurement.HIPS = txtHips.Text;
                    objMesurement.THIGH = txtThigh.Text;
                    objMesurement.CALF = txtCalf.Text;

                    objMesurement = new DesclaimerController().UpdateMeasurement(objMesurement);
                }
                ClearMeasurementValues();
                BindMeasurement();
                MeasurementPanelVisibility(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion





    }
}