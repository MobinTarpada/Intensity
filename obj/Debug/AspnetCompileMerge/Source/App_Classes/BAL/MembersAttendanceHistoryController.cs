using FitnessCenter.BO;
using FitnessCenter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessCenter.BAL
{
    public class MembersAttendanceHistoryController
    {
        #region Member's History

        public static List<GetAbsentMembers_Result> GetAbsentMember( string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetAbsentMembers(SortField,SortDir,FromDate,ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetPresentMembers_Result> GetPresentMember(string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetPresentMembers( SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        #endregion
    }
}