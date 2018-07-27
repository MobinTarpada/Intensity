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

        public static List<GetAbsentMembers_Result> GetAbsentMember(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetAbsentMembers(Searchtext, SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<GetAbsentEmployee_Result> GetAbsentEmployee(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetAbsentEmployee(Searchtext, SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetPresentMembers_Result> GetPresentMember(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetPresentMembers(Searchtext, SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<GetPresentEmployee_Result> GetPresentEmployee(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetPresentEmployee(Searchtext, SortField, SortDir, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetPresentMembersByID_Result> GetPresentMemberById(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate, long memberId)
        {
            try
            {
                return new FitnessCenterEntities().GetPresentMembersByID(Searchtext, SortField, SortDir, FromDate, ToDate, memberId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<GetAbsentMembersByID_Result> GetAbsentMemberById(string Searchtext, string SortField, string SortDir, string FromDate, string ToDate, long memberId)
        {
            try
            {
                return new FitnessCenterEntities().GetAbsentMembersByID(Searchtext, SortField, SortDir, FromDate, ToDate, memberId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}