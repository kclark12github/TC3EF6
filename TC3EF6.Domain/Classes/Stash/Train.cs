using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Trains"), TableDescription("Collection of Trains/Locomotives/Rolling Stock.")]
    public partial class Train : HobbyBase
    {
        #region "Locals"
        private string mScale = string.Empty;
        private string mLine = string.Empty;
        #endregion

        [DataMember, StringLength(72), ColumnDescription("Railroad line of this particular item")]
        public string Line
        {
            get => mLine;
            set { SetProperty(ref mLine, value); }
        }

        [DataMember, StringLength(12), ColumnDescription("Scale of Item.")]
        public string Scale
        {
            get => mScale;
            set { SetProperty(ref mScale, value); }
        }
    }
}
