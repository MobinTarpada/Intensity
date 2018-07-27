using FitnessCenter.BO;
using FitnessCenter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessCenter.BAL
{
    public class ExpiredMemberHistory
    {
        public static List<GetExpiredMembers_Result> GetExpiredMember(string SearchText,string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetExpiredMembers(SearchText,SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}