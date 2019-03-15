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
        IDbContext db = new TCContext();
        public ActionResult Index()
        {
            string database = string.Empty;
            string user = string.Empty;
            if (!string.IsNullOrEmpty(User.Identity.Name)) {
                user = $"User ID: {User.Identity.Name}";
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
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
            if (db != null) db.Dispose();
            base.Dispose(disposing);
        }
    }
}