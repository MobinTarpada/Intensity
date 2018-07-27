using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class PTPPackageController
    {
        public static List<PTPPackageMaster> GetPTPPackages(string packageName, string sortField, string sortDir, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetPTPPackages(packageName, sortField, sortDir, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static PTPPackageMaster GetPTPPackagesByID(long PackageId)
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

        public PTPPackageMaster InsertPackages(PTPPackageMaster objPTPPackages)
        {
            try
            {
                objPTPPackages.insertDate = DateTime.Now;
                objPTPPackages.isActive = true;
                objPTPPackages.isDelete = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPPackageMasters.AddObject(objPTPPackages);
                    context.SaveChanges();
                    return objPTPPackages;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PTPPackageMaster UpdatePackages(PTPPackageMaster objPTPPackages)
        {
            try
            {
                objPTPPackages.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.PTPPackageMasters.Attach(context.PTPPackageMasters.Single(x => x.ID == objPTPPackages.ID));
                    context.PTPPackageMasters.ApplyCurrentValues(objPTPPackages);
                    context.SaveChanges();
                    return objPTPPackages;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePackages(long PackageId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objPTP = context.PTPPackageMasters.SingleOrDefault(x => x.ID == PackageId);
                    objPTP.deleteDate = DateTime.Now;
                    objPTP.isDelete = true;
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