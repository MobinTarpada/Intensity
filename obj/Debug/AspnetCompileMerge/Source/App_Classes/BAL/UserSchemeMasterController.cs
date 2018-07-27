using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class UserSchemeMasterController
    {
        #region UserSchemeMaster

        public static UserSchemeMaster GetUserSchemeMasterByID(long UserSchemeId)
        {
            try
            {
                return new FitnessCenterEntities().UserSchemeMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == UserSchemeId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<GetUserSchemeMaster_Result> GetUserSchemeMaster(string SearchText,string SchemeName, string SortField, string SortDir, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetUserSchemeMaster(SearchText,SchemeName ,SortField, SortDir, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserSchemeMaster InsertUserScheme(UserSchemeMaster objScheme)
        {
            try
            {
                objScheme.insertDate = DateTime.Now;
                objScheme.isActive = true;
                objScheme.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserSchemeMasters.AddObject(objScheme);
                    context.SaveChanges();
                    return objScheme;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserSchemeMaster UpdateUserScheme(UserSchemeMaster objScheme)
        {
            try
            {
                objScheme.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserSchemeMasters.Attach(context.UserSchemeMasters.Single(varU => varU.ID == objScheme.ID));
                    context.UserSchemeMasters.ApplyCurrentValues(objScheme);

                    context.SaveChanges();
                    return objScheme;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteUserScheme(int UserShemeID)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objScheme = context.UserSchemeMasters.SingleOrDefault(varU => varU.ID == UserShemeID);

                    objScheme.isDeleted = true;
                    objScheme.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Package
        public static List<PackageMaster> GetPackages(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.Where(x => x.isDeleted == false && x.clubId == ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static PackageMaster GetPackagesByID(long PackageID)
        {
            try
            {
                return new FitnessCenterEntities().PackageMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == PackageID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
        #region UserType
        public static List<UserTypeMaster> GetUserTypes()
        {
            try
            {

                return new FitnessCenterEntities().UserTypeMasters.Where(x => x.isDeleted == false && x.ID == (long)EnumUserTypeMaster.Executive || x.ID == (long)EnumUserTypeMaster.ClubManager || x.ID == (long)EnumUserTypeMaster.FitnessManager).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region UserSchemeTransaction

        public UserSchemeTransaction InsertUserSchemeTransaction(UserSchemeTransaction objSchemeTran)
        {
            try
            {
                objSchemeTran.insertDate = DateTime.Now;
                objSchemeTran.isActive = true;
                objSchemeTran.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserSchemeTransactions.AddObject(objSchemeTran);
                    context.SaveChanges();
                    return objSchemeTran;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<UserSchemeTransaction> GetTransactionBySchemeID(long UserSchemeId)
        {
            return new FitnessCenterEntities().UserSchemeTransactions.Where(x => x.isDelete == false && x.isActive == true && x.userSchemeId == UserSchemeId).ToList();
        }
        public static List<UserSchemeTransaction> GetTransactionBySchemeIDAndUserType(long UserSchemeId, long UsertTypeId)
        {
            return new FitnessCenterEntities().UserSchemeTransactions.Where(x => x.isDelete == false && x.isActive == true && x.userSchemeId == UserSchemeId && x.userTypeId == UsertTypeId).ToList();
        }
        public static UserSchemeTransaction GetUserSchemeTransactionByID(long UserSchemeTransId)
        {
            try
            {
                return new FitnessCenterEntities().UserSchemeTransactions.FirstOrDefault(x => x.isDelete == false && x.ID == UserSchemeTransId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserSchemeTransaction UpdateUserSchemeTransaction(UserSchemeTransaction objSchemeTrans)
        {
            try
            {
                objSchemeTrans.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserSchemeTransactions.Attach(context.UserSchemeTransactions.Single(varU => varU.ID == objSchemeTrans.ID));
                    context.UserSchemeTransactions.ApplyCurrentValues(objSchemeTrans);

                    context.SaveChanges();
                    return objSchemeTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteUserSchemeTransaction(int UserShemeTransactionID)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objScheme = context.UserSchemeTransactions.SingleOrDefault(varU => varU.ID == UserShemeTransactionID);

                    objScheme.isDelete = true;
                    objScheme.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region CancellationMaster
        public static CancellationMaster GetCancellationBySchemeId(long UserSchemeId)
        {
            try
            {
                return new FitnessCenterEntities().CancellationMasters.FirstOrDefault(x => x.isDelete == false && x.isActive == true && x.schemeId == UserSchemeId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CancellationMaster InsertCancelMaster(CancellationMaster objCancelMaster)
        {
            try
            {
                objCancelMaster.insertDate = DateTime.Now;
                objCancelMaster.isActive = true;
                objCancelMaster.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.CancellationMasters.AddObject(objCancelMaster);
                    context.SaveChanges();
                    return objCancelMaster;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteCancelSchemeMaster(int UserShemeID)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objScheme = context.CancellationMasters.SingleOrDefault(varU => varU.schemeId == UserShemeID);

                    objScheme.isDelete = true;
                    objScheme.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CancellationMaster UpdateCancelMaster(CancellationMaster objCancelMaster)
        {
            try
            {
                objCancelMaster.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.CancellationMasters.Attach(context.CancellationMasters.Single(varC => varC.schemeId == objCancelMaster.schemeId));
                    context.CancellationMasters.ApplyCurrentValues(objCancelMaster);
                    context.SaveChanges();
                    return objCancelMaster;
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