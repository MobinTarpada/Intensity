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
    public partial class JuiceRecharge : System.Web.UI.Page
    {
        #region Properties
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
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelVisibility(false, false);
            }
        }

        protected void btnAddRecharge_Click(object sender, EventArgs e)
        {
            PanelVisibility(true, true);
            grdRecharge.Visible = false;
            BindPrevBalance();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InsertRecharge();
                ClearValues();
                PanelVisibility(false, false);
                txtRfid.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearValues();
            PanelVisibility(false, false);
            txtRfid.Text = "";
        }

        protected void txtRfid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRfid.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter RFID Number');", true);
                    ClearValues();
                    PanelVisibility(false, false);
                }
                else
                {
                    var objMember = new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.RFIDCardNumber == txtRfid.Text);
                    bool isPaid = true;
                    MemberId = objMember.ID;
                    List<MemberJuiceMaster> lstRech = JuiceRechargeController.GetRechargesByMemberId(MemberId);
                    if (lstRech != null && lstRech.Count > 0)
                    {
                        foreach (var obj in lstRech)
                        {
                            if (!obj.isPaid)
                            {
                                isPaid = false;
                                break;
                            }
                            else
                                isPaid = true;
                        }
                    }
                    if (isPaid)
                    {
                        PanelVisibility(true, false);
                        BindMemberValues();
                        BindGrid();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Previous Payment is not paid by this Member. Recharge fail');", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void chkIsForwarded_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                decimal prevAmt = 0, prepaidAmt = 0, total = 0;
                prevAmt = Convert.ToDecimal(txtPrevAmt.Text);
                prepaidAmt = (txtAmount.Text.Equals("")) ? 0 : Convert.ToDecimal(txtAmount.Text);

                if (chkIsForwarded.Checked)
                    total = prepaidAmt + prevAmt;
                else
                    total = prepaidAmt;
                txtTotalAmt.Text = total.ToString();
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Select Start Date');", true);
                else if (txtDays.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Error','Please Enter Days');", true);
                    txtStDate.Text = "";
                }
                else
                {
                    DateTime stDate, endDate;
                    stDate = UtillController.ConvertDateTime(txtStDate.Text);
                    endDate = stDate.AddDays(Convert.ToInt32(txtDays.Text));
                    txtEndDate.Text = endDate.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dis = 0, prepaid = 0, final = 0;
                dis = (txtDiscount.Text.Equals("")) ? 0 : Convert.ToDecimal(txtDiscount.Text);
                prepaid = (txtAmount.Text.Equals("")) ? 0 : Convert.ToDecimal(txtAmount.Text);
                final = prepaid - ((prepaid * dis) / 100);
                txtFinalAmt.Text = final.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal prevAmt = 0, prepaidAmt = 0, total = 0;
                prevAmt = Convert.ToDecimal(txtPrevAmt.Text);
                prepaidAmt = (txtAmount.Text.Equals("")) ? 0 : Convert.ToDecimal(txtAmount.Text);

                if (chkIsForwarded.Checked)
                    total = prepaidAmt + prevAmt;
                else
                    total = prepaidAmt;
                txtTotalAmt.Text = total.ToString();
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
                grdRecharge.DataSource = JuiceRechargeController.GetRechargesByMemberId(MemberId);
                grdRecharge.DataBind();
                grdRecharge.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit)
        {
            pnlView.Visible = View;
            pnlEdit.Visible = Edit;
        }

        public void InsertRecharge()
        {
            try
            {
                MemberJuiceMaster objMemberJuice = new MemberJuiceMaster();
                objMemberJuice.memberId = MemberId;
                objMemberJuice.rechargeAmount = Convert.ToDecimal(txtAmount.Text);
                objMemberJuice.validDays = Convert.ToInt32(txtDays.Text);
                objMemberJuice.startDate = UtillController.ConvertDateTime(txtStDate.Text);
                objMemberJuice.endDate = UtillController.ConvertDateTime(txtEndDate.Text);
                objMemberJuice.discount = Convert.ToDecimal(txtDiscount.Text);
                objMemberJuice.finalAmount = Convert.ToDecimal(txtFinalAmt.Text);
                objMemberJuice.availableAmount = Convert.ToDecimal(txtTotalAmt.Text);
                objMemberJuice.payMode = null;
                objMemberJuice.isPaid = false;
                objMemberJuice = new JuiceRechargeController().InsertJuiceRecharge(objMemberJuice);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Recharge Successfully');", true);
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
                foreach (Control ctrl in pnlEdit.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = "";
                }
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
                Membership objMember = CustomerController.GetMembersByID(MemberId);
                txtFirstName.Text = objMember.Lead.firstName;
                txtLastName.Text = objMember.Lead.lastName;
                txtDateOfBirth.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                txtContactNo.Text = objMember.Lead.mobileNumber;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindPrevBalance()
        {
            try
            {
                List<MemberJuiceMaster> lstRecharge = JuiceRechargeController.GetRechargesByMemberId(MemberId);
                decimal prevAmt = 0;
                foreach (var obj in lstRecharge)
                {
                    prevAmt = obj.availableAmount;
                }
                txtPrevAmt.Text = prevAmt.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }
}