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
    public partial class GetLeadTargetHeaders_Result
    {
        #region Primitive Properties
        
        [DataMember]
        public long ID
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
        public string FULLNAME
        {
            get;
            set;
        }
        
        [DataMember]
        public string ROLE
        {
            get;
            set;
        }
        
        [DataMember]
        public int TARGETACHIEVED
        {
            get;
            set;
        }
        
        [DataMember]
        public Nullable<int> TARGETCNT
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
        public Nullable<long> CNT
        {
            get;
            set;
        }

        #endregion

    }
}
