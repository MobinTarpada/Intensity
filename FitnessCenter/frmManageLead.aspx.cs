using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using FitnessCenter.DAL;
using System.Collections;
using System.Collections.Specialized;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using NsExcel = Microsoft.Office.Interop.Excel;



namespace FitnessCenter
{
    public partial class frmManageLead : System.Web.UI.Page
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

        public long LeadId
        {
            get
            {
                var obj = ViewState["LeadId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["LeadId"] = value;
            }
        }

        public long LeadAppointmentId
        {
            get
            {
                var obj = ViewState["LeadAppointmentId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["LeadAppointmentId"] = value;
            }
        }

        public long LeadPresentationId
        {
            get
            {
                var obj = ViewState["LeadPresentationId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["LeadPresentationId"] = value;
            }
        }

        public long LeadFollowupId
        {
            get
            {
                var obj = ViewState["LeadFollowupId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["LeadFollowupId"] = value;
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

        public string AppointmentMode
        {
            get
            {
                var obj = ViewState["AppointmentMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["AppointmentMode"] = value;
            }
        }

        public string PresentationMode
        {
            get
            {
                var obj = ViewState["PresentationMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["PresentationMode"] = value;
            }
        }

        public string FollowupMode
        {
            get
            {
                var obj = ViewState["FollowupMode"];
                return obj == null ? "Insert" : (string)obj;
            }
            set
            {
                ViewState["FollowupMode"] = value;
            }
        }

        public StringCollection DeleteLeads
        {
            get
            {
                var obj = ViewState["DeleteLeads"];
                return obj == null ? null : (StringCollection)obj;
            }
            set
            {
                ViewState["DeleteLeads"] = value;
            }
        }
        public StringCollection TransferLeads
        {
            get
            {
                var obj = ViewState["TransferLeads"];
                return obj == null ? null : (StringCollection)obj;
            }
            set
            {
                ViewState["TransferLeads"] = value;
            }
        }

        public FileUpload ExcelFile
        {
            get
            {
                var obj = Session["ExcelFile"];
                return obj == null ? null : (FileUpload)obj;
            }
            set
            {
                Session["ExcelFile"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser == null)
            {
                Response.Redirect("~/frmLogin.aspx");
            }
            try
            {
                if (!IsPostBack)
                {
                    if (LoginUser.UserTypeId == 2 || LoginUser.UserTypeId == 8)
                    {
                        grdLead.Columns[0].Visible = true;
                        grdLead.Columns[8].Visible = true;
                        btnConfirmTransfer.Visible = true;
                        btnConfirmDelete.Visible = true;
                        btnExcel.Visible = true;
                    }
                    else if (LoginUser.UserTypeId == 7)
                    {
                        //btnAddLead.Visible = false;
                        //btnSearch.Visible = false;
                        HeadBtn.Visible = false;
                        grdLead.Columns[0].Visible = false;
                        btnConfirmTransfer.Visible = false;
                        btnConfirmDelete.Visible = false;
                        btnExcel.Visible = false;
                        btnDeleteSelected.Visible = false;
                        btnTransferSelected.Visible = false;
                        btnTransferMultipleLeads.Visible = false;

                        //LinkButton edit, delete, details, transfer, lnkemail, lnksms;
                        //edit = (LinkButton)grdLead.FindControl("lnkBtnEdit");
                        //delete = (LinkButton)grdLead.FindControl("lnkBtnDelete");
                        //details = (LinkButton)grdLead.FindControl("lnkBtnDetail");
                        //transfer = (LinkButton)grdLead.FindControl("lnkBtnTransfer");
                        //lnkemail = (LinkButton)grdLead.FindControl("lnkBtnEmail");
                        //lnksms = (LinkButton)grdLead.FindControl("lnkBtnSMS");

                        //lnksms.Visible = false;
                        //lnkemail.Visible = false;
                        //edit.Visible = true;
                        //delete.Visible = false;
                        //details.Visible = true;
                        //transfer.Visible = false;
                    }
                    else
                    {

                        //LinkButton edit, delete, details, transfer;
                        //edit = (LinkButton)grdLead.FindControl("lnkBtnEdit");
                        //delete = (LinkButton)grdLead.FindControl("lnkBtnDelete");
                        //details = (LinkButton)grdLead.FindControl("lnkBtnDetail");
                        //transfer = (LinkButton)grdLead.FindControl("lnkBtnTransfer");

                        // grdLead.FindControl("lnkBtnEdit").Visible = false;

                        //edit.Visible = false;
                        //delete.Visible = false;
                        //details.Visible = true;
                        //transfer.Visible = false;

                        grdLead.Columns[0].Visible = false;
                        //grdLead.Columns[8].Visible = false;
                        btnConfirmTransfer.Visible = false;
                        btnConfirmDelete.Visible = false;
                        btnExcel.Visible = false;
                    }
                    PanelVisibility(true, false, false);
                    pnlRefferal.Visible = false;
                    BindGrid();
                    BindLeadType();
                    pnlAction.Visible = false;
                    PanelActionVisibility(false, false);
                    PannelDetailsVisibility(false, false, false);
                    //pnlExcel.Visible = false;
                }
                GetDeleteData();
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

        protected void btnAddLead_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                pnlAction.Visible = true;
                PanelActionVisibility(false, false);
                PanelVisibility(false, true, false);
                BindQuestions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdLead_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLead.PageIndex = e.NewPageIndex;
                BindGrid();
                SetDeleteData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdLead_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdLead_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditLead")
                {
                    LeadId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindLeadValues();
                    BindLeadAppointment();
                    BindQuestions();
                    PanelVisibility(false, true, false);
                    pnlAction.Visible = false;
                }
                else if (e.CommandName == "DeleteLead")
                {

                    int leadId = Convert.ToInt32(e.CommandArgument);
                    new LeadController().DeleteLead(leadId);
                    BindGrid();

                }
                else if (e.CommandName == "DetailLead")
                {
                    LeadId = Convert.ToInt64(e.CommandArgument);
                    BindLeadDetail();
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    txtLblFirstName.Text = objLead.firstName;
                    txtLblLastName.Text = objLead.lastName;
                    txtLblConNo.Text = objLead.mobileNumber;
                    ddlLeadStatus_SelectedIndexChanged(sender, e);
                    PanelVisibility(false, false, true);
                }
                else if (e.CommandName == "TransferLead")
                {
                    LeadId = Convert.ToInt64(e.CommandArgument);
                    string jScript = "";
                    jScript = "$('#MsgBoxModal1').removeClass('hide');";
                    jScript += "$('#masteroverlay1').removeClass('hide');";
                    jScript += "$('#MsgBoxModal1').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_lead", jScript, true);
                    BindTransferUsers();
                }
                else if (e.CommandName == "EmailLead")
                {
                    LeadId = Convert.ToInt64(e.CommandArgument);
                    string jScript = "";
                    jScript = "$('#MsgBoxModal4').removeClass('hide');";
                    jScript += "$('#masteroverlay4').removeClass('hide');";
                    jScript += "$('#MsgBoxModal4').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_Email", jScript, true);
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    txtPromoEmail.Text = objLead.Email;
                }
                else if (e.CommandName == "SMSLead")
                {
                    txtMsgSMS.Text = "";
                    LeadId = Convert.ToInt64(e.CommandArgument);
                    string jScript = "";
                    jScript = "$('#MsgBoxModal5').removeClass('hide');";
                    jScript += "$('#masteroverlay5').removeClass('hide');";
                    jScript += "$('#MsgBoxModal5').fadeIn(300);";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_SMS", jScript, true);
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    txtSmS.Text = objLead.mobileNumber;
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
                if (txtLastName.Text == "" || txtFirstName.Text == "" || txtMobile.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','FirstName or LastName or MobileNumber is not Inserted');", true);
                }
                else
                {
                    if (Mode == "Insert")
                    {
                        if (ddlLeadTypeAdd.SelectedIndex == 0 || ddlAction.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','LeadType Or Action Not Selected Please Select First');", true);
                            PanelVisibility(false, true, false);
                        }
                        else
                        {
                            if (!LeadController.IsLeadExists(txtMobile.Text.Trim()))
                            {
                                InsertLead();
                                ClearValues();
                                PanelVisibility(true, false, false);
                                BindGrid();
                                ClearMandatoryFields();
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Lead Saved Successfully');", true);
                            }
                            else if (LeadController.IsLeadExists(txtMobile.Text.Trim()))
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Mobile Number Already Exists');", true);
                                txtMobile.Focus();
                                PanelVisibility(false, true, false);
                            }

                        }
                    }
                    else
                    {
                        UpdateLead();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Lead Updated Successfully');", true);
                        ClearValues();
                        PanelVisibility(true, false, false);
                        BindGrid();
                        ClearMandatoryFields();
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
            try
            {
                ClearValues();
                ClearMandatoryFields();
                PanelVisibility(true, false, false);
                pnlAction.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                lstQuestionSingleOption.AutoPostBack = true;


                if (hdnFldQuestionTypeId.Value == "1")//single type
                {
                    pnlSingleType.Visible = true;
                    pnlMultipleType.Visible = false;
                    pnlMultipleTypeRadio.Visible = false;
                    if (Mode == "Update")
                    {
                        LeadQuestionAnswer objLeadQuestionAnswer = QuestionController.GetLeadQuestionAnswerByLeadAndQuestionIDs(LeadId, Convert.ToInt64(hdnFldQuestionId.Value));
                        if (objLeadQuestionAnswer != null)
                            txtQuestionAnswer.Text = objLeadQuestionAnswer.answerText;
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
                        LeadQuestionAnswer objLeadQuestionAnswer = QuestionController.GetLeadQuestionAnswerByLeadAndQuestionIDs(LeadId, hdnFldQuestionId.Value == "" ? 0 : Convert.ToInt64(hdnFldQuestionId.Value));
                        if (objLeadQuestionAnswer != null)
                            lstQuestionSingleOption.SelectedValue = objLeadQuestionAnswer.optionId == null ? null : objLeadQuestionAnswer.optionId.Value.ToString();
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

        protected void lstQuestionOptions_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (Mode == "Update")
                {
                    HiddenField hdnFldOptionId = (HiddenField)e.Item.FindControl("hdnFldOptionId");
                    CheckBox chkOptions = (CheckBox)e.Item.FindControl("chkOptions");
                    LeadQuestionOption objLeadQuestionOption = QuestionController.GetLeadQuestionOption(Convert.ToInt64(hdnFldOptionId.Value));
                    LeadQuestionAnswer objLeadQuestionAnswer = QuestionController.GetLeadQuestionAnswerByLeadQuestionAndOptionIDs(LeadId, objLeadQuestionOption.questionId, objLeadQuestionOption.ID);
                    if (objLeadQuestionAnswer != null)
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
                    LeadQuestionOption objLeadQuestionOption = QuestionController.GetLeadQuestionOption(Convert.ToInt64(hdnFldOptionId.Value));
                    LeadQuestionAnswer objLeadQuestionAnswer = QuestionController.GetLeadQuestionAnswerByLeadQuestionAndOptionIDs(LeadId, objLeadQuestionOption.questionId, objLeadQuestionOption.ID);
                    if (objLeadQuestionAnswer != null)
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

        protected void btnSaveLeadDetail_Click(object sender, EventArgs e)
        {
            if (ddlLeadType.SelectedIndex == 0 || ddlLeadStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error_msg", "MessageBox('Error','Please Select LeadType Or LeadStatus');", true);
            }
            else
            {
                try
                {
                    Lead objLead = LeadController.GetLeadById(LeadId);
                    if (objLead.leadStatusId != Convert.ToInt64(ddlLeadStatus.SelectedValue))
                    {
                        LeadTransaction objLeadTransaction = new LeadTransaction();
                        objLeadTransaction.leadId = LeadId;
                        objLeadTransaction.prevLeadStatusId = objLead.leadStatusId;
                        objLeadTransaction.currantLeadStatusId = Convert.ToInt64(ddlLeadStatus.SelectedValue);
                        objLeadTransaction.clubId = LoginUser.ClubId;
                        objLeadTransaction = new LeadController().InsertLeadTransaction(objLeadTransaction);
                    }

                    objLead.leadStatusId = Convert.ToInt64(ddlLeadStatus.SelectedValue);
                    objLead.leadTypeId = Convert.ToInt64(ddlLeadType.SelectedValue);
                    new LeadController().UpdateLead(objLead);
                    if (objLead.leadStatusId == 5)
                    {
                        Response.Redirect("ManageMembership.aspx");
                    }
                    else
                    {
                        BindGrid();
                        PanelVisibility(true, false, false);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void ddlMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaritalStatus.SelectedValue == "Married")
            {
                panelAnniversaryDate.Visible = true;
                txtAnniversaryDate.CssClass = "form-control datePicker";
            }
            else
            {
                panelAnniversaryDate.Visible = false;
                txtAnniversaryDate.CssClass = "form-control datePicker";
            }
        }

        protected void ddlLeadTypeAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lead objLType = new Lead();
            if (Convert.ToInt32(ddlLeadTypeAdd.SelectedValue) == 3)
            {
                pnlRefferal.Visible = true;
            }
            else
            {
                pnlRefferal.Visible = false;
            }
        }

        protected void txtMmbrReg_TextChanged(object sender, EventArgs e)
        {
            Membership objMembers = LeadController.GetMebersByRegistraionNumber(txtMmbrReg.Text);
            if (objMembers == null)
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "error_msg", "MessageBox('Error','This MeberId is Wrong Please Try Different MemberId');", true);
            else
            {
                Lead objLead = LeadController.GetLeadById(objMembers.LeadId);
                txtMmbrname.Text = objLead.firstName + ' ' + objLead.lastName;
                txtMemberContact.Text = objLead.mobileNumber;
            }
        }

        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeadStatusMaster objLeadStatus = new LeadStatusMaster();
            if (Convert.ToInt32(ddlAction.SelectedValue) == 0)
            {
                PanelActionVisibility(false, false);
            }
            else if (Convert.ToInt32(ddlAction.SelectedValue) == 2)
            {
                PanelActionVisibility(true, false);
            }
            else if (Convert.ToInt32(ddlAction.SelectedValue) == 4)
            {
                PanelActionVisibility(false, true);
            }
        }

        protected void chkDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkDeleteAll = (CheckBox)grdLead.HeaderRow.FindControl("chkDeleteAll");
                var obj = DeleteLeads;
                if (obj == null)
                    obj = new StringCollection();
                foreach (GridViewRow row in grdLead.Rows)
                {
                    CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (chkDeleteAll.Checked)
                    {
                        chkDelete.Checked = true;
                        if (!obj.Contains(hfLeadId.Value))
                            obj.Add(hfLeadId.Value);
                    }
                    else
                        chkDelete.Checked = false;

                }
                DeleteLeads = obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlLeadStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeadStatus.SelectedValue == "2")
            {
                PannelDetailsVisibility(true, false, false);
            }
            else if (ddlLeadStatus.SelectedValue == "3")
            {
                PannelDetailsVisibility(false, false, true);
            }
            else if (ddlLeadStatus.SelectedValue == "4")
            {
                PannelDetailsVisibility(false, true, false);
            }
            else
            {
                PannelDetailsVisibility(false, false, false);

            }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            DateTime db;
            db = UtillController.ConvertDateTime(txtDOB.Text);
            if (db >= DateTime.Today)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Valid Date of Birth ');", true);
                PanelVisibility(false, true, false);
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string jScript = "";
                //jScript = "console.log('Removing Class');";
                jScript = "$('#MsgBoxModal2').removeClass('hide');";
                jScript += "$('#masteroverlay2').removeClass('hide');";
                jScript += "$('#MsgBoxModal2').fadeIn(300);";
                //jScript = "console.log('Removed Class');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "excel_transfer", jScript, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            ExcelFile = fileuploadExcel;
            if (ExcelFile.HasFile)
            {
                string connString = "", dupLeads = "";
                string strFileType = Path.GetExtension(ExcelFile.FileName).ToLower();
                string fileName = Path.GetFileName(ExcelFile.FileName);
                string path = Server.MapPath("~/UploadedExcels/" + fileName);
                ExcelFile.SaveAs(path);
                int count = 0, dupCount = 0;
                //Connection String to Excel Workbook
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=Yes;IMEX=2'";
                }
                string query = "SELECT * FROM [Sheet1$]";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Close();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                //grdExcel.DataSource = dt;
                //grdExcel.DataBind();
                foreach (DataRow row in dt.Rows)
                {
                    if (!LeadController.IsLeadExists(row[7].ToString().Trim()))
                    {
                        count++;
                        Lead objLead = new Lead();
                        objLead.firstName = row[0].ToString();
                        objLead.lastName = row[1].ToString();
                        objLead.gender = (row[2].ToString() == "M") ? "Male" : "Female";
                        if (row[3].ToString().Equals(""))
                            objLead.dateOfBirth = null;
                        else
                            objLead.dateOfBirth = UtillController.ConvertDateTime(row[3].ToString());
                        //objLead.dateOfBirth = UtillController.ConvertDateTime(txtDOB.Text);
                        objLead.address = row[4].ToString();
                        objLead.city = row[5].ToString();
                        objLead.pincode = row[6].ToString();
                        objLead.mobileNumber = row[7].ToString();
                        objLead.otherContactNumber = row[8].ToString();
                        objLead.bestTimeToCall = "1";
                        objLead.responseTypeId = 1;
                        objLead.leadTypeId = 1;
                        objLead.leadStatusId = 1;
                        objLead.clubId = LoginUser.ClubId;
                        objLead.userId = LoginUser.ID;
                        objLead.maritalStatus = (row[9].ToString() == "") ? "Single" : row[9].ToString();
                        if (row[9].ToString() == "Married")
                        {
                            if (row[10].ToString().Equals(""))
                                objLead.anniversaryDate = null;
                            else
                                objLead.anniversaryDate = UtillController.ConvertDateTime(row[10].ToString());
                        }
                        else
                            objLead.anniversaryDate = null;
                        objLead.occupation = row[11].ToString();
                        objLead.employee = row[12].ToString();
                        objLead.Email = row[13].ToString();
                        objLead = new LeadController().InsertLead(objLead);

                    }
                    else
                    {
                        count++;
                        dupCount++;
                        if (dupLeads == "")
                            dupLeads = "" + count;
                        else
                            dupLeads += "," + count;
                    }
                }
                da.Dispose();
                conn.Close();
                conn.Dispose();
                string Msg = "Total Leads: " + dt.Rows.Count + " Duplicate Leads: " + dupCount + " Duplicate Leads No: " + dupLeads + " Success Leads: " + (dt.Rows.Count - dupCount) + " from Excel Saved Successfully";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','" + Msg + "');", true);
                BindGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Select File First');", true);
                btnExcel_Click(sender, e);
            }
        }

        protected void btnTransferLeads_Click(object sender, EventArgs e)
        {
            try
            {

                Lead objLead = LeadController.GetLeadById(LeadId);
                if (drpTransferUser.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select User To Transfer Lead');", true);
                else
                {
                    objLead.isTransfer = true;
                    objLead.transferBy = LoginUser.ID;
                    objLead.transferTo = objLead.userId = Convert.ToInt64(drpTransferUser.SelectedValue);
                    objLead = new LeadController().UpdateLead(objLead);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Lead Transfered Successfully');", true);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                // GetDeleteData();
                SetDeleteData();
                var obj = DeleteLeads;
                if (obj == null)
                    obj = new StringCollection();

                foreach (GridViewRow row in grdLead.Rows)
                {
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (obj.Contains(hfLeadId.Value))
                    {
                        new LeadController().DeleteLead(Convert.ToInt32(hfLeadId.Value));
                        obj.Remove(hfLeadId.Value);
                    }
                }
                BindGrid();
                DeleteLeads = obj;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Selected Leads Deleted Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnTransferSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //Lead objLead = LeadController.GetLeadById(LeadId);
                // LeadId = Convert.ToInt64(LeadId);
                string jScript1 = "";
                jScript1 = "$('#MsgBoxModel3').removeClass('hide');";
                jScript1 += "$('#masteroverlay3').removeClass('hide');";
                jScript1 += "$('#MsgBoxModel3').fadeIn(300);";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "transfer_lead", jScript1, true);
                BindUsers();
                // pnlTransferAll.Visible = true;
                //if (drpTransferUser.SelectedIndex == 0)
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select User To Transfer Lead');", true);
                //else
                //{
                //    SetDeleteData();
                //    var obj = TransferLeads;
                //    if (obj == null)
                //        obj = new StringCollection();

                //    foreach (GridViewRow row in grdLead.Rows)
                //    {
                //        HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                //        if (obj.Contains(hfLeadId.Value))
                //        {
                //            new LeadController().DeleteLead(Convert.ToInt32(hfLeadId.Value));
                //            obj.Remove(hfLeadId.Value);
                //        }
                //    }
                //    BindGrid();
                //    DeleteLeads = obj;
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Selected Leads Deleted Successfully');", true);
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnTransferLeadsAll_Click(object sender, EventArgs e)
        {
            SetDeleteData();
            var obj = DeleteLeads;
            if (obj == null)
                obj = new StringCollection();

            if (ddlUser.SelectedValue == "0")
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select User To Transfer Lead');", false);
            else
            {
                foreach (GridViewRow row in grdLead.Rows)
                {
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (obj.Contains(hfLeadId.Value))
                    {
                        LeadId = Convert.ToInt32(hfLeadId.Value);
                        Lead objLead = LeadController.GetLeadById(LeadId);
                        objLead.isTransfer = true;
                        objLead.transferBy = LoginUser.ID;
                        objLead.transferTo = objLead.userId = Convert.ToInt64(ddlUser.SelectedValue);
                        objLead = new LeadController().UpdateLead(objLead);
                        // new LeadController().UpdateLead(Convert.ToInt32(hfLeadId.Value));
                        obj.Remove(hfLeadId.Value);
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Lead Transfered Successfully');", true);
                BindGrid();
            }
        }
        protected void grdLead_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            var Details = (LinkButton)e.Row.FindControl("lnkBtnDetail");
            var Transfer = (LinkButton)e.Row.FindControl("lnkBtnTransfer");
            var Delete = (LinkButton)e.Row.FindControl("lnkBtnDelete");
            var lnkemail = (LinkButton)e.Row.FindControl("lnkBtnEmail");
            var lnksms = (LinkButton)e.Row.FindControl("lnkBtnSMS");

            if (Edit != null && Transfer != null && Delete != null && lnkemail != null && lnksms != null)
            {
                if (LoginUser.UserTypeId != 2 && LoginUser.UserTypeId != 8 && LoginUser.UserTypeId != 7)
                {
                    Edit.Visible = false;
                    Transfer.Visible = false;
                    Delete.Visible = false;
                }
                else if (LoginUser.UserTypeId == 7)
                {
                    Edit.Visible = true;
                    Transfer.Visible = false;
                    Delete.Visible = false;
                    Details.Visible = false;
                    lnkemail.Visible = false;
                    lnksms.Visible = false;
                }
            }
        }
        public string AgreementNumber()
        {
            string ANumber = "INT";
            ANumber += LoginUser.ClubId.ToString().PadLeft(3, '0');
            ANumber += DateTime.Now.ToString("yyMM");
            int i = 0;
            i = LeadController.GetLeadsByAgreementNumber().Count + 1;
            ANumber += i.ToString().PadLeft(4, '0');
            return ANumber;
        }

        #endregion

        #region Methods


        private void BindGrid()
        {
            try
            {
                if (LoginUser.UserTypeId != 5 && LoginUser.UserTypeId != 7)
                    grdLead.DataSource = LeadController.GetLeads(LoginUser.ClubId, txtSearchText.Text, txtSearchLastName.Text, txtSearchMobileNo.Text, txtSearchDateOfBirth.Text.ToString(), ddlSearchLeadStatus.SelectedValue == "" ? 0 : Convert.ToInt64(ddlSearchLeadStatus.SelectedValue.ToString()), SortField, SortDir, 0);
                else if (LoginUser.UserTypeId == 7)
                    grdLead.DataSource = new FitnessCenterEntities().Leads.Where(x => x.mobileNumber == LoginUser.Mobile);
                else
                    grdLead.DataSource = LeadController.GetLeads(LoginUser.ClubId, txtSearchText.Text, txtSearchLastName.Text, txtSearchMobileNo.Text, txtSearchDateOfBirth.Text, ddlSearchLeadStatus.SelectedValue == "" ? 0 : Convert.ToInt64(ddlSearchLeadStatus.SelectedValue.ToString()), SortField, SortDir, LoginUser.ID);
                grdLead.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void PanelVisibility(bool View, bool Edit, bool Detail)
        {
            try
            {
                pnlView.Visible = View;
                pnlEdit.Visible = Edit;
                pnlDetail.Visible = Detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PanelActionVisibility(bool AppoinMent, bool Followup)
        {
            try
            {
                pnlEditAppoinments.Visible = AppoinMent;
                pnlEditFollowup.Visible = Followup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PannelDetailsVisibility(bool Appoinment, bool Followup, bool Presentation)
        {
            try
            {
                pnlAppointment.Visible = Appoinment;
                pnlFollowup.Visible = Followup;
                pnlPresentation.Visible = Presentation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindLeadType()
        {
            try
            {
                ddlLeadTypeAdd.DataSource = ddlLeadType.DataSource = LeadController.GetLeadTypes();
                ddlLeadTypeAdd.DataTextField = ddlLeadType.DataTextField = "LeadTypeName";
                ddlLeadTypeAdd.DataValueField = ddlLeadType.DataValueField = "ID";

                ddlLeadTypeAdd.DataBind(); ddlLeadType.DataBind();
                ddlLeadTypeAdd.Items.Insert(0, new ListItem("Select Lead Type", "0"));
                ddlLeadType.Items.Insert(0, new ListItem("Select Lead Type", "0"));
                Lead objLType = new Lead();

                ddlSearchLeadStatus.DataSource = ddlLeadStatus.DataSource = LeadController.GetLeadStatus();
                ddlSearchLeadStatus.DataTextField = ddlLeadStatus.DataTextField = "StatusName";
                ddlSearchLeadStatus.DataValueField = ddlLeadStatus.DataValueField = "ID";
                ddlLeadStatus.DataBind();
                ddlLeadStatus.Items.Insert(0, new ListItem("Select Lead Status", "0"));
                ddlSearchLeadStatus.DataBind();
                ddlSearchLeadStatus.Items.Insert(0, new ListItem("Select Lead Status", "0"));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void InsertLead()
        {
            try
            {
                Lead objLead = new Lead();
                Membership objMember = new Membership();
                if (ddlLeadTypeAdd.SelectedItem.Text.ToUpper() == "REFERRALS")
                {
                    objLead.memberShipId = txtMmbrReg.Text;
                    objLead.relationWtihMember = txtRelation.Text;
                }
                else
                {
                    objLead.memberShipId = null;
                    objLead.relationWtihMember = null;
                }
                //objLead.agreementNumber = AgreementNumber();
                objLead.firstName = txtFirstName.Text;
                objLead.lastName = txtLastName.Text;
                objLead.gender = rdoGender.SelectedValue;
                if (txtDOB.Text.Equals(""))
                    objLead.dateOfBirth = null;
                else
                    objLead.dateOfBirth = UtillController.ConvertDateTime(txtDOB.Text);
                //objLead.dateOfBirth = UtillController.ConvertDateTime(txtDOB.Text);
                objLead.address = txtAddress.Text;
                objLead.city = txtCity.Text;
                objLead.pincode = txtPin.Text;
                objLead.mobileNumber = txtMobile.Text;
                objLead.otherContactNumber = txtOtherContact.Text;
                objLead.bestTimeToCall = ddlBestTimeToCall.SelectedValue;
                objLead.responseTypeId = Convert.ToInt32(ddlResponseType.SelectedValue);
                objLead.leadTypeId = Convert.ToInt32(ddlLeadTypeAdd.SelectedValue);
                objLead.leadStatusId = Convert.ToInt32(ddlAction.SelectedValue);
                objLead.clubId = LoginUser.ClubId;
                objLead.userId = LoginUser.ID;
                objLead.maritalStatus = ddlMaritalStatus.SelectedValue;
                if (ddlMaritalStatus.SelectedValue == "Married")
                {
                    if (txtAnniversaryDate.Text.Equals(""))
                        objLead.anniversaryDate = null;
                    else objLead.anniversaryDate = UtillController.ConvertDateTime(txtAnniversaryDate.Text);
                }
                else
                {
                    objLead.anniversaryDate = null;
                }
                objLead.occupation = txtOccupation.Text;
                objLead.employee = txtEmployee.Text;
                objLead.Email = txtEmail.Text;
                objLead = new LeadController().InsertLead(objLead);

                if (Convert.ToInt32(ddlAction.SelectedValue) == 2)
                {
                    LeadAppointment objLeadAppoinment = new LeadAppointment();
                    objLeadAppoinment.leadId = objLead.ID;
                    objLeadAppoinment.appointmentDate = UtillController.ConvertDateTime(txtaDate.Text);
                    objLeadAppoinment.reasonForNotAttend = txtApointRemarks.Text;
                    objLeadAppoinment.clubId = LoginUser.ClubId;
                    objLeadAppoinment.userId = LoginUser.ID;
                    objLeadAppoinment = new LeadController().InsertLeadAppointment(objLeadAppoinment);
                    //objLeadAppoint.isAttendAppointment = chkAttend.Checked;
                    //objLeadAppoint.reasonForNotAttend = txtrsn.Text;
                }
                else if (Convert.ToInt32(ddlAction.SelectedValue) == 4)
                {
                    LeadFollowup objLeadFollowup = new LeadFollowup();
                    objLeadFollowup.leadId = objLead.ID;
                    objLeadFollowup.followupDateTime = UtillController.ConvertDateTime(txtFDate.Text);
                    objLeadFollowup.Remarks = txtFolloupRemarks.Text;
                    //objLeadFollowup.appoinmentId = LeadAppointmentId;
                    //objLeadFollowup.presentationId = LeadPresentationId;
                    objLeadFollowup = new LeadController().InsertLeadFollowup(objLeadFollowup);

                }
                // insert new updated LeadQuestionAnswers..
                InsertLeadQuestionAnswers(objLead);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void UpdateLead()
        {
            try
            {

                Lead objLead = LeadController.GetLeadById(LeadId);
                LeadAppointment objLeadAppoinment = LeadController.GetLeadAppointmentById(LeadAppointmentId);

                objLead.leadTypeId = Convert.ToInt64(ddlLeadTypeAdd.SelectedValue);

                if (ddlLeadTypeAdd.SelectedItem.Text.ToUpper() == "REFERRALS")
                {
                    objLead.memberShipId = txtMmbrReg.Text;
                    objLead.relationWtihMember = txtRelation.Text;
                }
                else
                {
                    objLead.memberShipId = "";
                    objLead.relationWtihMember = "";
                }
                objLead.firstName = txtFirstName.Text;
                objLead.lastName = txtLastName.Text;
                //objLead.memberShipId = Convert.ToInt64(txtMmbrReg.Text);
                //objLead.relationWtihMember = txtRelation.Text;
                objLead.gender = rdoGender.SelectedValue;
                if (txtDOB.Text.Equals(""))
                    objLead.dateOfBirth = null;
                else
                    objLead.dateOfBirth = UtillController.ConvertDateTime(txtDOB.Text);
                objLead.address = txtAddress.Text;
                objLead.city = txtCity.Text;
                objLead.pincode = txtPin.Text;
                objLead.mobileNumber = txtMobile.Text;
                objLead.otherContactNumber = txtOtherContact.Text;
                objLead.bestTimeToCall = ddlBestTimeToCall.SelectedValue;
                objLead.responseTypeId = Convert.ToInt32(ddlResponseType.SelectedValue);
                objLead.maritalStatus = ddlMaritalStatus.SelectedValue;
                if (ddlMaritalStatus.SelectedValue == "Married")
                {
                    if (txtAnniversaryDate.Text.Equals(""))
                        objLead.anniversaryDate = null;
                    else objLead.anniversaryDate = UtillController.ConvertDateTime(txtAnniversaryDate.Text);
                }
                else
                {
                    objLead.anniversaryDate = null;
                }
                objLead.occupation = txtOccupation.Text;
                objLead.employee = txtEmployee.Text;
                objLead.Email = txtEmail.Text;
                //objLead.leadStatusId = Convert.ToInt32(ddlLeadStatus.SelectedValue);
                objLead = new LeadController().UpdateLead(objLead);
                // delete old LeadQuestionAnswers
                new QuestionController().DeleteAllLeadQuestionAnswerByLeadId(objLead.ID);

                // insert new updated LeadQuestionAnswers..
                InsertLeadQuestionAnswers(objLead);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindLeadValues()
        {
            if (LoginUser.UserTypeId == 7)
            {
                updtpnl1.Visible = false;
                pnlAction.Visible = false;
                foreach (Control ctrl in pnlEdit.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ReadOnly = true;
                    }
                }
                foreach (Control ctrl in pnlEdit.Controls)
                {
                    if (ctrl is DropDownList)
                    {
                        ((DropDownList)ctrl).Enabled = false;
                    }
                }
                foreach (Control ctrl in pnlRefferal.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ReadOnly = true;
                    }
                }

                txtAddress.ReadOnly = txtFirstName.ReadOnly = txtMobile.ReadOnly = txtEmail.ReadOnly = txtLastName.ReadOnly = false;
            }
            Lead objLead = LeadController.GetLeadById(LeadId);
            ddlLeadTypeAdd.SelectedValue = objLead.leadTypeId == 0 ? null : objLead.leadTypeId.ToString();
            if (Convert.ToInt32(ddlLeadTypeAdd.SelectedValue) == 3)
            {
                txtMmbrReg.Text = objLead.memberShipId;
                Membership objMembers = LeadController.GetMebersByRegistraionNumber(txtMmbrReg.Text);
                Lead objLead1 = LeadController.GetLeadById(objMembers.LeadId);
                pnlRefferal.Visible = true;
                txtMmbrname.Text = objLead1.firstName + ' ' + objLead1.lastName;
                txtMemberContact.Text = objLead1.mobileNumber;

                txtRelation.Text = objLead.relationWtihMember;
            }
            else
            {
                pnlRefferal.Visible = false;
            }

            txtFirstName.Text = objLead.firstName;
            txtLastName.Text = objLead.lastName;
            rdoGender.SelectedValue = objLead.gender;
            //DateTime dob = (DateTime)objLead.dateOfBirth;
            txtDOB.Text = (objLead.dateOfBirth == null) ? null : ((DateTime)objLead.dateOfBirth).ToString("dd/MM/yyyy");
            txtAddress.Text = objLead.address;
            txtCity.Text = objLead.city;
            txtPin.Text = objLead.pincode;
            txtMobile.Text = objLead.mobileNumber;
            txtOtherContact.Text = objLead.otherContactNumber;
            ddlBestTimeToCall.SelectedValue = objLead.bestTimeToCall;
            ddlResponseType.SelectedValue = objLead.responseTypeId.ToString();
            ddlLeadType.SelectedValue = objLead.leadTypeId.ToString();
            ddlMaritalStatus.SelectedValue = objLead.maritalStatus;
            txtAnniversaryDate.Text = objLead.anniversaryDate.ToString();
            txtOccupation.Text = objLead.occupation;
            txtEmployee.Text = objLead.employee;
            txtEmail.Text = objLead.Email;
            new LeadController().UpdateLead(objLead);

        }
        private void ClearValues()
        {
            txtFirstName.Text = txtSearchText.Text;
            txtLastName.Text = txtSearchLastName.Text;
            txtMobile.Text = txtSearchMobileNo.Text;
            txtOccupation.Text = "";
            txtEmployee.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtOtherContact.Text = "";
            txtPin.Text = "";
            txtDOB.Text = txtSearchDateOfBirth.Text;
            ddlLeadType.SelectedValue = "0";
        }
        private void ClearMandatoryFields()
        {
            txtFirstName.Text = txtLastName.Text = txtMobile.Text = txtDOB.Text = string.Empty;
        }
        private void BindQuestions()
        {
            try
            {
                lstQuestions.DataSource = QuestionController.GetAllQuestions();
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
                var lstOptions = QuestionController.GetLeadQuestionOptionByQuestionId(QuestionId);
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
                var lstOptions = QuestionController.GetLeadQuestionOptionByQuestionId(QuestionId);
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
        private void InsertLeadQuestionAnswers(Lead objLead)
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
                    RadioButtonList lstQuestionSingleOption = (RadioButtonList)lstQuestionList.FindControl("lstQuestionSingleOption");

                    if (Convert.ToInt32(hdnFldQuestionTypeId.Value) == 1) // single type
                    {
                        LeadQuestionAnswer objLeadQuestionAnswer = new LeadQuestionAnswer();
                        objLeadQuestionAnswer.leadId = objLead.ID;
                        objLeadQuestionAnswer.questionId = Convert.ToInt64(hdnFldQuestionId.Value);
                        objLeadQuestionAnswer.answerText = txtQuestionAnswer.Text;
                        objLeadQuestionAnswer = new QuestionController().InsertLeadQuestionAnswer(objLeadQuestionAnswer);
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
                                LeadQuestionAnswer objLeadQuestionAnswer = new LeadQuestionAnswer();
                                objLeadQuestionAnswer.leadId = objLead.ID;
                                objLeadQuestionAnswer.questionId = Convert.ToInt64(hdnFldQuestionId.Value);
                                objLeadQuestionAnswer.optionId = Convert.ToInt64(hdnFldOptionId.Value);
                                objLeadQuestionAnswer = new QuestionController().InsertLeadQuestionAnswer(objLeadQuestionAnswer);
                                //objLeadQuestionAnswer = new QuestionController().InsertLeadQuestionAnswer(objLeadQuestionAnswer);
                            }
                        }
                    }
                    else if (Convert.ToInt32(hdnFldQuestionTypeId.Value) == 3)// multi type
                    {
                        LeadQuestionAnswer objLeadQuestionAnswer = new LeadQuestionAnswer();
                        objLeadQuestionAnswer.leadId = objLead.ID;
                        objLeadQuestionAnswer.questionId = Convert.ToInt64(hdnFldQuestionId.Value);
                        if (lstQuestionSingleOption.SelectedValue != "")
                            objLeadQuestionAnswer.optionId = Convert.ToInt64(lstQuestionSingleOption.SelectedValue);
                        objLeadQuestionAnswer = new QuestionController().InsertLeadQuestionAnswer(objLeadQuestionAnswer);
                        //objLeadQuestionAnswer = new QuestionController().InsertLeadQuestionAnswer(objLeadQuestionAnswer);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindLeadDetail()
        {
            try
            {
                Lead objLead = LeadController.GetLeadById(LeadId);
                ddlLeadType.SelectedValue = objLead.leadTypeId.ToString();
                ddlLeadStatus.SelectedValue = objLead.leadStatusId.ToString();
                BindLeadAppointment();
                BindLeadPresentation();
                BindLeadFollowup();
                BindLeadHistory();
                AppointmentPanelVisible(true, false);
                PresentationPanelVisible(true, false);
                FollowupPanelVisible(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetDeleteData()
        {
            try
            {
                var obj = DeleteLeads;
                if (obj == null)
                    obj = new StringCollection();
                foreach (GridViewRow row in grdLead.Rows)
                {
                    CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (chkDelete.Checked)
                    {
                        if (!obj.Contains(hfLeadId.Value))
                            obj.Add(hfLeadId.Value);
                    }
                    else
                    {
                        if (obj.Contains(hfLeadId.Value))
                            obj.Remove(hfLeadId.Value);
                    }
                    //if (obj.Contains(hfLeadId.Value))
                    //    chkDelete.Checked = true;

                }
                DeleteLeads = obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetDeleteData()
        {
            try
            {
                //GetDeleteData();
                var obj = DeleteLeads;
                if (obj == null)
                    obj = new StringCollection();
                CheckBox chkDeleteAll = (CheckBox)grdLead.HeaderRow.FindControl("chkDeleteAll");
                chkDeleteAll.Checked = true;
                foreach (GridViewRow row in grdLead.Rows)
                {
                    CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (chkDelete != null)
                    {
                        chkDelete.Checked = obj.Contains(hfLeadId.Value);
                        if (!chkDelete.Checked)
                            chkDeleteAll.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SetTransferData()
        {
            try
            {
                var obj = TransferLeads;
                if (obj == null)
                    obj = new StringCollection();
                CheckBox chkDeleteAll = (CheckBox)grdLead.HeaderRow.FindControl("chkDeleteAll");
                chkDeleteAll.Checked = true;
                foreach (GridViewRow row in grdLead.Rows)
                {
                    CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
                    HiddenField hfLeadId = (HiddenField)row.FindControl("hfLeadId");
                    if (chkDelete != null)
                    {
                        chkDelete.Checked = obj.Contains(hfLeadId.Value);
                        if (!chkDelete.Checked)
                            chkDeleteAll.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindTransferUsers()
        {
            try
            {
                drpTransferUser.DataSource = LeadController.GetUserForTransfer(LoginUser.ClubId, LoginUser.ID);
                drpTransferUser.DataTextField = "firstName";
                drpTransferUser.DataValueField = "ID";
                drpTransferUser.DataBind();
                drpTransferUser.Items.Insert(0, new ListItem("Select User", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindUsers()
        {
            try
            {
                ddlUser.DataSource = LeadController.GetUserForTransfer(LoginUser.ClubId, LoginUser.ID);
                ddlUser.DataTextField = "firstName";
                ddlUser.DataValueField = "ID";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("Select User", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Appointment

        protected void btnAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentMode = "Insert";
            AppointmentPanelVisible(false, true);
        }

        protected void grdLeadAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditAppointment")
                {
                    LeadAppointmentId = Convert.ToInt64(e.CommandArgument);
                    AppointmentMode = "Update";
                    AppointmentPanelVisible(false, true);
                    LeadAppointment objLeadAppoint = LeadController.GetLeadAppointmentById(LeadAppointmentId);
                    txtAppointmentDate.Text = objLeadAppoint.appointmentDate.ToString("dd/MM/yyyy");
                    chkppointmentAttended.Checked = objLeadAppoint.isAttendAppointment == null ? false : objLeadAppoint.isAttendAppointment.Value;
                    txtReasonForNotAttend.Text = objLeadAppoint.reasonForNotAttend;
                }
                else if (e.CommandName == "DeleteAppointment")
                {
                    long AppointmentId = Convert.ToInt64(e.CommandArgument);
                    new LeadController().DeleteLeadAppointment(AppointmentId);
                    BindLeadAppointment();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindLeadAppointment()
        {
            try
            {
                grdLeadAppointment.DataSource = LeadController.GetLeadAppointmentByLeadId(LeadId);
                grdLeadAppointment.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ClearAppointmentValues()
        {
            txtAppointmentDate.Text = txtReasonForNotAttend.Text = string.Empty;
            chkppointmentAttended.Checked = false;
        }

        private void AppointmentPanelVisible(bool View, bool Edit)
        {
            pnlAppointmentView.Visible = View;
            pnlAppointmentEdit.Visible = Edit;
        }

        protected void btnSaveLeadAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppointmentMode == "Insert")
                {
                    LeadAppointment objLeadAppoint = new LeadAppointment();
                    objLeadAppoint.appointmentDate = UtillController.ConvertDateTime(txtAppointmentDate.Text);
                    objLeadAppoint.isAttendAppointment = chkppointmentAttended.Checked;
                    objLeadAppoint.reasonForNotAttend = txtReasonForNotAttend.Text;
                    objLeadAppoint.leadId = LeadId;
                    objLeadAppoint.clubId = LoginUser.ClubId;
                    objLeadAppoint.userId = LoginUser.ID;
                    objLeadAppoint = new LeadController().InsertLeadAppointment(objLeadAppoint);

                    Lead objLead = LeadController.GetLeadById(LeadId);
                    if (objLead.leadStatusId != (long)EnumLeadStatusMaster.Appoinment)
                    {
                        LeadTransaction objLeadTransaction = new LeadTransaction();
                        objLeadTransaction.leadId = LeadId;
                        objLeadTransaction.prevLeadStatusId = objLead.leadStatusId;
                        objLeadTransaction.currantLeadStatusId = (long)EnumLeadStatusMaster.Appoinment;
                        objLeadTransaction.clubId = LoginUser.ClubId;
                        objLeadTransaction = new LeadController().InsertLeadTransaction(objLeadTransaction);
                        BindLeadHistory();


                        objLead.leadStatusId = (long)EnumLeadStatusMaster.Appoinment;
                        objLead = new LeadController().UpdateLead(objLead);
                        ddlLeadStatus.SelectedValue = objLead.leadStatusId.ToString();
                    }
                }
                else
                {
                    LeadAppointment objLeadAppoint = LeadController.GetLeadAppointmentById(LeadAppointmentId);
                    objLeadAppoint.appointmentDate = UtillController.ConvertDateTime(txtAppointmentDate.Text);
                    objLeadAppoint.isAttendAppointment = chkppointmentAttended.Checked;
                    objLeadAppoint.reasonForNotAttend = txtReasonForNotAttend.Text;
                    objLeadAppoint = new LeadController().UpdateLeadAppointment(objLeadAppoint);
                }
                ClearAppointmentValues();
                BindLeadAppointment();
                AppointmentPanelVisible(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelLeadAppointment_Click(object sender, EventArgs e)
        {
            ClearAppointmentValues();
            AppointmentPanelVisible(true, false);
        }

        #endregion

        #region Presentation

        protected void btnAddPresentation_Click(object sender, EventArgs e)
        {
            PresentationMode = "Insert";
            PresentationPanelVisible(false, true);
        }

        protected void grdLeadPresentation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditPresentation")
                {
                    LeadPresentationId = Convert.ToInt64(e.CommandArgument);
                    PresentationMode = "Update";
                    PresentationPanelVisible(false, true);
                    LeadPresentation objLeadPresentation = LeadController.GetLeadPresentationById(LeadPresentationId);
                    //txtPresentationDate.Text = objLeadPresentation.presentationDate.ToString("dd/MM/yyyy");
                    chkPresentationAttend.Checked = objLeadPresentation.isAttendPresentation == null ? false : objLeadPresentation.isAttendPresentation.Value;
                    txtReasonsForNotAttendPresentation.Text = objLeadPresentation.reasonsForNotAttend;
                }
                else if (e.CommandName == "DeletePresentation")
                {
                    long PresentationId = Convert.ToInt64(e.CommandArgument);
                    new LeadController().DeleteLeadPresentation(PresentationId);
                    BindLeadPresentation();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindLeadPresentation()
        {
            try
            {
                grdLeadPresentation.DataSource = LeadController.GetLeadPresentationByLeadId(LeadId);
                grdLeadPresentation.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindLeadHistory()
        {
            try
            {
                grdLeadHistory.DataSource = LeadController.GetLeadTransactionByLeadId(LeadId);
                grdLeadHistory.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ClearPresentationValues()
        {
            txtReasonsForNotAttendPresentation.Text = string.Empty;
            chkPresentationAttend.Checked = false;
        }

        private void PresentationPanelVisible(bool View, bool Edit)
        {
            pnlPresentationView.Visible = View;
            pnlPresentationEdit.Visible = Edit;
        }

        protected void btnSaveLeadPresentation_Click(object sender, EventArgs e)
        {
            try
            {
                if (PresentationMode == "Insert")
                {
                    LeadPresentation objLeadAppoint = new LeadPresentation();
                    objLeadAppoint.presentationDate = DateTime.Now;
                    objLeadAppoint.isAttendPresentation = chkPresentationAttend.Checked;
                    objLeadAppoint.reasonsForNotAttend = txtReasonsForNotAttendPresentation.Text;
                    objLeadAppoint.leadId = LeadId;
                    objLeadAppoint.userId = LoginUser.ID;
                    objLeadAppoint = new LeadController().InsertLeadPresentation(objLeadAppoint);

                    Lead objLead = LeadController.GetLeadById(LeadId);
                    if (objLead.leadStatusId != (long)EnumLeadStatusMaster.Presentation)
                    {
                        LeadTransaction objLeadTransaction = new LeadTransaction();
                        objLeadTransaction.leadId = LeadId;
                        objLeadTransaction.prevLeadStatusId = objLead.leadStatusId;
                        objLeadTransaction.currantLeadStatusId = (long)EnumLeadStatusMaster.Presentation;
                        objLeadTransaction.clubId = LoginUser.ClubId;
                        objLeadTransaction = new LeadController().InsertLeadTransaction(objLeadTransaction);


                        objLead.leadStatusId = (long)EnumLeadStatusMaster.Presentation;
                        objLead = new LeadController().UpdateLead(objLead);
                        ddlLeadStatus.SelectedValue = objLead.leadStatusId.ToString();
                    }
                }
                else
                {
                    LeadPresentation objLeadAppoint = LeadController.GetLeadPresentationById(LeadPresentationId);
                    objLeadAppoint.presentationDate = DateTime.Now;
                    objLeadAppoint.isAttendPresentation = chkPresentationAttend.Checked;
                    objLeadAppoint.reasonsForNotAttend = txtReasonsForNotAttendPresentation.Text;
                    objLeadAppoint = new LeadController().UpdateLeadPresentation(objLeadAppoint);
                }
                ClearPresentationValues();
                BindLeadPresentation();
                BindLeadHistory();
                PresentationPanelVisible(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelLeadPresentation_Click(object sender, EventArgs e)
        {
            ClearPresentationValues();
            PresentationPanelVisible(true, false);
        }

        #endregion

        #region Followup
        protected void BindLeadFollowup()
        {
            try
            {
                grdLeadFollowup.DataSource = LeadController.GetLeadFollowupByLeadId(LeadId);
                grdLeadFollowup.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void ClearFollowupValues()
        {
            txtFollowupDate.Text = txtRemarks.Text = string.Empty;

        }
        protected void AddFollowup_Click(object sender, EventArgs e)
        {
            FollowupMode = "Insert";
            FollowupPanelVisible(false, true);
        }

        protected void btnCancelLeadFollowup_Click(object sender, EventArgs e)
        {
            ClearFollowupValues();
            FollowupPanelVisible(true, false);
        }

        protected void btnSaveLeadFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                if (FollowupMode == "Insert")
                {
                    LeadFollowup objLeadFollowup = new LeadFollowup();
                    objLeadFollowup.followupDateTime = UtillController.ConvertDateTime(txtFollowupDate.Text);
                    objLeadFollowup.Remarks = txtRemarks.Text;
                    objLeadFollowup.leadId = LeadId;
                    //objLeadFollowup.appoinmentId = LeadAppointmentId;
                    //objLeadFollowup.presentationId = LeadPresentationId;
                    objLeadFollowup = new LeadController().InsertLeadFollowup(objLeadFollowup);
                }
                else
                {
                    LeadFollowup objLeadFollowup = LeadController.GetLeadFollowupById(LeadFollowupId);
                    objLeadFollowup.followupDateTime = UtillController.ConvertDateTime(txtFollowupDate.Text);
                    objLeadFollowup.Remarks = txtRemarks.Text;
                    objLeadFollowup.leadId = LeadId;
                    //objLeadFollowup.appoinmentId = LeadAppointmentId;
                    //objLeadFollowup.presentationId = LeadPresentationId;
                    objLeadFollowup = new LeadController().UpdateLeadFollowup(objLeadFollowup);
                }
                BindLeadFollowup();
                BindLeadHistory();
                FollowupPanelVisible(true, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void grdLeadFollowup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditFollowup")
                {
                    LeadFollowupId = Convert.ToInt64(e.CommandArgument);
                    FollowupMode = "Update";
                    FollowupPanelVisible(false, true);
                    LeadFollowup objLeadFollowup = LeadController.GetLeadFollowupById(LeadFollowupId);
                    txtFollowupDate.Text = objLeadFollowup.followupDateTime.ToString("dd/MM/yyyy");
                    txtRemarks.Text = objLeadFollowup.Remarks;
                    //txtFollowupTime.Text = objLeadFollowup.followupTime.ToString("hh/mm/tt");
                }
                else if (e.CommandName == "DeleteFollowup")
                {
                    long FollowupId = Convert.ToInt64(e.CommandArgument);
                    new LeadController().DeleteLeadFollowup(LeadFollowupId);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FollowupPanelVisible(bool View, bool Edit)
        {
            pnlFollowupView.Visible = View;
            pnlFollowupEdit.Visible = Edit;
        }
        #endregion

        #region Question
        protected void lstQuestionSingleOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbtnlist = (RadioButtonList)sender;
            rbtnlist.Enabled = true;
            rbtnlist.AutoPostBack = true;
            long questionOpid = 0;

            if (rbtnlist.SelectedValue.ToString().Equals("") == false)
            {
                questionOpid = QuestionController.GetLeadQuestionOptionByID(Convert.ToInt64(rbtnlist.SelectedValue.ToString())).questionId;
            }
            for (int i = 0; i < lstQuestions.Items.Count; i++)
            {
                String strSuperQuestion = ((HiddenField)lstQuestions.Items[i].FindControl("hdnFldSuperQuestionId")).Value;

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
                else if (strSuperQuestion != null && strSuperQuestion != string.Empty)
                {
                    String[] superQustionList = strSuperQuestion.Split('|');
                    for (int t = 0; t < superQustionList.Length; t++)
                    {
                        if (superQustionList[t] == questionOpid.ToString())
                        {
                            ((RadioButtonList)(lstQuestions.Items[i].FindControl("lstQuestionSingleOption"))).SelectedIndex = -1;
                            ((RadioButtonList)(lstQuestions.Items[i].FindControl("lstQuestionSingleOption"))).SelectedValue = null;
                            lstQuestions.Items[i].Visible = false;
                        }
                    }
                }
            }

        }
        protected void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion


        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (ManageMemberShip.CheckForInternetConnection())
            {
                string from = "info@intensity.net.in"; //example:- sourabh9303@gmail.com
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(txtPromoEmail.Text);
                mail.Subject = "Promotion Mail";
                mail.Body = "Check our new promotion for special member";
                if (fileUploader.HasFile)
                {
                    string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
                    mail.Attachments.Add(new Attachment(fileUploader.PostedFile.InputStream, fileName));
                }
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("intensity.net.in", 587);
                smtp.EnableSsl = false;
                smtp.Credentials = new System.Net.NetworkCredential("info@intensity.net.in", "info@123");
                smtp.Send(mail);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Please Check Youur Internet Connection')", true);
        }

        public void SendSmS()
        {
            try
            {

                string msg = txtMsgSMS.Text;
                string Actype = "1";
                string Msgtype = "1";
                string SenderId = "INTNST";
                string ozSURL = "http://sms.infisms.co.in/API/SendSMS.aspx"; //where the SMS Gateway is running
                //string ozSPort = "9501"; //port number where the SMS Gateway is listening
                string ozUser = HttpUtility.UrlEncode("inten51ty"); //username for successful login
                string ozPassw = HttpUtility.UrlEncode("f1tn3ss"); //user's password
                //string ozMessageType = "SMS:TEXT"; //type of message
                string ozRecipients = HttpUtility.UrlEncode("7777944343"); //who will get the message
                string ozMessageData = HttpUtility.UrlEncode(msg); //body of message

                string createdURL = ozSURL +
                    "?UserID=" + ozUser +
                    "&UserPassword=" + ozPassw +
                    "&PhoneNumber=" + ozRecipients +
                    "&Text=" + msg +
                    "&SenderId=" + SenderId +
                    "&AccountType=" + Actype +
                    "&MessageType=" + Msgtype;

                //Create the request and send data to the SMS Gateway Server by HTTP connection
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                //Get response from the SMS Gateway Server and read the answer
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = txtMsgSMS.Text;
                string Actype = "1";
                string Msgtype = "0";
                string SenderId = "INTNST";
                string ozSURL = "http://sms.infisms.co.in/API/SendSMS.aspx"; //where the SMS Gateway is running
                //string ozSPort = "9501"; //port number where the SMS Gateway is listening
                string ozUser = HttpUtility.UrlEncode("inten51ty"); //username for successful login
                string ozPassw = HttpUtility.UrlEncode("f1tn3ss"); //user's password
                //string ozMessageType = "SMS:TEXT"; //type of message
                string ozRecipients = HttpUtility.UrlEncode(txtSmS.Text); //who will get the message
                string ozMessageData = HttpUtility.UrlEncode(msg); //body of message
                string createdURL = ozSURL +
                    "?UserID=" + ozUser +
                    "&UserPassword=" + ozPassw +
                    "&PhoneNumber=" + ozRecipients +
                    "&Text=" + msg +
                    "&SenderId=" + SenderId +
                    "&AccountType=" + Actype +
                    "&MessageType=" + Msgtype;

                //Create the request and send data to the SMS Gateway Server by HTTP connection
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                //Get response from the SMS Gateway Server and read the answer
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }



}
