using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Library of Music, including physical and electronic media.")]
    [Table("Albums")]
    public partial class Album : StashBase
    {
        #region "Locals"
        private string mTitle = string.Empty;
        private string mType = string.Empty;
        private int? mYear = null;
        private string mMediaFormat = string.Empty;
        private string mAlphaSort = string.Empty;
        private string mArtist = string.Empty;
        private Guid? mArtistID = null;
        #endregion

        [DataMember]
        [ColumnDescription("Album artist - Artist under which the album was released (not necessarily each track's artist).")]
        [StringLength(80)]
        public string Artist
        {
            get => mArtist;
            set { SetProperty(ref mArtist, value); }
        }

        [DataMember]
        [ColumnDescription("Album artist (ID) - Artist under which the album was released (not necessarily each track's artist).")]
        [Required]
        public virtual Guid? ArtistID
        {
            get => mArtistID;
            set { SetProperty(ref mArtistID, value); }
        }

        [DataMember]
        [ColumnDescription("Sort string.")]
        [StringLength(80)]
        //[Index("IX_AlbumsByAlphaSort", 1, IsUnique = true)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember]
        [ColumnDescription("Media/Format of this album (i.e. LP, CD, MP3, etc.).")]
        [StringLength(80)]
        //[Index("IX_AlbumsByAlphaSort", 2, IsUnique = true)]
        [SqlDefaultValue(DefaultValue = "'Unspecified'")]
        [MinLength(1)]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [DataMember]
        [ColumnDescription("Album title.")]
        [StringLength(80)]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember]
        [ColumnDescription("Genre of this title.")]
        [StringLength(80)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [DataMember]
        [ColumnDescription("Year this album was originally released.")]
        public int? Year
        {
            get => mYear;
            set { SetProperty(ref mYear, value); }
        }
    }
}
