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
    public partial class frmPayment : System.Web.UI.Page
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
        public long ClubId
        {
            get
            {
                var obj = ViewState["ClubId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ClubId"] = value;
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

        public String AgreementNumber
        {
            get
            {
                var obj = ViewState["AgreementNumber"];
                return obj == null ? null : (String)obj;
            }
            set
            {
                ViewState["AgreementNumber"] = value;
            }
        }

        public String MembershipId
        {
            get
            {
                var obj = ViewState["MembershipId"];
                return obj == null ? null : (String)obj;
            }
            set
            {
                ViewState["MembershipId"] = value;
            }
        }
        public decimal FinalAmount
        {
            get
            {
                var obj = ViewState["FinalAmount"];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                ViewState["FinalAmount"] = value;
            }
        }

        public decimal AmountPaid
        {
            get
            {
                var obj = ViewState["AmountPaid"];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                ViewState["AmountPaid"] = value;
            }
        }

        public decimal RemainingAmount
        {
            get
            {
                var obj = ViewState["RemainingAmount"];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                ViewState["RemainingAmount"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PanelVisibility(false, false);
                    pnlScanRfid.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //protected void chkAgreement_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        protected void txtRfid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRfid.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter RFID or Agreement Number');", true);
                else if (drpPaymentType.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Options For Payment');", true);
                }
                else
                {
                    if (BindMemberValues())
                    {
                        switch (drpPaymentType.SelectedIndex)
                        {
                            case 0:
                                PanelVisibility(true, false);
                                break;
                            case 1:     //Membership Table
                                Membership objMember = CustomerController.GetMembersByID(MemberId);
                                if (!(bool)objMember.isPaid || objMember.remainingAmount > 0)
                                {
                                    PanelVisibility(true, true);
                                    PanelPaymentVisibility(false, false);
                                    FinalAmount = (objMember.finalAmount == null) ? 0 : Convert.ToDecimal(objMember.finalAmount);
                                    AmountPaid = (objMember.amountPaid == null) ? 0 : Convert.ToDecimal(objMember.amountPaid);
                                    RemainingAmount = (objMember.remainingAmount == null) ? 0 : Convert.ToDecimal(objMember.remainingAmount);
                                }
                                else
                                {
                                    PanelVisibility(false, false);
                                    PanelPaymentVisibility(false, false);
                                    ClearValues();
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Member Fee is already paid by this Member.');", true);
                                }
                                break;
                            case 2:     //PTP Table
                                PTPMemberMaster objPTP = PaymentController.GetAssignedPTPByMemberId(MemberId);

                                if (objPTP != null)
                                {
                                    if (!(bool)objPTP.isPaid)
                                    {
                                        PanelVisibility(true, true);
                                        PanelPaymentVisibility(false, false);
                                        FinalAmount = (decimal)objPTP.amount;
                                    }
                                    else
                                    {
                                        PanelVisibility(false, false);
                                        PanelPaymentVisibility(false, false);
                                        ClearValues();
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','PTP Fee is already paid by this Member.');", true);
                                    }
                                }
                                else
                                {
                                    PanelVisibility(false, false);
                                    PanelPaymentVisibility(false, false);
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No PTP Package is Assigned to this Member.');", true);
                                }
                                break;
                            case 3:     //Towel Table
                                TowelHiringMaster objTowel = PaymentController.GetAssignedTowelByMemberId(MemberId);

                                if (objTowel != null)
                                {
                                    if (!(bool)objTowel.isPaid)
                                    {
                                        PanelVisibility(true, true);
                                        PanelPaymentVisibility(false, false);
                                        FinalAmount = (decimal)objTowel.amount;
                                    }
                                    else
                                    {
                                        PanelVisibility(false, false);
                                        PanelPaymentVisibility(false, false);
                                        ClearValues();
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Towel Fee is already paid by this Member.');", true);

                                    }
                                }
                                else
                                {
                                    PanelVisibility(false, false);
                                    PanelPaymentVisibility(false, false);
                                    ClearValues();
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No Towel Package is Assigned to this Member.');", true);
                                }
                                break;
                            case 4:     //Item Table
                                MemberItemTotalSale objTotal = PaymentController.GetTotalSalesByMemberId(MemberId);
                                if (objTotal != null)
                                {
                                    if (!(bool)objTotal.isPaid)
                                    {
                                        PanelVisibility(true, true);
                                        PanelPaymentVisibility(false, false);
                                        FinalAmount = (decimal)objTotal.finalAmount;
                                    }
                                    else
                                    {
                                        PanelVisibility(false, false);
                                        PanelPaymentVisibility(false, false);
                                        ClearValues();
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Payment of Items sold is already paid by this Member.');", true);
                                    }
                                }
                                else
                                {
                                    PanelVisibility(false, false);
                                    PanelPaymentVisibility(false, false);
                                    ClearValues();
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No Items are Sold to this Member.');", true);
                                }
                                break;
                            case 5:     //Juice Table
                                MemberJuiceMaster objJuice = PaymentController.GetJuiceRechargeByMemberId(MemberId);
                                if (objJuice != null)
                                {
                                    if (!(bool)objJuice.isPaid)
                                    {
                                        PanelVisibility(true, true);
                                        PanelPaymentVisibility(false, false);
                                        FinalAmount = (decimal)objJuice.finalAmount;
                                    }
                                    else
                                    {
                                        PanelVisibility(false, false);
                                        PanelPaymentVisibility(false, false);
                                        ClearValues();
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Payment of Juice Recharge is already paid by this Member.');", true);
                                    }
                                }
                                else
                                {
                                    PanelVisibility(false, false);
                                    PanelPaymentVisibility(false, false);
                                    ClearValues();
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No Juice Recharge is given to this Member.');", true);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpPaymentType.SelectedIndex == 0)
                {
                    PanelVisibility(false, false);
                    pnlScanRfid.Visible = false;
                    ClearValues();

                }
                else
                {
                    pnlScanRfid.Visible = true;
                }
                if (drpPaymentType.SelectedIndex == 1)
                    rfid.InnerText = "Enter Agreement Number";
                else
                    rfid.InnerText = "Scan RFID Number";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void rblPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (rblPayMode.SelectedIndex)
                {
                    case 0:
                        //Membership objMember = new Membership();
                        //Decimal RemaningAmount = Convert.ToDecimal(objMember.remainingAmount);
                        //Decimal BillAmount = Convert.ToDecimal(objMember.finalAmount);
                        PanelPaymentVisibility(true, false);
                        if (RemainingAmount != 0)
                        {
                            txtBillAmount.Text = Convert.ToString(RemainingAmount);
                        }
                        else
                        {
                            txtBillAmount.Text = Convert.ToString(FinalAmount);
                        }

                        txtAmountPaid.Text = "";
                        txtRemainingAmount.Text = "";
                        break;
                    case 1:
                        PanelPaymentVisibility(false, true);
                        //txtAmount.Text = Convert.ToString(FinalAmount);
                        //txtBillAmount.Text = Convert.ToString(AmountPaid);
                        //txtRemainingAmount.Text = Convert.ToString(RemainingAmount);
                        if (RemainingAmount != 0)
                        {
                            txtChqBillAmt.Text = Convert.ToString(RemainingAmount);
                        }
                        else
                        {
                            txtChqBillAmt.Text = Convert.ToString(FinalAmount);
                        }
                        txtAmountPaid.Text = "";
                        txtRemainingAmount.Text = "";
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal a = 0, b = 0;
                a = Convert.ToDecimal(txtBillAmount.Text);
                b = Convert.ToDecimal(txtAmountPaid.Text);
                if (b > a)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Enter Amount LessThan or Equal to Bill Amount')", true);
                    txtAmountPaid.Text = "";
                }
                else
                    txtRemainingAmount.Text = Convert.ToString(Convert.ToDecimal(txtBillAmount.Text) - Convert.ToDecimal(txtAmountPaid.Text));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void txtChqAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal a = 0, b = 0;
                a = Convert.ToDecimal(txtChqBillAmt.Text);
                b = Convert.ToDecimal(txtChqAmountPaid.Text);
                if (b > a)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Enter Amount LessThan or Equal to Bill Amount')", true);
                    txtChqAmountPaid.Text = "";
                }
                else
                    txtChqRemaiAmt.Text = Convert.ToString(Convert.ToDecimal(txtChqBillAmt.Text) - Convert.ToDecimal(txtChqAmountPaid.Text));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void chkIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpPaymentType.SelectedIndex == 1 && (chkIsPaid.Checked || chkChqPaid.Checked))
                    pnlRfidNo.Visible = true;
                else
                    pnlRfidNo.Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblPayMode.SelectedValue == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Select PayMode')", true);
                else
                {
                    Membership objMember = CustomerController.GetMembersByID(MemberId);
                    String AgreementNo = objMember.agreementNumber;
                    MakePayment();
                    ClearValues();

                    PanelVisibility(false, false);
                    pnlScanRfid.Visible = false;
                    Response.Redirect("./frmPaymentReceipt.aspx?agreementNo=" + AgreementNo);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Backbutton_Click(object sender, EventArgs e)
        {
            try
            {
                PanelVisibility(false, false);
                PanelPaymentVisibility(false, false);
                ClearValues();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Methods
        public bool BindMemberValues()
        {
            Membership objMember = new Membership();
            Membership objMember1 = new Membership();
            if (drpPaymentType.SelectedIndex == 1)
            {
                objMember = PaymentController.GetMembersByAgreementNo(txtRfid.Text);

            }
            //objMember = PaymentController.GetMembersByRfidNo(txtRfid.Text);
            if (drpPaymentType.SelectedIndex == 1)
            {
                objMember1 = PaymentController.GetMembersByRfidNo(txtRfid.Text);
            }
            if (objMember != null)
            {
                txtFirstName.Text = objMember.Lead.firstName;
                txtLastName.Text = objMember.Lead.lastName;
                txtDateOfBirth.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                txtContactNo.Text = objMember.Lead.mobileNumber;
                MemberId = objMember.ID;
                LeadId = objMember.leadId;
                PanelVisibility(true, false);
                return true;
            }
            else if (objMember1 != null)
            {
                txtFirstName.Text = objMember1.Lead.firstName;
                txtLastName.Text = objMember1.Lead.lastName;
                txtDateOfBirth.Text = ((DateTime)objMember1.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                txtContactNo.Text = objMember1.Lead.mobileNumber;
                MemberId = objMember1.ID;
                LeadId = objMember1.leadId;
                PanelVisibility(true, false);
                return true;
            }
            else
            {
                txtRfid.Text = "";
                PanelVisibility(false, false);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Invalid RFID or Agreement Number');", true);
                return false;
            }

        }

        public void PanelVisibility(bool View, bool Payment)
        {
            pnlView.Visible = View;
            pnlPayment.Visible = Payment;
        }

        public void BindPayMode()
        {
            try
            {
                rblPayMode.Items.Clear();
                foreach (ListItem item in rblPayMode.Items)
                    item.Selected = false;

                rblPayMode.Items.Add(new ListItem("Cash", "1"));
                rblPayMode.Items.Add(new ListItem("Cheque", "2"));
                rblPayMode.Items.Add(new ListItem("CreditCard", "3"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelPaymentVisibility(bool Cash, bool Cheque)
        {
            pnlCashPayment.Visible = Cash;
            pnlChequePayment.Visible = Cheque;
        }

        public void UpdateMembership()
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                Membership objRenew = CustomerController.GetMembersOldByID(LeadId);

                String a, b;
                if (objRenew == null)
                    a = objMember.agreementNumber;
                else
                    a = objRenew.agreementNumber.Substring(0);
                b = txtRfid.Text.Substring(0);
                objMember.payMode = Convert.ToInt32(rblPayMode.SelectedValue);
                if (rblPayMode.SelectedValue == "1")
                {
                    objMember.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                    objMember.remainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
                    objMember.isPaid = chkIsPaid.Checked;
                    objMember.chequeDate = null;
                    objMember.BankName = objMember.Branch = objMember.chequeNumber = null;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objMember.isPaid = chkChqPaid.Checked;
                    objMember.amountPaid = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objMember.remainingAmount = Convert.ToDecimal(txtChqRemaiAmt.Text);
                    objMember.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objMember.chequeNumber = txtChkNo.Text;
                    objMember.BankName = txtBankName.Text;
                    objMember.Branch = txtBranchDetails.Text;
                }

                if (a != b)
                {
                    objMember.membershipUniqueId = objMember.membershipUniqueId;
                }
                else
                {
                    objMember.membershipUniqueId = (bool)objMember.isPaid ? MembershipNumber() : null;
                    objMember.RFIDCardNumber = (bool)objMember.isPaid ? txtRFIDNo.Text : null;
                }
                objMember = new MembershipController().UpdateMember(objMember);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Member Payment Recieved Successfully')", true);

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

                objLead.leadStatusId = 7;

                objLead = new LeadController().UpdateLead(objLead);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePTP()
        {
            try
            {
                PTPMemberMaster objPTP = new FitnessCenterEntities().PTPMemberMasters.FirstOrDefault(x => x.isActive == true && x.isDelete == false && x.isPaid == false && x.memberId == MemberId);
                objPTP.payMode = Convert.ToInt32(rblPayMode.SelectedValue);

                if (rblPayMode.SelectedValue == "1")
                {
                    objPTP.amount = Convert.ToDecimal(txtAmountPaid.Text);
                    objPTP.isPaid = chkIsPaid.Checked;
                    objPTP.chequeDate = null;
                    objPTP.bankName = objPTP.branchDetails = objPTP.chequeNo = null;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objPTP.amount = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objPTP.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objPTP.chequeNo = txtChkNo.Text;
                    objPTP.bankName = txtBankName.Text;
                    objPTP.branchDetails = txtBranchDetails.Text;
                    objPTP.isPaid = chkChqPaid.Checked;
                }
                objPTP = new AssignPTPController().UpdatePTPMember(objPTP);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'PTP Package Payment Recieved Successfully')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTowel()
        {
            try
            {
                TowelHiringMaster objTowel = new FitnessCenterEntities().TowelHiringMasters.FirstOrDefault(x => x.isDeleted == false && x.isPaid == false && x.memberId == MemberId);
                objTowel.paymentMode = Convert.ToInt32(rblPayMode.SelectedValue);
                if (rblPayMode.SelectedValue == "1")
                {
                    objTowel.amount = Convert.ToDecimal(txtAmountPaid.Text);
                    objTowel.isPaid = chkIsPaid.Checked;
                    objTowel.chequeDate = null;
                    objTowel.bankName = objTowel.branchDetails = objTowel.chequeNo = null;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objTowel.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objTowel.amount = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objTowel.chequeNo = txtChkNo.Text;
                    objTowel.bankName = txtBankName.Text;
                    objTowel.branchDetails = txtBranchDetails.Text;
                    objTowel.isPaid = chkChqPaid.Checked;
                }
                objTowel = new AssignTowelController().UpdateTowelMember(objTowel);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Towel Package Payment Recieved Successfully')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTotalSales()
        {
            try
            {
                MemberItemTotalSale objTotalSales = new FitnessCenterEntities().MemberItemTotalSales.FirstOrDefault(x => x.isDeleted == false && x.isPaid == false && x.memberId == MemberId);
                objTotalSales.payMode = Convert.ToInt32(rblPayMode.SelectedValue);

                if (rblPayMode.SelectedValue == "1")
                {
                    objTotalSales.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                    objTotalSales.isPaid = chkIsPaid.Checked;
                    objTotalSales.remAmount = Convert.ToDecimal(txtRemainingAmount.Text);
                    objTotalSales.chequeDate = null;
                    objTotalSales.BankName = objTotalSales.BranchName = objTotalSales.chequeNumber = null;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objTotalSales.amountPaid = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objTotalSales.remAmount = Convert.ToDecimal(txtChqRemaiAmt.Text); ;
                    objTotalSales.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objTotalSales.chequeNumber = txtChkNo.Text;
                    objTotalSales.BankName = txtBankName.Text;
                    objTotalSales.BranchName = txtBranchDetails.Text;
                    objTotalSales.isPaid = chkChqPaid.Checked;
                }
                objTotalSales = new ProductSalesController().UpdateTotalSale(objTotalSales);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Payment of Items Recieved Successfully')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateJuiceRecharge()
        {
            try
            {
                MemberJuiceMaster objJuiceRecharge = new FitnessCenterEntities().MemberJuiceMasters.FirstOrDefault(x => x.isDelete == false && x.isPaid == false && x.memberId == MemberId);
                objJuiceRecharge.payMode = Convert.ToInt32(rblPayMode.SelectedValue);

                if (rblPayMode.SelectedValue == "1")
                {
                    objJuiceRecharge.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                    objJuiceRecharge.isPaid = chkIsPaid.Checked;
                    objJuiceRecharge.remAmount = Convert.ToDecimal(txtRemainingAmount.Text);
                    objJuiceRecharge.chequeDate = null;
                    objJuiceRecharge.BankName = objJuiceRecharge.BranchName = objJuiceRecharge.chequeNumber = null;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objJuiceRecharge.amountPaid = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objJuiceRecharge.remAmount = Convert.ToDecimal(txtChqRemaiAmt.Text);
                    objJuiceRecharge.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objJuiceRecharge.chequeNumber = txtChkNo.Text;
                    objJuiceRecharge.BankName = txtBankName.Text;
                    objJuiceRecharge.BranchName = txtBranchDetails.Text;
                    objJuiceRecharge.isPaid = chkChqPaid.Checked;
                }
                objJuiceRecharge = new JuiceRechargeController().UpdateJuiceRecharge(objJuiceRecharge);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Payment of Juice Recharge Recieved Successfully')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertPaymentHistory()
        {
            try
            {
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                Payment objReceipt = PaymentController.GetLastReceiptNumber(LoginUser.clubId);

                Payment objPayment = new Payment();
                objPayment.payMode = Convert.ToInt32(rblPayMode.SelectedValue);

                objPayment.leadId = objMember.leadId;
                objPayment.clubId = LoginUser.clubId;
                objPayment.packageTypeId = objMember.packageTypeId;
                objPayment.packageAmount = objMember.packageAmount;
                objPayment.schemeID = objMember.schemeID;
                objPayment.schemeAmount = objMember.schemeAmount;
                objPayment.joiningFee = objMember.joiningFee;
                objPayment.adminFee = objMember.adminFee;
                objPayment.membershipFee = objMember.membershipFee;
                objPayment.personalTrainingPack = objMember.personalTrainingPack;
                objPayment.serviceTaxInPercentage = objMember.serviceTaxInPercentage;
                objPayment.discountGivenBy = objMember.discountGivenBy;

                objPayment.registrationDate = objMember.registrationDate;
                objPayment.activationDate = objMember.activationDate;
                objPayment.agreementNumber = objMember.agreementNumber;
                objPayment.RFIDCardNumber = objMember.RFIDCardNumber;
                objPayment.membershipUniqueId = objMember.membershipUniqueId;
                objPayment.consult = objMember.consult;
                objPayment.branchName = objMember.branchName;
                objPayment.expiryDate = objMember.expiryDate;


                if (rblPayMode.SelectedValue == "1")
                {
                    objPayment.finalAmount = Convert.ToDecimal(txtBillAmount.Text);
                    objPayment.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                    objPayment.remainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
                    if (txtRemainingAmount.Text == "0.00")
                    {
                        objPayment.isFullPaid = Convert.ToBoolean("True");
                    }
                    else
                    {
                        if (txtDueAmount.Text == "")
                        {
                            txtDueAmount.Focus();

                        }
                        else
                        {
                            objPayment.DueAmountDate = UtillController.ConvertDateTime(txtDueAmount.Text);
                            objPayment.isFullPaid = Convert.ToBoolean("False");
                        }
                    }
                    objPayment.isPaid = chkIsPaid.Checked;
                    objPayment.ReceiptNumber = objReceipt.ReceiptNumber + 1;
                }
                else if (rblPayMode.SelectedValue == "2")
                {
                    objPayment.finalAmount = Convert.ToDecimal(txtChqBillAmt.Text);
                    objPayment.isPaid = chkChqPaid.Checked;
                    if (txtRemainingAmount.Text == "0.00")
                    {
                        if (txtDueAmount.Text == "")
                        {
                            objPayment.DueAmountDate = null;
                        }
                        else
                        {
                            objPayment.DueAmountDate = UtillController.ConvertDateTime(txtChqDueAmount.Text);
                        }
                    }
                    else
                    {
                        if (txtDueAmount.Text == "")
                        {
                            objPayment.DueAmountDate = null;
                        }
                        else
                        {
                            objPayment.DueAmountDate = UtillController.ConvertDateTime(txtChqDueAmount.Text);
                        }
                    }
                    objPayment.amountPaid = Convert.ToDecimal(txtChqAmountPaid.Text);
                    objPayment.remainingAmount = Convert.ToDecimal(txtChqRemaiAmt.Text);
                    objPayment.chequeDate = UtillController.ConvertDateTime(txtChkDate.Text);
                    objPayment.chequeNumber = txtChkNo.Text;
                    objPayment.BankName = txtBankName.Text;
                    objPayment.Branch = txtBranchDetails.Text;
                }
                objMember.membershipUniqueId = objMember.membershipUniqueId;
                objMember.RFIDCardNumber = objMember.RFIDCardNumber;

                new PaymentController().InsertPaymentHistory(objPayment);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success', 'Member Payment Recieved Successfully')", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void MakePayment()
        {
            try
            {
                if (rblPayMode.SelectedValue == "1" && txtAmountPaid.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Enter Amount Paid')", true);
                else if (rblPayMode.SelectedValue == "2" && txtChqAmountPaid.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Enter Amount Paid')", true);
                else
                {
                    switch (drpPaymentType.SelectedIndex)
                    {
                        case 1:
                            if ((chkChqPaid.Checked || chkIsPaid.Checked) && txtRFIDNo.Text == "")
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error', 'Please Enter RFID Number')", true);
                            else
                            {
                                DeactiveOldMember();
                                UpdateMembership();
                                InsertPaymentHistory();
                                UpdateLead();
                                DeActiveDuePayment();
                            }
                            break;
                        case 2:
                            UpdatePTP();
                            break;
                        case 3:
                            UpdateTowel();
                            break;
                        case 4:
                            UpdateTotalSales();
                            break;
                        case 5:
                            UpdateJuiceRecharge();
                            break;
                    }
                }
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
                Control[] ctrls = { pnlCashPayment, pnlChequePayment, pnlPayment, pnlRfidNo, pnlScanRfid, pnlView };
                new ManageMemberShip().ControlsClear(ctrls);
                drpPaymentType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string MembershipNumber()
        {
            //Membership objMembership = MembershipController.GetMemberById(MemberId);
            Membership objMembership = CustomerController.GetMembersByID(MemberId);

            string MNumber = "INT", MemberNo = "";
            MNumber += LoginUser.clubId.ToString().PadLeft(3, '0');
            long i = objMembership.ID;
            MemberNo = i.ToString().PadLeft(6, '0');
            MemberNo = MemberNo.Substring(MemberNo.Length - 6, 6);
            MNumber += MemberNo;
            return MNumber;

        }

        public void DeactiveOldMember()
        {
            try
            {
                Membership objMember = CustomerController.GetMembersOldByID(LeadId);


                if (objMember != null && objMember.remainingAmount == 0)
                {
                    objMember.isActive = Convert.ToBoolean("False");
                    objMember.isDeleted = Convert.ToBoolean("True");
                    objMember = new CustomerController().UpdateMembers(objMember);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeActiveDuePayment()
        {
            try
            {
                Payment objPayments = new Payment();
                if (objPayments.isFullPaid == true)
                {
                    Payment objPayment = PaymentController.GetDueMembersByAgreementNo(LeadId);

                    if (objPayment != null && objPayment.remainingAmount == 0)
                    {
                        objPayment.isFullPaid = Convert.ToBoolean("True");
                        objPayment = new PaymentController().UpdatePaymentHistory(objPayment);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}