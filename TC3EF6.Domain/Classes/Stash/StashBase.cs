using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain
{
    [DataContract]
    public abstract class StashBase : ImageEntityBase, IStash
    {
        #region "Locals"
        private bool? mCataloged = null;
        private DateTime? mDateInventoried = null;
        private DateTime? mDatePurchased = null;
        private DateTime? mDateVerified = null;
        private Guid? mLocationID = null;
        private Location mLocation = null;
        private string mNotes = string.Empty;
        private decimal? mPrice = null;
        private decimal? mValue = null;
        private bool? mWishList = null;
        #endregion

        [DataMember, ColumnDescription("Has this item been cataloged? (as opposed to representing something not actually owned)")]
        public bool? Cataloged
        {
            get => mCataloged;
            set { SetProperty(ref mCataloged, value); }
        }

        [DataMember, Display(Name = "Date Inventoried"), ColumnDescription("Date the item was last inventoried (location confirmed)."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        
        public DateTime? DateInventoried
        {
            get => mDateInventoried;
            set { SetProperty(ref mDateInventoried, value); }
        }

        [DataMember, Display(Name = "Date Purchased"), ColumnDescription("Date the item was purchased (null means unknown)."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime? DatePurchased
        {
            get => mDatePurchased;
            set { SetProperty(ref mDatePurchased, value); }
        }

        [DataMember, Display(Name = "Date Verified"), ColumnDescription("Date the value of the item was confirmed/updated (null means unknown)."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime? DateVerified
        {
            get => mDateVerified;
            set { SetProperty(ref mDateVerified, value); }
        }

        [DataMember, Required, ColumnDescription("Last known location of the item.")]
        public virtual Location Location
        {
            get => mLocation;
            set { SetProperty(ref mLocation, value); }
        }

        [DataMember, Required, ColumnDescription("Last known location (ID) of the item.")]
        public virtual Guid? LocationID
        {
            get => mLocationID;
            set { SetProperty(ref mLocationID, value); }
        }

        [DataMember, ColumnDescription("Miscellaneous notes regarding the item.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }

        [DataMember, ColumnDescription("Purchase price of the item."),
            Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Price
        {
            get => mPrice;
            set { SetProperty(ref mPrice, value); }
        }

        [DataMember, ColumnDescription("Current value of the item."),
            Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Value
        {
            get => mValue;
            set { SetProperty(ref mValue, value); }
        }

        [DataMember, ColumnDescription("Is this a WishList item?")]
        public bool? WishList
        {
            get => mWishList;
            set { SetProperty(ref mWishList, value); }
        }
    }
}
