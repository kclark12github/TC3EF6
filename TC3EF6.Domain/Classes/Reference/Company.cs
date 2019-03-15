using System.ComponentModel.DataAnnotations;
using TC3EF6.Domain.Annotations;
namespace TC3EF6.Domain.Classes.Reference
{
    [TableDescription("Hobby supply company address book.")]
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

        [ColumnDescription("Account number for ordering from this company.")]
        [StringLength(32)]
        public string Account
        {
            get => mAccount;
            set { SetProperty(ref mAccount, value); }
        }

        [ColumnDescription("Company mailing address.")]
        public string Address
        {
            get => mAddress;
            set { SetProperty(ref mAddress, value); }
        }

        [ColumnDescription("Company code.")]
        [StringLength(32)]
        public string Code
        {
            get => mCode;
            set { SetProperty(ref mCode, value); }
        }

        [ColumnDescription("Full Company Name.")]
        [StringLength(72)]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [ColumnDescription("Company phone number.")]
        [StringLength(14)]
        [Phone]
        public string Phone
        {
            get => mPhone;
            set { SetProperty(ref mPhone, value); }
        }

        [ColumnDescription("Type of hobby products supplied by this company.")]
        [StringLength(32)]
        public string ProductType
        {
            get => mProductType;
            set { SetProperty(ref mProductType, value); }
        }

        [ColumnDescription("Company Short Name.")]
        [StringLength(32)]
        public string ShortName
        {
            get => mShortName;
            set { SetProperty(ref mShortName, value); }
        }

        [ColumnDescription("Company web site.")]
        public string WebSite
        {
            get => mWebSite;
            set { SetProperty(ref mWebSite, value); }
        }
    }
}
