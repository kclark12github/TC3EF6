using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Episodes"), TableDescription("TV Episode Library")]
    public partial class Episode : VideoBase
    {
        #region "Locals"
        private string mNumber = string.Empty;
        private string mSeries = string.Empty;
        #endregion

        [DataMember, StringLength(80), ColumnDescription("Name of this TV Series.")]
        public string Series
        {
            get => mSeries;
            set { SetProperty(ref mSeries, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Episode number.")]
        public string Number
        {
            get => mNumber;
            set { SetProperty(ref mNumber, value); }
        }
    }
}
