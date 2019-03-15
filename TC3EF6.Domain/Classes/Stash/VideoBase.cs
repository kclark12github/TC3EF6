using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
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

        [ColumnDescription("Distributor of this title.")]
        [StringLength(80)]
        public string Distributor
        {
            get => mDistributor;
            set { SetProperty(ref mDistributor, value); }
        }

        [ColumnDescription("Media/Format of this title (i.e. VHS, DVD, Blu-Ray, MP4, etc.).")]
        [StringLength(80)]
        [SqlDefaultValue(DefaultValue = "'Unspecified'")]
        [MinLength(1)]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [ColumnDescription("Date the title was originally released (if known).")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Date Released")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateReleased
        {
            get => mDateReleased;
            set { SetProperty(ref mDateReleased, value); }
        }

        [ColumnDescription("Was this title purchased as opposed to recorded or ripped from the library? (TODO: Move into MediaFormat)")]
        public bool? StoreBought
        {
            get => mStoreBought;
            set { SetProperty(ref mStoreBought, value); }
        }

        [ColumnDescription("Subject of this title (i.e. Comedy, Drama, etc.).")]
        [StringLength(80)]
        public string Subject
        {
            get => mSubject;
            set { SetProperty(ref mSubject, value); }
        }

        [ColumnDescription("Title of this Video.")]
        [StringLength(80)]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [ColumnDescription("Has this title been ripped to digital format? (TODO: Move into MediaFormat)")]
        public bool? WMV
        {
            get => mWMV;
            set { SetProperty(ref mWMV, value); }
        }

        [ColumnDescription("Was this video/episode/set taped? (TODO: Move into MediaFormat)")]
        public bool? Taped
        {
            get => mTaped;
            set { SetProperty(ref mTaped, value); }
        }

        [ColumnDescription("Source Table for this Video (TODO: Remove after conversion).")]
        [StringLength(80)]
        public string SourceTable
        {
            get => mSourceTable;
            set { SetProperty(ref mSourceTable, value); }
        }
    }
}
