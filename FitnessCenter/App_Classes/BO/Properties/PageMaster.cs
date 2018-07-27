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
    [KnownType(typeof(AccessMaster))]
    public partial class PageMaster
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> pageCategoryId
        {
            get;
            set;
        }
        [DataMember]
        public virtual string pageName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string pageURL
        {
            get;
            set;
        }
        [DataMember]
        public virtual string MenuLI
        {
            get;
            set;
        }
        [DataMember]
        public virtual string MenuLICSSClass
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> moduleId
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
        public virtual Nullable<bool> isActive
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
        public virtual ICollection<AccessMaster> AccessMasters
        {
            get
            {
                if (_accessMasters == null)
                {
                    var newCollection = new FixupCollection<AccessMaster>();
                    newCollection.CollectionChanged += FixupAccessMasters;
                    _accessMasters = newCollection;
                }
                return _accessMasters;
            }
            set
            {
                if (!ReferenceEquals(_accessMasters, value))
                {
                    var previousValue = _accessMasters as FixupCollection<AccessMaster>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAccessMasters;
                    }
                    _accessMasters = value;
                    var newValue = value as FixupCollection<AccessMaster>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAccessMasters;
                    }
                }
            }
        }
        private ICollection<AccessMaster> _accessMasters;

        #endregion

        #region Association Fixup
    
        private void FixupAccessMasters(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (AccessMaster item in e.NewItems)
                {
                    item.PageMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (AccessMaster item in e.OldItems)
                {
                    if (ReferenceEquals(item.PageMaster, this))
                    {
                        item.PageMaster = null;
                    }
                }
            }
        }

        #endregion

    }
}
