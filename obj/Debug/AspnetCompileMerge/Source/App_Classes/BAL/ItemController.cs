using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class ItemController
    {
        #region Items
        public static List<GetItems_Result> GetItems(string Name, string Code, string SortDir, string SortField, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetItems(Name, Code, SortDir, SortField, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static ItemMaster GetItemsById(long ItemId)
        {
            try
            {
                return new FitnessCenterEntities().ItemMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == ItemId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ItemMaster InsertItems(ItemMaster objItem)
        {
            try
            {
                objItem.insertDate = DateTime.Now;
                objItem.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.ItemMasters.AddObject(objItem);
                    context.SaveChanges();
                    return objItem;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ItemMaster UpdateItems(ItemMaster objItem)
        {
            try
            {
                objItem.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.ItemMasters.Attach(context.ItemMasters.Single(x => x.ID == objItem.ID));
                    context.ItemMasters.ApplyCurrentValues(objItem);
                    context.SaveChanges();
                    return objItem;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteItems(long ItemId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objItem = context.ItemMasters.Single(x => x.ID == ItemId);
                    objItem.deleteDate = DateTime.Now;
                    objItem.isDeleted = true;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsNameExists(string ItemName, long ClubId)
        {
            try
            {
                var objItems = new FitnessCenterEntities().ItemMasters.FirstOrDefault(x => x.isDeleted == false && x.name == ItemName && x.GroupMaster.clubId == ClubId);
                return objItems == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsCodeExists(string ItemCode, long GroupId, long ClubId)
        {
            try
            {
                var objItems = new FitnessCenterEntities().ItemMasters.FirstOrDefault(x => x.isDeleted == false && x.code == ItemCode && x.GroupMaster.clubId == ClubId && x.groupId == GroupId);
                return objItems == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Groups
        public static List<GroupMaster> GetGroups(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GroupMasters.Where(x => x.isDeleted == false && x.clubId == ClubId && x.code != "000").ToList();
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
        #endregion
    }
}