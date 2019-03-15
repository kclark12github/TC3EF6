using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract]
    [TableDescription("Collection of Images both independent and those representing items tracked in the database.")]
    public class Image : DataEntityBase
    {
        #region "Locals"
        private string mName = string.Empty;
        private byte[] mImageContent = new byte[] { };
        private string mFileName = string.Empty;
        private string mURL = string.Empty;
        private int? mHeight = 0;
        private int? mWidth = 0;
        private string mCategory = string.Empty;
        private string mAlphaSort = string.Empty;
        private string mTableName = string.Empty;
        private Guid? mRecordID = Guid.Empty;
        private bool mThumbnail = false;
        private byte[] mThumbnailImage = new byte[] { };
        private string mCaption = string.Empty;
        private string mNotes = string.Empty;
        #endregion

        [DataMember]
        [ColumnDescription("Image Name.")]
        [StringLength(256)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember]
        [ColumnDescription("Actual Image binary.")]
        [Column("Image", TypeName = "image")]
        public byte[] ImageContent
        {
            get => mImageContent;
            set { SetProperty(ref mImageContent, value); }
        }

        [DataMember]
        [ColumnDescription("File system object from which this Image was imported.")]
        [StringLength(80)]
        public string FileName
        {
            get => mFileName;
            set { SetProperty(ref mFileName, value); }
        }

        [DataMember]
        [ColumnDescription("Internal web site providing this Image (if applicable).")]
        [StringLength(132)]
        public string URL
        {
            get => mURL;
            set { SetProperty(ref mURL, value); }
        }

        [DataMember]
        [ColumnDescription("Height in pixels of this Image.")]
        public int? Height
        {
            get => mHeight;
            set { SetProperty(ref mHeight, value); }
        }

        [DataMember]
        [ColumnDescription("Width in pixels of this Image.")]
        public int? Width
        {
            get => mWidth;
            set { SetProperty(ref mWidth, value); }
        }

        [DataMember]
        [ColumnDescription("Category of this Image.")]
        [StringLength(80)]
        public string Category
        {
            get => mCategory;
            set { SetProperty(ref mCategory, value); }
        }

        [DataMember]
        [ColumnDescription("Sort string.")]
        [StringLength(256)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember]
        [ColumnDescription("Table of the record related to this image.")]
        [Index("IX_ImageByRecord", 1)]
        [StringLength(32)]
        public string TableName
        {
            get => mTableName;
            set { SetProperty(ref mTableName, value); }
        }

        [DataMember]
        [ColumnDescription("Record ID of the record related to this image.")]
        [Index("IX_ImageByRecord", 2)]
        public Guid? RecordID
        {
            get => mRecordID;
            set { SetProperty(ref mRecordID, value); }
        }

        [DataMember]
        [ColumnDescription("Does this image represent the thumbnail of another, main image?")]
        public bool Thumbnail
        {
            get => mThumbnail;
            set { SetProperty(ref mThumbnail, value); }
        }

        [DataMember]
        [ColumnDescription("Thumbnail Image of this main image.")]
        [Column("ThumbnailImage", TypeName = "image")]
        public byte[] ThumbnailImage
        {
            get => mThumbnailImage;
            set { SetProperty(ref mThumbnailImage, value); }
        }

        [DataMember]
        [ColumnDescription("Image Caption.")]
        public string Caption
        {
            get => mCaption;
            set { SetProperty(ref mCaption, value); }
        }

        [DataMember]
        [ColumnDescription("Miscellaneous Notes.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }
    }
}
