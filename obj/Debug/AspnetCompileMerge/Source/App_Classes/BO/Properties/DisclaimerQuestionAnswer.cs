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
    [KnownType(typeof(DisclaimerQuestionOption))]
    [KnownType(typeof(DisclaimerQuestionsMaster))]
    public partial class DisclaimerQuestionAnswer
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long disclaimerId
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
                try
                {
                    _settingFK = true;
                    if (_questionId != value)
                    {
                        if (DisclaimerQuestionsMaster != null && DisclaimerQuestionsMaster.ID != value)
                        {
                            DisclaimerQuestionsMaster = null;
                        }
                        _questionId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private long _questionId;
        [DataMember]
        public virtual Nullable<long> optionId
        {
            get { return _optionId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_optionId != value)
                    {
                        if (DisclaimerQuestionOption != null && DisclaimerQuestionOption.ID != value)
                        {
                            DisclaimerQuestionOption = null;
                        }
                        _optionId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _optionId;
        [DataMember]
        public virtual string answerText
        {
            get;
            set;
        }
        [DataMember]
        public virtual string comment
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
        public virtual DisclaimerQuestionOption DisclaimerQuestionOption
        {
            get { return _disclaimerQuestionOption; }
            set
            {
                if (!ReferenceEquals(_disclaimerQuestionOption, value))
                {
                    var previousValue = _disclaimerQuestionOption;
                    _disclaimerQuestionOption = value;
                    FixupDisclaimerQuestionOption(previousValue);
                }
            }
        }
        private DisclaimerQuestionOption _disclaimerQuestionOption;
        
    
        [DataMember]
        public virtual DisclaimerQuestionsMaster DisclaimerQuestionsMaster
        {
            get { return _disclaimerQuestionsMaster; }
            set
            {
                if (!ReferenceEquals(_disclaimerQuestionsMaster, value))
                {
                    var previousValue = _disclaimerQuestionsMaster;
                    _disclaimerQuestionsMaster = value;
                    FixupDisclaimerQuestionsMaster(previousValue);
                }
            }
        }
        private DisclaimerQuestionsMaster _disclaimerQuestionsMaster;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupDisclaimerQuestionOption(DisclaimerQuestionOption previousValue)
        {
            if (previousValue != null && previousValue.DisclaimerQuestionAnswers.Contains(this))
            {
                previousValue.DisclaimerQuestionAnswers.Remove(this);
            }
    
            if (DisclaimerQuestionOption != null)
            {
                if (!DisclaimerQuestionOption.DisclaimerQuestionAnswers.Contains(this))
                {
                    DisclaimerQuestionOption.DisclaimerQuestionAnswers.Add(this);
                }
                if (optionId != DisclaimerQuestionOption.ID)
                {
                    optionId = DisclaimerQuestionOption.ID;
                }
            }
            else if (!_settingFK)
            {
                optionId = null;
            }
        }
    
        private void FixupDisclaimerQuestionsMaster(DisclaimerQuestionsMaster previousValue)
        {
            if (previousValue != null && previousValue.DisclaimerQuestionAnswers.Contains(this))
            {
                previousValue.DisclaimerQuestionAnswers.Remove(this);
            }
    
            if (DisclaimerQuestionsMaster != null)
            {
                if (!DisclaimerQuestionsMaster.DisclaimerQuestionAnswers.Contains(this))
                {
                    DisclaimerQuestionsMaster.DisclaimerQuestionAnswers.Add(this);
                }
                if (questionId != DisclaimerQuestionsMaster.ID)
                {
                    questionId = DisclaimerQuestionsMaster.ID;
                }
            }
        }

        #endregion

    }
}
