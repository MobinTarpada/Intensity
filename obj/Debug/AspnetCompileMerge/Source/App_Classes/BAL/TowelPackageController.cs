using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class TowelPackageController
    {
        public static List<TowelHiringPackage> GetTowelPackages(string SortDir, string SortField, string PackageName, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetTowelPackage(SortDir, SortField, PackageName, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TowelHiringPackage GetTowelPackageById(long PackageId)
        {
            try
            {
                return new FitnessCenterEntities().TowelHiringPackages.FirstOrDefault(x => x.isDeleted == false && x.ID == PackageId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelHiringPackage InsertPackage(TowelHiringPackage objTowel)
        {
            try
            {
                objTowel.insertDate = DateTime.Now;
                objTowel.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelHiringPackages.AddObject(objTowel);
                    context.SaveChanges();
                    return objTowel;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TowelHiringPackage UpdatePackage(TowelHiringPackage objTowel)
        {
            try
            {
                objTowel.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.TowelHiringPackages.Attach(context.TowelHiringPackages.Single(x => x.ID == objTowel.ID));
                    context.TowelHiringPackages.ApplyCurrentValues(objTowel);
                    context.SaveChanges();
                    return objTowel;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePackage(long PackageId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objTowel = context.TowelHiringPackages.Single(x => x.ID == PackageId);
                    objTowel.deleteDate = DateTime.Now;
                    objTowel.isDeleted = true;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsNameExists(string PackageName)
        {
            try
            {
                var objTowel = new FitnessCenterEntities().TowelHiringPackages.FirstOrDefault(x => x.isDeleted == false && x.packageName == PackageName);
                return objTowel == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}