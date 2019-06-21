using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain
{
    [DataContract]
    public abstract class DataEntityBase : EntityBase, IDataEntity
    {
        #region "Locals"
        private int? mOID = null;
        private DateTime mDateModified = DateTime.MinValue;
        private DateTime mDateCreated = DateTime.MinValue;
        #endregion
        [DataMember, ColumnDescription("Pre-conversion unique system-generated identifier.")]
        public int? OID
        {
            get => mOID;
            set { SetProperty(ref mOID, value); }
        }

        [DataMember, Display(Name="Date Created"), ColumnDescription("Date the item was added to the database."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode=true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime DateCreated
        {
            get => mDateCreated;
            set { SetProperty(ref mDateCreated, value); }
        }

        [DataMember, Display(Name = "Date Modified"), ColumnDescription("Date the item was last modified."),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true),
            SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime DateModified
        {
            get => mDateModified;
            set { SetProperty(ref mDateModified, value); }
        }
    }
}
