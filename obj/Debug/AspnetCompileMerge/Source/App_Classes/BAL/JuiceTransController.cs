using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class JuiceTransController
    {
        #region JuiceTrans
        public static List<GetJuiceTrans_Result> GetJuiceTrans(string SortDir, string SortField, string Rfid, string MemberName)
        {
            try
            {
                return new FitnessCenterEntities().GetJuiceTrans(SortDir, SortField, Rfid, MemberName).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MemberJuiceTransaction> GetJuiceTransByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberJuiceTransactions.Where(x => x.isDeleted == false && x.memberId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MemberJuiceTransaction InsertJuiceTrans(MemberJuiceTransaction objJuiceTrans)
        {
            try
            {
                objJuiceTrans.isDeleted = false;
                objJuiceTrans.insertDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.MemberJuiceTransactions.AddObject(objJuiceTrans);
                    context.SaveChanges();
                    return objJuiceTrans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 

        public MemberJuiceMaster UpdateJuiceRecharge(MemberJuiceMaster objJuice)
        {
            try
            {
                objJuice.updateDate = DateTime.Now;
                using (var context=new FitnessCenterEntities())
                {
                    context.MemberJuiceMasters.Attach(context.MemberJuiceMasters.Single(x => x.ID == objJuice.ID));
                    context.MemberJuiceMasters.ApplyCurrentValues(objJuice);
                    context.SaveChanges();
                    return objJuice;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region JuiceItems
        public  static List<ItemMaster> GetJuiceItems()
        {
            try
            {
                return new FitnessCenterEntities().ItemMasters.Where(x => x.isDeleted == false && x.GroupMaster.code == "000").ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}