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
    public partial class GetArobicExercise_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public long ID
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
        public Nullable<int> exerciseTypeId
        {
            get;
            set;
        }
        
        [DataMember]
        public long clubId
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
        public bool isActive
        {
            get;
            set;
        }
        
        [DataMember]
        public bool isDeleted
        {
            get;
            set;
        }
        
        [DataMember]
        public long CardID
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
        public string duration
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
        public string RPM
        {
            get;
            set;
        }

        #endregion

    }
}
