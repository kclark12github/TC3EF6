using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Video Library")]
    public partial class Video : VideoBase
    {
        #region "Locals"
        private string mAlphaSort = string.Empty;
        #endregion

        [ColumnDescription("Sort string.")]
        [StringLength(132)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }
    }
}
