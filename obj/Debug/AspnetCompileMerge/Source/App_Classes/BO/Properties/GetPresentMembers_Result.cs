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
    public partial class GetPresentMembers_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public string RFIDNumber
        {
            get;
            set;
        }
        
        [DataMember]
        public string AgreementNumber
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<System.DateTime> lastCheckInDate
        {
            get;
            set;
        }
        
        [DataMember]
        public string membershipNumber
        {
            get;
            set;
        }
        
        [DataMember]
        public string memberName
        {
            get;
            set;
        }
        
        [DataMember]
        public string MobileNumber
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
