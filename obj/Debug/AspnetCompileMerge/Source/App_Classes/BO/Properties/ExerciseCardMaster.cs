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
    [KnownType(typeof(ExrciseCardLevelSet))]
    [KnownType(typeof(AssignExercise))]
    [KnownType(typeof(ExerciseMaster))]
    public partial class ExerciseCardMaster
    {
        #region Primitive Properties
        [DataMember]
        public virtual long ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> bodyTypeId
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<long> exerciseId
        {
            get { return _exerciseId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_exerciseId != value)
                    {
                        if (ExerciseMaster != null && ExerciseMaster.ID != value)
                        {
                            ExerciseMaster = null;
                        }
                        _exerciseId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _exerciseId;
        [DataMember]
        public virtual Nullable<int> exerciseTypeId
        {
            get;
            set;
        }
        [DataMember]
        public virtual string duration
        {
            get;
            set;
        }
        [DataMember]
        public virtual string RPM
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Resistence
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Calories
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Distance
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
        public virtual ICollection<ExrciseCardLevelSet> ExrciseCardLevelSets
        {
            get
            {
                if (_exrciseCardLevelSets == null)
                {
                    var newCollection = new FixupCollection<ExrciseCardLevelSet>();
                    newCollection.CollectionChanged += FixupExrciseCardLevelSets;
                    _exrciseCardLevelSets = newCollection;
                }
                return _exrciseCardLevelSets;
            }
            set
            {
                if (!ReferenceEquals(_exrciseCardLevelSets, value))
                {
                    var previousValue = _exrciseCardLevelSets as FixupCollection<ExrciseCardLevelSet>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupExrciseCardLevelSets;
                    }
                    _exrciseCardLevelSets = value;
                    var newValue = value as FixupCollection<ExrciseCardLevelSet>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupExrciseCardLevelSets;
                    }
                }
            }
        }
        private ICollection<ExrciseCardLevelSet> _exrciseCardLevelSets;
        
    
        [DataMember]
        public virtual ICollection<AssignExercise> AssignExercises
        {
            get
            {
                if (_assignExercises == null)
                {
                    var newCollection = new FixupCollection<AssignExercise>();
                    newCollection.CollectionChanged += FixupAssignExercises;
                    _assignExercises = newCollection;
                }
                return _assignExercises;
            }
            set
            {
                if (!ReferenceEquals(_assignExercises, value))
                {
                    var previousValue = _assignExercises as FixupCollection<AssignExercise>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAssignExercises;
                    }
                    _assignExercises = value;
                    var newValue = value as FixupCollection<AssignExercise>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAssignExercises;
                    }
                }
            }
        }
        private ICollection<AssignExercise> _assignExercises;
        
    
        [DataMember]
        public virtual ExerciseMaster ExerciseMaster
        {
            get { return _exerciseMaster; }
            set
            {
                if (!ReferenceEquals(_exerciseMaster, value))
                {
                    var previousValue = _exerciseMaster;
                    _exerciseMaster = value;
                    FixupExerciseMaster(previousValue);
                }
            }
        }
        private ExerciseMaster _exerciseMaster;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupExerciseMaster(ExerciseMaster previousValue)
        {
            if (previousValue != null && previousValue.ExerciseCardMasters.Contains(this))
            {
                previousValue.ExerciseCardMasters.Remove(this);
            }
    
            if (ExerciseMaster != null)
            {
                if (!ExerciseMaster.ExerciseCardMasters.Contains(this))
                {
                    ExerciseMaster.ExerciseCardMasters.Add(this);
                }
                if (exerciseId != ExerciseMaster.ID)
                {
                    exerciseId = ExerciseMaster.ID;
                }
            }
            else if (!_settingFK)
            {
                exerciseId = null;
            }
        }
    
        private void FixupExrciseCardLevelSets(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ExrciseCardLevelSet item in e.NewItems)
                {
                    item.ExerciseCardMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ExrciseCardLevelSet item in e.OldItems)
                {
                    if (ReferenceEquals(item.ExerciseCardMaster, this))
                    {
                        item.ExerciseCardMaster = null;
                    }
                }
            }
        }
    
        private void FixupAssignExercises(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (AssignExercise item in e.NewItems)
                {
                    item.ExerciseCardMaster = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (AssignExercise item in e.OldItems)
                {
                    if (ReferenceEquals(item.ExerciseCardMaster, this))
                    {
                        item.ExerciseCardMaster = null;
                    }
                }
            }
        }

        #endregion

    }
}
