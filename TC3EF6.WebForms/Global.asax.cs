using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using TC3EF6.Data;
using TC3EF6.Data.Services;
using TC3EF6.Data.Services.SQL;
using TC3EF6.Domain.Classes;

namespace TC3EF6.WebForms
{
    public class Global : HttpApplication
    {
        static readonly object _object = new object();
        private void LogMessage(string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage((string)Application["AppName"], Message);
            }
        }
        //protected void Application_Start()
        //{
        //    LogMessage($"Application_Start()");
        //}
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["AppName"] = "TC3EF6.WebForms";
            Application["Owner"] = "kfc12@comcast.net";
            Application["WebMaster"] = "Ken Clark";
            Application["WebMasterEmail"] = Application["Owner"];
            LogMessage($"Application_Start(object sender, EventArgs e)");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_OnStart()
        //{
        //    LogMessage($"Application_OnStart()");
        //}
        //protected void Application_OnStart(object sender, EventArgs e)
        //{
        //    LogMessage($"Application_OnStart(object sender, EventArgs e)");
        //}
        //protected void Application_End()
        //{
        //    LogMessage($"Application_End()");
        //}
        protected void Application_End(object sender, EventArgs e)
        {
            LogMessage($"Application_End(object sender, EventArgs e)");
        }
        //protected void Application_OnEnd()
        //{
        //    LogMessage($"Application_OnEnd()");
        //}
        //protected void Application_OnEnd(object sender, EventArgs e)
        //{
        //    LogMessage($"Application_OnEnd(object sender, EventArgs e)");
        //}
        //protected void Session_Start()
        //{
        //    LogMessage($"Session_Start()");
        //}
        protected void Session_Start(object sender, EventArgs e)
        {
            LogMessage($"Session_Start(object sender, EventArgs e)");
            lock (_object)
            {
                if (Application["ActiveSessions"] == null) Application["ActiveSessions"] = 0;
                int Count = (int)Application["ActiveSessions"];
                Count += 1;
                Application["ActiveSessions"] = Count;
                using (var context = new TCContext())
                {   //We may not know the Visitor.Email yet, but update the HitCount now...
                    string appName = (string)Application["AppName"];
                    AppState appState = context.AppStates.Where(a => a.AppName == appName).SingleOrDefault();
                    if (appState == null)
                    {
                        var VisitCount = context.Visitors.Sum(v => v.Visits);
                        appState = new AppState { AppName = appName, HitCount = VisitCount, LastVisitor = "Anonymous", DateLastVisit = DateTime.Now };
                        context.AppStates.Add(appState);
                    }
                    appState.HitCount += 1;
                    context.SaveChanges();
                    Application["HitCount"] = appState.HitCount;
                }
            }
        }
        //protected void Session_OnStart()
        //{
        //    LogMessage($"Session_OnStart()");
        //}
        //protected void Session_OnStart(object sender, EventArgs e)
        //{
        //    LogMessage($"Session_OnStart(object sender, EventArgs e)");
        //}
        //protected void Session_End()
        //{
        //    LogMessage($"Session_End()");
        //}
        protected void Session_End(object sender, EventArgs e)
        {
            LogMessage($"Session_End(object sender, EventArgs e)");
            lock (_object)
            {
                if (Application["ActiveSessions"] == null)
                    Application["ActiveSessions"] = 0;
                else
                {
                    int Count = (int)Application["ActiveSessions"];
                    Count -= 1;
                    Application["ActiveSessions"] = Count;
                }
            }
        }
        //protected void Session_OnEnd()
        //{
        //    LogMessage($"Session_OnEnd()");
        //}
        //protected void Session_OnEnd(object sender, EventArgs e)
        //{
        //    LogMessage($"Session_OnEnd(object sender, EventArgs e)");
        //}
    }
}