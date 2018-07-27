using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;


namespace FitnessCenter.BAL
{
    public class UserProfileController
    {
        public static User GetUserByID(long UserId)
        {
            try
            {

                return new FitnessCenterEntities().Users.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<User> GetUsers(long ClubId,long UserId, long RoleId, string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetUsers(ClubId,UserId, RoleId, SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public User UpdateUser(User objUser)
        {
            try
            {
                objUser.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.Users.Attach(context.Users.Single(varU => varU.ID == objUser.ID));
                    context.Users.ApplyCurrentValues(objUser);

                    context.SaveChanges();

                    return objUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Role

        public static List<UserTypeMaster> GetUserTypesWithoutAdmin()
        {
            try
            {

                return new FitnessCenterEntities().UserTypeMasters.Where(x => x.isDeleted == false && x.ID != (long)EnumUserTypeMaster.SuperAdmin && x.ID != (int)EnumUserTypeMaster.Admin).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}