using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [TableDescription("History of changes applied by the application.")]
    [Table("History")]
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

        [ColumnDescription("Column changed.")]
        [Index("IX_HistoryByRecord", 4, IsUnique = false)]
        [Index("IX_HistoryByDate", 4, IsUnique = false)]
        [StringLength(32)]
        public string Column
        {
            get => mColumn;
            set { SetProperty(ref mColumn, value); }
        }

        [ColumnDescription("Date of this change.")]
        [Index("IX_HistoryByRecord", 3, IsUnique = false)]
        [Index("IX_HistoryByDate", 1, IsUnique = false)]
        [Display(Name = "Date Changed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateChanged
        {
            get => mDateChanged;
            set { SetProperty(ref mDateChanged, value); }
        }

        [ColumnDescription("Original (changed from) value.")]
        public string OriginalValue
        {
            get => mOriginalValue;
            set { SetProperty(ref mOriginalValue, value); }
        }

        [ColumnDescription("Record changed.")]
        [Index("IX_HistoryByRecord", 2, IsUnique = false)]
        [Index("IX_HistoryByDate", 3, IsUnique = false)]
        public Guid RecordID
        {
            get => mRecordID;
            set { SetProperty(ref mRecordID, value); }
        }

        [ColumnDescription("Table changed.")]
        [Index("IX_HistoryByRecord", 1, IsUnique = false)]
        [Index("IX_HistoryByDate", 2, IsUnique = false)]
        [Required]
        [StringLength(32)]
        public string TableName
        {
            get => mTableName;
            set { SetProperty(ref mTableName, value); }
        }

        [ColumnDescription("New (changed to) value.")]
        public string Value
        {
            get => mValue;
            set { SetProperty(ref mValue, value); }
        }

        [ColumnDescription("User ID affecting this change.")]
        [StringLength(32)]
        public string Who
        {
            get => mWho;
            set { SetProperty(ref mWho, value); }
        }
    }
}
