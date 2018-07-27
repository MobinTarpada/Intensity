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
    [KnownType(typeof(UserSchemeMaster))]
    public partial class CancellationMaster
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long schemeId
        {
            get { return _schemeId; }
            set
            {
                if (_schemeId != value)
                {
                    if (UserSchemeMaster != null && UserSchemeMaster.ID != value)
                    {
                        UserSchemeMaster = null;
                    }
                    _schemeId = value;
                }
            }
        }
        private long _schemeId;
        [DataMember]
        public virtual bool joiningFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool adminFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool membershipFee
        {
            get;
            set;
        }
        [DataMember]
        public virtual bool personalTrainingPack
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
        public virtual UserSchemeMaster UserSchemeMaster
        {
            get { return _userSchemeMaster; }
            set
            {
                if (!ReferenceEquals(_userSchemeMaster, value))
                {
                    var previousValue = _userSchemeMaster;
                    _userSchemeMaster = value;
                    FixupUserSchemeMaster(previousValue);
                }
            }
        }
        private UserSchemeMaster _userSchemeMaster;

        #endregion

        #region Association Fixup
    
        private void FixupUserSchemeMaster(UserSchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.CancellationMasters.Contains(this))
            {
                previousValue.CancellationMasters.Remove(this);
            }
    
            if (UserSchemeMaster != null)
            {
                if (!UserSchemeMaster.CancellationMasters.Contains(this))
                {
                    UserSchemeMaster.CancellationMasters.Add(this);
                }
                if (schemeId != UserSchemeMaster.ID)
                {
                    schemeId = UserSchemeMaster.ID;
                }
            }
        }

        #endregion

    }
}
