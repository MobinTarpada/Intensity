using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;


namespace FitnessCenter.BAL
{
    public class LeadTypeController
    {
        #region LeadType

        public static bool IsLeadType(string LeadType)
        {
            try
            {
                var objLeadType = new FitnessCenterEntities().LeadTypeMasters.FirstOrDefault(x => x.LeadTypeName == LeadType && x.isDeleted == false);
                return objLeadType == null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static LeadTypeMaster GetLeadTypeByID(long LeadID)
        {
            try
            {
                return new FitnessCenterEntities().LeadTypeMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == LeadID);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static List<LeadTypeMaster> GetLeadTypes(string SearchText, string SortField, string SortDir)
        {
            try
            {
                return new FitnessCenterEntities().GetLeadTypes(SearchText, SortField, SortDir).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public LeadTypeMaster InsertLeadType(LeadTypeMaster ObjLeadType)
        {
            try
            {
                ObjLeadType.insertDate = DateTime.Now;
                ObjLeadType.isActive = true;
                ObjLeadType.isDeleted = false;
                
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadTypeMasters.AddObject(ObjLeadType);
                    context.SaveChanges();
                    return ObjLeadType;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public LeadTypeMaster UpdateLeadType(LeadTypeMaster objLeadType)
        {
            try
            {
                objLeadType.updateDate = DateTime.Now;
                using(var context =new FitnessCenterEntities())
                {
                    context.LeadTypeMasters.Attach(context.LeadTypeMasters.Single(varL => varL.ID == objLeadType.ID));
                    context.LeadTypeMasters.ApplyCurrentValues(objLeadType);

                    context.SaveChanges();
                    return objLeadType;

                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public void DeleteLeadType(int leadTypeId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadType = context.LeadTypeMasters.SingleOrDefault(varL => varL.ID == leadTypeId);

                    objLeadType.isDeleted = true;
                    objLeadType.deleteDate = DateTime.Now;

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