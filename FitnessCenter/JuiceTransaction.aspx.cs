﻿using System;
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
    public partial class JuiceTransaction : System.Web.UI.Page
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

        public long ItemId
        {
            get
            {
                var obj = ViewState["ItemId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["ItemId"] = value;
            }
        }

        public List<MemberJuiceTransaction> lstJuiceTrans
        {
            get
            {
                var obj = Session["lstJuiceTrans"];
                return obj == null ? null : (List<MemberJuiceTransaction>)obj;
            }
            set
            {
                Session["lstJuiceTrans"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                ClearValues();
                PanelVisibility(true, false, false);
                pnlMember.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSales.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DetailSales")
                {
                    MemberId = Convert.ToInt64(e.CommandArgument);
                    BindDetails();
                    PanelVisibility(false, false, true);
                    Membership objMember = AssignPTPController.GetmembersByID(MemberId);
                    lblMemberName.Text = "Member Name: " + objMember.Lead.firstName + " " + objMember.Lead.lastName;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdSales_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
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

        protected void btnSalesItems_Click(object sender, EventArgs e)
        {
            PanelVisibility(false, true, false);
            BindItems();
            BindTempGrid();
            lblTotal.Text = "Total Amount: " + ShowTotal();
        }

        protected void txtRfid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRfid.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Rfid Number')", true);
                else
                {
                    Membership objMember = ProductSalesController.GetMembersByRfid(txtRfid.Text);
                    if (objMember != null)
                    {
                        MemberId = objMember.ID;
                        List<MemberJuiceMaster> lstRecharge = JuiceRechargeController.GetRechargesByMemberId(MemberId);
                        MemberJuiceMaster obj = new MemberJuiceMaster();
                        foreach (var objRecharge in lstRecharge)
                        {
                            obj = objRecharge;
                        }
                        if (obj != null && obj.isPaid)
                        {
                            if (obj.availableAmount == 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No Balance left for this Member')", true);
                                ClearMemberValues();
                            }
                            else if (DateTime.Now.CompareTo(obj.endDate) > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Validity Expires for this Member')", true);
                                ClearMemberValues();
                            }
                            else
                            {
                                pnlMember.Visible = true;
                                txtMemName.Text = objMember.Lead.firstName + " " + objMember.Lead.lastName;
                                txtMemCnt.Text = objMember.Lead.mobileNumber;
                                txtMemDOB.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                                lblAvailable.Text = "Available Amount: " + GetAvailableAmount();
                                lblTotal.Text = "Total Amount: " + ShowTotal();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','No Balance or No Payment Done by this Member')", true);
                            ClearMemberValues();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Incorrect Rfid Number or Member is Deactivated')", true);
                        ClearMemberValues();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpItems.SelectedIndex == 0)
                {
                    txtMRP.Text = txtQty.Text = "";
                    txtQty.ReadOnly = true;
                }
                else
                {
                    ItemId = Convert.ToInt64(drpItems.SelectedValue);
                    ItemMaster objItem = ItemController.GetItemsById(ItemId);
                    txtMRP.Text = Convert.ToString(objItem.mrp);
                    txtQty.ReadOnly = false;
                    txtQty.Text = "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpItems.SelectedIndex == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Item')", true);
                else if (txtRfid.Text == "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Rfid Number')", true);
                else if (txtQty.Text.Equals(""))
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Insert Quantity')", true);
                else
                {
                    InsertTempTrans();
                    BindTempGrid();
                    drpItems.SelectedIndex = 0;
                    drpItems_SelectedIndexChanged(sender, e);
                    lblTotal.Text = "Total Amount: " + ShowTotal();
                    lblAvailable.Text = "Available Amount: " + GetAvailableAmount();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstJuiceTrans != null && lstJuiceTrans.Count > 0)
                {
                    InsertTrans();
                    ClearValues();
                    PanelVisibility(true, false, false);
                    BindGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Insert Atleast one Item')", true);
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
                PanelVisibility(true, false, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdTempSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteItem")
                {
                    ItemId = Convert.ToInt64(e.CommandArgument);
                    var obj = lstJuiceTrans.FirstOrDefault(x => x.itemId == ItemId);
                    lstJuiceTrans.Remove(obj);
                    BindTempGrid();
                    lblTotal.Text = "Total Amount: " + ShowTotal();
                    lblAvailable.Text = "Available Amount: " + GetAvailableAmount();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                PanelVisibility(true, false, false);
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
                grdSales.DataSource = JuiceTransController.GetJuiceTrans(SortDir, "FULLNAME", txtSearchRfid.Text, txtSearchName.Text);
                grdSales.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindTempGrid()
        {
            try
            {
                grdTempSales.DataSource = lstJuiceTrans;
                grdTempSales.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindItems()
        {
            try
            {
                drpItems.DataSource = JuiceTransController.GetJuiceItems();
                drpItems.DataTextField = "name";
                drpItems.DataValueField = "ID";
                drpItems.DataBind();
                drpItems.Items.Insert(0, new ListItem("Select Item", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindDetails()
        {
            try
            {
                grdDetails.DataSource = JuiceTransController.GetJuiceTransByMemberId(MemberId);
                grdDetails.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertTempTrans()
        {
            try
            {
                var obj = lstJuiceTrans;
                MemberJuiceTransaction temp = new MemberJuiceTransaction();
                if (obj == null)
                    obj = new List<MemberJuiceTransaction>();
                ItemId = Convert.ToInt64(drpItems.SelectedValue);

                
                    if (lstJuiceTrans != null && lstJuiceTrans.Count > 0)
                    {

                        if (lstJuiceTrans.FirstOrDefault(x => x.isDeleted == false && x.itemId == ItemId) == null)
                        {
                            temp.itemId = ItemId;
                            ItemMaster objItem = ProductSalesController.GetItemsById(ItemId);
                            temp.ItemMaster = objItem;
                            temp.quantity = Convert.ToInt32(txtQty.Text);
                            temp.amount = Convert.ToDecimal(txtMRP.Text);
                            decimal total = 0;
                            total = temp.quantity * temp.amount;
                            temp.totalAmount = total;
                            temp.memberId = MemberId;
                            if (GetAvailableAmount() >= total)
                            {
                                obj.Add(temp);
                                lstJuiceTrans = obj;
                            }
                            else
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Sorry no More Balance Left. Delete some items or recharge')", true);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','This Item is already Sold to this Member')", true);
                    }
                    else
                    {
                        temp.itemId = ItemId;
                        ItemMaster objItem = ProductSalesController.GetItemsById(ItemId);
                        temp.ItemMaster = objItem;
                        temp.quantity = Convert.ToInt32(txtQty.Text);
                        temp.amount = Convert.ToDecimal(txtMRP.Text);
                        decimal total = 0;
                        total = temp.quantity * temp.amount;
                        temp.totalAmount = total;
                        temp.memberId = MemberId;
                        if (GetAvailableAmount() >= total)
                        {
                            obj.Add(temp);
                            lstJuiceTrans = obj;
                        }
                        else
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Sorry no More Balance Left. Delete some items or recharge')", true);
                    }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit, bool Details)
        {
            try
            {
                pnlEdit.Visible = Edit;
                pnlView.Visible = View;
                pnlDetails.Visible = Details;
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
                txtMRP.Text = txtQty.Text = txtRfid.Text = string.Empty;
                drpItems.SelectedIndex = 0;
                lstJuiceTrans = null;
                ClearMemberValues();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal ShowTotal()
        {
            try
            {
                decimal total = 0;
                if (lstJuiceTrans != null)
                {
                    foreach (var obj in lstJuiceTrans)
                        total += (decimal)obj.totalAmount;
                }
                return total;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal GetAvailableAmount()
        {
            try
            {
                decimal Available = 0, total = 0;
                List<MemberJuiceMaster> lstRecharge = JuiceRechargeController.GetRechargesByMemberId(MemberId);
                var obj = lstRecharge.LastOrDefault(x => x.isPaid == true && x.isDelete == false);
                if (obj != null)
                {
                    Available = obj.availableAmount;
                    total = ShowTotal();
                    Available -= total;
                }
                return Available;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertTrans()
        {
            try
            {
                foreach (var obj in lstJuiceTrans)
                {
                    MemberJuiceTransaction objsale = new MemberJuiceTransaction();
                    objsale.memberId = obj.memberId;
                    objsale.itemId = obj.itemId;
                    objsale.amount = obj.amount;
                    objsale.quantity = obj.quantity;
                    objsale.totalAmount = obj.totalAmount;
                    new JuiceTransController().InsertJuiceTrans(objsale);
                }
                UpdateJuiceRecharge();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Success','Items Sold Successfully')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateJuiceRecharge()
        {
            List<MemberJuiceMaster> lstRecharge = JuiceRechargeController.GetRechargesByMemberId(MemberId);
            var obj = lstRecharge.LastOrDefault(x => x.isPaid == true && x.isDelete == false);
            obj.availableAmount = GetAvailableAmount();
            obj = new JuiceTransController().UpdateJuiceRecharge(obj);
        }

        public void ClearMemberValues()
        {
            try
            {
                foreach (Control ctrl in pnlMember.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = string.Empty;
                }
                pnlMember.Visible = false;
                txtRfid.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}