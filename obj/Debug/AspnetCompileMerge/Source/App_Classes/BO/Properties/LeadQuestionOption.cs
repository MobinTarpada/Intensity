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
    [KnownType(typeof(LeadQuestionAnswer))]
    [KnownType(typeof(LeadQuestionsMaster))]
    public partial class LeadQuestionOption
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual string options
        {
            get;
            set;
        }
        [DataMember]
        public virtual long questionId
        {
            get { return _questionId; }
            set
            {
                if (_questionId != value)
                {
                    if (LeadQuestionsMaster != null && LeadQuestionsMaster.ID != value)
                    {
                        LeadQuestionsMaster = null;
                    }
                    _questionId = value;
                }
            }
        }
        private long _questionId;
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
        public virtual ICollection<LeadQuestionAnswer> LeadQuestionAnswers
        {
            get
            {
                if (_leadQuestionAnswers == null)
                {
                    var newCollection = new FixupCollection<LeadQuestionAnswer>();
                    newCollection.CollectionChanged += FixupLeadQuestionAnswers;
                    _leadQuestionAnswers = newCollection;
                }
                return _leadQuestionAnswers;
            }
            set
            {
                if (!ReferenceEquals(_leadQuestionAnswers, value))
                {
                    var previousValue = _leadQuestionAnswers as FixupCollection<LeadQuestionAnswer>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLeadQuestionAnswers;
                    }
                    _leadQuestionAnswers = value;
                    var newValue = value as FixupCollection<LeadQuestionAnswer>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLeadQuestionAnswers;
                    }
                }
            }
        }
        private ICollection<LeadQuestionAnswer> _leadQuestionAnswers;
        
    
        [DataMember]
        public virtual LeadQuestionsMaster LeadQuestionsMaster
        {
            get { return _leadQuestionsMaster; }
            set
            {
                if (!ReferenceEquals(_leadQuestionsMaster, value))
                {
                    var previousValue = _leadQuestionsMaster;
                    _leadQuestionsMaster = value;
                    FixupLeadQuestionsMaster(previousValue);
                }
            }
        }
        private LeadQuestionsMaster _leadQuestionsMaster;
        
    
        [DataMember]
        public virtual ICollection<LeadQuestionsMaster> LeadQuestionsMasters
        {
            get
            {
                if (_leadQuestionsMasters == null)
                {
                    var newCollection = new FixupCollection<LeadQuestionsMaster>();
                    newCollection.CollectionChanged += FixupLeadQuestionsMasters;
                    _leadQuestionsMasters = newCollection;
                }
                return _leadQuestionsMasters;
            }
            set
            {
                if (!ReferenceEquals(_leadQuestionsMasters, value))
                {
                    var previousValue = _leadQuestionsMasters as FixupCollection<LeadQuestionsMaster>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLeadQuestionsMasters;
                    }
                    _leadQuestionsMasters = value;
                    var newValue = value as FixupCollection<LeadQuestionsMaster>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLeadQuestionsMasters;
                    }
                }
            }
        }
        private ICollection<LeadQuestionsMaster> _leadQuestionsMasters;

        #endregion

        #region Association Fixup
    
        private void FixupLeadQuestionsMaster(LeadQuestionsMaster previousValue)
        {
            if (previousValue != null && previousValue.LeadQuestionOptions.Contains(this))
            {
                previousValue.LeadQuestionOptions.Remove(this);
            }
    
            if (LeadQuestionsMaster != null)
            {
                if (!LeadQuestionsMaster.LeadQuestionOptions.Contains(this))
                {
                    LeadQuestionsMaster.LeadQuestionOptions.Add(this);
                }
                if (questionId != LeadQuestionsMaster.ID)
                {
                    questionId = LeadQuestionsMaster.ID;
                }
            }
        }
    
        private void FixupLeadQuestionAnswers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LeadQuestionAnswer item in e.NewItems)
                {
                    item.LeadQuestionOption = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LeadQuestionAnswer item in e.OldItems)
                {
                    if (ReferenceEquals(item.LeadQuestionOption, this))
                    {
                        item.LeadQuestionOption = null;
                    }
                }
            }
        }
    
        private void FixupLeadQuestionsMasters(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LeadQuestionsMaster item in e.NewItems)
                {
                    item.LeadQuestionOption = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LeadQuestionsMaster item in e.OldItems)
                {
                    if (ReferenceEquals(item.LeadQuestionOption, this))
                    {
                        item.LeadQuestionOption = null;
                    }
                }
            }
        }

        #endregion

    }
}
