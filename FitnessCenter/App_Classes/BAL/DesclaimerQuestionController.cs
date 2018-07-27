using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.DAL;
using FitnessCenter.BO;

namespace FitnessCenter.BAL
{
    public class DisclaimerQuestionController
    {
        #region DisclaimerQuestionsMaster

        public static DisclaimerQuestionsMaster GetDisclaimerQuestionsMaster(long DisclaimerQuestionsMasterId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionsMasters.FirstOrDefault(x => x.isDeleted == false && x.ID == DisclaimerQuestionsMasterId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DisclaimerQuestionsMaster> GetAllQuestions()
        {
            try
            {

                return new FitnessCenterEntities().DisclaimerQuestionsMasters.Where(x => x.isDeleted == false && x.isActive == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DisclaimerQuestionsMaster InsertDisclaimerQuestionsMaster(DisclaimerQuestionsMaster objDisclaimerQuestionsMaster)
        {
            try
            {
                objDisclaimerQuestionsMaster.insertDate = DateTime.Now;
                objDisclaimerQuestionsMaster.isActive = true;
                objDisclaimerQuestionsMaster.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionsMasters.AddObject(objDisclaimerQuestionsMaster);
                    context.SaveChanges();
                    return objDisclaimerQuestionsMaster;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DisclaimerQuestionsMaster UpdateDisclaimerQuestionsMaster(DisclaimerQuestionsMaster objDisclaimerQuestionsMaster)
        {
            try
            {
                objDisclaimerQuestionsMaster.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionsMasters.Attach(context.DisclaimerQuestionsMasters.Single(varL => varL.ID == objDisclaimerQuestionsMaster.ID));
                    context.DisclaimerQuestionsMasters.ApplyCurrentValues(objDisclaimerQuestionsMaster);

                    context.SaveChanges();
                    return objDisclaimerQuestionsMaster;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteDisclaimerQuestionsMaster(int DisclaimerQuestionsMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objDisclaimerQuestionsMaster = context.DisclaimerQuestionsMasters.SingleOrDefault(varL => varL.ID == DisclaimerQuestionsMasterId);


                    objDisclaimerQuestionsMaster.isDeleted = true;
                    objDisclaimerQuestionsMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region DisclaimerQuestionOption

        public static DisclaimerQuestionOption GetDisclaimerQuestionOptionByID(long OptionId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionOptions.FirstOrDefault(x => x.ID == OptionId && x.isDeleted == false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<DisclaimerQuestionOption> GetDisclaimerQuestionOptionByQuestionId(long QuestionId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionOptions.Where(x => x.isDeleted == false && x.questionId == QuestionId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DisclaimerQuestionOption GetDisclaimerQuestionOption(long DisclaimerQuestionOptionId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionOptions.FirstOrDefault(x => x.isDeleted == false && x.ID == DisclaimerQuestionOptionId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DisclaimerQuestionOption InsertDisclaimerQuestionOption(DisclaimerQuestionOption objDisclaimerQuestionOption)
        {
            try
            {
                objDisclaimerQuestionOption.insertDate = DateTime.Now;
                objDisclaimerQuestionOption.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionOptions.AddObject(objDisclaimerQuestionOption);
                    context.SaveChanges();
                    return objDisclaimerQuestionOption;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DisclaimerQuestionOption UpdateDisclaimerQuestionOption(DisclaimerQuestionOption objDisclaimerQuestionOption)
        {
            try
            {
                objDisclaimerQuestionOption.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionOptions.Attach(context.DisclaimerQuestionOptions.Single(varL => varL.ID == objDisclaimerQuestionOption.ID));
                    context.DisclaimerQuestionOptions.ApplyCurrentValues(objDisclaimerQuestionOption);

                    context.SaveChanges();
                    return objDisclaimerQuestionOption;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteDisclaimerQuestionOption(int DisclaimerQuestionOptionId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objDisclaimerQuestionOption = context.DisclaimerQuestionOptions.SingleOrDefault(varL => varL.ID == DisclaimerQuestionOptionId);


                    objDisclaimerQuestionOption.isDeleted = true;
                    objDisclaimerQuestionOption.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region DisclaimerQuestionAnswers

        public static DisclaimerQuestionAnswer GetDisclaimerQuestionAnswers(long DisclaimerQuestionAnswersId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.ID == DisclaimerQuestionAnswersId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DisclaimerQuestionAnswer GetDisclaimerQuestionAnswerByDisclaimerQuestionAndOptionIDs(long DisclaimerId, long QuestionId, long OptionId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.disclaimerId == DisclaimerId && x.questionId == QuestionId && x.optionId == OptionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DisclaimerQuestionAnswer GetDisclaimerQuestionAnswerByDisclaimerAndQuestionIDs(long DisclaimerId, long QuestionId)
        {
            try
            {
                return new FitnessCenterEntities().DisclaimerQuestionAnswers.FirstOrDefault(x => x.isDeleted == false && x.disclaimerId == DisclaimerId && x.questionId == QuestionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DisclaimerQuestionAnswer InsertDisclaimerQuestionAnswer(DisclaimerQuestionAnswer objDisclaimerQuestionAnswer)
        {
            try
            {
                objDisclaimerQuestionAnswer.insertDate = DateTime.Now;
                objDisclaimerQuestionAnswer.isActive = true;
                objDisclaimerQuestionAnswer.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionAnswers.AddObject(objDisclaimerQuestionAnswer);
                    context.SaveChanges();
                    return objDisclaimerQuestionAnswer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DisclaimerQuestionAnswer UpdateDisclaimerQuestionAnswer(DisclaimerQuestionAnswer objDisclaimerQuestionAnswer)
        {
            try
            {
                objDisclaimerQuestionAnswer.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.DisclaimerQuestionAnswers.Attach(context.DisclaimerQuestionAnswers.Single(varL => varL.ID == objDisclaimerQuestionAnswer.ID));
                    context.DisclaimerQuestionAnswers.ApplyCurrentValues(objDisclaimerQuestionAnswer);

                    context.SaveChanges();
                    return objDisclaimerQuestionAnswer;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteDisclaimerQuestionAnswer(int DisclaimerQuestionAnswerId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objDisclaimerQuestionAnswer = context.DisclaimerQuestionAnswers.SingleOrDefault(varL => varL.ID == DisclaimerQuestionAnswerId);


                    objDisclaimerQuestionAnswer.isDeleted = true;
                    objDisclaimerQuestionAnswer.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteAllDisclaimerQuestionAnswerByDisclaimerId(long DisclaimerId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("Delete from DisclaimerQuestionAnswers where disclaimerId={0}", DisclaimerId);
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