using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Library of Music, including physical and electronic media.")]
    [Table("Music")]
    public partial class Music : StashBase
    {
        #region "Locals"
        private string mTitle = string.Empty;
        private string mType = string.Empty;
        private int? mYear = null;
        private string mMediaFormat = string.Empty;
        private string mAlphaSort = string.Empty;
        private string mArtist = string.Empty;
        #endregion

        [ColumnDescription("Artist of the album.")]
        [StringLength(80)]
        public string Artist
        {
            get => mArtist;
            set { SetProperty(ref mArtist, value); }
        }

        [ColumnDescription("Sort string.")]
        [StringLength(80)]
        //[Index("IX_MusicByAlphaSort", 1, IsUnique = true)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [ColumnDescription("Media/Format of this album (i.e. LP, CD, MP3, etc.).")]
        [StringLength(80)]
        //[Index("IX_MusicByAlphaSort", 2, IsUnique = true)]
        [SqlDefaultValue(DefaultValue = "'Unspecified'")]
        [MinLength(1)]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [ColumnDescription("Album title.")]
        [StringLength(80)]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [ColumnDescription("Genre of this title.")]
        [StringLength(80)]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [ColumnDescription("Year this album was originally released.")]
        public int? Year
        {
            get => mYear;
            set { SetProperty(ref mYear, value); }
        }
    }
}
