using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class PaymentController
    {
        #region Members
        public static Membership GetMembersByAgreementNo(string AgreementNo)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.AgreementNo == AgreementNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Payment GetMemberByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().Payments.FirstOrDefault(x => x.isDeleted == false  && x.LeadId == LeadId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Membership GetMembersByRfidNo(string RfidNo)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.RFIDCardNumber == RfidNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Payment InsertPaymentHistory(Payment objpayment)
            {
            try
            {
                objpayment.insertDate = DateTime.Now;
                objpayment.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Payments.AddObject(objpayment);
                    context.SaveChanges();
                    return objpayment;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Payment UpdatePayment(Payment objPay)
        //{
        //    try
        //    {
        //        using (var context = new FitnessCenterEntities())
        //        {
        //            (from p in context.Payments
        //             where p.MembershipId == objPay.MembershipId
        //             select p).ToList().ForEach(x => x.isFullPaid = true);

        //            context.SaveChanges();
        //            return objPay;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static Payment GetLastReceiptNumber(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().Payments.Where(x => x.ClubId == ClubId).OrderByDescending(x => x.PayNo).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Payment GetDueMembersByAgreementNo(long leadId)
        {
            try
            {
                return new FitnessCenterEntities().Payments.Where(x => x.isDeleted == false && x.LeadId == leadId).OrderByDescending(x => x.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Payment GetMembersByleadID(long leadId)
        {
            try
            {
                return new FitnessCenterEntities().Payments.FirstOrDefault(x => x.isDeleted == false && x.LeadId == leadId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Payment> GetMembersByAgrNo(long MembershipId)
        {
            try
            {
                return new FitnessCenterEntities().Payments.Where(x => x.isDeleted == false && x.MembershipId == MembershipId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Payment UpdateOldPayment(Payment objpayments)
        //{
        //    try
        //    {
        //        objpayments.updateDate = DateTime.Now;
        //        using (var context = new FitnessCenterEntities())
        //        {
        //            //context.Payments.Attach(context.Payments.Where(varC => varC.leadId == objpayment.leadId && varC.isDeleted == false && varC.isActive == true)).ToList().ForEach(varC => varC.isFullPaid == true);
        //            var users = (from u in context.Payments where u.MembershipId == objpayments.MembershipId select u).ToList();
        //            users.ForEach(u => u.isFullPaid = false);
        //            //context.Payments.Where(varC => varC.leadId == objpayment.leadId);
        //            context.Payments.ApplyCurrentValues(objpayments);
        //            context.SaveChanges();
        //            return objpayments;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public Payment UpdatePaymentHistory(Payment objpayment)
        //{
        //    try
        //    {
        //        objpayment.updateDate = DateTime.Now;
        //        using (var context = new FitnessCenterEntities())
        //        {
        //            //context.Payments.Attach(context.Payments.Where(varC => varC.leadId == objpayment.leadId && varC.isDeleted == false && varC.isActive == true)).ToList().ForEach(varC => varC.isFullPaid == true);
        //            var users = (from u in context.Payments where u.leadId == objpayment.leadId select u).ToList();
        //            users.ForEach(u => u.isFullPaid = true);
        //            //context.Payments.Where(varC => varC.leadId == objpayment.leadId);
        //            context.Payments.ApplyCurrentValues(objpayment);
        //            context.SaveChanges();
        //            return objpayment;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        #endregion

        #region PTPPackages

        public static PTPMemberMaster GetAssignedPTPByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().PTPMemberMasters.FirstOrDefault(x => x.isActive == true && x.isDelete == false && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region TowelPackages

        public static TowelHiringMaster GetAssignedTowelByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().TowelHiringMasters.FirstOrDefault(x => x.isDeleted == false && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region ItemSales

        public static MemberItemTotalSale GetTotalSalesByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberItemTotalSales.FirstOrDefault(x => x.isDeleted == false && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region JuiceRecharge

        public static MemberJuiceMaster GetJuiceRechargeByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberJuiceMasters.FirstOrDefault(x => x.isDelete == false && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Payment History
        public static List<GetPaymentHistory_Result> GetPaymentHistory(String SearchText, String AgreementNo, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetPaymentHistory(SearchText, AgreementNo, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetPartPayment_Result> GetPartPayment(String SearchText, long ClubId)
        {
            return new FitnessCenterEntities().GetPartPayment(SearchText, ClubId).ToList();
        }

        public static List<GetFullPayment_Result> GetFullPayment(String SearchText, long ClubId)
        {
            return new FitnessCenterEntities().GetFullPayment(SearchText, ClubId).ToList();
        }

        #endregion
    }
}