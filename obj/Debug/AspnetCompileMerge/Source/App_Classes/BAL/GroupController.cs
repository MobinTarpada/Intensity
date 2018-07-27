using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;
namespace FitnessCenter.BAL
{
    public class GroupController
    {
        public static List<GroupMaster> GetGroups(string Name, string Code, string SortDir, string SortField)
        {
            try
            {
                return new FitnessCenterEntities().GetGroups(Name, Code, SortDir, SortField).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static GroupMaster GetGroupsByID(long GroupId)
        {
            try
            {
                return new FitnessCenterEntities().GroupMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == GroupId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GroupMaster InsertGroups(GroupMaster objgroup)
        {
            try
            {
                objgroup.insertDate = DateTime.Now;
                objgroup.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.GroupMasters.AddObject(objgroup);
                    context.SaveChanges();
                    return objgroup;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GroupMaster UpdateGroups(GroupMaster objgroup)
        {
            try
            {
                objgroup.updateDate = DateTime.Now;
                using (var context=new FitnessCenterEntities())
                {
                    context.GroupMasters.Attach(context.GroupMasters.Single(x => x.ID == objgroup.ID));
                    context.GroupMasters.ApplyCurrentValues(objgroup);
                    context.SaveChanges();
                    return objgroup;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteGroups(long GroupId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objGroup = context.GroupMasters.Single(x => x.ID == GroupId);
                    objGroup.deleteDate = DateTime.Now;
                    objGroup.isDeleted = true;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsNameExists(string GroupName, long ClubId)
        {
            try
            {
                var objGroups = new FitnessCenterEntities().GroupMasters.FirstOrDefault(x => x.isDeleted == false && x.name == GroupName && x.clubId == ClubId);
                return objGroups == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsCodeExists(string GroupCode, long ClubId)
        {
            try
            {
                var objGroups = new FitnessCenterEntities().GroupMasters.FirstOrDefault(x => x.isDeleted == false && x.code == GroupCode && x.clubId == ClubId);
                return objGroups == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}