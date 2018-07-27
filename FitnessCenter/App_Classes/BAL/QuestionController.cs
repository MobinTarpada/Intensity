using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class QuestionController
    {
        #region LeadQuestionsMaster

        public static LeadQuestionsMaster GetLeadQuestionsMaster(long LeadQuestionsMasterId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionsMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == LeadQuestionsMasterId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<LeadQuestionsMaster> GetAllQuestions()
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionsMasters.Where(x => x.isDeleted == false && x.isActive == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LeadQuestionsMaster InsertLeadQuestionsMaster(LeadQuestionsMaster objLeadQuestionsMaster)
        {
            try
            {
                objLeadQuestionsMaster.insertDate = DateTime.Now;
                objLeadQuestionsMaster.isActive = true;
                objLeadQuestionsMaster.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionsMasters.AddObject(objLeadQuestionsMaster);
                    context.SaveChanges();
                    return objLeadQuestionsMaster;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public LeadQuestionsMaster UpdateLeadQuestionsMaster(LeadQuestionsMaster objLeadQuestionsMaster)
        {
            try
            {
                objLeadQuestionsMaster.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionsMasters.Attach(context.LeadQuestionsMasters.Single(varL => varL.ID == objLeadQuestionsMaster.ID));
                    context.LeadQuestionsMasters.ApplyCurrentValues(objLeadQuestionsMaster);

                    context.SaveChanges();
                    return objLeadQuestionsMaster;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteLeadQuestionsMaster(int LeadQuestionsMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadQuestionsMaster = context.LeadQuestionsMasters.SingleOrDefault(varL => varL.ID == LeadQuestionsMasterId);


                    objLeadQuestionsMaster.isDeleted = true;
                    objLeadQuestionsMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region LeadQuestionOption

        public static LeadQuestionOption GetLeadQuestionOptionByID(long OptionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionOptions.FirstOrDefault(x => x.ID == OptionId && x.isDeleted == false);
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }


        public static List<LeadQuestionOption> GetLeadQuestionOptionByQuestionId(long QuestionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionOptions.Where(x => x.isDeleted == false && x.questionId == QuestionId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static LeadQuestionOption GetLeadQuestionOption(long LeadQuestionOptionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionOptions.FirstOrDefault(x => x.isDeleted == false && x.ID == LeadQuestionOptionId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LeadQuestionOption InsertLeadQuestionOption(LeadQuestionOption objLeadQuestionOption)
        {
            try
            {
                objLeadQuestionOption.insertDate = DateTime.Now;
                objLeadQuestionOption.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionOptions.AddObject(objLeadQuestionOption);
                    context.SaveChanges();
                    return objLeadQuestionOption;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public LeadQuestionOption UpdateLeadQuestionOption(LeadQuestionOption objLeadQuestionOption)
        {
            try
            {
                objLeadQuestionOption.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionOptions.Attach(context.LeadQuestionOptions.Single(varL => varL.ID == objLeadQuestionOption.ID));
                    context.LeadQuestionOptions.ApplyCurrentValues(objLeadQuestionOption);

                    context.SaveChanges();
                    return objLeadQuestionOption;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteLeadQuestionOption(int LeadQuestionOptionId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadQuestionOption = context.LeadQuestionOptions.SingleOrDefault(varL => varL.ID == LeadQuestionOptionId);


                    objLeadQuestionOption.isDeleted = true;
                    objLeadQuestionOption.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region LeadQuestionAnswers

        public static LeadQuestionAnswer GetLeadQuestionAnswers(long LeadQuestionAnswersId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.ID == LeadQuestionAnswersId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static LeadQuestionAnswer GetLeadQuestionAnswerByLeadQuestionAndOptionIDs(long LeadId, long QuestionId, long OptionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.leadId == LeadId && x.questionId == QuestionId && x.optionId == OptionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LeadQuestionAnswer GetLeadQuestionAnswerByLeadAndQuestionIDs(long LeadId, long QuestionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.leadId == LeadId && x.questionId == QuestionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LeadQuestionAnswer InsertLeadQuestionAnswer(LeadQuestionAnswer objLeadQuestionAnswer)
        {
            try
            {
                objLeadQuestionAnswer.insertDate = DateTime.Now;
                objLeadQuestionAnswer.isActive = true;
                objLeadQuestionAnswer.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionAnswers.AddObject(objLeadQuestionAnswer);
                    context.SaveChanges();
                    return objLeadQuestionAnswer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadQuestionAnswer UpdateLeadQuestionAnswer(LeadQuestionAnswer objLeadQuestionAnswer)
        {
            try
            {
                objLeadQuestionAnswer.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadQuestionAnswers.Attach(context.LeadQuestionAnswers.Single(varL => varL.ID == objLeadQuestionAnswer.ID));
                    context.LeadQuestionAnswers.ApplyCurrentValues(objLeadQuestionAnswer);

                    context.SaveChanges();
                    return objLeadQuestionAnswer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeadQuestionAnswer(int LeadQuestionAnswerId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadQuestionAnswer = context.LeadQuestionAnswers.SingleOrDefault(varL => varL.ID == LeadQuestionAnswerId);


                    objLeadQuestionAnswer.isDeleted = true;
                    objLeadQuestionAnswer.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteAllLeadQuestionAnswerByLeadId(long LeadId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("Delete from LeadQuestionAnswers where leadId={0}", LeadId);
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