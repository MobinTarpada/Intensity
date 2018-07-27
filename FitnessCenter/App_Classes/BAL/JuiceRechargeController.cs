using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class JuiceRechargeController
    {
        public MemberJuiceMaster InsertJuiceRecharge(MemberJuiceMaster objMemberJuice)
        {
            try
            {
                objMemberJuice.insertDate = DateTime.Now;
                objMemberJuice.isDelete = false;
                using (var context=new FitnessCenterEntities())
                {
                    context.MemberJuiceMasters.AddObject(objMemberJuice);
                    context.SaveChanges();
                    return objMemberJuice;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MemberJuiceMaster> GetRechargesByMemberId(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().MemberJuiceMasters.Where(x => x.isDelete == false && x.memberId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MemberJuiceMaster UpdateJuiceRecharge(MemberJuiceMaster objJuiceRecharge)
        {
            try
            {
                objJuiceRecharge.updateDate = DateTime.Now;
                using (var context=new FitnessCenterEntities())
                {
                    context.MemberJuiceMasters.Attach(context.MemberJuiceMasters.Single(x => x.ID == objJuiceRecharge.ID));
                    context.MemberJuiceMasters.ApplyCurrentValues(objJuiceRecharge);
                    context.SaveChanges();
                    return objJuiceRecharge;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}