using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract]
    public partial class HobbyBase : StashBase
    {
        #region "Locals"
        private string mManufacturer = string.Empty;
        private string mName = string.Empty;
        private string mReference = string.Empty;
        private string mProductCatalog = string.Empty;
        private string mType = string.Empty;
        #endregion

        [DataMember, StringLength(132), ColumnDescription("Manufacturer of the Item.")]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [DataMember, StringLength(256), ColumnDescription("Name of the Item.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Vendor where the Item was purchased (or priced).")]
        public string ProductCatalog
        {
            get => mProductCatalog;
            set { SetProperty(ref mProductCatalog, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Reference number/code identifying the Item.")]
        public string Reference
        {
            get => mReference;
            set { SetProperty(ref mReference, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Type of Item (i.e. Aircraft, Ship, Tool, etc.).")]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }
    }
}
