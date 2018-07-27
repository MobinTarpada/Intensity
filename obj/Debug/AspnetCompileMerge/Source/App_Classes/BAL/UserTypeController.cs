using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class UserTypeController
    {
        #region UserType

        public static bool IsUserType(string UserType)
        {
            try
            {
                var objUserType = new FitnessCenterEntities().UserTypeMasters.FirstOrDefault(x => x.type == UserType && x.isDeleted == false);
                return objUserType == null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static UserTypeMaster GetUserTypeByID(long UserTypeID)
        {
            try
            {
                return new FitnessCenterEntities().UserTypeMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == UserTypeID);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<UserTypeMaster> GetUserTypes(string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetUserTypes(SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public UserTypeMaster InsertUserType(UserTypeMaster ObjUserType)
        {
            try
            {
                ObjUserType.insertDate = DateTime.Now;
                ObjUserType.isActive = true;
                ObjUserType.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserTypeMasters.AddObject(ObjUserType);
                    context.SaveChanges();
                    return ObjUserType;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserTypeMaster UpdateUserType(UserTypeMaster objUserType)
        {
            try
            {
                objUserType.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.UserTypeMasters.Attach(context.UserTypeMasters.Single(varL => varL.ID == objUserType.ID));
                    context.UserTypeMasters.ApplyCurrentValues(objUserType);

                    context.SaveChanges();
                    return objUserType;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteUserType(int UserTypeId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objUserType = context.UserTypeMasters.SingleOrDefault(varL => varL.ID == UserTypeId);

                    objUserType.isDeleted = true;
                    objUserType.deleteDate = DateTime.Now;

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