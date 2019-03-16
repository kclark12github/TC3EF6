using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TC3EF6.Data;
using TC3EF6.Data.Services.SQL;
using TC3EF6.Web.Models;

namespace TC3EF6.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private IDbContext _dbContext;
        public IDbContext DbContext
        {
            get { return _dbContext ?? HttpContext.GetOwinContext().Get<TCContext>(); }
            private set { _dbContext = value; }
        }
        public HomeController() { }
        public HomeController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            string database = string.Empty;
            string user = string.Empty;
            if (!string.IsNullOrEmpty(User.Identity.Name)) {
                user = $"User ID: {User.Identity.Name}";
                string ConnectionString = ConfigurationManager.ConnectionStrings["TC3EF6Context"].ToString();
                SQLUtilities utilities = new SQLUtilities();
                database = $"Database: {utilities.ParseConnectionString(ConnectionString, SQLUtilities.ConnectionStringParts.Database)}";
            }
            var model = new IndexModel {
                User = user,
                Database = database
            };
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var model = new AboutModel();
            return View(model);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var model = new ContactModel();
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null) _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}