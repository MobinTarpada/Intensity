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
    public partial class frmAssignTowel : System.Web.UI.Page
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

        public long TowelMasterId
        {
            get
            {
                var obj = ViewState["TowelMasterId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["TowelMasterId"] = value;
            }
        }

        public long TowelPackageId
        {
            get
            {
                var obj = ViewState["TowelPackageId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["TowelPackageId"] = value;
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
                PanelVisibility(false, false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAssignPackage_Click(object sender, EventArgs e)
        {
            PanelVisibility(false, true, false);
            Mode = "Insert";
            BindMembers();
            BindTowelPackages();
            ClearValues();
            txtStDate.ReadOnly = false;
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

        protected void grdAssignedPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditTowelMember")
                {
                    Mode = "Update";
                    TowelMasterId = Convert.ToInt32(e.CommandArgument);
                    TowelHiringMaster objTowel = AssignTowelController.GetAssignedTowelById(TowelMasterId);
                    MemberId = objTowel.memberId;
                    PanelVisibility(false, true, false);
                    BindValues();
                }
                else if (e.CommandName == "DetailTowelMember")
                {
                    TowelMasterId = Convert.ToInt32(e.CommandArgument);
                    TowelHiringMaster objTowel = AssignTowelController.GetAssignedTowelById(TowelMasterId);
                    MemberId = objTowel.memberId;
                    PanelVisibility(false, false, true);
                    BindTransaction();
                }
                else if (e.CommandName == "DeleteTowelMember")
                {
                    TowelMasterId = Convert.ToInt32(e.CommandArgument);
                    new AssignTowelController().DeleteTowelMember(TowelMasterId);
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Data Deleted Successfully');", true);
                }
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

        protected void drpTowelPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpTowelPackages.SelectedIndex == 0)
                {
                    txtDays.Text = txtHiringTime.Text = txtFees.Text = string.Empty;
                    PanelVisibility(false, false);
                }
                else
                {
                    PanelVisibility(false, true);
                    TowelPackageId = Convert.ToInt64(drpTowelPackages.SelectedValue);
                    txtHireRem.Text = BindHiringTime();
                    BindTowelPacakgesValues();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                    DateTime ExpDate = UtillController.ConvertDateTime(txtExpDate.Text);
                    DateTime endDate;
                    endDate = StDate.AddDays(Convert.ToInt32(txtDays.Text));
                    int result = endDate.CompareTo(ExpDate);
                    if (result == 1)
                        txtEndDate.Text = ExpDate.ToString("dd/MM/yyyy");
                    else
                        txtEndDate.Text = endDate.ToString("dd/MM/yyyy");

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
                if (drpMembers.SelectedIndex == 0 || drpTowelPackages.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please select Package or Member to Assign');", true);

                else
                {


                    if (Mode == "Insert")
                    {
                        if (!IfPrevAssigned())
                            InsertTowelMaster();

                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Same Package is Already Assigned to this Member');", true);
                    }
                    else
                        UpdateTowelMaster();

                    ClearValues();
                    BindGrid();
                    PanelVisibility(true, false, false);
                    PanelVisibility(false, false);
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
                PanelVisibility(false, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            PanelVisibility(true, true);
            BindPayMode();
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
                PanelVisibility(false, false);
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPymntSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        protected void btnPymntCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        protected void grdTrans_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditTowelTrans")
                {
                    int TowelTransid = Convert.ToInt32(e.CommandArgument);
                    TowelTransaction objTowelTrans = AssignTowelController.GetTransById(TowelTransid);
                    objTowelTrans.isTowelReturn = true;
                    new AssignTowelController().UpdateTransaction(objTowelTrans);
                    BindTransaction();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Towel Returned Successfully');", true);
                }
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
                grdAssignedPackages.DataSource = AssignTowelController.GetAssignedTowel(SortDir, SortField, txtRfidNo.Text, txtSearch.Text, LoginUser.clubId);
                grdAssignedPackages.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit, bool Details)
        {
            pnlView.Visible = View;
            pnlEdit.Visible = Edit;
            pnlDetails.Visible = Details;
        }

        public void PanelVisibility(bool Payment, bool Assign)
        {
            pnlPayment.Visible = Payment;
            pnlAssignValues.Visible = Assign;
        }

        public void BindTowelPackages()
        {
            try
            {
                drpTowelPackages.DataSource = AssignTowelController.GetPackages();
                drpTowelPackages.DataTextField = "packageName";
                drpTowelPackages.DataValueField = "ID";
                drpTowelPackages.DataBind();
                drpTowelPackages.Items.Insert(0, new ListItem("Select Package", "0"));
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
                txtFirstname.Text = objMember.Lead.firstName;
                txtLastName.Text = objMember.Lead.lastName;
                txtDOB.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                txtCntNo.Text = objMember.Lead.mobileNumber;
                txtExpDate.Text = ((DateTime)objMember.expiryDate).ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindTowelPacakgesValues()
        {
            try
            {
                TowelHiringPackage objTowelPackage = TowelPackageController.GetTowelPackageById(TowelPackageId);
                txtDays.Text = Convert.ToString(objTowelPackage.numberOfDays);
                txtHiringTime.Text = Convert.ToString(objTowelPackage.hiringTime);
                txtFees.Text = Convert.ToString(objTowelPackage.amount);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindValues()
        {
            TowelHiringMaster objTowelMaster = AssignTowelController.GetAssignedTowelById(TowelMasterId);
            BindMembers();
            BindTowelPackages();

            drpMembers.SelectedValue = Convert.ToString(objTowelMaster.memberId);
            drpTowelPackages.SelectedValue = Convert.ToString(objTowelMaster.towelPackageId);
            drpTowelPackages.Enabled = drpMembers.Enabled = false;

            txtStDate.Text = ((DateTime)objTowelMaster.startDate).ToString("dd/MM/yyyy");
            txtStDate.ReadOnly = true;
            txtEndDate.Text = ((DateTime)objTowelMaster.endDate).ToString("dd/MM/yyyy");

            pnlAssignValues.Visible = true;
            TowelPackageId = Convert.ToInt64(drpTowelPackages.SelectedValue);
            txtHireRem.Text = BindHiringTime();
            BindTowelPacakgesValues();

            MemberId = Convert.ToInt64(drpMembers.SelectedValue);
            BindMemberValues();

            chkPaidRet.Checked = objTowelMaster.isPaid;
            if (chkPaidRet.Checked)
            {
                pnlPayment.Visible = true;
                BindPayMode();
                rblPayMode.SelectedValue = Convert.ToString(objTowelMaster.paymentMode);
                rblPayMode.Enabled = chkPaidRet.Enabled = false;
            }
        }

        public string BindHiringTime()
        {
            try
            {
                int Trans = 0;
                long HiringTime = 0;

                TowelHiringPackage objTowelPackage = TowelPackageController.GetTowelPackageById(TowelPackageId);
                txtAmt.Text = Convert.ToString(objTowelPackage.amount);
                HiringTime = objTowelPackage.hiringTime;
                if (AssignTowelController.GetTransByMemberAndTowelMasterId(MemberId, TowelMasterId) != null)
                {
                    Trans = AssignTowelController.GetTransByMemberAndTowelMasterId(MemberId, TowelMasterId).Count;
                    HiringTime = HiringTime - Trans;
                }
                return HiringTime.ToString();
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
                rblPayMode.Items.Add(new ListItem("Credit Card", "3"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertTowelMaster()
        {
            try
            {
                TowelHiringMaster objTowelMember = new TowelHiringMaster();
                objTowelMember.towelPackageId = Convert.ToInt64(drpTowelPackages.SelectedValue);
                objTowelMember.memberId = Convert.ToInt64(drpMembers.SelectedValue);
                objTowelMember.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objTowelMember.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objTowelMember.hiringTimeUpdate = Convert.ToInt32(txtHiringTime.Text);
                objTowelMember.amount = Convert.ToDecimal(txtAmt.Text);
                objTowelMember.paymentMode = null;
                objTowelMember.chequeDate = null;
                objTowelMember.chequeNo = objTowelMember.bankName = objTowelMember.branchDetails = null;
                objTowelMember.isPaid = false;
                objTowelMember = new AssignTowelController().InsertTowelMember(objTowelMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Assigned Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTowelMaster()
        {
            try
            {
                TowelHiringMaster objTowelMember = AssignTowelController.GetAssignedTowelById(TowelMasterId);
                objTowelMember.towelPackageId = Convert.ToInt64(drpTowelPackages.SelectedValue);
                objTowelMember.memberId = Convert.ToInt64(drpMembers.SelectedValue);
                objTowelMember.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objTowelMember.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objTowelMember.hiringTimeUpdate = Convert.ToInt32(txtHiringTime.Text);
                objTowelMember.amount = Convert.ToDecimal(txtAmt.Text);
                objTowelMember.paymentMode = null;
                objTowelMember.chequeDate = null;
                objTowelMember.chequeNo = objTowelMember.bankName = objTowelMember.branchDetails = null;
                objTowelMember.isPaid = false;
                objTowelMember = new AssignTowelController().UpdateTowelMember(objTowelMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Package Updated Successfully');", true);
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
                Control[] ctrls = { pnlEdit, pnlAssignValues };
                foreach (Control ctrl in ctrls)
                {
                    foreach (Control item in ctrl.Controls)
                    {
                        if (item is TextBox)
                            ((TextBox)item).Text = "";
                    }
                }
                drpMembers.SelectedIndex = drpTowelPackages.SelectedIndex = 0;
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
                TowelHiringMaster objPTPMember = AssignTowelController.GetAssignedTowelByMemberIdAndPackageId(MemberId, TowelPackageId);
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
                grdTrans.DataSource = AssignTowelController.GetAssignedTransaction(TowelMasterId);
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
                TowelHiringMaster objTowelMaster = AssignTowelController.GetAssignedTowelById(TowelMasterId);
                TowelTransaction objTowelTrans = new TowelTransaction();
                long hiringTime = 0;
                objTowelTrans.towelHiriningId = TowelMasterId;
                objTowelTrans.memberId = MemberId;
                objTowelTrans.depositAmount = objTowelMaster.TowelHiringPackage.depositAmount;
                objTowelTrans.isTowelGiven = true;
                objTowelTrans.isTowelReturn = false;
                objTowelTrans = new AssignTowelController().InsertTransaction(objTowelTrans);

                hiringTime = objTowelMaster.hiringTimeUpdate - 1;
                objTowelMaster.hiringTimeUpdate = (int)hiringTime;
                objTowelMaster = new AssignTowelController().UpdateTowelMember(objTowelMaster);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Hiring Time Added Successfully');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}