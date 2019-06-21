using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("Locations"), TableDescription("Location of cataloged items.")]
    public class Location : DataEntityBase
    {
        #region "Locals"
        private string mDescription = string.Empty;
        private string mName = string.Empty;
        private string mPhysicalLocation = string.Empty;
        private string mOName = string.Empty;
        #endregion

        [DataMember, NotMapped]
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

        [DataMember, StringLength(1024), ColumnDescription("Description of box/container (if applicable).")]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); OnPropertyChanged("Caption"); }
        }

        [DataMember, StringLength(1024), ColumnDescription("Name of location.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); OnPropertyChanged("Caption"); }
        }

        [DataMember, StringLength(1024), ColumnDescription("Physical location of the box/container represented by this Location.")]
        public string PhysicalLocation
        {
            get => mPhysicalLocation;
            set { SetProperty(ref mPhysicalLocation, value); OnPropertyChanged("Caption"); }
        }

        [DataMember, StringLength(80), ColumnDescription("Original Location field from source database (TODO: Remove after conversion).")]
        public string OName
        {
            get => mOName;
            set { SetProperty(ref mOName, value); }
        }
    }
}
