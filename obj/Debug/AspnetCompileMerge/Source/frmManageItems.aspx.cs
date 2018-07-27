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
    public partial class frmManageGroups : System.Web.UI.Page
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
                PanelVisibility(true, false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                PanelVisibility(false, true);
                BindGroups();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string jScript = "";
                jScript = "$('#MsgBoxModal1').removeClass('hide');";
                jScript += "$('#masteroverlay1').removeClass('hide');";
                jScript += "$('#MsgBoxModal1').fadeIn(300);";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "add_grp", jScript, true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "test1", "console.log('Class Removed');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAddJuiceItems_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "InsertJuice";
                PanelVisibility(false, true);
                BindGroups();
                drpGroups.Visible = btnAddGroup.Visible = grp.Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnInsertGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGrpCode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Insert Group Code');", true);
                    btnAddGroup_Click(sender, e);
                }
                else if (txtGrpName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Insert Group Name');", true);
                    btnAddGroup_Click(sender, e);
                }
                else if (GroupController.IsNameExists(txtGrpName.Text, LoginUser.clubId))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Group Name Already Exists');", true);
                    btnAddGroup_Click(sender, e);
                }
                else if (GroupController.IsCodeExists(txtGrpCode.Text, LoginUser.clubId))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Group Code Already Exists');", true);
                    btnAddGroup_Click(sender, e);
                }
                else
                    InsertGroup();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void grdItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdItems.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditItem")
                {
                    ItemId = Convert.ToInt64(e.CommandArgument);
                    Mode = "Update";
                    BindValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteItem")
                {
                    ItemId = Convert.ToInt64(e.CommandArgument);
                    new ItemController().DeleteItems(ItemId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Item Deleted Successfully');", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void grdItems_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (drpGroups.SelectedIndex == 0 && (Mode == "Insert" || Mode == "Update"))
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Group');", true);
            else
            {
                if (Mode == "Insert" || Mode == "InsertJuice")
                {
                    long GroupId = Convert.ToInt64(drpGroups.SelectedValue);
                    if (ItemController.IsCodeExists(txtCode.Text, GroupId, LoginUser.clubId))
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Item Code Already Exists');", true);
                    else if (ItemController.IsNameExists(txtName.Text, LoginUser.clubId))
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Item Name Already Exists');", true);
                    else
                        InsertItem();
                }
                else
                    UpdateItem();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGroupValues();
                ClearValues();
                PanelVisibility(true, false);
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
                grdItems.DataSource = ItemController.GetItems(txtSearchName.Text, txtSearchCode.Text, SortDir, SortField, LoginUser.clubId);
                grdItems.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PanelVisibility(bool View, bool Edit)
        {
            pnlEdit.Visible = Edit;
            pnlView.Visible = View;
        }

        public void BindGroups()
        {
            try
            {
                drpGroups.Visible = btnAddGroup.Visible = grp.Visible = true;
                drpGroups.DataSource = ItemController.GetGroups(LoginUser.clubId);
                drpGroups.DataTextField = "name";
                drpGroups.DataValueField = "ID";
                drpGroups.DataBind();
                drpGroups.Items.Insert(0, new ListItem("Select Group", "0"));
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
                ItemMaster objItem = ItemController.GetItemsById(ItemId);
                BindGroups();
                if (objItem.GroupMaster.code == "000")
                {
                    Mode = "UpdateJuice";
                    drpGroups.Visible = btnAddGroup.Visible = grp.Visible = false;
                }
                txtCode.Text = objItem.code;
                txtName.Text = objItem.name;
                txtMrp.Text = Convert.ToString(objItem.mrp);
                if (Mode != "UpdateJuice")
                    drpGroups.SelectedValue = Convert.ToString(objItem.groupId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertItem()
        {
            try
            {
                ItemMaster objItem = new ItemMaster();
                objItem.name = txtName.Text;
                objItem.code = txtCode.Text;
                objItem.mrp = Convert.ToDecimal(txtMrp.Text);
                if (Mode == "InsertJuice")
                    objItem.groupId = 1;
                else
                    objItem.groupId = Convert.ToInt64(drpGroups.SelectedValue);
                objItem = new ItemController().InsertItems(objItem);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Item Inserted Successfully');", true);
                ClearValues();
                ClearGroupValues();
                PanelVisibility(true, false);
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateItem()
        {
            try
            {
                ItemMaster objItem = ItemController.GetItemsById(ItemId);

                objItem.name = txtName.Text;
                objItem.code = txtCode.Text;
                objItem.mrp = Convert.ToDecimal(txtMrp.Text);
                if (Mode == "UpdateJuice")
                    objItem.groupId = 1;
                else
                    objItem.groupId = Convert.ToInt64(drpGroups.SelectedValue);
                objItem = new ItemController().UpdateItems(objItem);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Item Updated Successfully');", true);
                ClearValues();
                PanelVisibility(true, false);
                BindGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertGroup()
        {
            try
            {
                GroupMaster objGroup = new GroupMaster();
                objGroup.name = txtGrpName.Text;
                objGroup.code = txtGrpCode.Text;
                objGroup.clubId = LoginUser.clubId;
                objGroup = new GroupController().InsertGroups(objGroup);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Group Added Successfully');", true);
                BindGroups();
                ClearGroupValues();
                if (Mode == "Update")
                    BindValues();
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

        public void ClearGroupValues()
        {
            foreach (Control ctrl in pnlGroup.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
            }
        }
        #endregion
    }
}