using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TC3EF6.WebAPI.Models
{
    public class BooksViewModel
    {
        public int ID { get; set; }
        public string AlphaSort { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string MediaFormat { get; set; }
        public string ISBN { get; set; }
        public string Location { get; set; }
    }
}