using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;
namespace TC3EF6.Domain.Classes.Reference
{
    [TableDescription("Aircraft Designations")]
    [Table("AircraftDesignations")]
    public partial class AircraftDesignation : ImageEntityBase
    {
        #region "Locals"
        private string mDesignation = string.Empty;
        private string mManufacturer = string.Empty;
        private string mName = string.Empty;
        private string mNicknames = string.Empty;
        private string mNotes = string.Empty;
        private double? mNumber = null;
        private DateTime? mServiceDate = null;
        private string mType = string.Empty;
        private string mVersion = string.Empty;
        #endregion

        [ColumnDescription("Official Designation of this aircraft.")]
        [StringLength(32)]
        public string Designation
        {
            get => mDesignation;
            set { SetProperty(ref mDesignation, value); }
        }

        [ColumnDescription("Manufacturer of this aircraft.")]
        [StringLength(72)]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [ColumnDescription("Official Name of this aircraft.")]
        [StringLength(72)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [ColumnDescription("Unofficial Nicknames of this aircraft.")]
        [StringLength(80)]
        public string Nicknames
        {
            get => mNicknames;
            set { SetProperty(ref mNicknames, value); }
        }

        [ColumnDescription("Miscellaneous Notes.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }

        [ColumnDescription("Designation number of this aircraft (for sorting).")]
        public double? Number
        {
            get => mNumber;
            set { SetProperty(ref mNumber, value); }
        }

        [ColumnDescription("Date this aircraft entered service.")]
        public DateTime? ServiceDate
        {
            get => mServiceDate;
            set { SetProperty(ref mServiceDate, value); }
        }

        [ColumnDescription("Type of this aircraft (i.e. Fighter, Bomber, etc.).")]
        [StringLength(32)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [ColumnDescription("Version of this aircraft.")]
        [StringLength(32)]
        public string Version
        {
            get => mVersion;
            set { SetProperty(ref mVersion, value); }
        }
    }
}
