using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TC3EF6.Data;
using TC3EF6.Domain.Classes.Stash;
using System.Collections;
using PagedList;
using TC3EF6.Domain.Classes;
using TC3EF6.Data.Services;

namespace TC3EF6.Web.Controllers
{
    //[Authorize]
    public class BooksController : Controller
    {
        private TCContext db = new TCContext();
        private IImageRepository<Book> repo = new SqlImageRepository<Book>();
        // GET: Books
        //public async Task<ActionResult> Index(string currentFilter, string searchString, int? page)
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var books = repo.GetAll(string.Empty, "AlphaSort");
            if (!String.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString)) {
                books = books.Where(b => b.AlphaSort.Contains(searchString)
                                       || b.Title.Contains(searchString)
                                       || b.Author.Contains(searchString)
                                       || b.MediaFormat.Contains(searchString)
                                       || b.ISBN.Contains(searchString)
                                       || b.Location.Name.Contains(searchString)
                                       || b.Misc.Contains(searchString)
                                       );
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Description");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AlphaSort,Author,MediaFormat,ISBN,Misc,Subject,Title,Cataloged,DateInventoried,DatePurchased,DateVerified,LocationID,Notes,Price,Value,WishList,OID,DateCreated,DateModified,RowID")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.ID = Guid.NewGuid();
                db.Books.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Description", book.LocationID);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Description", book.LocationID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AlphaSort,Author,MediaFormat,ISBN,Misc,Subject,Title,Cataloged,DateInventoried,DatePurchased,DateVerified,LocationID,Notes,Price,Value,WishList,OID,DateCreated,DateModified,RowID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Description", book.LocationID);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Book book = await db.Books.FindAsync(id);
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
