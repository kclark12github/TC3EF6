using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Library of Software, ranging from floppy discs, to CD/DVD to electronic media.")]
    [Table("Software")]
    public partial class Software : StashBase
    {
        #region "Locals"
        private string mVersion = string.Empty;
        private string mType = string.Empty;
        private string mTitle = string.Empty;
        private string mPublisher = string.Empty;
        private string mPlatform = string.Empty;
        private string mMediaFormat = string.Empty;
        private string mISBN = string.Empty;
        private string mDeveloper = string.Empty;
        private DateTime? mDateReleased = null;
        private string mCDkey = string.Empty;
        private string mAlphaSort = string.Empty;
        #endregion

        [ColumnDescription("Sort string.")]
        [Required]
        [StringLength(132)]
        //[Index("IX_SoftwareByAlphaSort", 1, IsUnique = true)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [ColumnDescription("License key (if applicable).")]
        [StringLength(80)]
        public string CDkey
        {
            get => mCDkey;
            set { SetProperty(ref mCDkey, value); }
        }

        [ColumnDescription("Date the software was originally released (if known).")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Date Released")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateReleased
        {
            get => mDateReleased;
            set { SetProperty(ref mDateReleased, value); }
        }

        [ColumnDescription("Company who developed the Software.")]
        [StringLength(80)]
        public string Developer
        {
            get => mDeveloper;
            set { SetProperty(ref mDeveloper, value); }
        }

        [ColumnDescription("International Standard Book Number (if known).")]
        [StringLength(24)]
        public string ISBN
        {
            get => mISBN;
            set { SetProperty(ref mISBN, value); }
        }

        [ColumnDescription("Distribution Media (i.e. CD, DVD, Digital Download, etc.).")]
        [StringLength(80)]
        [SqlDefaultValue(DefaultValue = "'Unspecified'")]
        [MinLength(1)]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [ColumnDescription("Operating System (O/S) or hardware Platform.")]
        [StringLength(32)]
        public string Platform
        {
            get => mPlatform;
            set { SetProperty(ref mPlatform, value); }
        }

        [ColumnDescription("Company who published the Software.")]
        [StringLength(80)]
        public string Publisher
        {
            get => mPublisher;
            set { SetProperty(ref mPublisher, value); }
        }

        [ColumnDescription("Software Title.")]
        [StringLength(80)]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [ColumnDescription("Type of Software (i.e. Game, Development IDE, etc.).")]
        [StringLength(32)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [ColumnDescription("Software version number (if known).")]
        [StringLength(32)]
        public string Version
        {
            get => mVersion;
            set { SetProperty(ref mVersion, value); }
        }
    }
}
