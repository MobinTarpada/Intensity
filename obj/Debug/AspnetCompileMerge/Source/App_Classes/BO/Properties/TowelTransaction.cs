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
    [KnownType(typeof(TowelHiringMaster))]
    public partial class TowelTransaction
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long towelHiriningId
        {
            get { return _towelHiriningId; }
            set
            {
                if (_towelHiriningId != value)
                {
                    if (TowelHiringMaster != null && TowelHiringMaster.ID != value)
                    {
                        TowelHiringMaster = null;
                    }
                    _towelHiriningId = value;
                }
            }
        }
        private long _towelHiriningId;
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
        public virtual decimal depositAmount
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool isTowelGiven
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool isTowelReturn
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
        public virtual bool isDeleted
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
        public virtual TowelHiringMaster TowelHiringMaster
        {
            get { return _towelHiringMaster; }
            set
            {
                if (!ReferenceEquals(_towelHiringMaster, value))
                {
                    var previousValue = _towelHiringMaster;
                    _towelHiringMaster = value;
                    FixupTowelHiringMaster(previousValue);
                }
            }
        }
        private TowelHiringMaster _towelHiringMaster;

        #endregion

        #region Association Fixup
    
        private void FixupMembership(Membership previousValue)
        {
            if (previousValue != null && previousValue.TowelTransactions.Contains(this))
            {
                previousValue.TowelTransactions.Remove(this);
            }
    
            if (Membership != null)
            {
                if (!Membership.TowelTransactions.Contains(this))
                {
                    Membership.TowelTransactions.Add(this);
                }
                if (memberId != Membership.ID)
                {
                    memberId = Membership.ID;
                }
            }
        }
    
        private void FixupTowelHiringMaster(TowelHiringMaster previousValue)
        {
            if (previousValue != null && previousValue.TowelTransactions.Contains(this))
            {
                previousValue.TowelTransactions.Remove(this);
            }
    
            if (TowelHiringMaster != null)
            {
                if (!TowelHiringMaster.TowelTransactions.Contains(this))
                {
                    TowelHiringMaster.TowelTransactions.Add(this);
                }
                if (towelHiriningId != TowelHiringMaster.ID)
                {
                    towelHiriningId = TowelHiringMaster.ID;
                }
            }
        }

        #endregion

    }
}
