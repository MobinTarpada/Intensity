//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace FitnessCenter.BO
{
    [DataContract(IsReference=true)]
    public partial class GetAssignExercise_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public long ID
        {
            get;
            set;
        }
        
        [DataMember]
        public long memberId
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<int> bodyTypeId
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<int> levelId
        {
            get;
            set;
        }
        
        [DataMember]
        public string set1
        {
            get;
            set;
        }
        
        [DataMember]
        public string set2
        {
            get;
            set;
        }
        
        [DataMember]
        public string set3
        {
            get;
            set;
        }
        
        [DataMember]
        public string set4
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<long> exerciseCardMasterId
        {
            get;
            set;
        }
        
        [DataMember]
        public string duration
        {
            get;
            set;
        }
        
        [DataMember]
        public string RPM
        {
            get;
            set;
        }
        
        [DataMember]
        public string Resistence
        {
            get;
            set;
        }
        
        [DataMember]
        public string Calories
        {
            get;
            set;
        }
        
        [DataMember]
        public string Distance
        {
            get;
            set;
        }
        
        [DataMember]
        public System.DateTime insertDate
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<System.DateTime> updateDate
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<System.DateTime> deleteDate
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<bool> isActive
        {
            get;
            set;
        }
        
        [DataMember]
        public bool isDelete
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<int> exerciseTypeId
        {
            get;
            set;
        }
        
        [DataMember]
        public string exerciseName
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<bool> isPersonalTrainingPackAllow
        {
            get;
            set;
        }
        
        [DataMember]
        public long leadId
        {
            get;
            set;
        }
        
        [DataMember]
        public string firstName
        {
            get;
            set;
        }
        
        [DataMember]
        public string lastName
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<long> SORTDATA
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<long> SORTDATABYORDER
        {
            get;
            set;
        }

        #endregion

    }
}
