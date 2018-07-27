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
    [KnownType(typeof(SchemeMaster))]
    public partial class UpgradeTransaction
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long memberId
        {
            get { return _memberId; }
            set
            {
                if (_memberId != value)
                {
                    if (Membership != null && Membership.ID != value)
                    {
                        Membership = null;
                    }
                    _memberId = value;
                }
            }
        }
        private long _memberId;
        [DataMember]
        public virtual long schemeId
        {
            get { return _schemeId; }
            set
            {
                if (_schemeId != value)
                {
                    if (SchemeMaster != null && SchemeMaster.ID != value)
                    {
                        SchemeMaster = null;
                    }
                    _schemeId = value;
                }
            }
        }
        private long _schemeId;
        [DataMember]
        public virtual decimal diffAmt
        {
            get;
            set;
        }
        [DataMember]
        public virtual decimal paidAmt
        {
            get;
            set;
        }
        [DataMember]
        public virtual decimal remAmt
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
        public virtual bool isPaid
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
        public virtual SchemeMaster SchemeMaster
        {
            get { return _schemeMaster; }
            set
            {
                if (!ReferenceEquals(_schemeMaster, value))
                {
                    var previousValue = _schemeMaster;
                    _schemeMaster = value;
                    FixupSchemeMaster(previousValue);
                }
            }
        }
        private SchemeMaster _schemeMaster;

        #endregion

        #region Association Fixup
    
        private void FixupMembership(Membership previousValue)
        {
            if (previousValue != null && previousValue.UpgradeTransactions.Contains(this))
            {
                previousValue.UpgradeTransactions.Remove(this);
            }
    
            if (Membership != null)
            {
                if (!Membership.UpgradeTransactions.Contains(this))
                {
                    Membership.UpgradeTransactions.Add(this);
                }
                if (memberId != Membership.ID)
                {
                    memberId = Membership.ID;
                }
            }
        }
    
        private void FixupSchemeMaster(SchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.UpgradeTransactions.Contains(this))
            {
                previousValue.UpgradeTransactions.Remove(this);
            }
    
            if (SchemeMaster != null)
            {
                if (!SchemeMaster.UpgradeTransactions.Contains(this))
                {
                    SchemeMaster.UpgradeTransactions.Add(this);
                }
                if (schemeId != SchemeMaster.ID)
                {
                    schemeId = SchemeMaster.ID;
                }
            }
        }

        #endregion

    }
}
