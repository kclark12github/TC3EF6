using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract]
    [TableDescription("Collection of Decals.")]
    public partial class Decal : KitBase
    {
        [DataMember]
        [ColumnDescription("Set of Model Kits to which this Decal may be applied.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kit> Kits { get; set; }
    }
}
