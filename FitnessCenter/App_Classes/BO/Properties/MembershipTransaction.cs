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
    [KnownType(typeof(Lead))]
    [KnownType(typeof(Membership))]
    [KnownType(typeof(SchemeMaster))]
    public partial class MembershipTransaction
    {
        #region Primitive Properties
        [DataMember]
        public virtual long Id
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> LeadId
        {
            get { return _leadId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_leadId != value)
                    {
                        if (Lead != null && Lead.ID != value)
                        {
                            Lead = null;
                        }
                        _leadId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _leadId;
        [DataMember]
        public virtual Nullable<long> MembershipId
        {
            get { return _membershipId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_membershipId != value)
                    {
                        if (Membership != null && Membership.ID != value)
                        {
                            Membership = null;
                        }
                        _membershipId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _membershipId;
        [DataMember]
        public virtual string MembershipNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual string RFIDNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> TransType
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> TransDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual string PrevAgreementNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> PrevPackageId
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> PrevSchemeId
        {
            get { return _prevSchemeId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_prevSchemeId != value)
                    {
                        if (SchemeMaster1 != null && SchemeMaster1.ID != value)
                        {
                            SchemeMaster1 = null;
                        }
                        _prevSchemeId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _prevSchemeId;
        [DataMember]
        public virtual Nullable<System.DateTime> FreezeDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> UnFreezeDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual string CurAgrementNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> CurPackageId
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> CurSchemeId
        {
            get { return _curSchemeId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_curSchemeId != value)
                    {
                        if (SchemeMaster != null && SchemeMaster.ID != value)
                        {
                            SchemeMaster = null;
                        }
                        _curSchemeId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _curSchemeId;
        [DataMember]
        public virtual string Remarks
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> InsertDate
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual Lead Lead
        {
            get { return _lead; }
            set
            {
                if (!ReferenceEquals(_lead, value))
                {
                    var previousValue = _lead;
                    _lead = value;
                    FixupLead(previousValue);
                }
            }
        }
        private Lead _lead;
        
    
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
        
    
        [DataMember]
        public virtual SchemeMaster SchemeMaster1
        {
            get { return _schemeMaster1; }
            set
            {
                if (!ReferenceEquals(_schemeMaster1, value))
                {
                    var previousValue = _schemeMaster1;
                    _schemeMaster1 = value;
                    FixupSchemeMaster1(previousValue);
                }
            }
        }
        private SchemeMaster _schemeMaster1;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupLead(Lead previousValue)
        {
            if (previousValue != null && previousValue.MembershipTransactions.Contains(this))
            {
                previousValue.MembershipTransactions.Remove(this);
            }
    
            if (Lead != null)
            {
                if (!Lead.MembershipTransactions.Contains(this))
                {
                    Lead.MembershipTransactions.Add(this);
                }
                if (LeadId != Lead.ID)
                {
                    LeadId = Lead.ID;
                }
            }
            else if (!_settingFK)
            {
                LeadId = null;
            }
        }
    
        private void FixupMembership(Membership previousValue)
        {
            if (previousValue != null && previousValue.MembershipTransactions.Contains(this))
            {
                previousValue.MembershipTransactions.Remove(this);
            }
    
            if (Membership != null)
            {
                if (!Membership.MembershipTransactions.Contains(this))
                {
                    Membership.MembershipTransactions.Add(this);
                }
                if (MembershipId != Membership.ID)
                {
                    MembershipId = Membership.ID;
                }
            }
            else if (!_settingFK)
            {
                MembershipId = null;
            }
        }
    
        private void FixupSchemeMaster(SchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.MembershipTransactions.Contains(this))
            {
                previousValue.MembershipTransactions.Remove(this);
            }
    
            if (SchemeMaster != null)
            {
                if (!SchemeMaster.MembershipTransactions.Contains(this))
                {
                    SchemeMaster.MembershipTransactions.Add(this);
                }
                if (CurSchemeId != SchemeMaster.ID)
                {
                    CurSchemeId = SchemeMaster.ID;
                }
            }
            else if (!_settingFK)
            {
                CurSchemeId = null;
            }
        }
    
        private void FixupSchemeMaster1(SchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.MembershipTransactions1.Contains(this))
            {
                previousValue.MembershipTransactions1.Remove(this);
            }
    
            if (SchemeMaster1 != null)
            {
                if (!SchemeMaster1.MembershipTransactions1.Contains(this))
                {
                    SchemeMaster1.MembershipTransactions1.Add(this);
                }
                if (PrevSchemeId != SchemeMaster1.ID)
                {
                    PrevSchemeId = SchemeMaster1.ID;
                }
            }
            else if (!_settingFK)
            {
                PrevSchemeId = null;
            }
        }

        #endregion

    }
}
