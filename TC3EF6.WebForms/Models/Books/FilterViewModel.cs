using System;
using System.ComponentModel.DataAnnotations;

namespace TC3EF6.WebForms.Models.Books
{
    public class FilterViewModel
    {
        public string AlphaSort { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string MediaFormat { get; set; }
        public string ISBN { get; set; }
        public string Location { get; set; }

        //SelectList is defined in System.Web.Mvc...
        //public SelectList AuthorList { get; set; }
        //public SelectList MediaFormatList { get; set; }
        //public SelectList LocationList { get; set; }
    }
}