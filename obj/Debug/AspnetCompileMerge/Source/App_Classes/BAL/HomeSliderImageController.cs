using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class HomeSliderImageController
    {

        public static List<HomepageSlider> GetSliderImages()
        {
            try
            {
                return new FitnessCenterEntities().HomepageSliders.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<HomepageSlider> GetSliderImagesForDisplay()
        {
            try
            {
                return new FitnessCenterEntities().HomepageSliders.Where(x => x.isDeleted == false && x.isDisplayed == true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static HomepageSlider GetSliderImagesById(long SliderId)
        {
            try
            {
                return new FitnessCenterEntities().HomepageSliders.FirstOrDefault(x => x.isDeleted == false && x.ID == SliderId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HomepageSlider InsertSliderImages(HomepageSlider objSliderImages)
        {
            try
            {
                objSliderImages.insertedDate = DateTime.Now;
                objSliderImages.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.HomepageSliders.AddObject(objSliderImages);
                    context.SaveChanges();
                    return objSliderImages;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HomepageSlider UpdateSliderImages(HomepageSlider objSliderImages)
        {
            try
            {
                objSliderImages.updatedDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.HomepageSliders.Attach(context.HomepageSliders.Single(x => x.ID == objSliderImages.ID));
                    context.HomepageSliders.ApplyCurrentValues(objSliderImages);
                    context.SaveChanges();
                    return objSliderImages;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteSliderImages(long SliderId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objFacility = context.HomepageSliders.SingleOrDefault(x => x.ID == SliderId);
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