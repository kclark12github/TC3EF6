using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace TC3EF6.WebForms
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Standard WebForms Bundles
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            #endregion

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            #region Stolen from the TC3EFC2.WebMVC project to support Ajax...
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //             "~/Scripts/jquery-{version}.js"
            //             //,"~/Scripts/jquery-ui-{version}.js"
            //             //,"~/Scripts/jquery.unobtrusive*"
            //             //,"~/Scripts/jquery.validate*"
            //             //,"~/Scripts/otf.js"
            //             ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));
            #endregion
            #region Stolen from the TC3EFC2.WebMVC project to support DataTables...
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/umd/popper.js",
                      "~/Scripts/umd/popper-utils.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                    //Bootstrap v4 dropped support for glyphicons, so we're using fontawesome below...
                                                                    //"~/Content/fontawesome/css/all.css",    //Using fontawesome from the bundle isn't working, so we're using explicit style tags...
                      "~/Content/fontawesome-5.9.0/css/all.css",    //Manually Downloaded from https://fontawesome.com/download and unzipped into this location...
                      "~/Content/site.css"
                      ));
            //https://www.codeproject.com/Articles/1114208/Beginners-Guide-for-Creating-GridView-in-ASP-NET-M
            //Install Jquery.DataTables using NuGet
            //npm install pdfmake
            //npm install jszip
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/DataTables/dataTables.buttons.js",
                        "~/Scripts/DataTables/buttons.bootstrap4.js",
                        "~/Scripts/jszip/dist/jszip.js",            //Used for Exporting as Zip
                        "~/Scripts/pdfmake/pdfmake.js",             //Used for Exporting as PDF
                        "~/Scripts/pdfmake/vfs_fonts.js",           //Used for Exporting as PDF
                        "~/Scripts/DataTables/buttons.colVis.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/buttons.print.js",
                        //"render.moment" was supposed to format dates, but didn't work with MS date formats, so we're using in-line JS code instead.
                        //"~/Scripts/DataTables/plug-ins/dataRender/datetime.js",   
                        "~/Scripts/DataTables/dataTables.responsive.js",
                        "~/Scripts/DataTables/dataTables.colReorder.js"
                        ));
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      //"~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/buttons.bootstrap4.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css"
                      ));
            #endregion
        }
    }
}