using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessCenter.BO;
using FitnessCenter.DAL;



namespace FitnessCenter.BAL
{
    public class LeadController
    {

        #region Lead
        public static Lead GetLeadById(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().Leads.FirstOrDefault(x =>  x.isActive == true && x.ID == LeadId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Lead> GetLeadsByAgreementNumber()
        {
            try
            {
                return new FitnessCenterEntities().Leads.Where(x => x.isDeleted == false || x.isActive == true || x.isDeleted == true || x.isActive == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public static Lead GetLeadStatusById(long LeadStatusId)
        //{
        //    try
        //    {
        //        return new FitnessCenterEntities().Leads.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.leadStatusId == LeadStatusId);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static List<Lead> GetLeads(long ClubId, string FIRSTNAME, string LASTNAME, string MOBILENO, string DOB, long LEADSTATUS, string SortField, string SortDir, long UserId)
        {
            try
            {
                return new FitnessCenterEntities().GetLeads(ClubId, FIRSTNAME, LASTNAME, MOBILENO, DOB, LEADSTATUS, SortField, SortDir, UserId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool IsLeadExists(string MobileNo)
        {
            try
            {
                var obj = new FitnessCenterEntities().Leads.FirstOrDefault(x => x.isActive == true && x.isDeleted == false &&  x.mobileNumber == MobileNo);
                return obj == null ? false : true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Lead InsertLead(Lead objLead)
        {
            try
            {
                objLead.insertDate = DateTime.Now;
                objLead.isActive = true;
                objLead.isDeleted = false;
                objLead.isTransfer = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.Leads.AddObject(objLead);
                    context.SaveChanges();
                    return objLead;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Lead UpdateLead(Lead objLead)
        {
            try
            {
                objLead.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.Leads.Attach(context.Leads.Single(varL => varL.ID == objLead.ID));
                    context.Leads.ApplyCurrentValues(objLead);

                    context.SaveChanges();
                    return objLead;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLead(int leadId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLead = context.Leads.SingleOrDefault(varL => varL.ID == leadId);


                    objLead.isDeleted = true;
                    objLead.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region LeadType

        public static List<LeadTypeMaster> GetLeadTypes()
        {
            try
            {
                return new FitnessCenterEntities().LeadTypeMasters.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region LeadStatus

        public static List<LeadStatusMaster> GetLeadStatus()
        {
            try
            {
                return new FitnessCenterEntities().LeadStatusMasters.Where(x => x.isDeleted == false).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion


        #region LeadAppointment

        public static LeadAppointment GetLeadAppointmentById(long LeadAppointmentId)
        {
            try
            {
                return new FitnessCenterEntities().LeadAppointments.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == LeadAppointmentId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LeadAppointment> GetLeadAppointmentByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().LeadAppointments.Where(x => x.isDeleted == false && x.isActive == true && x.leadId == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadAppointment InsertLeadAppointment(LeadAppointment objLeadAppointment)
        {
            try
            {
                objLeadAppointment.insertDate = DateTime.Now;
                objLeadAppointment.isActive = true;
                objLeadAppointment.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadAppointments.AddObject(objLeadAppointment);
                    context.SaveChanges();
                    return objLeadAppointment;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadAppointment UpdateLeadAppointment(LeadAppointment objLeadAppointment)
        {
            try
            {
                objLeadAppointment.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadAppointments.Attach(context.LeadAppointments.Single(varL => varL.ID == objLeadAppointment.ID));
                    context.LeadAppointments.ApplyCurrentValues(objLeadAppointment);

                    context.SaveChanges();
                    return objLeadAppointment;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeadAppointment(long LeadAppointmentId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadAppointment = context.LeadAppointments.SingleOrDefault(varL => varL.ID == LeadAppointmentId);


                    objLeadAppointment.isDeleted = true;
                    objLeadAppointment.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region LeadFollowup

        public static LeadFollowup GetLeadFollowupById(long LeadFollowupId)
        {
            try
            {
                return new FitnessCenterEntities().LeadFollowups.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == LeadFollowupId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LeadFollowup> GetLeadFollowupByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().LeadFollowups.Where(x => x.isDeleted == false && x.isActive == true && x.leadId == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadFollowup InsertLeadFollowup(LeadFollowup objLeadFollowup)
        {
            try
            {
                objLeadFollowup.insertDate = DateTime.Now;
                objLeadFollowup.isActive = true;
                objLeadFollowup.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadFollowups.AddObject(objLeadFollowup);
                    context.SaveChanges();
                    return objLeadFollowup;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadFollowup UpdateLeadFollowup(LeadFollowup objLeadFollowup)
        {
            try
            {
                objLeadFollowup.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadFollowups.Attach(context.LeadFollowups.Single(varL => varL.ID == objLeadFollowup.ID));
                    context.LeadFollowups.ApplyCurrentValues(objLeadFollowup);

                    context.SaveChanges();
                    return objLeadFollowup;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeadFollowup(long LeadFollowupId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadFollowup = context.LeadFollowups.SingleOrDefault(varL => varL.ID == LeadFollowupId);


                    objLeadFollowup.isDeleted = true;
                    objLeadFollowup.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region LeadPresentation

        public static LeadPresentation GetLeadPresentationById(long LeadPresentationId)
        {
            try
            {
                return new FitnessCenterEntities().LeadPresentations.FirstOrDefault(x => x.isDeleted == false && x.isActive == true && x.ID == LeadPresentationId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LeadPresentation> GetLeadPresentationByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().LeadPresentations.Where(x => x.isDeleted == false && x.isActive == true && x.leadId == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadPresentation InsertLeadPresentation(LeadPresentation objLeadPresentation)
        {
            try
            {
                objLeadPresentation.insertDate = DateTime.Now;
                objLeadPresentation.isActive = true;
                objLeadPresentation.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadPresentations.AddObject(objLeadPresentation);
                    context.SaveChanges();
                    return objLeadPresentation;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadPresentation UpdateLeadPresentation(LeadPresentation objLeadPresentation)
        {
            try
            {
                objLeadPresentation.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadPresentations.Attach(context.LeadPresentations.Single(varL => varL.ID == objLeadPresentation.ID));
                    context.LeadPresentations.ApplyCurrentValues(objLeadPresentation);

                    context.SaveChanges();
                    return objLeadPresentation;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeadPresentation(long LeadPresentationId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadPresentation = context.LeadPresentations.SingleOrDefault(varL => varL.ID == LeadPresentationId);


                    objLeadPresentation.isDeleted = true;
                    objLeadPresentation.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region LeadTransaction

        public static LeadTransaction GetLeadTransactionById(long LeadTransactionId)
        {
            try
            {
                return new FitnessCenterEntities().LeadTransactions.FirstOrDefault(x => x.isDeleted == false && x.ID == LeadTransactionId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LeadTransaction> GetLeadTransactionByLeadId(long LeadId)
        {
            try
            {
                return new FitnessCenterEntities().LeadTransactions.Where(x => x.isDeleted == false && x.leadId == LeadId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadTransaction InsertLeadTransaction(LeadTransaction objLeadTransaction)
        {
            try
            {
                objLeadTransaction.insertDate = DateTime.Now;
                objLeadTransaction.isDeleted = false;

                using (var context = new FitnessCenterEntities())
                {
                    context.LeadTransactions.AddObject(objLeadTransaction);
                    context.SaveChanges();
                    return objLeadTransaction;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LeadTransaction UpdateLeadTransaction(LeadTransaction objLeadTransaction)
        {
            try
            {
                objLeadTransaction.updateDate = DateTime.Now;
                using (var context = new FitnessCenterEntities())
                {
                    context.LeadTransactions.Attach(context.LeadTransactions.Single(varL => varL.ID == objLeadTransaction.ID));
                    context.LeadTransactions.ApplyCurrentValues(objLeadTransaction);

                    context.SaveChanges();
                    return objLeadTransaction;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeadTransaction(int LeadTransactionId)
        {
            try
            {
                using (var context = new FitnessCenterEntities())
                {
                    var objLeadTransaction = context.LeadTransactions.SingleOrDefault(varL => varL.ID == LeadTransactionId);


                    objLeadTransaction.isDeleted = true;
                    objLeadTransaction.deleteDate = DateTime.Now;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
        #region Membershp
        public static Membership GetMebersByRegistraionNumber(string RegNo)
        {
            try
            {
                return new FitnessCenterEntities().Memberships.FirstOrDefault(x => x.isActive == true && x.membershipUniqueId == RegNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region User
        public static List<User> GetUserForTransfer(long ClubId, long UserId)
        {
            try
            {
                return new FitnessCenterEntities().Users.Where(x => x.isActive == true && x.isDeleted == false && x.clubId == ClubId && x.ID != UserId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }

}