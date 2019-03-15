using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TC3EF6.Base;
using TC3EF6.Data.Services.SQL;

namespace TC3EF6.Web.Models
{
    public class ModelBase
    {
        private readonly string mConnectionString = string.Empty;
        private readonly string mCopyright = string.Empty;
        private readonly string mCopyrightLabel = string.Empty;
        private readonly string mDescription = string.Empty;
        private readonly string mProduct = string.Empty;
        private readonly string mTitle = string.Empty;
        private readonly string mTrademark = string.Empty;
        public ModelBase()
        {
            TCBase mTCBase = new TCBase();
            mCopyright = mTCBase.Copyright;
            mCopyright = $"{mTCBase.Copyright} - {mTCBase.Product}";
            mDescription = mTCBase.Description;
            mProduct = mTCBase.Product;
            mTitle = mTCBase.Title;
            mTrademark = mTCBase.Trademark;
        }
        public string ConnectionString { get => mConnectionString; }
        public string Copyright { get => mCopyright; }
        public string CopyrightLabel { get => mCopyrightLabel; }
        public string Description { get => mDescription; }
        public string Database { get; set; }
        public string Title { get => mTitle; }
        public string Trademark { get => mTrademark; }
        public string Product { get => mProduct; }
        public string User { get; set; }
    }
}