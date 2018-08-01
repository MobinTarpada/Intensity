using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ConnectionDb;
using System.Drawing;
using System.IO;


namespace AttendenceSystem
{
    public partial class AttendenceManagement : System.Web.UI.Page
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

        public long RFIDNumber
        {
            get
            {
                var obj = ViewState["RFIDNumber"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["RFIDNumber"] = value;
            }
        }

        public string RFIDCardNumber
        {
            get
            {
                var obj = ViewState["RFIDCardNumber"];
                return obj == null ? "RFIDCardNumber" : (string)obj;
            }
            set
            {
                ViewState["RFIDCardNumber"] = value;
            }
        }

        public string AgreementNumber
        {
            get
            {
                var obj = ViewState["AgreementNumber"];
                return obj == null ? "AgreementNumber" : (string)obj;
            }
            set
            {
                ViewState["AgreementNumber"] = value;
            }
        }

        public string MemberNumber
        {
            get
            {
                var obj = ViewState["MemberNumber"];
                return obj == null ? "MemberNumber" : (string)obj;
            }
            set
            {
                ViewState["MemberNumber"] = value;
            }
        }
        #endregion

        Database db = new Database();
        string LeadId = "", MembersId = "", PackageId = "", SchemeId = "", strLead = "", strMember = "", strCount = "", strDue = "", str = "", str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "", AgrNo = "", MobileNo = "", FirstName = "", LastName = "", RFID = "";
        DataTable dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dtLead, dtMember;
        DateTime ExpiryDate, EntryDate, LastEntryDate, LastCheckinDate, Today;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtStatus.Text == "")
            {
                txtStatus.BackColor = Color.Empty;
            }
            btnOK.Enabled = true;
            txtSearch.Focus();
        }
        public void BindMembersValues()
        {

            str += "select AM.ID,M.membershipUniqueId,M.RFIDCardNumber,M.agreementNumber,L.mobileNumber,U.SchemeName,L.firstName + ' ' +L.lastName as MemberName,M.branchName,U.startTime + ' ' + 'TO' + ' ' + U.endTime as AccessType,AM.Message ,AM.Status,AM.profilePicture,AM.lastCheckInTime,AM.lastCheckInDate,AM.lastCheckInDays,AM.insertDate,M.expiryDate from AccessManagement as AM inner join Memberships As M on M.ID = AM.memberId inner join Leads AS L on L.ID = M.leadId inner join PackageMaster as P on P.ID = M.packageTypeId inner join UserSchemeMaster as U on U.ID = M.schemeID where (M.isPaid = 'True' AND M.isActive = 'True' AND M.isDeleted = 'False') AND (M.RFIDCardNumber =  '" + txtSearch.Text + "' " + " OR M.agreementNumber = '" + txtSearch.Text + "' " + " OR L.mobileNumber = '" + txtSearch.Text + "' " + ") ";
            str += " ORDER BY AM.ID DESC ";
            dt = db.bound_control(str);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtMemberId.Text = dt.Rows[0][1].ToString();
                    RFID = dt.Rows[0][2].ToString();
                    txtBranchName.Text = dt.Rows[0][7].ToString();
                    lblMemberName.Text = dt.Rows[0][6].ToString();
                    lblPackageName.Text = dt.Rows[0][5].ToString();
                    txtAccessType.Text = dt.Rows[0][8].ToString();
                    txtMsg.Text = dt.Rows[0][9].ToString();
                    if (dt.Rows[0][11].ToString() == "")
                        imgProfileImage.ImageUrl = "~/MemberProfilePicture/ProfileImage.png";
                    else
                        imgProfileImage.ImageUrl = dt.Rows[0][11].ToString();
                    ExpiryDate = Convert.ToDateTime(dt.Rows[0][16].ToString().Trim()).Date;
                    if (ExpiryDate.Date < DateTime.Now.Date)
                    {
                        txtStatus.Text = "InActive";
                        txtStatus.BackColor = Color.Red;
                        btnOK.Enabled = false;
                    }
                    else
                    {
                        txtStatus.Text = "Active";
                        txtStatus.BackColor = Color.Lime;
                    }
                    EntryDate = Convert.ToDateTime(dt.Rows[0][15].ToString());
                    EntryDate.ToString("dd/MM/yyyy").Substring(0, 10);
                    lblCheckInTime.Text = dt.Rows[0][12].ToString();
                    LastCheckinDate = Convert.ToDateTime(dt.Rows[0][13].ToString());
                    lblCheckInDate.Text = LastCheckinDate.ToString().Substring(0, 10);
                    lblDays.Text = dt.Rows[0][14].ToString();

                    str1 = "with data as(	select AM.lastCheckInTime,AM.insertDate,AM.lastCheckInDate,AM.lastCheckInDays,	ROW_NUMBER() over (order by lastCheckInTime desc) as RowNum	from AccessManagement as AM inner join Memberships as M on M.ID = AM.memberId where  M.RFIDCardNumber = '" + RFID + "' )select * from data where RowNum >= 2 AND RowNum < 3";
                    dt1 = db.bound_control(str1);
                    if (dt1.Rows.Count > 0)
                    {
                        LastEntryDate = Convert.ToDateTime(dt1.Rows[0][1].ToString());
                        LastEntryDate.ToString("dd/MM/yyyy").Substring(0, 10);
                        lblDays.Text = (EntryDate.Date - DateTime.Now.Date).ToString("dd") + " days ago";
                    }
                }
            }
            else
            {

                str2 = "select M.membershipUniqueId,M.RFIDCardNumber,M.branchName,U.startTime + ' ' + 'TO' + ' ' + U.endTime, U.SchemeName , P.durationInMonths, L.firstName + ' ' + L.lastName  as MemberName,M.isActive,M.expiryDate ,M.isPaid FROM Memberships AS M inner join Leads as L ON L.ID = M.leadId  inner join PackageMaster as P on P.ID = M.packageTypeId  inner join UserSchemeMaster as U on U.ID = M.schemeID where (M.isPaid = 1 AND M.isDeleted = 0 AND M.isActive = 1 AND U.isDeleted = 0 AND L.isDeleted = 0 AND P.isDeleted = 0) AND (M.RFIDCardNumber =  '" + txtSearch.Text + "' " + "  OR M.agreementNumber = '" + txtSearch.Text + "' " + "  OR L.mobileNumber = '" + txtSearch.Text + "' " + ")";
                dt2 = db.bound_control(str2);
                if (dt2.Rows.Count > 0)
                {


                    txtMemberId.Text = dt2.Rows[0][0].ToString();
                    txtBranchName.Text = dt2.Rows[0][2].ToString();
                    String AccessType = dt2.Rows[0][3].ToString();
                    if (AccessType == "Full Access TO Full Access")
                    {
                        AccessType = "Full Access";
                    }
                    lblPackageName.Text = dt2.Rows[0][4].ToString() + "\n" + dt2.Rows[0][5].ToString() + " MONTHS";
                    lblMemberName.Text = dt2.Rows[0][6].ToString();
                    ExpiryDate = Convert.ToDateTime(dt2.Rows[0][8].ToString().Trim()).Date;
                    txtAccessType.Text = AccessType;
                    lblCheckInTime.Text = DateTime.Now.ToString("hh:mm:ss");
                    lblCheckInDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblDays.Text = "";
                    imgProfileImage.ImageUrl = "~/MemberProfilePicture/ProfileImage.png";
                    if (ExpiryDate.Date < DateTime.Now.Date)
                    {
                        txtStatus.Text = "InActive";
                        txtStatus.BackColor = Color.Red;
                        btnOK.Enabled = false;
                    }
                    else
                    {
                        txtStatus.Text = "Active";
                        txtStatus.BackColor = Color.Lime;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'No Member Found....' );", true);
                    txtSearch.Text = "";
                    ClearValues();
                    txtSearch.Focus();
                }
            }

        }

        public void AlertDueDate()
        {
            try
            {
                String Currentdate = Convert.ToString(DateTime.Now);

                strDue = " select P.agreementNumber,P.RFIDCardNumber,P.DueAmountDate,P.remainingAmount,P.isFullPaid,L.mobileNumber from Payment AS P inner join Leads AS L ON L.ID = P.leadId   ";
                strDue += "where  (isFullPaid = 0 AND CONVERT(date,P.DueAmountDate,103) < CONVERT(date,'" + Currentdate + "',103))";
                strDue += " and (P.RFIDCardNumber =  '" + txtSearch.Text + "'  OR P.agreementNumber = '" + txtSearch.Text + "' OR L.mobileNumber = '" + txtSearch.Text + "') ";

                dt3 = db.bound_control(strDue);
                if (dt3.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'Access Denied - Balance Ovredue' );", true);

                    BindMembersValues();
                    btnOK.Enabled = false;
                    txtSearch.Text = "";
                }
                else
                {
                    BindMembersValues();
                    Page.SetFocus(this.btnOK);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'Please Enter Valid RFID Number or MembershipNumber' );", true);
                ClearValues();
                txtSearch.Focus();
            }
            else
            {
                RFIDCardNumber = txtSearch.Text;
                str3 = "select M.agreementNumber,M.RFIDCardNumber,L.firstName,L.lastName,L.mobileNumber from Memberships AS M inner join Leads AS L on L.ID = M.leadId where M.isActive = 1 and L.isActive = 1 and M.isDeleted = 0 and L.isDeleted = 0 ";
                dt4 = db.bound_control(str3);
                if (dt4.Rows.Count > 0)
                {
                    AgrNo = dt4.Rows[0][0].ToString();
                    RFID = dt4.Rows[0][1].ToString();
                    MobileNo = dt4.Rows[0][4].ToString();
                    FirstName = dt4.Rows[0][2].ToString();
                    LastName = dt4.Rows[0][3].ToString();
                }
                AlertDueDate();
                CountEntry();
                ExpiryAlert();
                Page.SetFocus(this.btnOK);
            }
        }

        public void ClearValues()
        {
            try
            {
                lblMemberName.Text = lblPackageName.Text = txtStatus.Text = txtMemberId.Text = txtBranchName.Text = txtAccessType.Text = txtMsg.Text = string.Empty;
                imgProfileImage.ImageUrl = "~/MemberProfilePicture/ProfileImage.png";
                lblCheckInDate.Text = lblCheckInTime.Text = lblDays.Text = string.Empty;
                txtStatus.BackColor = Color.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void UpdateUser()
        {
            try
            {
                if (txtAccessType.Text == "" || txtBranchName.Text == "" || txtMemberId.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'All Fields are mendatory please fill all fields.. ' );", true);
                }
                else
                {
                    String profilePicture = "";
                    String lastCheckInTime = Convert.ToString(DateTime.Now.ToString("hh:mm:ss tt"));
                    String lastCheckInDate = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                    String CurrentDate = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));

                    str4 = "select M.RFIDCardNumber,M.expiryDate from AccessManagement AS AM inner join Memberships as M on M.ID = AM.memberId inner join Leads AS L on L.ID = M.leadId where M.RFIDCardNumber =  '" + txtSearch.Text + "' " + " OR M.agreementNumber = '" + txtSearch.Text + "' " + " OR L.mobileNumber = '" + txtSearch.Text + "' ";
                    str4 += " ORDER BY AM.ID DESC ";
                    dt5 = db.bound_control(str4);
                    if (dt5.Rows.Count > 0)
                    {
                        RFID = dt5.Rows[0][0].ToString();
                    }

                    str5 = "select M.agreementNumber,M.RFIDCardNumber,M.membershipUniqueId,L.firstName,L.lastName,L.mobileNumber from Memberships AS M inner join Leads AS L  On L.ID = M.leadId  where M.isActive = 'true' and M.isDeleted = 'false' and membershipUniqueId =  '" + txtMemberId.Text + "' ";
                    dt6 = db.bound_control(str5);
                    if (dt6.Rows.Count > 0)
                    {
                        AgrNo = dt6.Rows[0][0].ToString();
                        RFID = dt6.Rows[0][1].ToString();
                        MobileNo = dt6.Rows[0][5].ToString();
                        FirstName = dt6.Rows[0][3].ToString();
                        LastName = dt6.Rows[0][4].ToString();
                    }
                    else
                    {
                        AgrNo = "";
                        MobileNo = "";
                        FirstName = "";
                        LastName = "";
                    }
                    if (FileUploadControl.HasFile)
                        profilePicture = "~/MemberProfilePicture/" + Path.GetFileName(FileUploadControl.FileName);
                    else
                    {

                        //str6 = "select * from AttendenceManagement where RFIDNumber =  '" + txtSearch.Text + "' " + " OR AgreementNumber = '" + txtSearch.Text + "' " + " OR MobileNumber = '" + txtSearch.Text + "' " + "  order by ID DESC";
                        str6 = "select M.RFIDCardNumber,M.agreementNumber,L.mobileNumber,AM.profilePicture from AccessManagement as AM inner join Memberships as M on M.ID = AM.memberId  inner join Leads as L on L.ID = M.leadId where M.RFIDCardNumber =  '" + txtSearch.Text + "' " + " OR M.agreementNumber = '" + txtSearch.Text + "' " + " OR L.mobileNumber = '" + txtSearch.Text + "' " + "  order by AM.ID DESC";
                        dt7 = db.bound_control(str6);
                        if (dt7.Rows.Count > 0)
                        {
                            profilePicture = imgProfileImage.ImageUrl = dt7.Rows[0][3].ToString();
                        }
                    }
                    strLead = "select L.ID from Leads as L where L.mobileNumber = '" + RFIDCardNumber + "' AND L.isActive = 1 AND L.isDeleted = 0 ";
                    dtLead = db.bound_control(strLead);
                    if (dtLead != null && dtLead.Rows.Count > 0)
                    {
                        LeadId = dtLead.Rows[0][0].ToString();
                    }
                    strMember = "select M.leadId,M.ID,M.packageTypeId,M.schemeID from Memberships as M where (M.isActive = 1 AND M.isDeleted = 0) AND M.RFIDCardNumber = '" + RFIDCardNumber + "' OR agreementNumber = '" + RFIDCardNumber + "' OR M.leadId = '" + LeadId + "'";
                    dtMember = db.bound_control(strMember);
                    //dt = db.bound_control(str7);
                    if (dtMember != null && dtMember.Rows.Count > 0)
                    {
                        LeadId = dtMember.Rows[0][0].ToString();
                        MembersId = dtMember.Rows[0][1].ToString();
                        PackageId = dtMember.Rows[0][2].ToString();
                        SchemeId = dtMember.Rows[0][3].ToString();
                    }
                    str7 = "insert into AccessManagement(memberId,leadId,Message,Status,profilePicture,lastCheckInTime,lastCheckInDate,lastCheckInDays,insertDate)";
                    //str7 = "insert into AttendenceManagement(membershipNumber,RFIDNumber,AgreementNumber,MobileNumber,packageName,memberName,branchName,accessType,Message,Status,profilePicture,lastCheckInTime,lastCheckInDate,lastCheckInDays,insertDate)";
                    str7 += "values('" + MembersId + "','" + LeadId + "','" + txtMsg.Text + "','" + txtStatus.Text + "','" + profilePicture + "','" + lastCheckInTime + "','" + lastCheckInDate + "','" + lblDays.Text + "','" + CurrentDate + "')";
                    dt8 = db.bound_control(str7);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                if (FileUploadControl.HasFile)
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        filename = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("~/MemberProfilePicture/" + filename));
                        imgProfileImage.ImageUrl = "~/" + Server.MapPath("~/MemberProfilePicture/" + filename);
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }

                UpdateUser();
                ClearValues();
                txtSearch.Text = "";
                txtSearch.Focus();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'You Are Not Eligible For Access Intensity Beyond Fitness Please ask To ClubManager' );", true);
            ClearValues();
            txtSearch.Text = "";
        }

        protected void btnOverride_Click(object sender, EventArgs e)
        {
            if (txtMsg.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'Write Message compulsory!!' );", true);
            }
            else
            {
                try
                {
                    string filename = "";
                    if (FileUploadControl.HasFile)
                    {
                        if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                        {
                            filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/MemberProfilePicture/" + filename));
                            imgProfileImage.ImageUrl = "~/" + Server.MapPath("~/MemberProfilePicture/" + filename);
                        }
                        else
                            StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                    }
                    UpdateUser();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'You Are Eligible Only Today For Access Intensity Beyond Fitness Please ask To ClubManager' );", true);
                    ClearValues();
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    btnOK.Enabled = false;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void CountEntry()
        {
            try
            {
                DateTime Today, GetDate;
                Today = DateTime.Now;
                //strCount = "select * from AttendenceManagement where RFIDNumber =  '" + txtSearch.Text + "' " + " OR AgreementNumber = '" + txtSearch.Text + "' " + " OR MobileNumber = '" + txtSearch.Text + "' " + " order by ID Desc";
                strCount = "select M.RFIDCardNumber,M.agreementNumber,L.mobileNumber,AM.lastCheckInDate from AccessManagement as AM inner join Memberships as M on M.ID = AM.memberId  inner join Leads as L on L.ID = M.leadId where M.RFIDCardNumber =  '" + txtSearch.Text + "' " + " OR M.agreementNumber = '" + txtSearch.Text + "' " + " OR L.mobileNumber = '" + txtSearch.Text + "' " + "  order by AM.ID DESC";
                dt9 = db.bound_control(strCount);
                if (dt9 != null && dt9.Rows.Count > 0)
                {
                    GetDate = Convert.ToDateTime(dt9.Rows[0][3].ToString().Trim()).Date;
                    if (GetDate.Date == Today.Date)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert( 'Second Time Visit' );", true);
                        btnOK.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExpiryAlert()
        {
            try
            {
                Today = DateTime.Now;
                TimeSpan ts;
                ts = ExpiryDate - Today;
                long Days = Convert.ToInt64(ts.TotalDays);
                if (Days <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'Membership Expired'   );", true);
                }
                else if (Days <= 15)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Erro_Msg", "alert( 'Your Expiry Date Will Be Coming After " + Days + " Days '  );", true);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}