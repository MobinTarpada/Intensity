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
    public partial class GetClubs_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public long ID
        {
            get;
            set;
        }
        
        [DataMember]
        public string clubName
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<System.DateTime> startDate
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<System.DateTime> endDate
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
        public string email
        {
            get;
            set;
        }
        
        [DataMember]
        public string mobileNumber
        {
            get;
            set;
        }
        
        [DataMember]
        public string address
        {
            get;
            set;
        }
        
        [DataMember]
        public long UserId
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
