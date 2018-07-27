using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using System.Text;

namespace FitnessCenter
{
    public partial class frmManageTarget : System.Web.UI.Page
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

        public long UserId
        {
            get
            {
                var obj = ViewState["UserId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["UserId"] = value;
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
            try
            {
                if (!IsPostBack)
                {
                    BindDRP();
                    BindLeadType();
                    BindTargetHeader();
                    MainPanelVisibility(true, false);
                    PanelVisibility(false, false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Events

        protected void grdTargetHeaders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTarget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnFldLeadTypeId = (HiddenField)e.Row.FindControl("hdnFldLeadTypeId");
                    Label lblAchievedTarget = (Label)e.Row.FindControl("lblAchievedTarget");

                    string obj = UsersController.GetAchievedTargetByUserAndLeadtype_Result(Convert.ToInt32(UserId), Convert.ToInt32(hdnFldLeadTypeId.Value)).ToList()[0].ACHIVEDTARGET.ToString();
                    lblAchievedTarget.Text = obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTargetHeaders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditTargetHeader")
                {
                    MainPanelVisibility(false, true);
                    PanelVisibility(true, false);
                    UserId = Convert.ToInt64(e.CommandArgument);
                    ddlUser.SelectedValue = UserId.ToString();
                    BindGrid(UserId);
                }
                else if (e.CommandName == "DeleteTargetHeder")
                {
                    long UserId = Convert.ToInt64(e.CommandArgument);
                    new UsersController().DeleteAllTargetByUser(UserId);
                    BindTargetHeader();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddTarget_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUser.SelectedValue == "0")
                {
                    lblMsg.Text = "Please SelectUser First";
                }
                else
                {
                    lblMsg.Text = "";
                    Mode = "Insert";

                    PanelVisibility(false, true);
                    BindLeadType();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTarget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTarget.PageIndex = e.NewPageIndex;
                BindGrid(Convert.ToInt64(ddlUser.SelectedValue));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTarget_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortField = e.SortExpression;
                if (SortDir == "ASC")
                    SortDir = "DESC";
                else
                    SortDir = "ASC";
                BindGrid(Convert.ToInt64(ddlUser.SelectedValue));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTarget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditTarget")
                {
                    UserId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindUserTargetValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteTarget")
                {
                    try
                    {
                        int ID = Convert.ToInt32(e.CommandArgument);
                        new UsersController().DeleteLeadTypeByLeadTypeId(ID);
                        BindGrid(Convert.ToInt64(ddlUser.SelectedValue));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
                if (ddlLead.SelectedValue == "0")
                {
                    lblErrorMsg.Text = "PLease Select Any LeadType";
                }
                else
                {
                    lblErrorMsg.Text = "";
                    if (Mode == "Insert")
                    {
                        var lst = UsersController.GetUserTargetByDateAndLeadType(Convert.ToInt64(ddlUser.SelectedValue), Convert.ToInt64(ddlLead.SelectedValue),UtillController.ConvertDateTime(txtFromDate.Text).ToString("MM/dd/yyyy"),UtillController.ConvertDateTime(txtToDate.Text).ToString("MM/dd/yyyy"));
                        if (lst.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBoxForAnotherPopup('Message','You have already given target for the same date and same leadtype.','" + btnContinue.ClientID + "');", true);
                        }
                        else
                        {
                            InsertUserTarget();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','Target Save Successfully.');", true);
                            txtTarget.Text = "";
                            ddlLead.SelectedIndex = 0;
                        }

                    }
                    else
                    {
                        UpdateUserTarget();
                        //ClearValues();
                        //PanelVisibility(true, false);
                        //BindGrid(Convert.ToInt64(ddlUser.SelectedValue));
                        txtTarget.Text = "";
                        ddlLead.SelectedIndex = 0;
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
                lblMsg.Text = "";
                lblErrorMsg.Text = "";
                ClearValues();
                PanelVisibility(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddNewTarget_Click(object sender, EventArgs e)
        {
            try
            {
                MainPanelVisibility(false, true);
                PanelVisibility(true, false);
                ClearValues();
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
                lblMsg.Text = "";
                lblErrorMsg.Text = "";
                ClearValues();
                MainPanelVisibility(true, false);
                BindTargetHeader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                var lst = UsersController.GetUserTargetByDateAndLeadType(Convert.ToInt64(ddlUser.SelectedValue), Convert.ToInt64(ddlLead.SelectedValue),UtillController.ConvertDateTime(txtFromDate.Text).ToString("MM/dd/yyyy"),UtillController.ConvertDateTime(txtToDate.Text).ToString("MM/dd/yyyy"));
                UserTarget objUserTarget = lst[0];

                objUserTarget.fromDate =UtillController.ConvertDateTime(txtFromDate.Text);
                objUserTarget.toDate =UtillController.ConvertDateTime(txtToDate.Text);
                objUserTarget.leadTypeId = Convert.ToInt64(ddlLead.SelectedValue);
                objUserTarget.target = Convert.ToInt32(txtTarget.Text);
                new UsersController().UpdateUserTarget(objUserTarget);
                ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','Target Save Successfully.'", true);
                txtTarget.Text = "";
                ddlLead.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Methods

        //private bool IsControlsValid()
        //{
        //    bool isValid = true;
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<ul>");

        //    if (ddlLead.SelectedValue == "0")
        //    {
        //        isValid = false;
        //        ddlLead.CssClass = "error";
        //        sb.Append(String.Format("<li>{0}</li>", "Please select DropDowlist item"));
        //    }
        //    else
        //    {
        //        ddlLead.CssClass = "";
        //    }
        //    sb.Append("</ul>");
        //    lblErrorMsg.Text = sb.ToString();
        //    return isValid;

        //}
        private int GetUserTargetByDate(long UserId, long LeadTypeId, DateTime FromDate, DateTime ToDate)
        {
            int a = 0;
            try
            {
                a = UsersController.GetUserTargetByDate(UserId, LeadTypeId, FromDate, ToDate).Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return a;

        }
        private void BindTargetHeader()
        {
            try
            {
                grdTargetHeaders.DataSource = UsersController.GetLeadTargetHeaders_Result(LoginUser.clubId, LoginUser.userTypeId);
                grdTargetHeaders.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindGrid(long UserId)
        {
            try
            {
                grdTarget.DataSource = UsersController.GetUserTargetsByUserId_Result(UserId);
                grdTarget.DataBind();
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
                ddlLead.DataSource = UsersController.GetLeadType();
                ddlLead.DataTextField = "leadType";
                ddlLead.DataValueField = "ID";
                ddlLead.DataBind();
                ddlLead.Items.Insert(0, new ListItem("Select Lead", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MainPanelVisibility(bool TargetHeader, bool TargetBody)
        {
            pnlTargetHeader.Visible = TargetHeader;
            pnlTargetBody.Visible = TargetBody;
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

        public void BindDRP()
        {
            try
            {
                ddlUser.DataSource = UsersController.GetClubEmployees(LoginUser.clubId, LoginUser.userTypeId);
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
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedIndex == 0)
            {
                PanelVisibility(false, false);

            }
            else
            {
                lblMsg.Text = "";
                UserId = Convert.ToInt64(ddlUser.SelectedValue);
                PanelVisibility(true, false);
                BindGrid(Convert.ToInt64(ddlUser.SelectedValue));
            }

        }

        private void InsertUserTarget()
        {
            try
            {
                UserTarget objUserTarget = new UserTarget();
                objUserTarget.clubId = LoginUser.clubId;
                objUserTarget.userId = Convert.ToInt64(ddlUser.SelectedValue);
                objUserTarget.fromDate =UtillController.ConvertDateTime(txtFromDate.Text);
                objUserTarget.toDate =UtillController.ConvertDateTime(txtToDate.Text);
                objUserTarget.leadTypeId = Convert.ToInt64(ddlLead.SelectedValue);
                objUserTarget.target = Convert.ToInt32(txtTarget.Text);
                objUserTarget = new UsersController().InsertUserTarget(objUserTarget);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateUserTarget()
        {
            try
            {
                UserTarget objUserTarget = UsersController.GetUserTargetById(UserId);
                objUserTarget.fromDate =UtillController.ConvertDateTime(txtFromDate.Text);
                objUserTarget.toDate =UtillController.ConvertDateTime(txtToDate.Text);
                objUserTarget.leadTypeId = Convert.ToInt64(ddlLead.SelectedValue);
                objUserTarget.target = Convert.ToInt32(txtTarget.Text);
                new UsersController().UpdateUserTarget(objUserTarget);
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
                txtFromDate.Text = txtToDate.Text = txtTarget.Text = string.Empty;
                ddlUser.SelectedValue = ddlLead.SelectedValue = "0";
                grdTarget.DataSource = null;
                grdTarget.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindUserTargetValues()
        {
            try
            {
                UserTarget objUserTarget = UsersController.GetUserTargetById(UserId);
                txtFromDate.Text = Convert.ToString(objUserTarget.fromDate);
                txtToDate.Text = Convert.ToString(objUserTarget.toDate);
                ddlLead.SelectedValue = objUserTarget.leadTypeId.ToString();
                txtTarget.Text = Convert.ToString(objUserTarget.target);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter FromDate First..');", true);
                txtToDate.Text = "";
            }
            else
            {
                DateTime frmdate, todate;
                frmdate =UtillController.ConvertDateTime(txtFromDate.Text);
                todate =UtillController.ConvertDateTime(txtToDate.Text);
                int cmp = DateTime.Compare(frmdate, todate);
                if (cmp == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Enter ToDate Greater Than FromDate');", true);
                    txtToDate.Text = "";
                    //todate = frmdate.AddDays(30);
                    //txtToDate.Text = todate.ToString("dd/MM/yyyy");
                }
            }
        }






    }
}