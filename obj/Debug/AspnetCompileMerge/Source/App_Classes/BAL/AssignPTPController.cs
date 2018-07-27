using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class AssignPTPController
    {
        #region PTPMember Master
        public static List<GetAssignedPTP_Result> GetAssignedPTP(string MemberName, string RfidNo, string MembershipNo, string SortDir, string SortField, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetAssignedPTP(MemberName, RfidNo, MembershipNo, SortDir, SortField, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static PTPMemberMaster GetAssignedPTPByID(long PTPMemberMasterId)
        {
            try
            {
                return new FitnessCenterEntities().PTPMemberMasters.FirstOrDefault(x => x.isDelete == false && x.isActive == true && x.ID == PTPMemberMasterId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static PTPMemberMaster GetAssignedPTPByPackageIdAndMemberId(long PTPPackageId, long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().PTPMemberMasters.FirstOrDefault(x => x.isDelete == false && x.isActive == true && x.PTPPackageID == PTPPackageId && x.memberId == MemberId && x.sessionCount != 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PTPMemberMaster InsertPTPMember(PTPMemberMaster objPTPMember)
        {
            try
            {
                objPTPMember.insertDate = DateTime.Now;
                objPTPMember.isActive = true;
                objPTPMember.isDelete = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPMemberMasters.AddObject(objPTPMember);
                    context.SaveChanges();
                    return objPTPMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PTPMemberMaster UpdatePTPMember(PTPMemberMaster objPTPMember)
        {
            try
            {
                objPTPMember.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPMemberMasters.Attach(context.PTPMemberMasters.Single(varC => varC.ID == objPTPMember.ID));
                    context.PTPMemberMasters.ApplyCurrentValues(objPTPMember);
                    context.SaveChanges();
                    return objPTPMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeletePTPMember(long PTPMemberMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objPTPMember = context.PTPMemberMasters.SingleOrDefault(x => x.ID == PTPMemberMasterId);
                    objPTPMember.isDelete = true;
                    objPTPMember.deleteDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Members
        public static List<GetMembersByLeadID_Result> GetMembersByLeadID(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetMembersByLeadID(ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Membership GetmembersByID(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.ID == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region PTPPackages
        public static List<PTPPackageMaster> GetPackages()
        {
            try
            {
                return new FitnessCenterEntities().PTPPackageMasters.Where(x => x.isActive == true && x.isDelete == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static PTPPackageMaster GetPackagesByID(long PackageId)
        {
            try
            {
                return new FitnessCenterEntities().PTPPackageMasters.FirstOrDefault(x => x.isActive == true && x.isDelete == false && x.ID == PackageId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region PTPMember Trans
        public static List<PTPMemberTransaction> GetTransByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().PTPMemberTransactions.Where(x => x.isActive == true && x.isDelete == false && x.memberId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PTPMemberTransaction> GetTransByMemberIdAndPTPMasterId(long MemberId, long PTPMasterId)
        {
            try
            {
                return new FitnessCenterEntities().PTPMemberTransactions.Where(x => x.isActive == true && x.isDelete == false && x.memberId == MemberId && x.PTPMemberMasterId == PTPMasterId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetAssignedTransaction_Result> GetAssignedTransaction(long PTPMemberMasterId)
        {
            try
            {
                return new FitnessCenterEntities().GetAssignedTransaction(PTPMemberMasterId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PTPMemberTransaction InsertTransaction(PTPMemberTransaction objPTPTrans)
        {
            try
            {
                objPTPTrans.insertDate = DateTime.Now;
                objPTPTrans.isDelete = false;
                objPTPTrans.isActive = true;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPMemberTransactions.AddObject(objPTPTrans);
                    context.SaveChanges();
                    return objPTPTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PTPMemberTransaction UpdateTransaction(PTPMemberTransaction objPTPTrans)
        {
            try
            {
                objPTPTrans.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPMemberTransactions.Attach(context.PTPMemberTransactions.Single(x => x.memberId == objPTPTrans.memberId));
                    context.PTPMemberTransactions.ApplyCurrentValues(objPTPTrans);
                    context.SaveChanges();
                    return objPTPTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}