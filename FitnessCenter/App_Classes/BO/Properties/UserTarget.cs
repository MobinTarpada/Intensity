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
    [KnownType(typeof(LeadTypeMaster))]
    [KnownType(typeof(User))]
    public partial class UserTarget
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
        public virtual long userId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (User != null && User.ID != value)
                    {
                        User = null;
                    }
                    _userId = value;
                }
            }
        }
        private long _userId;
        [DataMember]
        public virtual long leadTypeId
        {
            get { return _leadTypeId; }
            set
            {
                if (_leadTypeId != value)
                {
                    if (LeadTypeMaster != null && LeadTypeMaster.ID != value)
                    {
                        LeadTypeMaster = null;
                    }
                    _leadTypeId = value;
                }
            }
        }
        private long _leadTypeId;
        [DataMember]
        public virtual int target
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime fromDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime toDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> targetBy
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> targetUpdateBy
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
        public virtual LeadTypeMaster LeadTypeMaster
        {
            get { return _leadTypeMaster; }
            set
            {
                if (!ReferenceEquals(_leadTypeMaster, value))
                {
                    var previousValue = _leadTypeMaster;
                    _leadTypeMaster = value;
                    FixupLeadTypeMaster(previousValue);
                }
            }
        }
        private LeadTypeMaster _leadTypeMaster;
        
    
        [DataMember]
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private User _user;

        #endregion

        #region Association Fixup
    
        private void FixupClub(Club previousValue)
        {
            if (previousValue != null && previousValue.UserTargets.Contains(this))
            {
                previousValue.UserTargets.Remove(this);
            }
    
            if (Club != null)
            {
                if (!Club.UserTargets.Contains(this))
                {
                    Club.UserTargets.Add(this);
                }
                if (clubId != Club.ID)
                {
                    clubId = Club.ID;
                }
            }
        }
    
        private void FixupLeadTypeMaster(LeadTypeMaster previousValue)
        {
            if (previousValue != null && previousValue.UserTargets.Contains(this))
            {
                previousValue.UserTargets.Remove(this);
            }
    
            if (LeadTypeMaster != null)
            {
                if (!LeadTypeMaster.UserTargets.Contains(this))
                {
                    LeadTypeMaster.UserTargets.Add(this);
                }
                if (leadTypeId != LeadTypeMaster.ID)
                {
                    leadTypeId = LeadTypeMaster.ID;
                }
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.UserTargets.Contains(this))
            {
                previousValue.UserTargets.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.UserTargets.Contains(this))
                {
                    User.UserTargets.Add(this);
                }
                if (userId != User.ID)
                {
                    userId = User.ID;
                }
            }
        }

        #endregion

    }
}
