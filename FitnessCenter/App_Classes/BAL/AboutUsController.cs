using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class AboutUsController
    {
        public static List<AboutU> GetAboutUs()
        {
            try
            {
                return new FitnessCenterEntities().AboutUs.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static AboutU GetAboutUsById(long ABoutUsId)
        {
            try
            {
                return new FitnessCenterEntities().AboutUs.FirstOrDefault(x => x.isDeleted == false && x.ID == ABoutUsId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AboutU InsertAboutUs(AboutU objAbout)
        {
            try
            {
                objAbout.isDeleted = false;
                objAbout.insertDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.AboutUs.AddObject(objAbout);
                    context.SaveChanges();
                    return objAbout;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AboutU UpdateAboutUs(AboutU objAbout)
        {
            try
            {
                objAbout.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.AboutUs.Attach(context.AboutUs.Single(x => x.ID == objAbout.ID));
                    context.AboutUs.ApplyCurrentValues(objAbout);
                    context.SaveChanges();
                    return objAbout;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteAboutUs(long AboutUsId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objAboutUs = context.AboutUs.SingleOrDefault(x => x.ID == AboutUsId);
                    objAboutUs.isDeleted=true;
                    objAboutUs.deleteDate = DateTime.Now;
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