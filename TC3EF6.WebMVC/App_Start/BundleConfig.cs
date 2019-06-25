using System.Web;
using System.Web.Optimization;

namespace TC3EF6.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/otf").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/otf.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/umd/popper.js",
                      "~/Scripts/umd/popper-utils.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/fontawesome/css/all.css", //Bootstrap v4 dropped support for glyphicons, so we're using fontawesome below...
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));
            //https://www.codeproject.com/Articles/1114208/Beginners-Guide-for-Creating-GridView-in-ASP-NET-M
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/DataTables/dataTables.buttons.js",
                        "~/Scripts/DataTables/buttons.bootstrap4.js",
                        "~/node_modules/jszip/dist/jszip.js",
                        "~/node_modules/pdfmake/build/pdfmake.js",
                        "~/node_modules/pdfmake/build/vfs_fonts.js",
                        "~/Scripts/DataTables/buttons.colVis.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/buttons.print.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      //"~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/buttons.bootstrap4.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css"
                      ));
        }
    }
}
