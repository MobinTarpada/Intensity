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
    [DataContract(IsReference = true)]
    public partial class FreeTrial
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual string FullName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Email
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Contact
        {
            get;
            set;
        }
        [DataMember]
        public virtual string TrialMessage
        {
            get;
            set;
        }
        [DataMember]
        public virtual string FitnessGoal
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime insertedDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> TrialDate
        {
            get;
            set;
        }

        #endregion

    }
}
