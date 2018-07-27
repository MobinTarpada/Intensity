using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter.BAL
{
    public class ExerciseController
    {
        #region ExerciseMasters

        public static ExerciseMaster GetExerciseMastersByID(long ExerciseMasterId)
        {
            try
            {

                return new FitnessCenterEntities().ExerciseMasters.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == ExerciseMasterId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetExerciseMaster_Result> GetExerciseMaster_Result(string SearchText, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetExerciseMaster(SearchText, "ID", "DESC", ClubId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExerciseMaster InsertExerciseMaster(ExerciseMaster objExerciseMaster)
        {
            try
            {
                objExerciseMaster.insertDate = DateTime.Now;
                objExerciseMaster.isActive = true;
                objExerciseMaster.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExerciseMasters.AddObject(objExerciseMaster);
                    context.SaveChanges();
                    return objExerciseMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ExerciseMaster UpdateExerciseMaster(ExerciseMaster objExerciseMaster)
        {
            try
            {
                objExerciseMaster.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExerciseMasters.Attach(context.ExerciseMasters.Single(varC => varC.ID == objExerciseMaster.ID));
                    context.ExerciseMasters.ApplyCurrentValues(objExerciseMaster);

                    context.SaveChanges();
                    return objExerciseMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteExerciseMaster(int ExerciseMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objExerciseMaster = context.ExerciseMasters.SingleOrDefault(varU => varU.ID == ExerciseMasterId);

                    objExerciseMaster.isDeleted = true;
                    objExerciseMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region ExerciseCardMasters

        public static ExerciseCardMaster GetExerciseCardMastersByID(long ExerciseCardMasterId)
        {
            try
            {

                return new FitnessCenterEntities().ExerciseCardMasters.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == ExerciseCardMasterId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExerciseCardMaster InsertExerciseCardMaster(ExerciseCardMaster objExerciseCardMaster)
        {
            try
            {
                objExerciseCardMaster.insertDate = DateTime.Now;
                //objExerciseCardMaster.isActive = true;
                objExerciseCardMaster.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExerciseCardMasters.AddObject(objExerciseCardMaster);
                    context.SaveChanges();
                    return objExerciseCardMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ExerciseCardMaster UpdateExerciseCardMaster(ExerciseCardMaster objExerciseCardMaster)
        {
            try
            {
                objExerciseCardMaster.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExerciseCardMasters.Attach(context.ExerciseCardMasters.Single(varC => varC.ID == objExerciseCardMaster.ID));
                    context.ExerciseCardMasters.ApplyCurrentValues(objExerciseCardMaster);

                    context.SaveChanges();

                    return objExerciseCardMaster;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteExerciseCardMaster(int ExerciseCardMasterId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objExerciseCardMaster = context.ExerciseCardMasters.SingleOrDefault(varU => varU.ID == ExerciseCardMasterId);

                    objExerciseCardMaster.isDeleted = true;
                    objExerciseCardMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region ExrciseCardLevelSets

        public static ExrciseCardLevelSet GetExrciseCardLevelSetsByID(long ExrciseCardLevelSetId)
        {
            try
            {

                return new FitnessCenterEntities().ExrciseCardLevelSets.FirstOrDefault(x => x.isDeleted == false && x.ID == ExrciseCardLevelSetId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ExrciseCardLevelSet GetExrciseCardLevelSetsByCardID(long ExrciseCardId)
        {
            try
            {

                return new FitnessCenterEntities().ExrciseCardLevelSets.FirstOrDefault(x => x.isDeleted == false && x.exrciseCardId == ExrciseCardId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ExrciseCardLevelSet> GetExrciseCardLevelSetsByExerciseCardMaterIdAndLevelId(long ExerciseCardMasterId, int LevelId)
        {
            try
            {
                return new FitnessCenterEntities().ExrciseCardLevelSets.Where(x => x.isDeleted == false && x.exrciseCardId == ExerciseCardMasterId && x.levelId == LevelId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ExrciseCardLevelSet> GetExrciseCardLevelSetsByExerciseCardMaterId(long ExerciseCardMasterId)
        {
            try
            {
                return new FitnessCenterEntities().ExrciseCardLevelSets.Where(x => x.isDeleted == false && x.exrciseCardId == ExerciseCardMasterId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExrciseCardLevelSet InsertExrciseCardLevelSet(ExrciseCardLevelSet objExrciseCardLevelSet)
        {
            try
            {
                objExrciseCardLevelSet.insertDate = DateTime.Now;
                //objExrciseCardLevelSet.isActive = true;
                objExrciseCardLevelSet.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExrciseCardLevelSets.AddObject(objExrciseCardLevelSet);
                    context.SaveChanges();
                    return objExrciseCardLevelSet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ExrciseCardLevelSet UpdateExrciseCardLevelSet(ExrciseCardLevelSet objExrciseCardLevelSet)
        {
            try
            {
                objExrciseCardLevelSet.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.ExrciseCardLevelSets.Attach(context.ExrciseCardLevelSets.Single(varC => varC.exrciseCardId == objExrciseCardLevelSet.exrciseCardId));
                    context.ExrciseCardLevelSets.ApplyCurrentValues(objExrciseCardLevelSet);

                    context.SaveChanges();

                    return objExrciseCardLevelSet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteExrciseCardLevelSet(int ExrciseCardLevelSetId, long ExerciseCardId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objExrciseCardLevelSet = context.ExrciseCardLevelSets.SingleOrDefault(varU => varU.ID == ExrciseCardLevelSetId && varU.exrciseCardId == ExerciseCardId);

                    objExrciseCardLevelSet.isDeleted = true;
                    objExrciseCardLevelSet.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteAllExrciseCardLevelSets(long exrciseCardId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("Delete from ExrciseCardLevelSets where exrciseCardId={0}", exrciseCardId);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Assign Exercise
        public static AssignExercise GetAssignExerciseByMembersId(long MemberId)
        {
            try
            {

                return new FitnessCenterEntities().AssignExercises.FirstOrDefault(x => x.isDelete == false && x.isActive == true && x.memberId == MemberId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<GetAssignExercise_Result> GetAssignExercises(string SearchText, string SortField, string SortDir, long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetAssignExercise(SearchText, SortField, SortDir, ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<AssignExercise> GetAssignExrciseByMember(long MemberId)
        {
            try
            {
                return new FitnessCenterEntities().AssignExercises.Where(x => x.memberId == MemberId && x.isDelete == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<GetAssignExerciseByMemberId_Result> GetAssignExerciseByMemberId(long MemberId)
        {
            return new FitnessCenterEntities().GetAssignExerciseByMemberId(MemberId).ToList();
        }
        public static List<GetMembersFromAssignExercise_Result> GetMembersFromAssignExercise(string FullName, long ClubId)
        {
            return new FitnessCenterEntities().GetMembersFromAssignExercise(FullName, ClubId).ToList();
        }

        public AssignExercise InsertAssignExercise(AssignExercise objAssignExercise)
        {
            try
            {
                objAssignExercise.insertDate = DateTime.Now;
                objAssignExercise.isActive = true;
                objAssignExercise.isDelete = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.AssignExercises.AddObject(objAssignExercise);
                    context.SaveChanges();
                    return objAssignExercise;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AssignExercise UpdateAssignExercise(AssignExercise objAssignExercise)
        {
            try
            {
                objAssignExercise.updateDate = DateTime.Now;

                using (var context = new FitnessCenterEntities())
                {
                    context.AssignExercises.Attach(context.AssignExercises.Single(varC => varC.memberId == objAssignExercise.memberId));
                    context.AssignExercises.ApplyCurrentValues(objAssignExercise);

                    context.SaveChanges();
                    return objAssignExercise;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAssignExercise(int MemberId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objExerciseMaster = context.AssignExercises.SingleOrDefault(varU => varU.ID == MemberId);

                    objExerciseMaster.isDelete = true;
                    objExerciseMaster.deleteDate = DateTime.Now;

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteAllAssignExerciseByMemberId(long MemberId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    context.ExecuteStoreCommand("Delete from AssignExercise where memberId={0}", MemberId);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Members

        public static List<GetMembersByLeadID_Result> GetMembersByLeadID(long ClubId)
        {
            try
            {
                return new FitnessCenterEntities().GetMembersByLeadID(ClubId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
        #region  Arobic Non-Arobic ExerciseName
        public static List<GetNonArobicExercise_Result> GetNonArobicExercise(long BodyType, long LevelId, long MemberId, long ClubId)
        {
            return new FitnessCenterEntities().GetNonArobicExercise(BodyType, LevelId, MemberId, ClubId).ToList();
        }
        public static List<GetArobicExercise_Result> GetArobicExercise(long BodyType, long MemberId, long ClubId)
        {
            return new FitnessCenterEntities().GetArobicExercise(BodyType, MemberId, ClubId).ToList();
        }
        #endregion
        #region ArobicExerciseName
        public static List<ExerciseMaster> GetArobicExerciseName()
        {
            return new FitnessCenterEntities().ExerciseMasters.Where(x => x.exerciseTypeId == 1 && x.isActive == true && x.isDeleted == false).ToList();
        }
        #endregion
    }
}