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
    public partial class GetUserTargetsByUserId_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public long leadTypeId
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<int> CNT
        {
            get;
            set;
        }
        
        [DataMember]
        public System.DateTime fromDate
        {
            get;
            set;
        }
        
        [DataMember]
        public System.DateTime toDate
        {
            get;
            set;
        }
        
        [DataMember]
        public long userId
        {
            get;
            set;
        }
        
        [DataMember]
        public string leadType
        {
            get;
            set;
        }

        #endregion

    }
}
