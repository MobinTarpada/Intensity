using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class DesclaimerController
    {
        public static Membership GetDisclaimerByRFIDNo(long RFIDNumber)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.ID == RFIDNumber);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Disclaimer GetDisclaimerByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().Disclaimers.FirstOrDefault(x => x.isActive == true && x.isDeleted == false && x.memberId != null && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<GetMembers_Result> GetMembers(long CLUBID, string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetMembers(CLUBID, SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetDiscalimersEntry_Result> GetDisclaimerEntry(long CLUBID, long MemberId, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetDiscalimersEntry(CLUBID, MemberId, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Disclaimer InsertDisclaimer(Disclaimer objDisclaimer)
        {
            try
            {
                objDisclaimer.insertDate = DateTime.Now;
                objDisclaimer.isActive = true;
                objDisclaimer.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Disclaimers.AddObject(objDisclaimer);
                    context.SaveChanges();
                    return objDisclaimer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Disclaimer UpdateDisclaimer(Disclaimer objDisclaimer)
        {
            try
            {
                objDisclaimer.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Disclaimers.Attach(context.Disclaimers.Single(varL => varL.ID == objDisclaimer.ID));
                    context.Disclaimers.ApplyCurrentValues(objDisclaimer);

                    context.SaveChanges();
                    return objDisclaimer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteDisclaimer(long MemberId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objDisclaimer = context.Disclaimers.SingleOrDefault(varL => varL.memberId == MemberId);


                    objDisclaimer.isDeleted = true;
                    objDisclaimer.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteDisclaimerEntry(int DisID)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objDisclaimer = context.Disclaimers.SingleOrDefault(varL => varL.ID == DisID);


                    objDisclaimer.isDeleted = true;
                    objDisclaimer.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Measurement

        public static MeasurementMaster GetMeasurementById(long MeasurementId)
        {
            try
            {
                return new FitnessCenterEntities().MeasurementMasters.FirstOrDefault(x => x.isDelete == false && x.isActive == true && x.ID == MeasurementId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MeasurementMaster> GetMemberByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MeasurementMasters.Where(x => x.isDelete == false && x.isActive == true && x.memberId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MeasurementMaster InsertMeasurement(MeasurementMaster objMeasurement)
        {
            try
            {
                objMeasurement.insertDate = DateTime.Now;
                objMeasurement.isActive = true;
                objMeasurement.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.MeasurementMasters.AddObject(objMeasurement);
                    context.SaveChanges();
                    return objMeasurement;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MeasurementMaster UpdateMeasurement(MeasurementMaster objMeasurement)
        {
            try
            {
                objMeasurement.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.MeasurementMasters.Attach(context.MeasurementMasters.Single(varL => varL.ID == objMeasurement.ID));
                    context.MeasurementMasters.ApplyCurrentValues(objMeasurement);

                    context.SaveChanges();
                    return objMeasurement;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteMeasurement(long MeasurementId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objMeasurement = context.MeasurementMasters.SingleOrDefault(varL => varL.ID == MeasurementId);


                    objMeasurement.isDelete = true;
                    objMeasurement.deleteDate = DateTime.Now;

                    context.SaveChanges();
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