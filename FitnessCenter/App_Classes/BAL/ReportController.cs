using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class ReportController
    {

        public static List<GetPackageandSchemeWiseReport_Result> GetPkgnScmReport(long ClubId, long SrchPackageId, long SrchSchemeID, string FromDate, string ToDate)
        {
            try
            {
                return new FitnessCenterEntities().GetPackageandSchemeWiseReport(ClubId, SrchPackageId, SrchSchemeID, FromDate, ToDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Lead> GetRefrrelsmember(string MemberId)
        {
            try
            {
                return new FitnessCenterEntities().Leads.Where(x => x.memberShipId == MemberId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetSchemeAnalysis_Result> GetPkgnScmAnlysis(long SrchPackageId, long SrchSchemeID, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetSchemeAnalysis(SrchPackageId, SrchSchemeID, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetDongrdSchemeAnalysis_Result> GetDowngrdScmAnlysis(long SrchPackageId, long SrchSchemeID, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetDongrdSchemeAnalysis(SrchPackageId, SrchSchemeID, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<GetCancelSchemeAnalysis_Result> GetCamcelScmAnlysis(long SrchPackageId, long SrchSchemeID, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetCancelSchemeAnalysis(SrchPackageId, SrchSchemeID, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<GetFreezeSchemeAnalysis_Result> GetFreezeScmAnlysis(long SrchPackageId, long SrchSchemeID, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetFreezeSchemeAnalysis(SrchPackageId, SrchSchemeID, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}