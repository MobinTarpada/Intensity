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
    [KnownType(typeof(Membership))]
    [KnownType(typeof(UserSchemeMaster))]
    public partial class CancellationTransaction
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long schemeId
        {
            get { return _schemeId; }
            set
            {
                if (_schemeId != value)
                {
                    if (UserSchemeMaster != null && UserSchemeMaster.ID != value)
                    {
                        UserSchemeMaster = null;
                    }
                    _schemeId = value;
                }
            }
        }
        private long _schemeId;
        [DataMember]
        public virtual long membershipId
        {
            get { return _membershipId; }
            set
            {
                if (_membershipId != value)
                {
                    if (Membership != null && Membership.ID != value)
                    {
                        Membership = null;
                    }
                    _membershipId = value;
                }
            }
        }
        private long _membershipId;
        [DataMember]
        public virtual Nullable<decimal> joiningFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> adminFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> membershipFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> personalTrainingPack
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> payMode
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> chequeDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual string chequeNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual string bankName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string branchDetails
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool isReturn
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime insertDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> updateDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> deleteDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool isActive
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool isDelete
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual Membership Membership
        {
            get { return _membership; }
            set
            {
                if (!ReferenceEquals(_membership, value))
                {
                    var previousValue = _membership;
                    _membership = value;
                    FixupMembership(previousValue);
                }
            }
        }
        private Membership _membership;
        
    
        [DataMember]
        public virtual UserSchemeMaster UserSchemeMaster
        {
            get { return _userSchemeMaster; }
            set
            {
                if (!ReferenceEquals(_userSchemeMaster, value))
                {
                    var previousValue = _userSchemeMaster;
                    _userSchemeMaster = value;
                    FixupUserSchemeMaster(previousValue);
                }
            }
        }
        private UserSchemeMaster _userSchemeMaster;

        #endregion

        #region Association Fixup
    
        private void FixupMembership(Membership previousValue)
        {
            if (previousValue != null && previousValue.CancellationTransactions.Contains(this))
            {
                previousValue.CancellationTransactions.Remove(this);
            }
    
            if (Membership != null)
            {
                if (!Membership.CancellationTransactions.Contains(this))
                {
                    Membership.CancellationTransactions.Add(this);
                }
                if (membershipId != Membership.ID)
                {
                    membershipId = Membership.ID;
                }
            }
        }
    
        private void FixupUserSchemeMaster(UserSchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.CancellationTransactions.Contains(this))
            {
                previousValue.CancellationTransactions.Remove(this);
            }
    
            if (UserSchemeMaster != null)
            {
                if (!UserSchemeMaster.CancellationTransactions.Contains(this))
                {
                    UserSchemeMaster.CancellationTransactions.Add(this);
                }
                if (schemeId != UserSchemeMaster.ID)
                {
                    schemeId = UserSchemeMaster.ID;
                }
            }
        }

        #endregion

    }
}
