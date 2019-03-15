using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Collection of Collectables, ranging from baseball cards, to Hot Wheels to Keepsake Ornaments.")]
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

        [ColumnDescription("Condition of the item (i.e. Packaged, Opened, etc.).")]
        [StringLength(80)]
        public string Condition
        {
            get => mCondition;
            set { SetProperty(ref mCondition, value); }
        }

        [ColumnDescription("Manufacturer of the item.")]
        [StringLength(80)]
        public string Manufacturer
        {
            get => mManufacturer;
            set { SetProperty(ref mManufacturer, value); }
        }

        [ColumnDescription("Name of the item.")]
        [StringLength(132)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [ColumnDescription("Is the item out-of-production?")]
        public bool OutOfProduction
        {
            get => mOutOfProduction;
            set { SetProperty(ref mOutOfProduction, value); }
        }

        [ColumnDescription("Reference number/code identifying the item.")]
        [StringLength(32)]
        public string Reference
        {
            get => mReference;
            set { SetProperty(ref mReference, value); }
        }

        [ColumnDescription("Series of the item.")]
        [StringLength(80)]
        public string Series
        {
            get => mSeries;
            set { SetProperty(ref mSeries, value); }
        }

        [ColumnDescription("Type of collectable (i.e. baseball card, board game, Hot Wheel, etc.).")]
        [StringLength(80)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }
    }
}
