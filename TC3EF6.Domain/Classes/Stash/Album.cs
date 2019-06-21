using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Albums"), TableDescription("Library of Music, including physical and electronic media.")]
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

        [DataMember, StringLength(80), ColumnDescription("Album artist - Artist under which the album was released (not necessarily each track's artist).")]
        public string Artist
        {
            get => mArtist;
            set { SetProperty(ref mArtist, value); }
        }

        [DataMember, Required, ColumnDescription("Album artist (ID) - Artist under which the album was released (not necessarily each track's artist).")]
        public virtual Guid? ArtistID
        {
            get => mArtistID;
            set { SetProperty(ref mArtistID, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Sort string.")]
        //[Index("IX_AlbumsByAlphaSort", 1, IsUnique = true)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Media/Format of this album (i.e. LP, CD, MP3, etc.)."),
            MinLength(1),
            SqlDefaultValue(DefaultValue = "'Unspecified'")]
        //[Index("IX_AlbumsByAlphaSort", 2, IsUnique = true)]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Album title.")]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Genre of this title.")]
        public string Type
        {
            get => mType;
            set { SetProperty(ref mType, value); }
        }

        [DataMember, ColumnDescription("Year this album was originally released.")]
        public int? Year
        {
            get => mYear;
            set { SetProperty(ref mYear, value); }
        }
    }
}
