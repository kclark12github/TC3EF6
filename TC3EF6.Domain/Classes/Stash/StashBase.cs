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

        [DataMember]
        [ColumnDescription("Has this item been cataloged? (as opposed to representing something not actually owned)")]
        public bool? Cataloged
        {
            get => mCataloged;
            set { SetProperty(ref mCataloged, value); }
        }

        [DataMember]
        [ColumnDescription("Date the item was last inventoried (location confirmed).")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Date Inventoried")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateInventoried
        {
            get => mDateInventoried;
            set { SetProperty(ref mDateInventoried, value); }
        }

        [DataMember]
        [ColumnDescription("Date the item was purchased (null means unknown).")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Date Purchased")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DatePurchased
        {
            get => mDatePurchased;
            set { SetProperty(ref mDatePurchased, value); }
        }

        [DataMember]
        [ColumnDescription("Date the value of the item was confirmed/updated (null means unknown).")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Date Verified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateVerified
        {
            get => mDateVerified;
            set { SetProperty(ref mDateVerified, value); }
        }

        [DataMember]
        [ColumnDescription("Last known location of the item.")]
        [Required]
        public virtual Location Location
        {
            get => mLocation;
            set { SetProperty(ref mLocation, value); }
        }

        [DataMember]
        [ColumnDescription("Last known location (ID) of the item.")]
        [Required]
        public virtual Guid? LocationID
        {
            get => mLocationID;
            set { SetProperty(ref mLocationID, value); }
        }

        [DataMember]
        [ColumnDescription("Miscellaneous notes regarding the item.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }

        [DataMember]
        [ColumnDescription("Purchase price of the item.")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Price
        {
            get => mPrice;
            set { SetProperty(ref mPrice, value); }
        }

        [DataMember]
        [ColumnDescription("Current value of the item.")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Value
        {
            get => mValue;
            set { SetProperty(ref mValue, value); }
        }

        [DataMember]
        [ColumnDescription("Is this a WishList item?")]
        public bool? WishList
        {
            get => mWishList;
            set { SetProperty(ref mWishList, value); }
        }
    }
}
