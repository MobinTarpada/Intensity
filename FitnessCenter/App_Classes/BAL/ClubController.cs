using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class ClubController
    {
        #region Clubs

        public static Club GetClubsByID(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().Clubs.FirstOrDefault(x => x.isDeleted == false && x.ID == ClubId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetClubs_Result> GetClubs(string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetClubs(SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Club InsertClub(Club objClub)
        {
            try
            {
                objClub.insertDate = DateTime.Now;
                //objClub.isActive = true;
                objClub.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Clubs.AddObject(objClub);
                    context.SaveChanges();
                    return objClub;
                }
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
                objUser.isDeleted = false;

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

        public Club UpdateClub(Club objClub)
        {
            try
            {
                objClub.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.Clubs.Attach(context.Clubs.Single(varC => varC.ID == objClub.ID));
                    context.Clubs.ApplyCurrentValues(objClub);

                    context.SaveChanges();

                    return objClub;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteClub(int ClubId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objClub = context.Clubs.SingleOrDefault(varU => varU.ID == ClubId);

                    objClub.isDeleted = true;
                    objClub.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Users

        public static List<User> GetUsersById()
        {
            try
            {
                return new FitnessCenterEntities().Users.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion


        internal static object GetUsers(long ClubId, long UserId,string SortField, string SortDir)
        {
            throw new NotImplementedException();
        }
        
        #region AccessMaster & PageMaster

        public static List<PageMaster> GetPageMaster()
        {
            try
            {
                return new FitnessCenterEntities().PageMasters.Where(x => x.isActive == true && x.isDeleted == false && x.pageCategoryId == 2).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static List<PageMaster> GetMemberPageMaster()
        {
            try
            {
                return new FitnessCenterEntities().PageMasters.Where(x => x.isActive == true && x.isDeleted == false && x.pageCategoryId == 4).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AccessMaster InsertAccessMaster(AccessMaster objAccess)
        {
            try
            {
                objAccess.insertDate = DateTime.Now;
                objAccess.isActive = true;
                objAccess.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.AccessMasters.AddObject(objAccess);
                    context.SaveChanges();
                    return objAccess;
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