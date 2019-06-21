using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("AppStates"), TableDescription("State information of supported applications.")]
    public class AppState : DataEntityBase
    {
        #region "Locals"
        private string mAppName = string.Empty;
        private string mLastVisitor = string.Empty;
        private DateTime mDateLastVisit = DateTime.MinValue;
        private int mHitCount = 0;
        #endregion

        [DataMember, Required, StringLength(80), ColumnDescription("Supported application name")]
        public string AppName
        {
            get => mAppName;
            set { SetProperty(ref mAppName, value); }
        }

        [DataMember, ColumnDescription("Application hit count")]
        public int HitCount
        {
            get => mHitCount;
            set { SetProperty(ref mHitCount, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Email address of last registered Visitor")]
        public string LastVisitor
        {
            get => mLastVisitor;
            set { SetProperty(ref mLastVisitor, value); }
        }

        [DataMember, ColumnDescription("Date of last visit")]
        public DateTime DateLastVisit
        {
            get => mDateLastVisit;
            set { SetProperty(ref mDateLastVisit, value); }
        }
    }
}
