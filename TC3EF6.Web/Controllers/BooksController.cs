using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
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
using DataTables.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TC3EF6.Base;
using TC3EF6.Web.Models.Books;

namespace TC3EF6.Web.Controllers
{
    //[Authorize]
    public class BooksController : Controller
    {
        //private TCContext db = new TCContext();
        //private IImageRepository<Book> repo = new SqlImageRepository<Book>();
        public BooksController() { }
        //private IImageRepository<Book> repo;
        //public IImageRepository<Book> Repository
        //{
        //    get { return repo ?? HttpContext.GetOwinContext().Get<IImageRepository<Book>>(); }
        //    private set { repo = value; }
        //}
        //public BooksController(IImageRepository<Book> repository)
        //{
        //    repo = repository;
        //}
        private IDbContext _dbContext;
        public IDbContext DbContext
        {
            get { return _dbContext ?? HttpContext.GetOwinContext().Get<TCContext>(); }
            private set { _dbContext = value; }
        }
        public BooksController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Book> Filter(IDataTablesRequest requestModel, FilterViewModel filterViewModel, IQueryable<Book> query, out int count)
        {
            #region Filtering
            if (!string.IsNullOrEmpty(requestModel.Search.Value))
            {
                //We were triggered from the Search box...
                var value = requestModel.Search.Value.Trim();
                query = query.Where(b => b.AlphaSort.Contains(value)
                                       || b.Title.Contains(value)
                                       || b.Author.Contains(value)
                                       || b.MediaFormat.Contains(value)
                                       || b.ISBN.Contains(value)
                                       || b.Location.Name.Contains(value)
                                    );
            }
            #region AdvancedSearch
            //If we are coming from our frmFilter dialog, filterViewModel may be populated...
            if (!string.IsNullOrEmpty(filterViewModel.AlphaSort))
                query = query.Where(b => b.AlphaSort.Contains(filterViewModel.AlphaSort));
            if (!string.IsNullOrEmpty(filterViewModel.Title))
                query = query.Where(b => b.Title.Contains(filterViewModel.Title));
            if (!string.IsNullOrEmpty(filterViewModel.Author))
                query = query.Where(b => b.Author.Contains(filterViewModel.Author));
            if (!string.IsNullOrEmpty(filterViewModel.MediaFormat))
                query = query.Where(b => b.MediaFormat.Contains(filterViewModel.MediaFormat));
            if (!string.IsNullOrEmpty(filterViewModel.ISBN))
                query = query.Where(b => b.ISBN.Contains(filterViewModel.ISBN));
            if (!string.IsNullOrEmpty(filterViewModel.Location))
                query = query.Where(b => b.Location.Name.Contains(filterViewModel.Location));
            #endregion
            count = query.Count();
            #endregion Filtering
            #region Sorting
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var orderByString = String.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Data) +
                  (column.SortDirection ==
                  Column.OrderDirection.Ascendant ? " asc" : " desc");
            }
            query = query.OrderBy(orderByString == string.Empty ? "AlphaSort asc" : orderByString);
            //query = Repository.OrderBy(query, orderByString == string.Empty ? "AlphaSort asc" : orderByString);
            #endregion Sorting
            return query;
        }

        public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, FilterViewModel filterViewModel)
        {
            //IQueryable<Book> query = Repository.GetAll(); 
            IQueryable<Book> query = Filter(requestModel, filterViewModel, DbContext.Books, out int filteredCount);
            query = query.Skip(requestModel.Start).Take(requestModel.Length);

            var data = query.Select(item => new {
                item.ID,
                item.AlphaSort,
                item.Title,
                item.Author,
                item.MediaFormat,
                item.ISBN,
                Location = item.Location.Name
            }).ToList();

            var TableCount = DbContext.Books.Count();
            var mTCBase = new TCBase();
            ViewBag.CopyrightLabel = $"{mTCBase.Copyright} - {mTCBase.Product}";
            return Json(new DataTablesResponse
                (requestModel.Draw, data, filteredCount, TableCount),
                JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Filter()
        {
            var filterViewModel = new FilterViewModel
            {
                //TODO: Authors is too big - must replace with some sort of auto-complete AJAX mechanism...
                AuthorList = new SelectList(DbContext.Books
                    .GroupBy(b => b.Author)
                    .Where(x => x.Key != null && !x.Key.Equals(string.Empty) && x.Key.ToUpper().Contains("MOORCOCK"))
                    .OrderBy(x => x.Key)
                    .Select(x => new { Author = x.Key }),
                "Author",
                "Author"),

                MediaFormatList = new SelectList(DbContext.Books
                    .GroupBy(b => b.MediaFormat)
                    .Where(x => x.Key != null && !x.Key.Equals(string.Empty))
                    .Select(x => new { MediaFormat = x.Key }),
                "MediaFormat",
                "MediaFormat"),

                LocationList = new SelectList(DbContext.Books
                    .GroupBy(b => b.Location.Name + " (" + b.Location.Description + ") @ " + b.Location.PhysicalLocation)
                    .Where(x => x.Key != null && !x.Key.Equals(string.Empty))
                    .Select(x => new { Location = x.Key }),
                "Location",
                "Location")
            };
            return View("_FilterPartial", filterViewModel);
        }
        // GET: Books
        //public async Task<ActionResult> Index(string currentFilter, string searchString, int? page)
        //public ActionResult Index(string currentFilter, string searchString, int? page)
        //{
        //    var books = repo.GetAll(string.Empty, "AlphaSort");
        //    if (!String.IsNullOrEmpty(searchString))
        //        page = 1;
        //    else
        //        searchString = currentFilter;
        //    ViewBag.CurrentFilter = searchString;
        //    if (!String.IsNullOrEmpty(searchString)) {
        //        books = books.Where(b => b.AlphaSort.Contains(searchString)
        //                               || b.Title.Contains(searchString)
        //                               || b.Author.Contains(searchString)
        //                               || b.MediaFormat.Contains(searchString)
        //                               || b.ISBN.Contains(searchString)
        //                               || b.Location.Name.Contains(searchString)
        //                               || b.Misc.Contains(searchString)
        //                               );
        //    }

        //    int pageSize = 25;
        //    int pageNumber = (page ?? 1);
        //    return View(books.ToPagedList(pageNumber, pageSize));
        //}
        public ActionResult Index()
        {
            //var books = repo.GetAll("Author==\"Terry Brooks\"", "AlphaSort");
            //return View(books.ToList());
            ViewBag.Title = "Books";
            var mTCBase = new TCBase();
            ViewBag.CopyrightLabel = $"{mTCBase.Copyright} - {mTCBase.Product}";
            return View();
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(_dbContext.Locations, "ID", "Description");
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
                _dbContext.Books.Add(book);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(_dbContext.Locations, "ID", "Description", book.LocationID);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(_dbContext.Locations, "ID", "Description", book.LocationID);
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
                _dbContext.Entry(book).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(_dbContext.Locations, "ID", "Description", book.LocationID);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await _dbContext.Books.FindAsync(id);
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
            Book book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null) _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
