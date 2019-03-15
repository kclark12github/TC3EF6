using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [TableDescription("Location of cataloged items.")]
    public class Location : DataEntityBase
    {
        #region "Locals"
        private string mDescription = string.Empty;
        private string mName = string.Empty;
        private string mPhysicalLocation = string.Empty;
        private string mOName = string.Empty;
        #endregion

        [NotMapped]
        public string Caption
        {
            get
            {
                string caption = mName;
                if (!String.IsNullOrEmpty(mDescription)) { caption = string.Format("{0} ({1})", caption, mDescription); }
                if (!String.IsNullOrEmpty(mPhysicalLocation)) { caption = string.Format("{0} @ {1}", caption, mPhysicalLocation); }
                return caption;
            }
        }

        [ColumnDescription("Description of box/container (if applicable).")]
        [StringLength(1024)]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); OnPropertyChanged("Caption"); }
        }

        [ColumnDescription("Name of location.")]
        [StringLength(1024)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); OnPropertyChanged("Caption"); }
        }

        [ColumnDescription("Physical location of the box/container represented by this Location.")]
        [StringLength(1024)]
        public string PhysicalLocation
        {
            get => mPhysicalLocation;
            set { SetProperty(ref mPhysicalLocation, value); OnPropertyChanged("Caption"); }
        }

        [ColumnDescription("Original Location field from source database (TODO: Remove after conversion).")]
        [StringLength(80)]
        public string OName
        {
            get => mOName;
            set { SetProperty(ref mOName, value); }
        }
    }
}
