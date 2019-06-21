using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("ShipClassTypes"), TableDescription("United States Navy Ship Classification Types.")]
    public partial class ShipClassType : ImageEntityBase
    {
        #region "Locals"
        private string mDescription = string.Empty;
        private string mTypeCode = string.Empty;
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShipClassType()
        {
            ShipClasses = new HashSet<ShipClass>();
            Ships = new HashSet<Ship>();
        }

        [DataMember, StringLength(80), ColumnDescription("Class Type Description (i.e. Aircraft Carrier, Battleship, Destroyer, etc.).")]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); }
        }

        [DataMember, ColumnDescription("List of Ship Classes representing this particular Classification."),
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipClass> ShipClasses { get; set; }

        [DataMember, ColumnDescription("List of Ships for representing this particular Classification."),
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ship> Ships { get; set; }

        [DataMember, StringLength(32), ColumnDescription("Classification Type Code (i.e. CV, BB, DD, etc.).")]
        public string TypeCode
        {
            get => mTypeCode;
            set { SetProperty(ref mTypeCode, value); }
        }
    }
}
