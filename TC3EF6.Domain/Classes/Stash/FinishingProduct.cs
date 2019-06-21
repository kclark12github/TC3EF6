using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("FinishingProducts"), TableDescription("Inventory of Finishing Products (i.e. Paint, Brushes, etc.).")]
    public partial class FinishingProduct : HobbyBase
    {
        #region "Locals"
        private double? mCount = null;
        #endregion

        [DataMember, ColumnDescription("Count of this item.")]
        public double? Count
        {
            get => mCount;
            set { SetProperty(ref mCount, value); }
        }
    }
}
