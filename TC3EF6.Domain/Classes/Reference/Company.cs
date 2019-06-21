using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract, Table("Companies"), TableDescription("Hobby supply company address book.")]
    public partial class Company : ImageEntityBase
    {
        #region "Locals"
        private string mWebSite = string.Empty;
        private string mShortName = string.Empty;
        private string mProductType = string.Empty;
        private string mPhone = string.Empty;
        private string mName = string.Empty;
        private string mCode = string.Empty;
        private string mAccount = string.Empty;
        private string mAddress = string.Empty;
        #endregion

        [DataMember, StringLength(32), ColumnDescription("Account number for ordering from this company.")]
        public string Account
        {
            get => mAccount;
            set { SetProperty(ref mAccount, value); }
        }

        [DataMember, ColumnDescription("Company mailing address.")]
        public string Address
        {
            get => mAddress;
            set { SetProperty(ref mAddress, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Company code.")]
        public string Code
        {
            get => mCode;
            set { SetProperty(ref mCode, value); }
        }

        [DataMember, StringLength(72), ColumnDescription("Full Company Name.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, StringLength(14), ColumnDescription("Company phone number."),
            Phone]
        public string Phone
        {
            get => mPhone;
            set { SetProperty(ref mPhone, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Type of hobby products supplied by this company.")]
        public string ProductType
        {
            get => mProductType;
            set { SetProperty(ref mProductType, value); }
        }

        [DataMember, StringLength(32), ColumnDescription("Company Short Name.")]
        public string ShortName
        {
            get => mShortName;
            set { SetProperty(ref mShortName, value); }
        }

        [DataMember, ColumnDescription("Company web site.")]
        public string WebSite
        {
            get => mWebSite;
            set { SetProperty(ref mWebSite, value); }
        }
    }
}
