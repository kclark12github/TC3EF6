using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("History"), TableDescription("History of changes applied by the application.")]
    public partial class History : DataEntityBase
    {
        #region "Locals"
        private string mWho = string.Empty;
        private string mValue = string.Empty;
        private string mTableName = string.Empty;
        private Guid mRecordID = Guid.Empty;
        private string mOriginalValue = string.Empty;
        private DateTime mDateChanged = DateTime.MinValue;
        private string mColumn = string.Empty;
        #endregion

        [DataMember, StringLength(32), ColumnDescription("Column changed.")]
            //Index("IX_HistoryByRecord", 4, IsUnique = false),
            //Index("IX_HistoryByDate", 4, IsUnique = false)]
        public string Column
        {
            get => mColumn;
            set { SetProperty(ref mColumn, value); }
        }

        [DataMember, Display(Name = "Date Changed"), ColumnDescription("Date of this change."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            //Index("IX_HistoryByRecord", 3, IsUnique = false),
            //Index("IX_HistoryByDate", 1, IsUnique = false)]
        public DateTime DateChanged
        {
            get => mDateChanged;
            set { SetProperty(ref mDateChanged, value); }
        }

        [DataMember, ColumnDescription("Original (changed from) value.")]
        public string OriginalValue
        {
            get => mOriginalValue;
            set { SetProperty(ref mOriginalValue, value); }
        }

        [DataMember, ColumnDescription("Record changed.")]
            //Index("IX_HistoryByRecord", 2, IsUnique = false),
            //Index("IX_HistoryByDate", 3, IsUnique = false)]
        public Guid RecordID
        {
            get => mRecordID;
            set { SetProperty(ref mRecordID, value); }
        }

        [DataMember, Required, StringLength(32), ColumnDescription("Table changed.")]
            //Index("IX_HistoryByRecord", 1, IsUnique = false),
            //Index("IX_HistoryByDate", 2, IsUnique = false)]
        public string TableName
        {
            get => mTableName;
            set { SetProperty(ref mTableName, value); }
        }

        [DataMember, ColumnDescription("New (changed to) value.")]
        public string Value
        {
            get => mValue;
            set { SetProperty(ref mValue, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("User ID affecting this change.")]
        public string Who
        {
            get => mWho;
            set { SetProperty(ref mWho, value); }
        }
    }
}
