using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class CareerController
    {
        public static List<Career> GetCareerPositions()
        {
            try
            {
                return new FitnessCenterEntities().Careers.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Career GetCareerPositionsById(long CareerId)
        {
            try
            {
                return new FitnessCenterEntities().Careers.FirstOrDefault(x => x.isDeleted == false && x.ID == CareerId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Career InsertPosition(Career objCareer)
        {
            try
            {
                objCareer.insertDate = DateTime.Now;
                objCareer.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.Careers.AddObject(objCareer);
                    context.SaveChanges();
                    return objCareer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Career UpdatePosition(Career objCareer)
        {
            try
            {
                objCareer.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Careers.Attach(context.Careers.Single(x => x.ID == objCareer.ID));
                    context.Careers.ApplyCurrentValues(objCareer);
                    context.SaveChanges();
                    return objCareer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePosition(long CareerId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objCareer = context.Careers.SingleOrDefault(x => x.ID == CareerId);
                    objCareer.isDeleted = true;
                    objCareer.deleteDate = DateTime.Now;
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