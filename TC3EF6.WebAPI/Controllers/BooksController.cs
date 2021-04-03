using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TC3EF6.Data;
using TC3EF6.Data.Services;
using TC3EF6.Domain.Classes.Stash;
using TC3EF6.WebAPI.Models;

namespace TC3EF6.WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        public IHttpActionResult GetAllBooks()
        {
            IList<BooksViewModel> books = null;
            SqlImageRepository<Book> repo = null;
            try {
                repo = new SqlImageRepository<Book>();
                books = repo.GetAll().Select(b => new BooksViewModel()
                {
                    ID = (int)b.OID,
                    AlphaSort = b.AlphaSort,
                    Title = b.Title,
                    Author = b.Author,
                    MediaFormat = b.MediaFormat,
                    ISBN = b.ISBN,
                    Location = b.Location.Name
                }).ToList<BooksViewModel>();
            }
            finally {
                if (repo != null) repo = null;
            }
            if (books.Count == 0) {
                return NotFound();
            }
            return Ok(books);
        }
        public IHttpActionResult GetBookByID(int id)
        {
            IList<BooksViewModel> books = null;
            SqlImageRepository<Book> repo = null;
            try {
                repo = new SqlImageRepository<Book>();
                books = repo.GetAll($"OID={id}").Select(b => new BooksViewModel()
                {
                    ID = (int)b.OID,
                    AlphaSort = b.AlphaSort,
                    Title = b.Title,
                    Author = b.Author,
                    MediaFormat = b.MediaFormat,
                    ISBN = b.ISBN,
                    Location = b.Location.Name
                }).ToList<BooksViewModel>();
            }
            finally {
                if (repo != null) repo = null;
            }
            if (books.Count == 0) {
                return NotFound();
            }
            return Ok(books);
        }
        public IHttpActionResult GetAllBooksByAuthor(string author, string format)
        {
            IList<BooksViewModel> books = null;
            SqlImageRepository<Book> repo = null;
            try
            {
                repo = new SqlImageRepository<Book>();
                var query = repo.FindBy(b => b.MediaFormat==format && b.Author.Contains(author), b => b.Location);
                books = query.Select(b => new BooksViewModel()
                {
                    ID = (int)b.OID,
                    AlphaSort = b.AlphaSort,
                    Title = b.Title,
                    Author = b.Author,
                    MediaFormat = b.MediaFormat,
                    ISBN = b.ISBN,
                    Location = b.Location.Name
                }).ToList<BooksViewModel>();
            }
            finally
            {
                if (repo != null) repo = null;
            }
            if (books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }
        public IHttpActionResult GetAllBooksByAlphaSort(string alphaSort)
        {
            IList<BooksViewModel> books = null;
            SqlImageRepository<Book> repo = null;
            try {
                repo = new SqlImageRepository<Book>();
                var query = repo.FindBy(b => b.AlphaSort.Contains(alphaSort), b => b.Location);
                books = query.Select(b => new BooksViewModel()
                {
                    ID = (int)b.OID,
                    AlphaSort = b.AlphaSort,
                    Title = b.Title,
                    Author = b.Author,
                    MediaFormat = b.MediaFormat,
                    ISBN = b.ISBN,
                    Location = b.Location.Name
                }).ToList<BooksViewModel>();
            }
            finally {
                if (repo != null) repo = null;
            }
            if (books.Count == 0) {
                return NotFound();
            }
            return Ok(books);
        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}
        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
