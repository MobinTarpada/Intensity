using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class AssignTowelController
    {
        #region TowelMemberMaster
        public static List<GetAssignedTowel_Result> GetAssignedTowel(string SortDir, string SortField, string Rfid, string MemberName, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetAssignedTowel(SortDir, SortField, Rfid, MemberName, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TowelHiringMaster GetAssignedTowelById(long TowelMasterId)
        {
            try
            {
                return new FitnessCenterEntities().TowelHiringMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == TowelMasterId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TowelHiringMaster GetAssignedTowelByMemberIdAndPackageId(long MemberId, long PackageId)
        {
            try
            {
                return new FitnessCenterEntities().TowelHiringMasters.FirstOrDefault(x => x.isDeleted == false && x.memberId == MemberId && x.towelPackageId == PackageId && x.hiringTimeUpdate != 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelHiringMaster InsertTowelMember(TowelHiringMaster objTowelMember)
        {
            try
            {
                objTowelMember.insertDate = DateTime.Now;
                objTowelMember.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelHiringMasters.AddObject(objTowelMember);
                    context.SaveChanges();
                    return objTowelMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelHiringMaster UpdateTowelMember(TowelHiringMaster objTowelMember)
        {
            try
            {
                objTowelMember.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelHiringMasters.Attach(context.TowelHiringMasters.Single(x => x.ID == objTowelMember.ID));
                    context.TowelHiringMasters.ApplyCurrentValues(objTowelMember);
                    context.SaveChanges();
                    return objTowelMember;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTowelMember(long TowelMemberId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objTowelMember = context.TowelHiringMasters.SingleOrDefault(x => x.ID == TowelMemberId);
                    objTowelMember.isDeleted = true;
                    objTowelMember.deleteDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region TowelPackage
        public static List<TowelHiringPackage> GetPackages()
        {
            try
            {
                return new FitnessCenterEntities().TowelHiringPackages.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region TowelMember Trans
        public static List<TowelTransaction> GetTransByMemberAndTowelMasterId(long MemberId, long TowelMasterId)
        {
            try
            {
                return new FitnessCenterEntities().TowelTransactions.Where(x => x.isDeleted == false && x.memberId == MemberId && x.towelHiriningId == TowelMasterId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<TowelTransaction> GetAssignedTransaction(long TowelMasterId)
        {
            try
            {
                return new FitnessCenterEntities().TowelTransactions.Where(x => x.isDeleted == false && x.towelHiriningId == TowelMasterId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TowelTransaction GetTransById(long TowelTransId)
        {
            try
            {
                return new FitnessCenterEntities().TowelTransactions.FirstOrDefault(x => x.isDeleted == false && x.ID == TowelTransId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelTransaction InsertTransaction(TowelTransaction objTowelTrans)
        {
            try
            {
                objTowelTrans.insertDate = DateTime.Now;
                objTowelTrans.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelTransactions.AddObject(objTowelTrans);
                    context.SaveChanges();
                    return objTowelTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelTransaction UpdateTransaction(TowelTransaction objTowelTrans)
        {
            try
            {
                objTowelTrans.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelTransactions.Attach(context.TowelTransactions.Single(x => x.ID == objTowelTrans.ID));
                    context.TowelTransactions.ApplyCurrentValues(objTowelTrans);
                    context.SaveChanges();
                    return objTowelTrans;
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