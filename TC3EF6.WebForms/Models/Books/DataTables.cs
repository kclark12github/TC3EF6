using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TC3EF6.Domain.Classes.Stash;

namespace TC3EF6.WebForms.Models.Books
{
    public class DataTables
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<Book> Data { get; set; }
    }
}