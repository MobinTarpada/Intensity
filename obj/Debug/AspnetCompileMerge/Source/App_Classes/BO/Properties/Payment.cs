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
    [KnownType(typeof(Lead))]
    [KnownType(typeof(PackageMaster))]
    [KnownType(typeof(UserSchemeMaster))]
    public partial class Payment
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual long leadId
        {
            get { return _leadId; }
            set
            {
                if (_leadId != value)
                {
                    if (Lead != null && Lead.ID != value)
                    {
                        Lead = null;
                    }
                    _leadId = value;
                }
            }
        }
        private long _leadId;
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
        public virtual long packageTypeId
        {
            get { return _packageTypeId; }
            set
            {
                if (_packageTypeId != value)
                {
                    if (PackageMaster != null && PackageMaster.ID != value)
                    {
                        PackageMaster = null;
                    }
                    _packageTypeId = value;
                }
            }
        }
        private long _packageTypeId;
        [DataMember]
        public virtual Nullable<decimal> packageAmount
        {
            get;
            set;
        }
        [DataMember]
        public virtual long schemeID
        {
            get { return _schemeID; }
            set
            {
                if (_schemeID != value)
                {
                    if (UserSchemeMaster != null && UserSchemeMaster.ID != value)
                    {
                        UserSchemeMaster = null;
                    }
                    _schemeID = value;
                }
            }
        }
        private long _schemeID;
        [DataMember]
        public virtual Nullable<decimal> schemeAmount
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
        public virtual long discountGivenBy
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> finalAmount
        {
            get;
            set;
        }
        [DataMember]
        public virtual string chequeNumber
        {
            get;
            set;
        }
        [DataMember]
        public virtual string BankName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Branch
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> chequeDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> activationDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> registrationDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual string RFIDCardNumber
        {
            get;
            set;
        }
        [DataMember]
        public virtual string membershipUniqueId
        {
            get;
            set;
        }
        [DataMember]
        public virtual string agreementNumber
        {
            get;
            set;
        }
        [DataMember]
        public virtual string consult
        {
            get;
            set;
        }
        [DataMember]
        public virtual string branchName
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> expiryDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> payMode
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> amountPaid
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<decimal> remainingAmount
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> ReceiptDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> ReceiptNumber
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> DueAmountDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<bool> isPaid
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> insertDate
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
        public virtual Nullable<bool> isDeleted
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<bool> isFullPaid
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
        public virtual PackageMaster PackageMaster
        {
            get { return _packageMaster; }
            set
            {
                if (!ReferenceEquals(_packageMaster, value))
                {
                    var previousValue = _packageMaster;
                    _packageMaster = value;
                    FixupPackageMaster(previousValue);
                }
            }
        }
        private PackageMaster _packageMaster;
        
    
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
    
        private void FixupClub(Club previousValue)
        {
            if (previousValue != null && previousValue.Payments.Contains(this))
            {
                previousValue.Payments.Remove(this);
            }
    
            if (Club != null)
            {
                if (!Club.Payments.Contains(this))
                {
                    Club.Payments.Add(this);
                }
                if (clubId != Club.ID)
                {
                    clubId = Club.ID;
                }
            }
        }
    
        private void FixupLead(Lead previousValue)
        {
            if (previousValue != null && previousValue.Payments.Contains(this))
            {
                previousValue.Payments.Remove(this);
            }
    
            if (Lead != null)
            {
                if (!Lead.Payments.Contains(this))
                {
                    Lead.Payments.Add(this);
                }
                if (leadId != Lead.ID)
                {
                    leadId = Lead.ID;
                }
            }
        }
    
        private void FixupPackageMaster(PackageMaster previousValue)
        {
            if (previousValue != null && previousValue.Payments.Contains(this))
            {
                previousValue.Payments.Remove(this);
            }
    
            if (PackageMaster != null)
            {
                if (!PackageMaster.Payments.Contains(this))
                {
                    PackageMaster.Payments.Add(this);
                }
                if (packageTypeId != PackageMaster.ID)
                {
                    packageTypeId = PackageMaster.ID;
                }
            }
        }
    
        private void FixupUserSchemeMaster(UserSchemeMaster previousValue)
        {
            if (previousValue != null && previousValue.Payments.Contains(this))
            {
                previousValue.Payments.Remove(this);
            }
    
            if (UserSchemeMaster != null)
            {
                if (!UserSchemeMaster.Payments.Contains(this))
                {
                    UserSchemeMaster.Payments.Add(this);
                }
                if (schemeID != UserSchemeMaster.ID)
                {
                    schemeID = UserSchemeMaster.ID;
                }
            }
        }

        #endregion

    }
}
