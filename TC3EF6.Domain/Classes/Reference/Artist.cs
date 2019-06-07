using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [TableDescription("Dictionary of Music Artists.")]
    [Table("Artists")]
    public class Artist : DataEntityBase
    {
        #region "Locals"
        private string mAKA = string.Empty;
        private string mAlphaSort = string.Empty;
        private string mComments = string.Empty;
        private string mName = string.Empty;
        #endregion

        [DataMember]
        [ColumnDescription("Alternate artist name string (Also Known As).")]
        [StringLength(32)]
        public string AKA
        {
            get => mAKA;
            set { SetProperty(ref mAKA, value); }
        }

        [DataMember]
        [ColumnDescription("Artist Comments.")]
        public string Comments
        {
            get => mComments;
            set { SetProperty(ref mComments, value); }
        }

        [DataMember]
        [ColumnDescription("Sort string.")]
        [Required]
        [StringLength(256)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember]
        [ColumnDescription("Artist Name.")]
        [Required]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }
    }
}
