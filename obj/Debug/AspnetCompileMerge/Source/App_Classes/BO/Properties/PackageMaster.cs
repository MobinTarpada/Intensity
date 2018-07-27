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
    [KnownType(typeof(Club))]
    [KnownType(typeof(Membership))]
    [KnownType(typeof(UserSchemeMaster))]
    [KnownType(typeof(Payment))]
    public partial class PackageMaster
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long clubId
        {
            get { return _clubId; }
            set
            {
                if (_clubId != value)
                {
                    if (Club != null && Club.ID != value)
                    {
                        Club = null;
                    }
                    _clubId = value;
                }
            }
        }
        private long _clubId;
        [DataMember]
        public virtual string packageName
        {
            get;
            set;
        }
        [DataMember]
        public virtual int durationInMonths
        {
            get;
            set;
        }
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
        public virtual Nullable<decimal> serviceTaxInPercentage
        {
            get;
            set;
        }
        [DataMember]
        public virtual decimal finalAmount
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
        public virtual bool isDeleted
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual Club Club
        {
            get { return _club; }
            set
            {
                if (!ReferenceEquals(_club, value))
                {
                    var previousValue = _club;
                    _club = value;
                    FixupClub(previousValue);
                }
            }
        }
        private Club _club;
        
    
        [DataMember]
        public virtual ICollection<Membership> Memberships
        {
            get
            {
                if (_memberships == null)
                {
                    var newCollection = new FixupCollection<Membership>();
                    newCollection.CollectionChanged += FixupMemberships;
                    _memberships = newCollection;
                }
                return _memberships;
            }
            set
            {
                if (!ReferenceEquals(_memberships, value))
                {
                    var previousValue = _memberships as FixupCollection<Membership>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMemberships;
                    }
                    _memberships = value;
                    var newValue = value as FixupCollection<Membership>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMemberships;
                    }
                }
            }
        }
        private ICollection<Membership> _memberships;
        
    
        [DataMember]
        public virtual ICollection<UserSchemeMaster> UserSchemeMasters
        {
            get
            {
                if (_userSchemeMasters == null)
                {
                    var newCollection = new FixupCollection<UserSchemeMaster>();
                    newCollection.CollectionChanged += FixupUserSchemeMasters;
                    _userSchemeMasters = newCollection;
                }
                return _userSchemeMasters;
            }
            set
            {
                if (!ReferenceEquals(_userSchemeMasters, value))
                {
                    var previousValue = _userSchemeMasters as FixupCollection<UserSchemeMaster>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUserSchemeMasters;
                    }
                    _userSchemeMasters = value;
                    var newValue = value as FixupCollection<UserSchemeMaster>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUserSchemeMasters;
                    }
                }
            }
        }
        private ICollection<UserSchemeMaster> _userSchemeMasters;
        
    
        [DataMember]
        public virtual ICollection<Payment> Payments
        {
            get
            {
                if (_payments == null)
                {
                    var newCollection = new FixupCollection<Payment>();
                    newCollection.CollectionChanged += FixupPayments;
                    _payments = newCollection;
                }
                return _payments;
            }
            set
            {
                if (!ReferenceEquals(_payments, value))
                {
                    var previousValue = _payments as FixupCollection<Payment>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPayments;
                    }
                    _payments = value;
                    var newValue = value as FixupCollection<Payment>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPayments;
                    }
                }
            }
        }
        private ICollection<Payment> _payments;

        #endregion

        #region Association Fixup
    
        private void FixupClub(Club previousValue)
        {
            if (previousValue != null && previousValue.PackageMasters.Contains(this))
            {
                previousValue.PackageMasters.Remove(this);
            }
    
            if (Club != null)
            {
                if (!Club.PackageMasters.Contains(this))
                {
                    Club.PackageMasters.Add(this);
                }
                if (clubId != Club.ID)
                {
                    clubId = Club.ID;
                }
            }
        }
    
        private void FixupMemberships(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Membership item in e.NewItems)
                {
                    item.PackageMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Membership item in e.OldItems)
                {
                    if (ReferenceEquals(item.PackageMaster, this))
                    {
                        item.PackageMaster = null;
                    }
                }
            }
        }
    
        private void FixupUserSchemeMasters(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserSchemeMaster item in e.NewItems)
                {
                    item.PackageMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserSchemeMaster item in e.OldItems)
                {
                    if (ReferenceEquals(item.PackageMaster, this))
                    {
                        item.PackageMaster = null;
                    }
                }
            }
        }
    
        private void FixupPayments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Payment item in e.NewItems)
                {
                    item.PackageMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Payment item in e.OldItems)
                {
                    if (ReferenceEquals(item.PackageMaster, this))
                    {
                        item.PackageMaster = null;
                    }
                }
            }
        }

        #endregion

    }
}
