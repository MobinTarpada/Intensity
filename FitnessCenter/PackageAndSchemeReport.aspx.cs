using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using System.Net;
using System.Data;
using System.Drawing.Printing;


namespace FitnessCenter
{

    public partial class PackageAndSchemeReport : System.Web.UI.Page
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

        public decimal PackAmt
        {
            get
            {
                var obj = ViewState["PackAmt"];
                return obj == null ? 0 : (decimal)obj;

            }
            set
            {
                ViewState["PackAmt"] = value;
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

        public int TransMode
        {
            get
            {
                var obj = ViewState["TransMode"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                ViewState["TransMode"] = value;
            }
        }

        public string Message
        {
            get
            {
                var obj = ViewState["Message"];
                return obj == null ? "Message" : (string)obj;
            }
            set
            {
                ViewState["Message"] = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                var obj = ViewState["MobileNumber"];
                return obj == null ? "MobileNumber" : (string)obj;
            }
            set
            {
                ViewState["MobileNumber"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSrchPckg();
                BindSrchSchm(0);
                BindGrid();
            }
        }


        public void BindGrid()
        {
            try
            {
                grdPkgNScmReport.DataSource = ReportController.GetPkgnScmReport( LoginUser.ClubId,Convert.ToInt64(ddlSrchPkg.SelectedValue), Convert.ToInt64(ddlSrchScheme.SelectedValue),txtFromDate.Text,txtToDate.Text);
                grdPkgNScmReport.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BindSrchPckg()
        {
            try
            {
                ddlSrchPkg.DataSource = MembershipController.GetPackageTypes();
                ddlSrchPkg.DataTextField = "packageName";
                ddlSrchPkg.DataValueField = "ID";
                ddlSrchPkg.DataBind();
                ddlSrchPkg.Items.Insert(0, new ListItem("Select Package Type", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSrchSchm(long PackageId)
        {
            try
            {
                if (PackageId == 0)
                {
                    ddlSrchScheme.DataSource = MembershipController.GetSchemes();
                    ddlSrchScheme.DataTextField = "schemeName";
                    ddlSrchScheme.DataValueField = "ID";
                    ddlSrchScheme.DataBind();
                }
                else
                {
                    ddlSrchScheme.DataSource = MembershipController.GetSchemesByPackageId(PackageId);
                    ddlSrchScheme.DataTextField = "schemeName";
                    ddlSrchScheme.DataValueField = "ID";
                    ddlSrchScheme.DataBind();
                }
                ddlSrchScheme.Items.Insert(0, new ListItem("Select Scheme", "0"));
                ddlSrchScheme.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlSrchPkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSrchPkg.SelectedIndex == 0)
                {
                    BindSrchSchm(0);
                }
                else
                {
                    BindSrchSchm(Convert.ToInt64(ddlSrchPkg.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        
    }
}