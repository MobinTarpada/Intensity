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
    [KnownType(typeof(LeadTransaction))]
    [KnownType(typeof(Lead))]
    public partial class LeadStatusMaster
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual string status
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
        public virtual ICollection<LeadTransaction> LeadTransactions
        {
            get
            {
                if (_leadTransactions == null)
                {
                    var newCollection = new FixupCollection<LeadTransaction>();
                    newCollection.CollectionChanged += FixupLeadTransactions;
                    _leadTransactions = newCollection;
                }
                return _leadTransactions;
            }
            set
            {
                if (!ReferenceEquals(_leadTransactions, value))
                {
                    var previousValue = _leadTransactions as FixupCollection<LeadTransaction>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLeadTransactions;
                    }
                    _leadTransactions = value;
                    var newValue = value as FixupCollection<LeadTransaction>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLeadTransactions;
                    }
                }
            }
        }
        private ICollection<LeadTransaction> _leadTransactions;
        
    
        [DataMember]
        public virtual ICollection<LeadTransaction> LeadTransactions1
        {
            get
            {
                if (_leadTransactions1 == null)
                {
                    var newCollection = new FixupCollection<LeadTransaction>();
                    newCollection.CollectionChanged += FixupLeadTransactions1;
                    _leadTransactions1 = newCollection;
                }
                return _leadTransactions1;
            }
            set
            {
                if (!ReferenceEquals(_leadTransactions1, value))
                {
                    var previousValue = _leadTransactions1 as FixupCollection<LeadTransaction>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLeadTransactions1;
                    }
                    _leadTransactions1 = value;
                    var newValue = value as FixupCollection<LeadTransaction>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLeadTransactions1;
                    }
                }
            }
        }
        private ICollection<LeadTransaction> _leadTransactions1;
        
    
        [DataMember]
        public virtual ICollection<Lead> Leads
        {
            get
            {
                if (_leads == null)
                {
                    var newCollection = new FixupCollection<Lead>();
                    newCollection.CollectionChanged += FixupLeads;
                    _leads = newCollection;
                }
                return _leads;
            }
            set
            {
                if (!ReferenceEquals(_leads, value))
                {
                    var previousValue = _leads as FixupCollection<Lead>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLeads;
                    }
                    _leads = value;
                    var newValue = value as FixupCollection<Lead>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLeads;
                    }
                }
            }
        }
        private ICollection<Lead> _leads;

        #endregion

        #region Association Fixup
    
        private void FixupLeadTransactions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LeadTransaction item in e.NewItems)
                {
                    item.LeadStatusMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LeadTransaction item in e.OldItems)
                {
                    if (ReferenceEquals(item.LeadStatusMaster, this))
                    {
                        item.LeadStatusMaster = null;
                    }
                }
            }
        }
    
        private void FixupLeadTransactions1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LeadTransaction item in e.NewItems)
                {
                    item.LeadStatusMaster1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LeadTransaction item in e.OldItems)
                {
                    if (ReferenceEquals(item.LeadStatusMaster1, this))
                    {
                        item.LeadStatusMaster1 = null;
                    }
                }
            }
        }
    
        private void FixupLeads(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Lead item in e.NewItems)
                {
                    item.LeadStatusMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Lead item in e.OldItems)
                {
                    if (ReferenceEquals(item.LeadStatusMaster, this))
                    {
                        item.LeadStatusMaster = null;
                    }
                }
            }
        }

        #endregion

    }
}
