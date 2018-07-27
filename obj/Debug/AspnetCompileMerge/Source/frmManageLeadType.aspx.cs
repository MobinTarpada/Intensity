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
    public partial class frmManageLeadType : System.Web.UI.Page
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
                    PanelVisibility(true, false);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
        #region Events

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddLeadType_Click(object sender, EventArgs e)
        {
            try
            {
                Mode = "Insert";
                ClearValues();
                PanelVisibility(false, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdLeadType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLeadType.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdLeadType_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void grdLeadType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditLeadType")
                {
                    LeadId = Convert.ToInt32(e.CommandArgument);
                    Mode = "Update";
                    BindLeadTypeValues();
                    PanelVisibility(false, true);
                }
                else if (e.CommandName == "DeleteLeadType")
                {
                    try
                    {
                        int leadTypeId = Convert.ToInt32(e.CommandArgument);
                        new LeadTypeController().DeleteLeadType(leadTypeId);
                        BindGrid();
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
                if (Mode == "Insert")
                {
                    if(!LeadTypeController.IsLeadType(txtLeadType.Text.Trim()))
                    {
                            InsertLeadType();
                            ClearValues();
                            PanelVisibility(true, false);
                            BindGrid();
                    }    
               
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), new Guid().ToString(), "MessageBox('Message','LeadType already exists..!');", true);
                }

                else
                {
                    UpdateLeadType();
                    ClearValues();
                    PanelVisibility(true, false);
                    BindGrid();
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
                PanelVisibility(true, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

       
        #region Methods
        private void BindGrid()
        {
            try
            {
                grdLeadType.DataSource = LeadTypeController.GetLeadTypes(txtSearchText.Text, SortField, SortDir);
                grdLeadType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void InsertLeadType()
        {
            try
            {
                LeadTypeMaster objLeadTypes = new LeadTypeMaster();
                objLeadTypes.leadType = txtLeadType.Text;
                objLeadTypes = new LeadTypeController().InsertLeadType(objLeadTypes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateLeadType()
        {
            try
            {
                LeadTypeMaster objLeadTypeMaster = LeadTypeController.GetLeadTypeByID(LeadId);
                objLeadTypeMaster.leadType = txtLeadType.Text;
                new LeadTypeController().UpdateLeadType(objLeadTypeMaster);
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValues()
        {
            txtLeadType.Text = string.Empty;
        }
        private void BindLeadTypeValues()
        {
            try
            {
                LeadTypeMaster objLeadTypeMaster = LeadTypeController.GetLeadTypeByID(LeadId);
                txtLeadType.Text = objLeadTypeMaster.leadType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}