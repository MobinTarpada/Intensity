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
    public partial class frmAssignPTP : System.Web.UI.Page
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

        public long PTPMemberMasterId
        {
            get
            {
                var obj = ViewState["PTPMemberMasterId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["PTPMemberMasterId"] = value;
            }
        }

        public long PTPPackageId
        {
            get
            {
                var obj = ViewState["PTPPackageId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["PTPPackageId"] = value;
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
            if (!IsPostBack)
            {
                BindGrid();
                PanelVisibility(true, false, false);
                pnlPayment.Visible = pnlAssignValues.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAssignPackage_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                PanelVisibility(false, true, false);
                BindMembers();
                BindPTPPackages();
                ClearValues();
                txtStDate.ReadOnly = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdAssignedPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "DetailPTPMember")
                {
                    PTPMemberMasterId = Convert.ToInt32(e.CommandArgument);
                    PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                    MemberId = objPTPMember.memberId;
                    PanelVisibility(false, false, true);
                    BindTransaction();
                }
                else if (e.CommandName == "EditPTPMember")
                {
                    Mode = "Update";
                    PTPMemberMasterId = Convert.ToInt32(e.CommandArgument);
                    PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                    MemberId = objPTPMember.memberId;
                    PanelVisibility(false, true, false);
                    BindValues();
                }
                else if (e.CommandName == "DeletePTPMember")
                {
                    PTPMemberMasterId = Convert.ToInt32(e.CommandArgument);
                    PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                    MemberId = objPTPMember.memberId;
                    new AssignPTPController().DeletePTPMember(PTPMemberMasterId);
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Deleted Successfully');", true);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdAssignedPackages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAssignedPackages.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdAssignedPackages_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void drpMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpMembers.SelectedIndex == 0)
                    txtFirstname.Text = txtLastName.Text = txtDOB.Text = txtCntNo.Text = txtExpDate.Text = string.Empty;
                else
                {
                    MemberId = Convert.ToInt64(drpMembers.SelectedValue);
                    BindMemberValues();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpPTPPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpPTPPackages.SelectedIndex == 0)
                {
                    txtDays.Text = txtNoOfSessions.Text = txtFees.Text = string.Empty;
                    pnlAssignValues.Visible = false;
                }
                else
                {
                    pnlAssignValues.Visible = true;
                    PTPPackageId = Convert.ToInt64(drpPTPPackages.SelectedValue);
                    txtSesRem.Text = BindSession();
                    BindPTPPackagesValues();
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
                if (drpMembers.SelectedIndex == 0 || drpPTPPackages.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Package or Member to Assign');", true);

                else
                {


                    if (Mode == "Insert")
                    {
                        if (!IfPrevAssigned())
                            InsertPTPMembers();

                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Same Package is Already Assigned to this Member');", true);
                    }
                    else
                        UpdatePTPMembers();

                    ClearValues();
                    BindGrid();
                    PanelVisibility(true, false, false);
                    pnlPayment.Visible = pnlAssignValues.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Error. Please try Again');", true);
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                PanelVisibility(true, false, false);
                pnlAssignValues.Visible = pnlPayment.Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            pnlPayment.Visible = true;
            BindPayMode();
        }

        protected void rblPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlChqDetails.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).ReadOnly = false;
            }
            if (rblPayMode.SelectedValue == "2")
                pnlChqDetails.Visible = true;
            else
                pnlChqDetails.Visible = false;
        }

        protected void btnPymntSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        protected void btnPymntCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        protected void txtStDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStDate.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Start Date');", true);
                else
                {
                    DateTime StDate = UtillController.ConvertDateTime(txtStDate.Text);
                    DateTime endDate;
                    endDate = StDate.AddDays(Convert.ToInt32(txtDays.Text));
                    // txtEndDate.Text = endDate.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDate.ToString("dd/MM/yyyy");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAddSession_Click(object sender, EventArgs e)
        {
            try
            {
                string jScript = "";
                jScript = "$('#MsgBoxModal1').removeClass('hide');";
                jScript += "$('#masteroverlay1').removeClass('hide');";
                jScript += "$('#MsgBoxModal1').fadeIn(300);";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "add_session", jScript, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDetailCancel_Click(object sender, EventArgs e)
        {
            try
            {
                PanelVisibility(true, false, false);
                pnlAssignValues.Visible = pnlPayment.Visible = false;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnInsertSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRFIDSes.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter RFID Number');", true);
                else
                {
                    Membership objMember = PaymentController.GetMembersByRfidNo(txtRFIDSes.Text);
                    if (objMember != null && objMember.ID == MemberId)
                    {
                        InsertTransaction();
                        BindTransaction();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Invalid RFID Number');", true);
                        txtRFIDSes.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Methods
        public void BindGrid()
        {
            try
            {
                grdAssignedPackages.DataSource = AssignPTPController.GetAssignedPTP(txtSearch.Text, txtRfidNo.Text, txtMemberShipNo.Text, SortDir, SortField, LoginUser.clubId);
                grdAssignedPackages.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit, bool Detail)
        {
            pnlView.Visible = View;
            pnlEdit.Visible = Edit;
            pnlDetails.Visible = Detail;
        }

        public void BindPTPPackages()
        {
            try
            {
                drpPTPPackages.Enabled = true;
                drpPTPPackages.DataSource = AssignPTPController.GetPackages();
                drpPTPPackages.DataTextField = "packageName";
                drpPTPPackages.DataValueField = "ID";
                drpPTPPackages.DataBind();
                drpPTPPackages.Items.Insert(0, new ListItem("Select Package", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindMembers()
        {
            try
            {
                drpMembers.Enabled = true;
                drpMembers.DataSource = AssignPTPController.GetMembersByLeadID(LoginUser.clubId);
                drpMembers.DataTextField = "MembersName";
                drpMembers.DataValueField = "ID";
                drpMembers.DataBind();
                drpMembers.Items.Insert(0, new ListItem("Select Member", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindMemberValues()
        {
            try
            {
                Membership objMember = AssignPTPController.GetmembersByID(MemberId);
                LeadId = objMember.leadId;
                Lead objLead = LeadController.GetLeadById(LeadId);
                txtFirstname.Text = objLead.firstName;
                txtLastName.Text = objLead.lastName;
                //txtDOB.Text = ((DateTime)objLead.dateOfBirth).ToString("dd/MM/yyyy");
                txtDOB.Text = ((DateTime)objLead.dateOfBirth).ToString("dd/MM/yyyy");
                txtCntNo.Text = objLead.mobileNumber;
                //txtExpDate.Text = ((DateTime)objMember.expiryDate).ToString("dd/MM/yyyy");
                txtExpDate.Text = ((DateTime)objMember.expiryDate).ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindPTPPackagesValues()
        {
            try
            {
                PTPPackageMaster objPTPPackages = AssignPTPController.GetPackagesByID(PTPPackageId);
                txtDays.Text = Convert.ToString(objPTPPackages.validDays);
                txtNoOfSessions.Text = Convert.ToString(objPTPPackages.noOfSessions);
                txtFees.Text = Convert.ToString(objPTPPackages.fees);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindValues()
        {
            try
            {
                PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                BindMembers();
                BindPTPPackages();

                drpMembers.SelectedValue = Convert.ToString(objPTPMember.memberId);
                drpPTPPackages.SelectedValue = Convert.ToString(objPTPMember.PTPPackageID);
                drpPTPPackages.Enabled = drpMembers.Enabled = false;
                //txtStDate.Text = ((DateTime)objPTPMember.startDate).ToString("dd/MM/yyyy");
                txtStDate.Text = ((DateTime)objPTPMember.startDate).ToString("dd/MM/yyyy");
                txtStDate.ReadOnly = true;
                //txtEndDate.Text = ((DateTime)objPTPMember.endDate).ToString("dd/MM/yyyy");
                txtEndDate.Text = ((DateTime)objPTPMember.endDate).ToString("dd/MM/yyyy");

                pnlAssignValues.Visible = true;
                PTPPackageId = Convert.ToInt64(drpPTPPackages.SelectedValue);
                txtSesRem.Text = BindSession();
                BindPTPPackagesValues();

                MemberId = Convert.ToInt64(drpMembers.SelectedValue);
                BindMemberValues();

                chkPaidRet.Checked = objPTPMember.isPaid;
                if (chkPaidRet.Checked)
                {
                    pnlPayment.Visible = true;
                    BindPayMode();
                    rblPayMode.SelectedValue = Convert.ToString(objPTPMember.payMode);
                    rblPayMode.Enabled = chkPaidRet.Enabled = false;
                    if (rblPayMode.SelectedValue == "2")
                    {
                        pnlChqDetails.Visible = true;
                        txtChqDate.Text = Convert.ToString(objPTPMember.chequeDate);
                        txtChqNo.Text = objPTPMember.chequeNo;
                        txtBankName.Text = objPTPMember.bankName;
                        txtBranchDetails.Text = objPTPMember.branchDetails;
                        foreach (Control ctrl in pnlChqDetails.Controls)
                        {
                            if (ctrl is TextBox)
                                ((TextBox)ctrl).ReadOnly = true;
                        }
                    }
                    else
                        pnlChqDetails.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertPTPMembers()
        {
            try
            {
                PTPMemberMaster objPTPMember = new PTPMemberMaster();
                objPTPMember.PTPPackageID = Convert.ToInt64(drpPTPPackages.SelectedValue);
                objPTPMember.memberId = Convert.ToInt64(drpMembers.SelectedValue);
                //objPTPMember.startDate =UtillController.ConvertDateTime(txtStDate.Text);
                //objPTPMember.endDate =UtillController.ConvertDateTime(txtEndDate.Text);
                objPTPMember.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objPTPMember.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objPTPMember.sessionCount = Convert.ToInt64(txtSesRem.Text);
                objPTPMember.amount = Convert.ToDecimal(txtAmt.Text);
                if (rblPayMode.SelectedValue == "")
                    objPTPMember.payMode = 0;
                else
                    objPTPMember.payMode = Convert.ToInt64(rblPayMode.SelectedValue);
                objPTPMember.chequeDate = null;
                objPTPMember.chequeNo = objPTPMember.bankName = objPTPMember.branchDetails = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objPTPMember.chequeDate =UtillController.ConvertDateTime(txtChqDate.Text);
                    objPTPMember.chequeNo = txtChqNo.Text;
                    objPTPMember.bankName = txtBankName.Text;
                    objPTPMember.branchDetails = txtBranchDetails.Text;
                }
                objPTPMember.isPaid = chkPaidRet.Checked;
                objPTPMember = new AssignPTPController().InsertPTPMember(objPTPMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Assigned Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePTPMembers()
        {
            try
            {
                PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                objPTPMember.PTPPackageID = Convert.ToInt64(drpPTPPackages.SelectedValue);
                objPTPMember.memberId = Convert.ToInt64(drpMembers.SelectedValue);
                //objPTPMember.startDate =UtillController.ConvertDateTime(txtStDate.Text);
                //objPTPMember.endDate =UtillController.ConvertDateTime(txtEndDate.Text);
                objPTPMember.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objPTPMember.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objPTPMember.sessionCount = Convert.ToInt64(txtSesRem.Text);
                objPTPMember.amount = Convert.ToDecimal(txtAmt.Text);
                if (rblPayMode.SelectedValue == "")
                    objPTPMember.payMode = 0;
                else
                    objPTPMember.payMode = Convert.ToInt64(rblPayMode.SelectedValue);
                objPTPMember.chequeDate = null;
                objPTPMember.chequeNo = objPTPMember.bankName = objPTPMember.branchDetails = null;
                if (rblPayMode.SelectedValue == "2")
                {
                    objPTPMember.chequeDate =UtillController.ConvertDateTime(txtChqDate.Text);
                    objPTPMember.chequeNo = txtChqNo.Text;
                    objPTPMember.bankName = txtBankName.Text;
                    objPTPMember.branchDetails = txtBranchDetails.Text;
                }
                objPTPMember.isPaid = chkPaidRet.Checked;
                objPTPMember = new AssignPTPController().UpdatePTPMember(objPTPMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Assigned Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClearValues()
        {
            try
            {
                Control[] ctrls = { pnlChqDetails, pnlEdit, pnlAssignValues, pnlDetails };
                foreach (Control ctrl in ctrls)
                {
                    foreach (Control item in ctrl.Controls)
                    {
                        if (item is TextBox)
                            ((TextBox)item).Text = "";
                    }
                }
                txtRFIDSes.Text = "";
                drpMembers.SelectedIndex = drpPTPPackages.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string BindSession()
        {
            try
            {
                int Trans = 0;
                long session = 0;

                PTPPackageMaster objPTPPackage = AssignPTPController.GetPackagesByID(PTPPackageId);
                txtAmt.Text = Convert.ToString(objPTPPackage.fees);
                session = objPTPPackage.noOfSessions;
                if (AssignPTPController.GetTransByMemberIdAndPTPMasterId(MemberId, PTPMemberMasterId) != null)
                {
                    Trans = AssignPTPController.GetTransByMemberIdAndPTPMasterId(MemberId, PTPMemberMasterId).Count;
                    session = session - Trans;
                }
                return session.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindPayMode()
        {
            try
            {
                rblPayMode.Items.Clear();
                rblPayMode.Enabled = true;
                rblPayMode.Items.Add(new ListItem("Cash", "1"));
                rblPayMode.Items.Add(new ListItem("Cheque", "2"));
                rblPayMode.Items.Add(new ListItem("Credit Card", "3"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IfPrevAssigned()
        {
            try
            {
                PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByPackageIdAndMemberId(PTPPackageId, MemberId);
                return objPTPMember != null ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindTransaction()
        {
            try
            {
                grdTrans.DataSource = AssignPTPController.GetAssignedTransaction(PTPMemberMasterId);
                grdTrans.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertTransaction()
        {
            try
            {
                PTPMemberMaster objPTPMember = AssignPTPController.GetAssignedPTPByID(PTPMemberMasterId);
                PTPMemberTransaction objPTPTrans = new PTPMemberTransaction();
                long session = 0;
                objPTPTrans.PTPMemberMasterId = PTPMemberMasterId;
                objPTPTrans.memberId = MemberId;
                objPTPTrans = new AssignPTPController().InsertTransaction(objPTPTrans);
                session = objPTPMember.sessionCount - 1;
                objPTPMember.sessionCount = session;
                objPTPMember = new AssignPTPController().UpdatePTPMember(objPTPMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Session Added Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion



    }
}