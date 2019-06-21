using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("Log"), TableDescription("Application Log.")]
    public partial class Log : EntityBase
    {
        #region "Locals"
        private string mMilestone = string.Empty;
        private string mMessage = string.Empty;
        private DateTime? mStartTime = null;
        private DateTime? mFinishTime = null;
        private DateTime mEffectiveDate = DateTime.MinValue;
        #endregion

        [DataMember, StringLength(256), ColumnDescription("String briefly describing the action being reported.")]
        public string Milestone
        {
            get => mMilestone;
            set { SetProperty(ref mMilestone, value); }
        }

        [DataMember, ColumnDescription("String describing more detail regarding the action taken.")]
        public string Message
        {
            get => mMessage;
            set { SetProperty(ref mMessage, value); }
        }

        [DataMember, Display(Name = "Start Time"), ColumnDescription("Start Time of a timed action."),
            DataType(DataType.Date),  DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime? StartTime
        {
            get => mStartTime;
            set { SetProperty(ref mStartTime, value); }
        }

        [DataMember, Display(Name = "Finish Time"), ColumnDescription("Finish Time of a timed action."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? FinishTime
        {
            get => mFinishTime;
            set { SetProperty(ref mFinishTime, value); }
        }

        [DataMember, Display(Name = "Effective Date"), ColumnDescription("Effective date-time of the reported action."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime EffectiveDate
        {
            get => mEffectiveDate;
            set { SetProperty(ref mEffectiveDate, value); }
        }
    }
}
