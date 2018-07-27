using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class MembershipController
    {
        #region Membership

        public static List<Lead> GetLeadForTransfer(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().Leads.Where(x => x.isActive == true && x.isDeleted == false && x.clubId == ClubId && x.leadStatusId != 5 && x.leadStatusId != 6 && x.leadStatusId != 7).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool IsMemberExists(string AgreementNo)
        {
            try
            {
                var obj = new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.AgreementNo == AgreementNo);
                return obj == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Membership GetMemberById(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.ID == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Membership GetLeadById(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.LeadId == LeadId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Membership> GetMembersByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.Where(x => x.isDeleted == false && x.isActive == true && x.LeadId == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Membership GetMembersByLeadId(string LeadId)
        {
            try
            {
                long leadId = Convert.ToInt64(LeadId);
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.LeadId == leadId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Membership GetmembersById(long memberId)
        {
            try
            {
                 return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == memberId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Membership> GetMembersByMembershipNumber()
        {
            try
            {
                return new FitnessCenterEntities().Memberships.Where(x => x.MembershipNo != null).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Membership> GetMembersByAgreementNumber()
        {
            try
            {
                return new FitnessCenterEntities().Memberships.Where(x => x.isDeleted == false || x.isActive == true || x.isDeleted == true || x.isActive == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Membership InsertMember(Membership ObjMember)
        {
            try
            {
                ObjMember.insertDate = DateTime.Now;
                ObjMember.isActive = true;
                ObjMember.isDeleted = false;
                //ObjMember.isPaid = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Memberships.AddObject(ObjMember);
                    context.SaveChanges();
                    return ObjMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Membership UpdateMember(Membership objMember)
        {
            try
            {
                objMember.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Memberships.Attach(context.Memberships.Single(varC => varC.ID == objMember.ID && varC.isDeleted == false && varC.isActive == true));
                    context.Memberships.ApplyCurrentValues(objMember);
                    context.SaveChanges();
                    return objMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteMember(int LeadId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLead = context.Leads.SingleOrDefault(varM => varM.ID == LeadId);
                    //objLead.isDeleted = true;
                    objLead.deleteDate = DateTime.Now;
                    objLead.leadStatusId = 4;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Membership UpdateMembers(Membership ObjMember)
        {
            try
            {
                ObjMember.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Memberships.Attach(context.Memberships.Single(varL => varL.LeadId == ObjMember.LeadId));
                    context.Memberships.ApplyCurrentValues(ObjMember);

                    context.SaveChanges();
                    return ObjMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Leads
        public static List<Lead> GetLeadsById(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().Leads.Where(x => x.isDeleted == false && x.isActive == true && x.leadStatusId == 5 && x.ID == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Lead> GetLeads(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().Leads.Where(x => x.leadStatusId == 5 && x.isDeleted == false && x.isActive == true && x.clubId == ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Lead> GetSalesLeads(long ClubId, string FirstName, string LastName, string MobileNo, string AgreementNo, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetSalesLeads(ClubId, FirstName, LastName, MobileNo, AgreementNo, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        #endregion

        //#region UserschemeMaster
        //public static SchemeMaster GetDiscountByUserTypeId(long UserTypeId)
        //{
        //    try
        //    {
        //        return new FitnessCenterEntities().SchemeMasters.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.userTypeId == UserTypeId);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //#endregion
        #region Package

        public static List<PackageMaster> GetPackageTypes()
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
        #region Clubs
        public static Club GetClubsByID(long ClubId)
        {
            try
            {

                return new FitnessCenterEntities().Clubs.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == ClubId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Schemes

        public static List<SchemeMaster> GetSchemes()
        {
            try
            {
                return new FitnessCenterEntities().SchemeMasters.Where(x => x.isActive == true && x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<SchemeMaster> GetSchemesByPackageId(long PackageId)
        {
            try
            {
                return new FitnessCenterEntities().SchemeMasters.Where(x => x.isActive == true && x.isDeleted == false && x.PackageId == PackageId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static SchemeMaster GetSchemesById(long SchemeId)
        {
            return new FitnessCenterEntities().SchemeMasters.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.ID == SchemeId);
        }
        #endregion
        #region SchemesTrans
        public static UserSchemeTransaction GetTransBySchemeAndUserType(long SchemeId, long UserTypeId)
        {
            return new FitnessCenterEntities().UserSchemeTransactions.FirstOrDefault(x => x.isActive == true && x.isDelete == false && x.userSchemeId == SchemeId && x.userTypeId == UserTypeId);
        }
        #endregion
    }
}