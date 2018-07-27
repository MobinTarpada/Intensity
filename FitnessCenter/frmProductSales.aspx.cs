using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using FitnessCenter.DAL;

namespace FitnessCenter
{
    public partial class frmProductSales : System.Web.UI.Page
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

        public long MemberFinalSalesId
        {
            get
            {
                var obj = ViewState["MemberFinalSalesId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["MemberFinalSalesId"] = value;
            }
        }

        public List<MemberItemSale> lstSales
        {
            get
            {
                var obj = Session["lstSales"];
                return obj == null ? null : (List<MemberItemSale>)obj;
            }
            set
            {
                Session["lstSales"] = value;
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

        protected void btnSalesItems_Click(object sender, EventArgs e)
        {
            PanelVisibility(false, true, false);
            BindItems();
            BindTempGrid();
            lblTotal.Text = "Total Amount: " + ShowTotal();
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
                if (lstSales != null && lstSales.Count > 0)
                {
                    if (txtDis.Text == "")
                    {
                        txtDis.Text = "0";
                        txtFinalAmt.Text = ShowTotal();
                    }
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

        protected void grdTempSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteItem")
                {
                    ItemId = Convert.ToInt64(e.CommandArgument);
                    var obj = lstSales.FirstOrDefault(x => x.itemId == ItemId);
                    lstSales.Remove(obj);
                    BindTempGrid();
                    lblTotal.Text = "Total Amount: " + ShowTotal();

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
                        pnlMember.Visible = true;
                        MemberId = objMember.ID;
                        MemberItemTotalSale objTotalsale = ProductSalesController.GetTotalSalesbyMemberId(MemberId);
                        if (objTotalsale == null)
                        {
                            txtMemName.Text = objMember.Lead.firstName + " " + objMember.Lead.lastName;
                            txtMemCnt.Text = objMember.Lead.mobileNumber;
                            txtMemDOB.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                        }
                        else if (objTotalsale != null && objTotalsale.isPaid)
                        {
                            txtMemName.Text = objMember.Lead.firstName + " " + objMember.Lead.lastName;
                            txtMemCnt.Text = objMember.Lead.mobileNumber;
                            txtMemDOB.Text = ((DateTime)objMember.Lead.dateOfBirth).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Previous Payment of this Member is not paid. No more sales Possible')", true);
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

        protected void txtDis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dis = 0, final = 0;
                if (txtDis.Text != "")
                {
                    dis = Convert.ToDecimal(txtDis.Text);
                    final = (Convert.ToDecimal(ShowTotal()) * dis) / 100;
                    final = Convert.ToDecimal(ShowTotal()) - final;
                    txtFinalAmt.Text = final.ToString();
                }
                else
                {
                    txtFinalAmt.Text = ShowTotal();
                    txtDis.Text = "0";
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
                grdSales.DataSource = ProductSalesController.GetProductSales(SortDir, "FULLNAME", txtSearchRfid.Text, txtSearchName.Text, LoginUser.ClubId);
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
                grdTempSales.DataSource = lstSales;
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
                drpItems.DataSource = ProductSalesController.GetItems();
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
                grdDetails.DataSource = ProductSalesController.GetProductSalesByMemberId(MemberId);
                grdDetails.DataBind();
                // MemberItemTotalSale objTotalSale = new FitnessCenterEntities().MemberItemTotalSales.FirstOrDefault(x => x.ID == MemberFinalSalesId);
                //MemberId = objTotalSale.memberId;
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
                var obj = lstSales;
                MemberItemSale temp = new MemberItemSale();
                if (obj == null)
                    obj = new List<MemberItemSale>();

                ItemId = Convert.ToInt64(drpItems.SelectedValue);
                //MemberId = Convert.ToInt64(drpMembers.SelectedValue);
                //To check whether same item is already sold to this customer
                if (lstSales != null && lstSales.Count > 0)
                {
                    if (lstSales.FirstOrDefault(x => x.isDeleted == false && x.itemId == ItemId) == null)
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
                        obj.Add(temp);
                        lstSales = obj;
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
                    obj.Add(temp);
                    lstSales = obj;
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
                lstSales = null;
                ClearMemberValues();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ShowTotal()
        {
            try
            {
                decimal total = 0;
                if (lstSales != null)
                {
                    foreach (var obj in lstSales)
                        total += (decimal)obj.totalAmount;
                }
                return total.ToString();
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
                decimal totalAmount = 0;
                long qty = 0, itemID = 0;
                totalAmount = Convert.ToDecimal(ShowTotal());
                MemberItemTotalSale objTotalSale = new MemberItemTotalSale();
                objTotalSale.totalAmount = totalAmount;
                objTotalSale.discount = Convert.ToDecimal(txtDis.Text);
                objTotalSale.finalAmount = Convert.ToDecimal(txtFinalAmt.Text);
                objTotalSale.memberId = MemberId;
                objTotalSale.isPaid = false;
                objTotalSale = new ProductSalesController().InsertTotalSales(objTotalSale);
                foreach (var obj in lstSales)
                {
                    MemberItemSale objsale = new MemberItemSale();
                    objsale.memberId = obj.memberId;
                    objsale.itemId = obj.itemId;
                    itemID = obj.itemId;
                    objsale.amount = obj.amount;
                    qty = obj.quantity;
                    objsale.quantity = obj.quantity;
                    objsale.totalAmount = obj.totalAmount;
                    objsale.memberFinalSaleID = objTotalSale.ID;
                    new ProductSalesController().InsertProductSale(objsale);
                }
                ItemMaster objItem = ItemController.GetItemsById(itemID);
                
                //var Inventory = new FitnessCenterEntities().ItemMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == itemID);
                objItem.Inventory = objItem.Inventory - qty;
                objItem = new ItemController().UpdateItems(objItem);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Success','Items Sold Successfully')", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            long ItemId = Convert.ToInt64(drpItems.SelectedValue);
            var Inventory = new FitnessCenterEntities().ItemMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == ItemId);
            if (Convert.ToInt64(txtQty.Text) > Inventory.Inventory)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','You Have Not Enough Stock For This Item ')", true);
                txtQty.Text = "";
            }

        }


    }
}