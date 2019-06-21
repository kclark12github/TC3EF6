using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Software"), TableDescription("Library of Software, ranging from floppy discs, to CD/DVD to electronic media.")]
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

        [DataMember, Required, StringLength(132), ColumnDescription("Sort string.")]
        //[Index("IX_SoftwareByAlphaSort", 1, IsUnique = true)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("License key (if applicable).")]
        public string CDkey
        {
            get => mCDkey;
            set { SetProperty(ref mCDkey, value); }
        }

        [DataMember, Display(Name = "Date Released"), ColumnDescription("Date the software was originally released (if known)."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime? DateReleased
        {
            get => mDateReleased;
            set { SetProperty(ref mDateReleased, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Company who developed the Software.")]
        public string Developer
        {
            get => mDeveloper;
            set { SetProperty(ref mDeveloper, value); }
        }

        [DataMember, StringLength(24), ColumnDescription("International Standard Book Number (if known).")]
        public string ISBN
        {
            get => mISBN;
            set { SetProperty(ref mISBN, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Distribution Media (i.e. CD, DVD, Digital Download, etc.)."),
            MinLength(1),
            SqlDefaultValue(DefaultValue = "'Unspecified'")]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Operating System (O/S) or hardware Platform.")]
        public string Platform
        {
            get => mPlatform;
            set { SetProperty(ref mPlatform, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Company who published the Software.")]
        public string Publisher
        {
            get => mPublisher;
            set { SetProperty(ref mPublisher, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Software Title.")]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Type of Software (i.e. Game, Development IDE, etc.).")]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Software version number (if known).")]
        public string Version
        {
            get => mVersion;
            set { SetProperty(ref mVersion, value); }
        }
    }
}
