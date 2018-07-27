using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class VirtualTourController
    {
        public static List<VirtualVideo> GetVirtualVideos()
        {
            try
            {
                return new FitnessCenterEntities().VirtualVideos.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static VirtualVideo GetVirtualVideosById(long VirtualId)
        {
            try
            {
                return new FitnessCenterEntities().VirtualVideos.FirstOrDefault(x => x.isDeleted == false && x.ID == VirtualId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VirtualVideo InsertVideos(VirtualVideo objVideo)
        {
            try
            {
                objVideo.insertDate = DateTime.Now;
                objVideo.isDeleted = false;
                using (var context=new FitnessCenterEntities())
                {
                    context.VirtualVideos.AddObject(objVideo);
                    context.SaveChanges();
                    return objVideo;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VirtualVideo UpdateVideos(VirtualVideo objVideo)
        {
            try
            {
                objVideo.updateDate = DateTime.Now;
                using (var context=new FitnessCenterEntities())
                {
                    context.VirtualVideos.Attach(context.VirtualVideos.Single(x => x.ID == objVideo.ID));
                    context.VirtualVideos.ApplyCurrentValues(objVideo);
                    context.SaveChanges();
                    return objVideo;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteVideo(long VideoId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objVideo = context.VirtualVideos.SingleOrDefault(varU => varU.ID == VideoId);

                    objVideo.isDeleted = true;
                    objVideo.deleteDate = DateTime.Now;
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