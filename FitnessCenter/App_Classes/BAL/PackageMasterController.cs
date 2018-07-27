using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class PackageMasterController
    {
        #region PackageMaster

        public static bool IsPackageName(string PackageName)
        {
            try
            {
                var objPackageName = new FitnessCenterEntities().PackageMasters.FirstOrDefault(x => x.PackageName == PackageName && x.isDeleted == false);
                return objPackageName == null ? false : true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static PackageMaster GetPackageById(long PackageId)
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.FirstOrDefault(x => x.ID == PackageId && x.isDeleted == false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<PackageMaster> GetPackageMaster(long Clubid, string SearchText, string SortField, string SortDir)

        {
            try
            {
                return new FitnessCenterEntities().GetPackageMaster(Clubid,SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public PackageMaster InsertPackage(PackageMaster objPackage)
        {
            try
            {
                objPackage.isActive = true;
                objPackage.isDeleted = false;
                objPackage.insertDate = DateTime.Now;
                
                using (var context = new FitnessCenterEntities())
                {
                    context.PackageMasters.AddObject(objPackage);
                    context.SaveChanges();
                    return objPackage;
                }
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public PackageMaster UpdatePackage(PackageMaster objPackage)
        {
            try
            {
                objPackage.updateDate = DateTime.Now;

                using(var context = new FitnessCenterEntities())
                {
                    context.PackageMasters.Attach(context.PackageMasters.Single(varP => varP.ID == objPackage.ID));
                    context.PackageMasters.ApplyCurrentValues(objPackage);

                    context.SaveChanges();
                    return objPackage;


                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public void DeletePackage(int PackageId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objPackage = context.PackageMasters.SingleOrDefault(varP => varP.ID == PackageId);
                    objPackage.isDeleted = true;
                    objPackage.deleteDate = DateTime.Now;

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