using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Data;
using TC3EF6.Data.Services;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Stash;

using System.Linq.Dynamic;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;

namespace TC3EF6
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLocations();
            //TestBooks();
            //TestMusic();
            //TestEpisodes();
            //TestGroupByComprehension();
            //TestGroupByFluent();
            //TestJoinComprehension();
            //TestJoinFluent();
            //TestDynamic();
            //TestFind();
            //TestFindWithImages();
            //TestDynamicGet();
            TestAppState();

            if (Debugger.IsAttached)
            {
                Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine();
            }
        }
        static void TestAppState()
        {
            using (var context = new TCContext())
            {   //We may not know the Visitor.Email yet, but update the HitCount now...
                string appName = "TC3EF6.WebForms";
                AppState appState = context.AppStates.Where(a => a.AppName == appName).SingleOrDefault();
                if (appState == null)
                {
                    var VisitCount = context.Visitors.Sum(v => v.Visits);
                    appState = new AppState { AppName = appName, HitCount = VisitCount, LastVisitor = "Anonymous", DateLastVisit = DateTime.Now };
                    context.AppStates.Add(appState);
                }
                appState.HitCount += 1;
                context.SaveChanges();
            }
        }
        static void TestLocations()
        {
            //private SqlStashRepository<Book> _repo = new SqlRepository<Book>();
            using (var context = new TCContext())
            {
                //decal = context.Decals.Find(1);
                //decal = context.Decals.Where(d => d.ID == 1).Include(d => d.Location).FirstOrDefault();
                //context.SaveChanges();
                var locations = context.Locations.OrderBy(l => l.Name).ToList();
                //var query = context.Samurais;
                //var samuraisAgain = query.ToList();
                foreach (var location in locations)
                {
                    Console.WriteLine(location.Name);
                }
            }
        }
        static async void TestBooks()
        {
            IImageRepository<Book> _repos = new SqlImageRepository<Book>();
            IQueryable<Book> query = null;
            query = await _repos.FindByAsync(b => b.MediaFormat == "MM Paperback" && b.AlphaSort.StartsWith("DUNE:"), b => b.Location);
            var data = query.Select(s => new { s.OID, s.Title, s.Author, s.Location.Name, s.Location.PhysicalLocation })
                .ToList();
            foreach (var datum in data)
            {
                Console.WriteLine("{0}\t{1:40} by {2}; in {3} @ {4}", datum.OID, datum.Title, datum.Author, datum.Name, datum.PhysicalLocation);
            }
            Console.WriteLine();
            Console.ReadKey();

            query = await _repos.GetAllAsync("MediaFormat=\"MM Paperback\"");
            data = query.Select(s => new { s.OID, s.Title, s.Author, s.Location.Name, s.Location.PhysicalLocation }).ToList();
            foreach (var datum in data)
            {
                Console.WriteLine("{0}\t{1:40} by {2}; in {3} @ {4}", datum.OID, datum.Title, datum.Author, datum.Name, datum.PhysicalLocation);
            }
            Console.WriteLine();
            var book = _repos.FindByAsync(Guid.Parse("4443CD01-0D28-E911-9C25-001583F52824"));
            Console.WriteLine(book);
            book = _repos.FindByAsync(Guid.Parse("3333CD01-0D28-E911-9C25-001583F52824"));
            Console.WriteLine(book);


            //IEnumerable<Book> books =
            //    from b in context.Books
            //    where ((DateTime)b.DateInventoried).Year > 2018
            //        && b.MediaFormat == "Kindle"
            //    //orderby b.Reviews.Average(r => r.Rating) descending
            //    orderby b.OID ascending
            //    select b;
            //foreach (Book book in books)
            //{
            //    Console.WriteLine(book.Title);
            //}
            //Console.WriteLine();
        }
        static void TestQueryMusic()
        {
            using (var context = new TCContext())
            {
                //Select Music.ID,Music.OID,Title,Artist,Year,Count(*)
                //From Music
                //  Left Outer Join History On TableName = 'Music' And RecordID = Music.ID
                //Group By Music.ID,Music.OID,Title,Artist,Year
                //Order By 6 Desc;
                //Select* From History Where RecordID = '3EF47857-2127-E911-9C25-001583F52824';
                var data = context.Albums
                    .OrderByDescending(m => m.Year)
                    .Where(m => m.Artist == "Genesis" && m.MediaFormat == "MP3")
                    .Select(m => new { m.OID, m.Title, m.Artist, m.Year })
                    .ToList();
                foreach (var datum in data)
                {
                    Console.WriteLine("{0}\t{1:D4}\t{2:40} by {3}", datum.OID, datum.Year, datum.Title, datum.Artist);
                }
                Console.WriteLine();
            }
        }
        static void TestQueryComprehension()
        {
            //"Composition/Comprehension" Syntax
            var q1Data =
                from e in new TCContext().Episodes
                    //let lsubject = e.Subject.ToLower()
                    //where lsubject == "comedy"
                where e.Subject == "Comedy"
                orderby e.Series ascending, e.DateReleased descending
                select e;
            foreach (var d in q1Data)
            {
                Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.OID, d.Series, d.Title, d.DateReleased);
            }
            Console.WriteLine();
        }
        static async void TestQueryFluent()
        {
            IQueryable<Episode> query = null;
            //Fluent Syntax (Extension Methods/Lambda Expresion) Syntax
            query = await new SqlImageRepository<Episode>().GetAllAsync();
            var q2Data = query.Where(e => e.Subject == "Comedy")
                .OrderByDescending(e => e.DateReleased)
                .OrderBy(e => e.Series);
            foreach (var d in q2Data)
            {
                Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.OID, d.Series, d.Title, d.DateReleased);
            }
            Console.WriteLine();
        }
        static void TestGroupByComprehension()
        {
            Console.WriteLine("[TestGroupByComprehension]");
            Console.WriteLine("Group By Demo using Comprehension Syntax...");
            var q1Data =
                from e in new TCContext().Episodes
                orderby e.MediaFormat
                let year = ((DateTime)e.DateReleased).Year
                where e.Subject == "Comedy"
                group e by year into yearGroup
                orderby yearGroup.Key ascending
                select yearGroup;
            foreach (var g in q1Data)
            {
                Console.WriteLine("\n{0}", g.Key);
                foreach (var d in g)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            Console.WriteLine("\nGroup By with a Composite Key...");
            var q2Data =
                from e in new TCContext().Episodes
                let year = ((DateTime)e.DateReleased).Year
                where e.Subject == "Comedy"
                group e by new { year, e.MediaFormat }
                    into yearGroup
                orderby yearGroup.Key.year descending, yearGroup.Key.MediaFormat ascending
                select yearGroup;
            foreach (var g in q2Data)
            {
                Console.WriteLine("\n{0} - {1} ({2})", g.Key.year, g.Key.MediaFormat, g.Count());
                foreach (var d in g)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            Console.WriteLine("\nGrouping and Projecting...");
            var q3Data =
                from e in new TCContext().Episodes
                let year = ((DateTime)e.DateReleased).Year
                where e.Subject == "Comedy"
                group e by new { year, e.MediaFormat }
                    into yearGroup
                where yearGroup.Key.MediaFormat != "DVD"
                orderby yearGroup.Key.year descending, yearGroup.Key.MediaFormat ascending
                select new
                {
                    Year = yearGroup.Key.year,
                    Format = yearGroup.Key.MediaFormat,
                    Count = yearGroup.Count(),
                    Group = yearGroup
                };
            foreach (var g in q3Data)
            {
                Console.WriteLine("\n{0} - {1} ({2})", g.Year, g.Format, g.Count);
                foreach (var d in g.Group)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.WriteLine();
        }
        static async void TestGroupByFluent()
        {
            IQueryable<Episode> query = null;
            Console.WriteLine("[TestGroupByFluent]");
            Console.WriteLine("Group By Demo using Fluent Syntax...");
            query = await new SqlImageRepository<Episode>().GetAllAsync();
            var q1Data = query.Where(e => e.Subject == "Comedy")
                .OrderBy(e => e.MediaFormat)
                .GroupBy(e => new { ((DateTime)e.DateReleased).Year })
                .OrderBy(g => g.Key.Year)
                .Select(g => g);
            foreach (var g in q1Data)
            {
                Console.WriteLine("\n{0}", g.Key.Year);
                foreach (var d in g)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            Console.WriteLine("\nGroup By with a Composite Key...");
            query = await new SqlImageRepository<Episode>().GetAllAsync();
            var q2Data = query.Where(e => e.Subject == "Comedy")
                .Where(e => e.Subject == "Comedy")
                .OrderBy(e => e.MediaFormat)
                .GroupBy(e => new { year = ((DateTime)e.DateReleased).Year, e.MediaFormat })
                .OrderBy(g => g.Key.MediaFormat)
                .OrderByDescending(g => g.Key.year);
            foreach (var g in q2Data)
            {
                Console.WriteLine("\n{0} - {1} ({2})", g.Key.year, g.Key.MediaFormat, g.Count());
                foreach (var d in g)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            Console.WriteLine("\nGrouping and Projecting...");
            query = await new SqlImageRepository<Episode>().GetAllAsync();
            var q3Data = query.Where(e => e.Subject == "Comedy")
                .OrderBy(e => e.MediaFormat)
                .GroupBy(e => new { year = ((DateTime)e.DateReleased).Year, e.MediaFormat })
                .OrderBy(g => g.Key.MediaFormat)
                .OrderByDescending(g => g.Key.year)
                .Select(g => new {
                    Year = g.Key.year,
                    Format = g.Key.MediaFormat,
                    Count = g.Count(),
                    Group = g
                });
            foreach (var g in q3Data)
            {
                Console.WriteLine("\n{0} - {1} ({2})", g.Year, g.Format, g.Count);
                foreach (var d in g.Group)
                {
                    Console.WriteLine("{0}\t{1:40}\t{2:40}\t{3:MM/dd/yyyy}", d.MediaFormat, d.Series, d.Title, d.DateReleased);
                }
            }
            Console.WriteLine();
        }
        static void TestJoinComprehension()
        {
            Console.WriteLine("[TestJoinComprehension]");
            TCContext context = new TCContext();
            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Inner Join Images On Images.RecordID = Kits.ID
            //Where Type = 'Ship' And ProductCatalog = 'Pacific Front Hobbies' And Scale = '1/700'
            //Order By Scale, Designation, Kits.Name;
            Console.WriteLine("Join (inner) Demo using Comprehension Syntax...");
            var q1Data =
                from k1 in context.Kits
                join i1 in context.Images on k1.ID equals i1.RecordID
                where k1.Type == "Ship" && k1.ProductCatalog == "Pacific Front Hobbies" && k1.Scale == "1/700"
                orderby k1.Designation ascending, k1.Name ascending
                select new { k1, caption = i1.Caption };
            int iCount = 1;
            foreach (var j in q1Data)
            {
                Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-20}{5}", iCount, j.k1.Type, j.k1.Manufacturer, j.k1.Scale, j.k1.Location.Name, j.caption);
                iCount++;
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Left Join Images On Images.RecordID = Kits.ID
            //Where Type = 'Ship' And ProductCatalog = 'Pacific Front Hobbies' And Scale = '1/700'
            //Order By Scale, Designation, Kits.Name;
            Console.WriteLine("Group Join Demo using Comprehension Syntax [Technique to approximate Outer Joins]...");
            var q2Data =
                from k2 in context.Kits
                join i2 in context.Images on k2.ID equals i2.RecordID into kitsWithImages
                from ki in kitsWithImages.DefaultIfEmpty()
                where k2.Type == "Ship" && k2.ProductCatalog == "Pacific Front Hobbies" && k2.Scale == "1/700"
                orderby k2.Designation ascending, k2.Name ascending
                select new { k2, caption = ki.Caption };
            iCount = 1;
            foreach (var j in q2Data)
            {
                Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-20}{5}", iCount, j.k2.Type, j.k2.Manufacturer, j.k2.Scale, j.k2.Location.Name, j.caption);
                iCount++;
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");
        }
        static void TestJoinFluent()
        {
            Console.WriteLine("[TestJoinFluent]");
            TCContext context = new TCContext();
            Console.WriteLine("Join Demo using Fluent Syntax...");
            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Inner Join Images On Images.RecordID = Kits.ID
            //Where Type = 'Ship' And ProductCatalog = 'Pacific Front Hobbies' And Scale = '1/700'
            //Order By Scale, Designation, Kits.Name;
            var q1Data = context.Kits   // outer collection
                .Join(context.Images,   // inner collection
                    k => k.ID,          // outer key selector
                    i => i.RecordID,    // inner key selector
                    (k, i) => new { kit = k, image = i }) // result selector 
                .Where(j => (j.kit.Type == "Ship" && j.kit.ProductCatalog == "Pacific Front Hobbies" && j.kit.Scale == "1/700"))
                .OrderBy(j => j.kit.Designation).ThenBy(j => j.kit.Name)
                .Select(j => j);
            int iCount = 1;
            foreach (var j in q1Data)
            {
                Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-20}{5}", iCount, j.kit.Type, j.kit.Manufacturer, j.kit.Scale, j.kit.Location.Name, j.image.Caption);
                iCount++;
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");

            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Left Join Images On Images.RecordID = Kits.ID
            //Where Type = 'Ship' And ProductCatalog = 'Pacific Front Hobbies' And Scale = '1/700'
            //Order By Scale, Designation, Kits.Name;
            Console.WriteLine("Group Join Demo using Fluent Syntax [Technique to approximate Outer Joins]...");
            var q2Data =
                context.Kits
                    .SelectMany(
                        k => context.Images.Where(i => k.ID == i.RecordID).DefaultIfEmpty(),
                        (k, i) => new { kit = k, image = i })
                    .Where(j => (j.kit.Type == "Ship" && j.kit.ProductCatalog == "Pacific Front Hobbies" && j.kit.Scale == "1/700"))
                    .OrderBy(j => j.kit.Designation).ThenBy(j => j.kit.Name)
                    .Select(j => j);
            iCount = 1;
            foreach (var j in q2Data)
            {
                Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-20}{5}", iCount, j.kit.Type, j.kit.Manufacturer, j.kit.Scale, j.kit.Location.Name, j.image == null ? "[Null]" : j.image.Caption);
                iCount++;
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");
        }
        static async void TestDynamic()
        {
            IQueryable<Kit> query = null;
            Console.WriteLine("[TestDynamic]");
            Console.WriteLine("Dynamic Query Demo using Fluent Syntax...");
            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Inner Join Images On Images.RecordID = Kits.ID
            //Where Type = 'SciFi: Star Wars' And Manufacturer = 'BANDAI' And Scale = '1/72'
            //Order By Scale,Designation,Kits.Name;
            Console.WriteLine("Join Demo using Extension Methods (and System.Linq.Dynamic extensions)...");
            query = await new SqlImageRepository<Kit>().GetAllAsync();
            var q1Data = query.Where("Type=\"SciFi: Star Wars\" && Manufacturer=\"BANDAI\" && Scale=\"1/72\"")
                .OrderBy("Designation,Name");
            foreach (var j in q1Data)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", j.Scale, j.Designation, j.Name, j.Location.Name);
            }
        }
        static async void TestFind()
        {
            IImageRepository<Kit> repo = new SqlImageRepository<Kit>();
            var kit = await repo.FindByAsync(Guid.Parse("C2DD8FEC-4C27-E911-9C25-001583F52824"));
            Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-40}{5,-20}", 1, kit.Type, kit.Manufacturer, kit.Scale, kit.Name, kit.Location.Name);//, j.image == null ? "[Null]" : j.image.Caption);
        }
        static async void TestFindWithImages()
        {
            IImageRepository<Kit> repo = new SqlImageRepository<Kit>();
            var kit2 = await repo.FindByIDWithImagesAsync(Guid.Parse("C2DD8FEC-4C27-E911-9C25-001583F52824"));
            Console.WriteLine("{0,3}) {1,-6}{2,-20}{3,-10}{4,-40}{5,-20} Image Count: {6,3}", 1, kit2.Type, kit2.Manufacturer, kit2.Scale, kit2.Name, kit2.Location.Name, kit2.Images.Count);
        }
        static void TestValidations()
        {
            //Sample of using Rules List for Validation...
            Book book = new Book();
            var bookValidationRules = new List<Func<Book, bool>>()
            {
                b => !String.IsNullOrEmpty(b.Title),
                b => !String.IsNullOrEmpty(b.Author)
            };
            bool isBookValid = bookValidationRules.All(rule => rule(book));
        }

        private async static void TestDynamicGet()
        {
            IImageRepository<Kit> repos = new SqlImageRepository<Kit>();
            Console.WriteLine("[TestDynamicGet]");
            Console.WriteLine("Dynamic Query Demo using Repository...");
            //Select*
            //From Kits
            //    Inner Join Locations On Locations.ID = Kits.LocationID
            //    Inner Join Images On Images.RecordID = Kits.ID
            //Where Type = 'SciFi: Star Wars' And Manufacturer = 'BANDAI' And Scale = '1/72'
            //Order By Scale,Designation,Kits.Name;
            var q1Data = await repos.GetAllAsync(
                    "Type=\"SciFi: Star Wars\" && Manufacturer=\"BANDAI\" && Scale=\"1/72\"",
                    "Designation,Name");
            int iCount = 1;
            Console.WriteLine("{0,3}  {1,-20} {2,-20} {3,-10} {4,-20} {5,-3}", "Row", "Type", "Manufacturer", "Scale", "Location", "Images");
            foreach (var kit in q1Data)
            {
                kit.Images = await repos.GetImagesAsync(kit);
                Console.WriteLine("{0,3}) {1,-20} {2,-20} {3,-10} {4,-20} {5,-3}", iCount, kit.Type, kit.Manufacturer, kit.Scale, kit.Location.Name, kit.Images.Count);
                iCount++;
            }
            Console.Write("\nPress any key to continue . . ."); Console.ReadKey(true); Console.WriteLine("\n");
        }
    }
}
