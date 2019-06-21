using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract]
    public partial class KitBase : HobbyBase
    {
        #region "Locals"
        private string mDesignation = string.Empty;
        private string mNation = string.Empty;
        private string mScale = string.Empty;
        #endregion

        [DataMember, StringLength(132), ColumnDescription("Designation of the Item (i.e. F-14A, BB-63, etc.).")]
        public string Designation
        {
            get => mDesignation;
            set { SetProperty(ref mDesignation, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Nationality of the Item.")]
        public string Nation
        {
            get => mNation;
            set { SetProperty(ref mNation, value); }
        }

        [DataMember, StringLength(12), ColumnDescription("Scale of Item.")]
        public string Scale
        {
            get => mScale;
            set { SetProperty(ref mScale, value); }
        }
    }
}
