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
    public partial class GetLeadHistoryByDates_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public string CurrentStatus
        {
            get;
            set;
        }
        
        [DataMember]
        public string PreviousStatus
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
        public Nullable<System.DateTime> insertDate
        {
            get;
            set;
        }

        #endregion

    }
}
