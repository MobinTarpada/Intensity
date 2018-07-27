using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class CustomerController
    {
        #region Customers
        public static List<GetCustomers_Result> GetCustomers(string firstName, string lastName, string DOB, string mobileNo, string rfidNo, string membershipNo, string sortField, string sortDir, long ClubId, string SrchPackageId, string SrchSchemeID)
        {
            try
            {
                return new FitnessCenterEntities().GetCustomers(firstName, lastName, DOB, mobileNo, rfidNo, membershipNo, sortField, sortDir, ClubId, SrchPackageId, SrchSchemeID).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Members
        public static Membership GetMembersByID(long MembershipId)
        {
            return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.ID == MembershipId && x.isDeleted == false && x.isActive == true);
        }
        public static Membership GetMembersByRenew(string MembershipId)
        {
            return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.MembershipNo == MembershipId && x.isActive == false && x.isDeleted == true);
        }

        public static Membership GetMembersOldByID(long MembershipId)
        {
            return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.LeadId == MembershipId  && x.isActive == true && x.isDeleted == false);
        }

        public static Membership GetMembersByLeadID(long MembershipId)
        {
            return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.LeadId == MembershipId);
        }
        public Membership DeleteMember(Membership objMember)
        {
            try
            {
                objMember.deleteDate = DateTime.Now;
                objMember.isDeleted = true;
                objMember.isActive = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.Memberships.Attach(context.Memberships.Single(varM => varM.ID == objMember.ID));
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

        public Membership UpdateMembers(Membership ObjMember)
        {
            try
            {
                ObjMember.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Memberships.Attach(context.Memberships.Single(varL => varL.ID == ObjMember.ID));
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
        public static Lead GetLeadByID(long LeadId)
        {
            return new FitnessCenterEntities().Leads.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.ID == LeadId);
        }
        #endregion

        #region Schemes
        public static List<SchemeMaster> GetSchemes()
        {
            return new FitnessCenterEntities().SchemeMasters.Where(x => x.isActive == true && x.isDeleted == false).ToList();
        }

        public static List<SchemeMaster> GetSchemesByPackageId(long PackageId)
        {
            return new FitnessCenterEntities().SchemeMasters.Where(x => x.isActive == true && x.isDeleted == false && x.PackageId == PackageId).ToList();
        }
        #endregion

        #region Transactions
        public CancellationTransaction InsertCancelTrans(CancellationTransaction objCancelTrans)
        {
            try
            {
                objCancelTrans.insertDate = DateTime.Now;
                objCancelTrans.isActive = true;
                objCancelTrans.isDelete = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.CancellationTransactions.AddObject(objCancelTrans);
                    context.SaveChanges();
                    return objCancelTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DowngradeTransaction InsertDownTrans(DowngradeTransaction objDownTrans)
        {
            try
            {
                objDownTrans.isActive = true;
                objDownTrans.isDelete = false;
                objDownTrans.insertDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.DowngradeTransactions.AddObject(objDownTrans);
                    context.SaveChanges();
                    return objDownTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UpgradeTransaction InsertUpgradeTrans(UpgradeTransaction objUpgradeTrans)
        {
            try
            {
                objUpgradeTrans.isActive = true;
                objUpgradeTrans.isDelete = false;
                objUpgradeTrans.insertDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.UpgradeTransactions.AddObject(objUpgradeTrans);
                    context.SaveChanges();
                    return objUpgradeTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TimeTransaction InsertTimeTrans(TimeTransaction objTimeTrans)
        {
            try
            {
                objTimeTrans.insertDate = DateTime.Now;
                objTimeTrans.isActive = true;
                objTimeTrans.isDelete = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.TimeTransactions.AddObject(objTimeTrans);
                    context.SaveChanges();
                    return objTimeTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TimeTransaction GetFreezeByMemberId(long MemberId)
        {
            return new FitnessCenterEntities().TimeTransactions.FirstOrDefault(x => x.memberId == MemberId && x.isActive == true);
        }
        public TimeTransaction UpdateTimeTransaction(TimeTransaction ObjMember)
        {
            try
            {
                ObjMember.updateDate = DateTime.Now;
                ObjMember.isActive = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.TimeTransactions.Attach(context.TimeTransactions.Single(varL => varL.ID == ObjMember.ID));
                    context.TimeTransactions.ApplyCurrentValues(ObjMember);

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

        #region Packages
        public static List<PackageMaster> GetPackageTypes()
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.Where(x => x.isDeleted == false && x.isActive == true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<PackageMaster> GetPackageTypesForUpgrade(PackageMaster objPackage)
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.Where(x => x.isDeleted == false && x.isActive == true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<PackageMaster> GetPackageTypesForDowngrade(PackageMaster objPackage)
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.Where(x => x.isDeleted == false && x.isActive == true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}