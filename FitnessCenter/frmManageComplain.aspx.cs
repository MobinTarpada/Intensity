using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.DAL;
using FitnessCenter.BAL;
using FitnessCenter.BO;

namespace FitnessCenter
{
    public partial class frmManageComplain : System.Web.UI.Page
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

        public long Id
        {
            get
            {
                var obj = ViewState["Id"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        public long CLUBID
        {
            get
            {
                var obj = ViewState["CLUBID"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["CLUBID"] = value;
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
        public string ComplainCode
        {
            get
            {
                var obj = ViewState["ComplainCode"];
                return obj == null ? "ComplainCode" : (string)obj;
            }
            set
            {
                ViewState["ComplainCode"] = value;
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
            if (!IsPostBack)
            {
                BindGrid();
                PannelVisible(false, true);
            }
        }

        public void BindGrid()
        {
            try
            {
                grdComplain.DataSource = ComplainController.GetComplains(txtSearchText.Text, SortField, SortDir, LoginUser.ClubId, LoginUser.UserTypeId);
                grdComplain.DataBind();
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
                if (Mode == "Insert")
                {
                    InsertComplain();
                    BindGrid();
                    PannelVisible(false, true);
                }
                else
                {
                    UpdateComplain();
                    BindGrid();
                    PannelVisible(false, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PannelVisible(bool edit, bool view)
        {
            pnlEdit.Visible = edit;
            pnlView.Visible = view;
        }

        private void InsertComplain()
        {
            try
            {
                ComplainManagement objComplain = new ComplainManagement();
                objComplain.clubId = LoginUser.ClubId;
                objComplain.userId = LoginUser.ID;
                objComplain.ComplainCode = txtComplainCode.Text;
                objComplain.ComplainMessage = txtComplainMsg.Text;
                objComplain.Status = "Pending";
                objComplain.updateBy = LoginUser.FirstName + ' ' + LoginUser.LastName;


                objComplain = new ComplainController().InsertComplain(objComplain);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Your Complain Saved Successfully');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateComplain()
        {
            try
            {
                ComplainManagement objComplain = new ComplainManagement();
                objComplain.clubId = LoginUser.ClubId;
                objComplain.userId = LoginUser.ID;
                objComplain.ComplainCode = txtComplainCode.Text;
                objComplain.ComplainMessage = txtComplainMsg.Text;
                objComplain.Status = "Pending";
                objComplain.updateBy = LoginUser.FirstName + ' ' + LoginUser.LastName;


                objComplain = new ComplainController().UpdateComplain(objComplain);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Your Complain Updated Successfully');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PannelVisible(false, true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddComplain_Click(object sender, EventArgs e)
        {
            PannelVisible(true, false);
            long a = 0;
            using (var context = new FitnessCenterEntities())
            {
                var L2EQuery = from st in context.ComplainManagements

                               select st;

                a = context.ComplainManagements.Count();
            }
            DateTime day = DateTime.Now;
            ComplainCode = day.ToString("ddMMyyyy") + (a + 1);
            txtComplainCode.Text = ComplainCode;

        }

        protected void grdComplain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditComplain")
            {
                Id = Convert.ToInt64(e.CommandArgument);
                PannelVisible(true, false);
                BindComplainValues();
            }
            if (e.CommandName == "Feedback")
            {
                Id = Convert.ToInt64(e.CommandArgument);
                string jScript = "";
                jScript = "$('#MsgBoxModal1').removeClass('hide');";
                jScript += "$('#masteroverlay1').removeClass('hide');";
                jScript += "$('#MsgBoxModal1').fadeIn(300);";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "feedback", jScript, true);
                
            }
        }
        public void BindComplainValues()
        {
            ComplainManagement objComplain = ComplainController.GetComplainById(Id);
            txtComplainCode.Text = objComplain.ComplainCode;
            txtComplainMsg.Text = objComplain.ComplainMessage;
            objComplain = new ComplainController().UpdateComplain(objComplain);

        }
        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                ComplainManagement objComplain = ComplainController.GetComplainById(Id);

                objComplain.Feedback = txtFeedback.Text;
                objComplain.Status = ddlStatus.SelectedItem.Text;
                objComplain = new ComplainController().UpdateComplain(objComplain);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Your Feedback Saved Successfully');", true);
                BindGrid();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtRfidCard_TextChanged(object sender, EventArgs e)
        {
            if (txtRfidCard.Text != "")
                pnlMsg.Visible = true;
        }
    }
}