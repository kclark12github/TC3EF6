using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("Tracks"), TableDescription("Music Track Listing.")]
    public class Track : DataEntityBase
    {
        #region "Locals"
        private string mGenre = string.Empty;
        private string mAlbumArtist = string.Empty; //Temporary Fields (until things get wired-up)
        private Guid? mAlbumArtistID = null;		//s/b NOT NULL When everything is wired-up
        private string mArtist = string.Empty;      //Temporary Fields(until things get wired-up)
        private Guid? mArtistID = null;				//s/b NOT NULL When everything is wired-up
        private int mYear = 0;	                    //Should this be a DateTime?
        private string mAlbum = string.Empty;       //Temporary Fields (until things get wired-up)
        private Guid? mAlbumID = null;				//s/b NOT NULL When everything is wired-up
        private int mDisc = 1;
        private int mTrack = 0;
        private string mTitle = string.Empty;
        private decimal mDuration = 0;
        private string mComposer = string.Empty;
        private string mComment = string.Empty;
        private string mPath = string.Empty;		//Temporary Fields(until things get wired-up)
        private string mLyrics = string.Empty;
        private string mPublisher = string.Empty;
        #endregion

        [DataMember, ColumnDescription("Genre name for this track (if any)")]
        public string Genre
        {
            get => mGenre;
            set { SetProperty(ref mGenre, value); }
        }

        [DataMember, ColumnDescription("Album artist name - (temporary until post-conversion)")]
        public string AlbumArtist
        {
            get => mAlbumArtist;
            set { SetProperty(ref mAlbumArtist, value); }
        }

        [DataMember, Required, ColumnDescription("Album artist reference (ID)")]
        public Guid? AlbumArtistID
        {
            get => mAlbumArtistID;
            set { SetProperty(ref mAlbumArtistID, value); }
        }

        [DataMember, ColumnDescription("Artist name - (temporary until post-conversion)")]
        public string Artist
        {
            get => mArtist;
            set { SetProperty(ref mArtist, value); }
        }

        [DataMember, ColumnDescription("Track artist reference (ID) - (if known)")]
        public Guid? ArtistID
        {
            get => mArtistID;
            set { SetProperty(ref mArtistID, value); }
        }

        [DataMember, ColumnDescription("Year track was written/published - (if known)")] //Should this be a DateTime?
        public int Year
        {
            get => mYear;
            set { SetProperty(ref mYear, value); }
        }

        [DataMember, ColumnDescription("Album name - (temporary until post-conversion)")]
        public string Album
        {
            get => mAlbum;
            set { SetProperty(ref mAlbum, value); }
        }

        [DataMember, ColumnDescription("Album reference (ID)")]
        public Guid? AlbumID
        {
            get => mAlbumID;
            set { SetProperty(ref mAlbumID, value); }
        }

        [DataMember, ColumnDescription("Disc number (if known)")]
        public int DiscNumber
        {
            get => mDisc;
            set { SetProperty(ref mDisc, value); }
        }

        [DataMember]
        [ColumnDescription("Track number")]
        public int TrackNumber
        {
            get => mTrack;
            set { SetProperty(ref mTrack, value); }
        }

        [DataMember, Required, StringLength(256), ColumnDescription("Track Title/Name")]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember, Required, ColumnDescription("Track length in seconds"),
            Column(TypeName = "money")]    //4 decimals...
        public decimal Duration
        {
            get => mDuration;
            set { SetProperty(ref mDuration, value); }
        }

        [DataMember, ColumnDescription("Composer (if known)")]
        public string Composer
        {
            get => mComposer;
            set { SetProperty(ref mComposer, value); }
        }

        [DataMember, ColumnDescription("Comment (if any)")]
        public string Comment
        {
            get => mComment;
            set { SetProperty(ref mComment, value); }
        }

        [DataMember, StringLength(512), ColumnDescription("Path of the Track (MP3/MP4) in file system (if appropriate).")]
        public string Path
        {
            get => mPath;
            set { SetProperty(ref mPath, value); }
        }

        [DataMember, ColumnDescription("Lyrics (if known)")]
        public string Lyrics
        {
            get => mLyrics;
            set { SetProperty(ref mLyrics, value); }
        }

        [DataMember, ColumnDescription("Publisher Name (if known).")]
        public string Publisher
        {
            get => mPublisher;
            set { SetProperty(ref mPublisher, value); }
        }
    }
}
