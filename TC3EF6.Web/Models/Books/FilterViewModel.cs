using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TC3EF6.Web.Models.Books
{
    public class FilterViewModel
    {
        public string AlphaSort { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string MediaFormat { get; set; }
        public string ISBN { get; set; }
        public string Location { get; set; }

        public SelectList AuthorList { get; set; }
        public SelectList MediaFormatList { get; set; }
        public SelectList LocationList { get; set; }
    }
}