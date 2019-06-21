using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("Ships"), TableDescription("United States Navy Ships.")]
    public partial class Ship : ShipClassBase
    {
        #region "Locals"
        private string mZipCode = string.Empty;
        private string mStatus = string.Empty;
        private double? mNumber = null;
        private string mLocalURL = string.Empty;
        private string mInternetURL = string.Empty;
        private string mHomePort = string.Empty;
        private string mHullNumber = string.Empty;
        private string mHistory = string.Empty;
        private DateTime? mDateCommissioned = null;
        private string mCommand = string.Empty;
        #endregion

        [DataMember, StringLength(80), ColumnDescription("Command to which this Ship is currently assigned.")]
        public string Command
        {
            get => mCommand;
            set { SetProperty(ref mCommand, value); }
        }

        [DataMember, ColumnDescription("Date this Ship was [last] commissioned.")]
        public DateTime? DateCommissioned
        {
            get => mDateCommissioned;
            set { SetProperty(ref mDateCommissioned, value); }
        }

        [DataMember, ColumnDescription("History of this Ship.")]
        public string History
        {
            get => mHistory;
            set { SetProperty(ref mHistory, value); }
        }

        [DataMember, StringLength(12), ColumnDescription("Designation of this Ship (i.e. Classification Type Code + Number).")]
        public string HullNumber
        {
            get => mHullNumber;
            set { SetProperty(ref mHullNumber, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Current Home Port of this Ship.")]
        public string HomePort
        {
            get => mHomePort;
            set { SetProperty(ref mHomePort, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Public Internet Web Site of this Ship."),
            Url]
        public string InternetURL
        {
            get => mInternetURL;
            set { SetProperty(ref mInternetURL, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Ken's Local intranet web site of this Ship."),
            Url]
        public string LocalURL
        {
            get => mLocalURL;
            set { SetProperty(ref mLocalURL, value); }
        }

        [DataMember, ColumnDescription("Designation number of this Ship (for sorting).")]
        public double? Number
        {
            get => mNumber;
            set { SetProperty(ref mNumber, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Current Status of this Ship.")]
        public string Status
        {
            get => mStatus;
            set { SetProperty(ref mStatus, value); }
        }

        [DataMember, StringLength(18), ColumnDescription("Current Zip Code for snail-mail to the crew of this Ship.")]
        public string ZipCode
        {
            get => mZipCode;
            set { SetProperty(ref mZipCode, value); }
        }
    }
}
