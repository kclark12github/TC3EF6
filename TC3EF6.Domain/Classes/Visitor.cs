using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("Visitors"), TableDescription("Registered Visitors")]
    public class Visitor : DataEntityBase
    {
        #region "Locals"
        private string mAddress = string.Empty;
        private string mEmail = string.Empty;
        private string mFirstName = string.Empty;
        private string mLastName = string.Empty;
        private string mPhone = string.Empty;
        private DateTime mDateLastVisit = DateTime.MinValue;
        private int mVisits = 0;
        private bool mMusic = false;
        private bool mAutoStart = false;
        private bool mDetached = false;
        private string mButtonColor = null;
        private bool mDoLake = false;
        private int? mLakeGIF = 0;
        #endregion

        [DataMember, Required, StringLength(80), ColumnDescription("Last name of registered Visitor")]
        public string LastName
        {
            get => mLastName;
            set { SetProperty(ref mLastName, value); }
        }

        [DataMember, Required, StringLength(80), ColumnDescription("First name of registered Visitor")]
        public string FirstName
        {
            get => mFirstName;
            set { SetProperty(ref mFirstName, value); }
        }

        [DataMember, Required, StringLength(80), ColumnDescription("Email address of registered Visitor")]
        public string Email
        {
            get => mEmail;
            set { SetProperty(ref mEmail, value); }
        }

        [DataMember, StringLength(14), ColumnDescription("Phone number of registered Visitor (if any)"),
            Phone]
        public string Phone
        {
            get => mPhone;
            set { SetProperty(ref mPhone, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Address of registered Visitor (if any)")]
        public string Address
        {
            get => mAddress;
            set { SetProperty(ref mAddress, value); }
        }

        [DataMember, Required, ColumnDescription("Date of last visit")]
        public DateTime DateLastVisit
        {
            get => mDateLastVisit;
            set { SetProperty(ref mDateLastVisit, value); }
        }

        [DataMember, Required, ColumnDescription("Number of visits")]
        public int Visits
        {
            get => mVisits;
            set { SetProperty(ref mVisits, value); }
        }

        [DataMember, Required, ColumnDescription("Preferences - Does the visitor wish to play background music?")]
        public bool Music
        {
            get => mMusic;
            set { SetProperty(ref mMusic, value); }
        }

        [DataMember, Required, ColumnDescription("Preferences - Does the visitor wish background music starts automatically?")]
        public bool AutoStart
        {
            get => mAutoStart;
            set { SetProperty(ref mAutoStart, value); }
        }

        [DataMember, Required, ColumnDescription("Preferences - Does the visitor wish the music player appear detached?")]
        public bool Detached
        {
            get => mDetached;
            set { SetProperty(ref mDetached, value); }
        }

        [DataMember, StringLength(12), ColumnDescription("Preferences - Which button color does the user prefer?")]
        public string ButtonColor
        {
            get => mButtonColor;
            set { SetProperty(ref mButtonColor, value); }
        }

        [DataMember, Required, ColumnDescription("Preferences - Apply the Lake applet to the Welcome image?")]
        public bool DoLake
        {
            get => mDoLake;
            set { SetProperty(ref mDoLake, value); }
        }

        [DataMember, ColumnDescription("Preferences - Lake GIF selection")]
        public int? LakeGIF
        {
            get => mLakeGIF;
            set { SetProperty(ref mLakeGIF, value); }
        }
    }
}
