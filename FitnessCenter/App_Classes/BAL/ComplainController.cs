using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class ComplainController
    {
        public static List<GetComplains_Result> GetComplains(string SearchText, string SortField, string SortDir, long ClubId,long UserID)
        {
            try
            {
                return new FitnessCenterEntities().GetComplains(SearchText, SortField, SortDir, ClubId,UserID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ComplainManagement GetComplainById(long Id)
        {
            try
            {
                return new FitnessCenterEntities().ComplainManagements.FirstOrDefault(x => x.isActive == true && x.ID == Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ComplainManagement InsertComplain(ComplainManagement objComplain)
        {
            try
            {
                objComplain.insertDate = DateTime.Now;
                objComplain.isActive = true;


                using (var context = new FitnessCenterEntities())
                {
                    context.ComplainManagements.AddObject(objComplain);
                    context.SaveChanges();
                    return objComplain;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ComplainManagement UpdateComplain(ComplainManagement objComplain)
        {
            try
            {
                objComplain.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.ComplainManagements.Attach(context.ComplainManagements.Single(varL => varL.ID == objComplain.ID));
                    context.ComplainManagements.ApplyCurrentValues(objComplain);

                    context.SaveChanges();
                    return objComplain;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteComplain(int ComplainId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLead = context.ComplainManagements.SingleOrDefault(varL => varL.ID == ComplainId);


                    objLead.isActive = false;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}