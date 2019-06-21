using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain
{
    [DataContract]
    public abstract partial class ImageEntityBase : DataEntityBase, IImageEntity
    {
        #region "Locals"
        private List<Image> mImages = new List<Image>();
        #endregion

        [DataMember, ColumnDescription("Image(s) representing the appearance of the item."),
            NotMapped,
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Image> Images
        {
            get => mImages;
            set { SetProperty(ref mImages, value); }
        }
    }
}
