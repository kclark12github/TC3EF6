using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract]
    public class VideoBase : StashBase
    {
        #region "Locals"
        private string mSourceTable = string.Empty;
        private bool? mTaped = null;
        private bool? mWMV = null;
        private string mTitle = string.Empty;
        private string mSubject = string.Empty;
        private bool? mStoreBought = null;
        private DateTime? mDateReleased = null;
        private string mMediaFormat = string.Empty;
        private string mDistributor = string.Empty;
        #endregion

        [DataMember, StringLength(80), ColumnDescription("Distributor of this title.")]
        public string Distributor
        {
            get => mDistributor;
            set { SetProperty(ref mDistributor, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Media/Format of this title (i.e. VHS, DVD, Blu-Ray, MP4, etc.)."),
            MinLength(1),
            SqlDefaultValue(DefaultValue = "'Unspecified'")]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [DataMember, Display(Name = "Date Released"), ColumnDescription("Date the title was originally released (if known)."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime? DateReleased
        {
            get => mDateReleased;
            set { SetProperty(ref mDateReleased, value); }
        }

        [DataMember, ColumnDescription("Was this title purchased as opposed to recorded or ripped from the library? (TODO: Move into MediaFormat)")]
        public bool? StoreBought
        {
            get => mStoreBought;
            set { SetProperty(ref mStoreBought, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Subject of this title (i.e. Comedy, Drama, etc.).")]
        public string Subject
        {
            get => mSubject;
            set { SetProperty(ref mSubject, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Title of this Video.")]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember, ColumnDescription("Has this title been ripped to digital format? (TODO: Move into MediaFormat)")]
        public bool? WMV
        {
            get => mWMV;
            set { SetProperty(ref mWMV, value); }
        }

        [DataMember, ColumnDescription("Was this video/episode/set taped? (TODO: Move into MediaFormat)")]
        public bool? Taped
        {
            get => mTaped;
            set { SetProperty(ref mTaped, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Source Table for this Video (TODO: Remove after conversion).")]
        public string SourceTable
        {
            get => mSourceTable;
            set { SetProperty(ref mSourceTable, value); }
        }
    }
}
