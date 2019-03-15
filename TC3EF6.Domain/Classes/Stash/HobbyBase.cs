using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    public partial class HobbyBase : StashBase
    {
        #region "Locals"
        private string mManufacturer = string.Empty;
        private string mName = string.Empty;
        private string mReference = string.Empty;
        private string mProductCatalog = string.Empty;
        private string mType = string.Empty;
        #endregion

        [ColumnDescription("Manufacturer of the Item.")]
        [StringLength(132)]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [ColumnDescription("Name of the Item.")]
        [StringLength(256)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [ColumnDescription("Vendor where the Item was purchased (or priced).")]
        [StringLength(132)]
        public string ProductCatalog
        {
            get => mProductCatalog;
            set { SetProperty(ref mProductCatalog, value); }
        }

        [ColumnDescription("Reference number/code identifying the Item.")]
        [StringLength(132)]
        public string Reference
        {
            get => mReference;
            set { SetProperty(ref mReference, value); }
        }

        [ColumnDescription("Type of Item (i.e. Aircraft, Ship, Tool, etc.).")]
        [StringLength(132)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }
    }
}
