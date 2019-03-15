using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [TableDescription("Canned queries which can be run within the application.")]
    [Table("Query")]
    public partial class Query : DataEntityBase
    {
        #region "Locals"
        private string mName = string.Empty;
        private string mDescription = string.Empty;
        private string mQueryText = string.Empty;
        private short mAccess = 0;
        #endregion

        [ColumnDescription("Query Name.")]
        [StringLength(250)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [ColumnDescription("Query Description.")]
        [StringLength(250)]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); }
        }

        [ColumnDescription("Query body.")]
        public string QueryText
        {
            get => mQueryText;
            set { SetProperty(ref mQueryText, value); }
        }

        [ColumnDescription("Query Access.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Access
        {
            get => mAccess;
            set { SetProperty(ref mAccess, value); }
        }
    }
}
