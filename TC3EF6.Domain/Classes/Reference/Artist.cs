using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("Artists"), TableDescription("Dictionary of Music Artists.")]
    public class Artist : DataEntityBase
    {
        #region "Locals"
        private string mAKA = string.Empty;
        private string mAlphaSort = string.Empty;
        private string mComments = string.Empty;
        private string mName = string.Empty;
        #endregion

        [DataMember, StringLength(32), ColumnDescription("Alternate artist name string (Also Known As).")]
        public string AKA
        {
            get => mAKA;
            set { SetProperty(ref mAKA, value); }
        }

        [DataMember, ColumnDescription("Artist Comments.")]
        public string Comments
        {
            get => mComments;
            set { SetProperty(ref mComments, value); }
        }

        [DataMember, Required, StringLength(256), ColumnDescription("Sort string.")]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember, Required, ColumnDescription("Artist Name.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }
    }
}
