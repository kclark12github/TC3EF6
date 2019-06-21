using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes
{
    [DataContract, Table("Query"), TableDescription("Canned queries which can be run within the application.")]
    public partial class Query : DataEntityBase
    {
        #region "Locals"
        private string mName = string.Empty;
        private string mDescription = string.Empty;
        private string mQueryText = string.Empty;
        private short mAccess = 0;
        #endregion

        [DataMember, StringLength(250), ColumnDescription("Query Name.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, StringLength(250), ColumnDescription("Query Description.")]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); }
        }

        [DataMember, ColumnDescription("Query body.")]
        public string QueryText
        {
            get => mQueryText;
            set { SetProperty(ref mQueryText, value); }
        }

        [DataMember, ColumnDescription("Query Access."), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Access
        {
            get => mAccess;
            set { SetProperty(ref mAccess, value); }
        }
    }
}
