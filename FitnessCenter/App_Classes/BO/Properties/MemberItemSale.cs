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
    [KnownType(typeof(ItemMaster))]
    [KnownType(typeof(Membership))]
    public partial class MemberItemSale
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long itemId
        {
            get { return _itemId; }
            set
            {
                if (_itemId != value)
                {
                    if (ItemMaster != null && ItemMaster.ID != value)
                    {
                        ItemMaster = null;
                    }
                    _itemId = value;
                }
            }
        }
        private long _itemId;
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
        public virtual int quantity
        {
            get;
            set;
        }
        [DataMember]
        public virtual decimal amount
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> totalAmount
        {
            get;
            set;
        }
        [DataMember]
        public virtual long memberFinalSaleID
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
        public virtual ItemMaster ItemMaster
        {
            get { return _itemMaster; }
            set
            {
                if (!ReferenceEquals(_itemMaster, value))
                {
                    var previousValue = _itemMaster;
                    _itemMaster = value;
                    FixupItemMaster(previousValue);
                }
            }
        }
        private ItemMaster _itemMaster;
        
    
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

        #endregion

        #region Association Fixup
    
        private void FixupItemMaster(ItemMaster previousValue)
        {
            if (previousValue != null && previousValue.MemberItemSales.Contains(this))
            {
                previousValue.MemberItemSales.Remove(this);
            }
    
            if (ItemMaster != null)
            {
                if (!ItemMaster.MemberItemSales.Contains(this))
                {
                    ItemMaster.MemberItemSales.Add(this);
                }
                if (itemId != ItemMaster.ID)
                {
                    itemId = ItemMaster.ID;
                }
            }
        }
    
        private void FixupMembership(Membership previousValue)
        {
            if (previousValue != null && previousValue.MemberItemSales.Contains(this))
            {
                previousValue.MemberItemSales.Remove(this);
            }
    
            if (Membership != null)
            {
                if (!Membership.MemberItemSales.Contains(this))
                {
                    Membership.MemberItemSales.Add(this);
                }
                if (memberId != Membership.ID)
                {
                    memberId = Membership.ID;
                }
            }
        }

        #endregion

    }
}
