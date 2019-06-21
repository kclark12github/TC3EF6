using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("AircraftDesignations"), TableDescription("Aircraft Designations")]
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

        [DataMember, StringLength(32), ColumnDescription("Official Designation of this aircraft.")]
        public string Designation
        {
            get => mDesignation;
            set { SetProperty(ref mDesignation, value); }
        }

        [DataMember, StringLength(72), ColumnDescription("Manufacturer of this aircraft.")]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [DataMember, StringLength(72), ColumnDescription("Official Name of this aircraft.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Unofficial Nicknames of this aircraft.")]
        public string Nicknames
        {
            get => mNicknames;
            set { SetProperty(ref mNicknames, value); }
        }

        [DataMember, ColumnDescription("Miscellaneous Notes.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }

        [DataMember, ColumnDescription("Designation number of this aircraft (for sorting).")]
        public double? Number
        {
            get => mNumber;
            set { SetProperty(ref mNumber, value); }
        }

        [DataMember, ColumnDescription("Date this aircraft entered service.")]
        public DateTime? ServiceDate
        {
            get => mServiceDate;
            set { SetProperty(ref mServiceDate, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Type of this aircraft (i.e. Fighter, Bomber, etc.).")]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Version of this aircraft.")]
        public string Version
        {
            get => mVersion;
            set { SetProperty(ref mVersion, value); }
        }
    }
}
