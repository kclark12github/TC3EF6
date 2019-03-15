using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Collection of Trains/Locomotives/Rolling Stock.")]
    public partial class Train : HobbyBase
    {
        #region "Locals"
        private string mScale = string.Empty;
        private string mLine = string.Empty;
        #endregion

        [ColumnDescription("Railroad line of this particular item")]
        [StringLength(72)]
        public string Line
        {
            get => mLine;
            set { SetProperty(ref mLine, value); }
        }

        [ColumnDescription("Reference number/code identifying the item.")]
        [StringLength(12)]
        public string Scale
        {
            get => mScale;
            set { SetProperty(ref mScale, value); }
        }
    }
}
