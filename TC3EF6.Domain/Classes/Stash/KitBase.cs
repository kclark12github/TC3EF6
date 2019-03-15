using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    public partial class KitBase : HobbyBase
    {
        #region "Locals"
        private string mDesignation = string.Empty;
        private string mNation = string.Empty;
        private string mScale = string.Empty;
        #endregion

        [ColumnDescription("Designation of the Item (i.e. F-14A, BB-63, etc.).")]
        [StringLength(132)]
        public string Designation
        {
            get => mDesignation;
            set { SetProperty(ref mDesignation, value); }
        }

        [ColumnDescription("Nationality of the Item.")]
        [StringLength(132)]
        public string Nation
        {
            get => mNation;
            set { SetProperty(ref mNation, value); }
        }

        [ColumnDescription("Scale of Item.")]
        [StringLength(12)]
        public string Scale
        {
            get => mScale;
            set { SetProperty(ref mScale, value); }
        }
    }
}
