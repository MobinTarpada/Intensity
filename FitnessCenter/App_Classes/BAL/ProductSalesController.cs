using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class ProductSalesController
    {
        #region ProductSales
        public static List<GetProductSales_Result> GetProductSales(string SortDir, string SortField, string Rfid, string MemberName, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetProductSales(SortDir, SortField, Rfid, MemberName, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MemberItemSale> GetProductSalesByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberItemSales.Where(x => x.isDeleted == false && x.memberId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MemberItemSale> GetProductSalesByFinalSalesId(long MemberFinalSalesId)
        {
            try
            {
                return new FitnessCenterEntities().MemberItemSales.Where(x => x.isDeleted == false && x.memberFinalSaleID == MemberFinalSalesId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MemberItemSale InsertProductSale(MemberItemSale objSales)
        {
            try
            {
                objSales.insertDate = DateTime.Now;
                objSales.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.MemberItemSales.AddObject(objSales);
                    context.SaveChanges();
                    return objSales;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Items
        public static List<ItemMaster> GetItems()
        {
            try
            {
                return new FitnessCenterEntities().ItemMasters.Where(x => x.isDeleted == false && x.GroupMaster.code != "000").ToList();
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
        #endregion

        #region Members
        public static Membership GetMembersByRfid(string RfidNo)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.RFIDCardNumber == RfidNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region TotalSales

        public MemberItemTotalSale InsertTotalSales(MemberItemTotalSale objTotalSales)
        {
            try
            {
                objTotalSales.insertDate = DateTime.Now;
                objTotalSales.isDeleted = false;
                using (var context = new FitnessCenterEntities())
                {
                    context.MemberItemTotalSales.AddObject(objTotalSales);
                    context.SaveChanges();
                    return objTotalSales;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static MemberItemTotalSale GetTotalSalesbyMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberItemTotalSales.FirstOrDefault(x => x.isDeleted == false && x.memberId == MemberId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MemberItemTotalSale UpdateTotalSale(MemberItemTotalSale objTotalSales)
        {
            try
            {
                objTotalSales.updateDate = DateTime.Now;
                using (var context=new FitnessCenterEntities())
                {
                    context.MemberItemTotalSales.Attach(context.MemberItemTotalSales.Single(x => x.ID == objTotalSales.ID));
                    context.MemberItemTotalSales.ApplyCurrentValues(objTotalSales);
                    context.SaveChanges();
                    return objTotalSales;
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