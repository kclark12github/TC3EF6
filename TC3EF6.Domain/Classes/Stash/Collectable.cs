using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Collectables"), TableDescription("Collection of Collectables, ranging from baseball cards, to Hot Wheels to Keepsake Ornaments.")]
    public partial class Collectable : StashBase
    {
        #region "Locals"
        private string mSeries = string.Empty;
        private string mType = string.Empty;
        private string mReference = string.Empty;
        private bool mOutOfProduction = false;
        private string mName = string.Empty;
        private string mManufacturer = string.Empty;
        private string mCondition = string.Empty;
        #endregion

        [DataMember, StringLength(80), ColumnDescription("Condition of the item (i.e. Packaged, Opened, etc.).")]
        public string Condition
        {
            get => mCondition;
            set { SetProperty(ref mCondition, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Manufacturer of the item.")]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Name of the item.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, ColumnDescription("Is the item out-of-production?")]
        public bool OutOfProduction
        {
            get => mOutOfProduction;
            set { SetProperty(ref mOutOfProduction, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Reference number/code identifying the item.")]
        public string Reference
        {
            get => mReference;
            set { SetProperty(ref mReference, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Series of the item.")]
        public string Series
        {
            get => mSeries;
            set { SetProperty(ref mSeries, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Type of collectable (i.e. baseball card, board game, Hot Wheel, etc.).")]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }
    }
}
