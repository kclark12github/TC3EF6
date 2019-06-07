using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [TableDescription("Application Log.")]
    [Table("Log")]
    public partial class Log : EntityBase
    {
        #region "Locals"
        private string mMilestone = string.Empty;
        private string mMessage = string.Empty;
        private DateTime? mStartTime = null;
        private DateTime? mFinishTime = null;
        private DateTime mEffectiveDate = DateTime.MinValue;
        #endregion

        [DataMember]
        [ColumnDescription("String briefly describing the action being reported.")]
        [StringLength(256)]
        public string Milestone
        {
            get => mMilestone;
            set { SetProperty(ref mMilestone, value); }
        }

        [DataMember]
        [ColumnDescription("String describing more detail regarding the action taken.")]
        public string Message
        {
            get => mMessage;
            set { SetProperty(ref mMessage, value); }
        }

        [DataMember]
        [ColumnDescription("Start Time of a timed action.")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime
        {
            get => mStartTime;
            set { SetProperty(ref mStartTime, value); }
        }

        [DataMember]
        [ColumnDescription("Finish Time of a timed action.")]
        [Display(Name = "Finish Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? FinishTime
        {
            get => mFinishTime;
            set { SetProperty(ref mFinishTime, value); }
        }

        [DataMember]
        [ColumnDescription("Effective date-time of the reported action.")]
        [SqlDefaultValue(DefaultValue = "getdate()")]
        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate
        {
            get => mEffectiveDate;
            set { SetProperty(ref mEffectiveDate, value); }
        }
    }
}
