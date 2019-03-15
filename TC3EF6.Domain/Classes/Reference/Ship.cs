using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;
namespace TC3EF6.Domain.Classes.Reference
{
    [TableDescription("United States Navy Ships.")]
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

        [ColumnDescription("Command to which this Ship is currently assigned.")]
        [StringLength(80)]
        public string Command
        {
            get => mCommand;
            set { SetProperty(ref mCommand, value); }
        }

        [ColumnDescription("Date this Ship was [last] commissioned.")]
        public DateTime? DateCommissioned
        {
            get => mDateCommissioned;
            set { SetProperty(ref mDateCommissioned, value); }
        }

        [ColumnDescription("History of this Ship.")]
        public string History
        {
            get => mHistory;
            set { SetProperty(ref mHistory, value); }
        }

        [ColumnDescription("Designation of this Ship (i.e. Classification Type Code + Number).")]
        [StringLength(12)]
        public string HullNumber
        {
            get => mHullNumber;
            set { SetProperty(ref mHullNumber, value); }
        }

        [ColumnDescription("Current Home Port of this Ship.")]
        [StringLength(80)]
        public string HomePort
        {
            get => mHomePort;
            set { SetProperty(ref mHomePort, value); }
        }

        [ColumnDescription("Public Internet Web Site of this Ship.")]
        [StringLength(132)]
        [Url]
        public string InternetURL
        {
            get => mInternetURL;
            set { SetProperty(ref mInternetURL, value); }
        }

        [ColumnDescription("Ken's Local intranet web site of this Ship.")]
        [StringLength(132)]
        [Url]
        public string LocalURL
        {
            get => mLocalURL;
            set { SetProperty(ref mLocalURL, value); }
        }

        [ColumnDescription("Designation number of this Ship (for sorting).")]
        public double? Number
        {
            get => mNumber;
            set { SetProperty(ref mNumber, value); }
        }

        [ColumnDescription("Current Status of this Ship.")]
        [StringLength(80)]
        public string Status
        {
            get => mStatus;
            set { SetProperty(ref mStatus, value); }
        }

        [ColumnDescription("Current Zip Code for snail-mail to the crew of this Ship.")]
        [StringLength(18)]
        public string ZipCode
        {
            get => mZipCode;
            set { SetProperty(ref mZipCode, value); }
        }
    }
}
