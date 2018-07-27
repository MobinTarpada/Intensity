using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class FacilityController
    {
        public static List<Facility> GetFacilities()
        {
            try
            {
                return new FitnessCenterEntities().Facilities.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Facility GetFacilitiesById(long FacilityId)
        {
            try
            {
                return new FitnessCenterEntities().Facilities.FirstOrDefault(x => x.isDeleted == false && x.ID == FacilityId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Facility InsertFacility(Facility objFacility)
        {
            try
            {
                objFacility.insertDate = DateTime.Now;
                objFacility.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.Facilities.AddObject(objFacility);
                    context.SaveChanges();
                    return objFacility;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Facility UpdateFacility(Facility objFacility)
        {
            try
            {
                objFacility.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Facilities.Attach(context.Facilities.Single(x => x.ID == objFacility.ID));
                    context.Facilities.ApplyCurrentValues(objFacility);
                    context.SaveChanges();
                    return objFacility;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteFacility(long FacilityId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objFacility = context.Facilities.SingleOrDefault(x => x.ID == FacilityId);
                    objFacility.deleteDate = DateTime.Now;
                    objFacility.isDeleted = true;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}