using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using System.Data;

namespace FitnessCenter
{
    public partial class AttendanceHistory : System.Web.UI.Page
    {

        #region Properties

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindGrid()
        {
            try
            {
                if (ddlOptions.SelectedValue == "1")
                {
                    grdPresentMembers.DataSource = MembersAttendanceHistoryController.GetPresentMember(SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdPresentMembers.DataBind();
                }
                if (ddlOptions.SelectedValue == "2")
                {
                    grdAbsentMembers.DataSource = MembersAttendanceHistoryController.GetAbsentMember(SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdAbsentMembers.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFullSearch_Click(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Option First');", true);
            }
            else
            {
                if (ddlOptions.SelectedValue == "1")
                {
                    pnlPresent.Visible = true;
                    pnlAbsent.Visible = false;
                }
                else if (ddlOptions.SelectedValue == "2")
                {
                    pnlPresent.Visible = false;
                    pnlAbsent.Visible = true;
                }
                else
                {
                    pnlPresent.Visible = false;
                    pnlAbsent.Visible = false;
                }
                BindGrid();
            }
        }

        protected void grdAbsentMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAbsentMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPresentMembers_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdPresentMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}