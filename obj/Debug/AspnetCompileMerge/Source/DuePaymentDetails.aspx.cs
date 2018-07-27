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
    public partial class DuePaymentDetails : System.Web.UI.Page
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

        public String RFIDNO
        {
            get
            {
                var obj = ViewState["RFIDNO"];
                return obj == null ? null : (String)obj;
            }
            set
            {
                ViewState["RFIDNO"] = value;
            }
        }

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
            PannelVisibility(false, false, true, false);
        }

        #region Methods

        private void BindGrid()
        {
            try
            {
                grdDuePayment.DataSource = PaymentController.GetPaymentHistory(txtSearchText.Text, AgreementNumber, LoginUser.clubId);
                grdDuePayment.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindPartPaymentDetails()
        {
            try
            {
                grdMain.DataSource = PaymentController.GetPartPayment(txtSrchTxt.Text, LoginUser.clubId);
                grdMain.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindFullPaymentDetails()
        {
            try
            {
                grdFullPaidMember.DataSource = PaymentController.GetFullPayment(txtFullSearch.Text, LoginUser.clubId);
                grdFullPaidMember.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PannelVisibility(bool Detail, bool View, bool Option, bool FullPiad)
        {
            try
            {
                pnlDetails.Visible = Detail;
                pnlView.Visible = View;
                pnlOptions.Visible = Option;
                pnlFullPaid.Visible = FullPiad;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PannelVisibility(false, false, true, true);
                if (pnlFullPaid.Visible == true)
                {
                    BindFullPaymentDetails();
                }
                if (pnlDetails.Visible == true)
                {
                    BindPartPaymentDetails();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMain.PageIndex = e.NewPageIndex;
            PannelVisibility(true, false, true, false);
            BindPartPaymentDetails();
        }

        protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailPayment")
            {
                AgreementNumber = Convert.ToString(e.CommandArgument);
                //pnlDisclaimerDetails.Visible = true;
                PannelVisibility(true, true, true, false);
                BindGrid();

            }
        }

        protected void grdDuePayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDuePayment.PageIndex = e.NewPageIndex;
            PannelVisibility(true, true, true, false);
            BindGrid();
        }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            try
            {
                BindPartPaymentDetails();
                PannelVisibility(true, false, true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedValue == "1")
            {
                BindFullPaymentDetails();
                PannelVisibility(false, false, true, true);
            }
            if (ddlOptions.SelectedValue == "2")
            {
                BindPartPaymentDetails();
                PannelVisibility(true, false, true, false);
            }

        }

        protected void btnFullSearch_Click(object sender, EventArgs e)
        {
            PannelVisibility(false, false, true, true);
            BindFullPaymentDetails();
        }

        protected void grdFullPaidMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFullPaidMember.PageIndex = e.NewPageIndex;
            BindFullPaymentDetails();
            PannelVisibility(false, false, true, true);
        }

        protected void grdFullPaidMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailPayment")
            {
                AgreementNumber = Convert.ToString(e.CommandArgument);
                //pnlDisclaimerDetails.Visible = true;
                PannelVisibility(false, true, true, true);
                BindGrid();

            }
        }





    }
}