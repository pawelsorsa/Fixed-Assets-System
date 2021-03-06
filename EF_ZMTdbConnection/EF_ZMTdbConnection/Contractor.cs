//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace EF_ZMTdbEntities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(FixedAsset))]
    public partial class Contractor: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public int nip
        {
            get { return _nip; }
            set
            {
                if (_nip != value)
                {
                    _nip = value;
                    OnPropertyChanged("nip");
                }
            }
        }
        private int _nip;
    
        [DataMember]
        public string street
        {
            get { return _street; }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged("street");
                }
            }
        }
        private string _street;
    
        [DataMember]
        public string postal_code
        {
            get { return _postal_code; }
            set
            {
                if (_postal_code != value)
                {
                    _postal_code = value;
                    OnPropertyChanged("postal_code");
                }
            }
        }
        private string _postal_code;
    
        [DataMember]
        public string city
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged("city");
                }
            }
        }
        private string _city;
    
        [DataMember]
        public string country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged("country");
                }
            }
        }
        private string _country;
    
        [DataMember]
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string account_number
        {
            get { return _account_number; }
            set
            {
                if (_account_number != value)
                {
                    _account_number = value;
                    OnPropertyChanged("account_number");
                }
            }
        }
        private string _account_number;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<FixedAsset> FixedAssets
        {
            get
            {
                if (_fixedAssets == null)
                {
                    _fixedAssets = new TrackableCollection<FixedAsset>();
                    _fixedAssets.CollectionChanged += FixupFixedAssets;
                }
                return _fixedAssets;
            }
            set
            {
                if (!ReferenceEquals(_fixedAssets, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fixedAssets != null)
                    {
                        _fixedAssets.CollectionChanged -= FixupFixedAssets;
                    }
                    _fixedAssets = value;
                    if (_fixedAssets != null)
                    {
                        _fixedAssets.CollectionChanged += FixupFixedAssets;
                    }
                    OnNavigationPropertyChanged("FixedAssets");
                }
            }
        }
        private TrackableCollection<FixedAsset> _fixedAssets;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            FixedAssets.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupFixedAssets(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FixedAsset item in e.NewItems)
                {
                    item.Contractor = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FixedAssets", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FixedAsset item in e.OldItems)
                {
                    if (ReferenceEquals(item.Contractor, this))
                    {
                        item.Contractor = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FixedAssets", item);
                    }
                }
            }
        }

        #endregion
    }
}
