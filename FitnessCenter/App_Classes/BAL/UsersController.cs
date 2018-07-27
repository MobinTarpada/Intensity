using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class UsersController
    {
        #region Users

        public static User GetUserByID(long UserId)
        {
            try
            {

                return new FitnessCenterEntities().Users.FirstOrDefault(x => x.isDeleted == false && x.ID == UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static User GetUserByIDForClubs(long UserId)
        {
            try
            {

                return new FitnessCenterEntities().Users.FirstOrDefault(x => x.isDeleted == false && x.ID == UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static User AuthanticateUser(string Username, string Password)
        {
            try
            {
                //var auth = 
                   return new FitnessCenterEntities().Users.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.UserName == Username && x.Password == Password);
                //if (auth != null && auth.username == Username && auth.password == Password)
                //    return auth;
                //else
                //    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Membership AuthanticateMmber(string MemberId)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.MembershipNo == MemberId && x.isActive == true == x.isDeleted == false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IsUserNameExists(string Username, string MobileNo )
        {
            try
            {
                var objUser = new FitnessCenterEntities().Users.FirstOrDefault(x => x.UserName == Username && x.Mobile == MobileNo && x.isDeleted == false && x.isActive == true);
                return objUser == null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsEmailExists(string Email)
        {
            try
            {
                var objUser = new FitnessCenterEntities().Users.FirstOrDefault(x => x.Email == Email && x.isDeleted == false);
                return objUser == null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetStaffActivity_Result> GetStaffActivity(string SearchText,string SortField,string SortDir,string FromDate,string ToDate,long UserId,long ClubId,long LeadStatus)
        {
            try
            {
                return new FitnessCenterEntities().GetStaffActivity(SearchText, SortField, SortDir, FromDate, ToDate, UserId, ClubId,LeadStatus).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<User> GetStaff()
        {
            try
            {
                string UserName = "";
                return new FitnessCenterEntities().Users.Where(x =>  x.FirstName+' '+x.LastName == UserName && x.UserTypeId != 7 && x.UserTypeId != 8 && x.UserTypeId != 9 && x.UserTypeId != 1 && x.isActive == true && x.isDeleted == false).ToList();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<LeadStatusMaster> GetStatus()
        {
            try
            {
                return new FitnessCenterEntities().LeadStatusMasters.Where(x => x.ID != 6 && x.isActive == true && x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<User> GetUsers(long ClubId, long UserId, long RoleId, string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetUsers(ClubId, UserId, RoleId, SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public User InsertUser(User objUser)
        {
            try
            {
                objUser.insertDate = DateTime.Now;
                //objUser.isActive = true;
                //objUser.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Users.AddObject(objUser);
                    context.SaveChanges();
                    return objUser;
                }
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

        public void DeleteUser(int userId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objUser = context.Users.SingleOrDefault(varU => varU.ID == userId);

                    objUser.isDeleted = true;
                    objUser.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

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

        #region Target

        public static List<UserTarget> GetUserTarget(long UserId)
        {
            try
            {
                return new FitnessCenterEntities().UserTargets.Where(x => x.isDeleted == false && x.isActive == true && x.userId == UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<UserTarget> GetUserTargetByDate(long UserId, long LeadTypeId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return new FitnessCenterEntities().UserTargets.Where(x => x.fromDate == FromDate && x.toDate == ToDate && x.userId == UserId && x.leadTypeId == LeadTypeId && x.isActive == true && x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<UserTarget> GetUserTargetByDateAndLeadType(long UserId, long LeadTypeId, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetUserTargetByDateAndLeadType(LeadTypeId, UserId, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<GetUserTargetsByUserId_Result> GetUserTargetsByUserId_Result(long UserId)
        {
            try
            {
                return new FitnessCenterEntities().GetUserTargetsByUserId(UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetAchievedTargetByUserAndLeadtype_Result> GetAchievedTargetByUserAndLeadtype_Result(int UserId, int LeadTypeId)
        {
            try
            {
                return new FitnessCenterEntities().GetAchievedTargetByUserAndLeadtype(UserId, LeadTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetLeadTargetHeaders_Result> GetLeadTargetHeaders_Result(long ClubId, long UserTypeId)
        {
            try
            {
                return new FitnessCenterEntities().GetLeadTargetHeaders(ClubId, UserTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserTarget GetUserTargetById(long UserTargetId)
        {
            try
            {
                return new FitnessCenterEntities().UserTargets.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == UserTargetId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<User> GetClubEmployees(long ClubId, long UserTypeId)
        {
            try
            {
                if (UserTypeId == (int)EnumUserTypeMaster.Admin)
                {
                    return new FitnessCenterEntities().Users.Where(x => x.isDeleted == false && x.ClubId == ClubId &&
                        (x.UserTypeId == (int)EnumUserTypeMaster.ClubManager ||
                         x.UserTypeId == (int)EnumUserTypeMaster.FitnessManager ||
                         x.UserTypeId == (int)EnumUserTypeMaster.Executive ||
                         x.UserTypeId == (int)EnumUserTypeMaster.Receptionist
                        )).ToList();
                }
                else
                {
                    return new FitnessCenterEntities().Users.Where(x => x.isDeleted == false && x.ClubId == ClubId &&
                   (
                    x.UserTypeId == (int)EnumUserTypeMaster.Executive ||
                    x.UserTypeId == (int)EnumUserTypeMaster.Receptionist
                   )).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserTarget InsertUserTarget(UserTarget objUserTarget)
        {
            try
            {
                objUserTarget.insertDate = DateTime.Now;
                objUserTarget.isActive = true;
                objUserTarget.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserTargets.AddObject(objUserTarget);
                    context.SaveChanges();
                    return objUserTarget;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserTarget UpdateUserTarget(UserTarget objUserTarget)
        {
            try
            {
                objUserTarget.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.UserTargets.Attach(context.UserTargets.Single(varU => varU.ID == objUserTarget.ID));
                    context.UserTargets.ApplyCurrentValues(objUserTarget);

                    context.SaveChanges();

                    return objUserTarget;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserTarget(int ID)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objUserTarget = context.UserTargets.SingleOrDefault(varU => varU.ID == ID);

                    objUserTarget.isDeleted = true;
                    objUserTarget.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLeadTypeByLeadTypeId(long leadTypeId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("delete from UserTargets where leadTypeId={0}", leadTypeId);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAllTargetByUser(long UserId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("delete UserTargets where userid={0}", UserId);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserTargetHard(int UserTargetId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("delete from UserTargets where ID={0}", UserTargetId);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region LeadType

        public static List<LeadTypeMaster> GetLeadType()
        {
            try
            {

                return new FitnessCenterEntities().LeadTypeMasters.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region PagePermissions

        public static List<GetPagePermissions_Result> GetPagePermissions_Result(long UserId)
        {
            try
            {
                return new FitnessCenterEntities().GetPagePermissions(UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AccessMaster InsertAccessMaster(AccessMaster objAccessMaster)
        {
            try
            {
                objAccessMaster.insertDate = DateTime.Now;
                objAccessMaster.isActive = true;
                objAccessMaster.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.AccessMasters.AddObject(objAccessMaster);
                    context.SaveChanges();
                    return objAccessMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AccessMaster UpdateAccessMaster(AccessMaster objAccessMaster)
        {
            try
            {
                objAccessMaster.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.AccessMasters.Attach(context.AccessMasters.Single(varU => varU.ID == objAccessMaster.ID));
                    context.AccessMasters.ApplyCurrentValues(objAccessMaster);

                    context.SaveChanges();

                    return objAccessMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAccessMaster(int AccessMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objAccessMaster = context.AccessMasters.SingleOrDefault(varU => varU.ID == AccessMasterId);

                    objAccessMaster.isDelete = true;
                    objAccessMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAccessMasterByUser(long UserId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("delete from AccessMaster where userid={0}", UserId);
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