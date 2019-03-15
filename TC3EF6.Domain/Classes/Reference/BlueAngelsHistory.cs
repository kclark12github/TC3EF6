using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;
namespace TC3EF6.Domain.Classes.Reference
{
    [Table("BlueAngelsHistory")]
    public partial class BlueAngelsHistory : ImageEntityBase
    {
        #region "Locals"
        private string mServiceDates = string.Empty;
        private string mAircraftType = string.Empty;
        private string mNotes = string.Empty;
        #endregion

        [ColumnDescription("Dates this aircraft served with the Blue Angels.")]
        [StringLength(80)]
        public string ServiceDates
        {
            get => mServiceDates;
            set { SetProperty(ref mServiceDates, value); }
        }

        [ColumnDescription("Aircraft Type serving with the Blue Angels.")]
        [StringLength(80)]
        public string AircraftType
        {
            get => mAircraftType;
            set { SetProperty(ref mAircraftType, value); }
        }

        //TODO: Revisit these linkages...
        public string Decals { get; set; }
        public string DecalSets { get; set; }
        public string Kits { get; set; }

        [ColumnDescription("Miscellaneous Notes.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }
    }
}
