using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BO;
using FitnessCenter.BAL;
using FitnessCenter.DAL;
using System.Net;
using System.Data;
namespace FitnessCenter
{
    public partial class FindReferralsMember : System.Web.UI.Page
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

        public string MembershipID
        {
            get
            {
                var obj = ViewState["MembershipID"];
                return obj == null ? "MembershipID" : (string)obj;
            }
            set
            {
                ViewState["MembershipID"] = value;
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
                BindSrchMember();
                BindGrid();
            }
        }

        public void BindGrid()
        {
            try
            {

                grdFindReferrals.DataSource = ReportController.GetRefrrelsmember(MembershipID);
                grdFindReferrals.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void BindSrchMember()
        {
            try
            {
                var db = new FitnessCenterEntities();
                var query = (from a in db.Memberships
                             join b in db.Leads on a.LeadId equals b.ID
                             where a.MembershipNo != ""
                             orderby b.firstName + " " + b.lastName ascending
                             select new { a.MembershipNo, MemberName = b.firstName + " " + b.lastName }).ToList();

                //foreach (var item in query)
                // {
                ddlSrchMember.DataSource = query;
                ddlSrchMember.DataTextField = "MemberName";
                ddlSrchMember.DataValueField = "membershipUniqueId";
                ddlSrchMember.DataBind();
                ddlSrchMember.Items.Insert(0, new ListItem("Select Member", "0"));
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlSrchMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            MembershipID = ddlSrchMember.SelectedValue;
            BindGrid();
        }
    }
}