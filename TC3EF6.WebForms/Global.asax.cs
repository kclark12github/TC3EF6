using ADODB;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            #region Classic ASP Stuff
            Application.Lock();
            //Application["ConnectionString"] = "Provider=MSDASQL.1;Persist Security Info=False;User ID=Admin;Data Source=C:\My Documents\Home Inventory\Database\Ken's Stuff.mdb; "
            Application["ConnectionString"] = ConfigurationManager.ConnectionStrings["adoTC3EF6"].ConnectionString;
            Application["RuntimeUserName"] = "";
            Application["RuntimePassword"] = "";
            Application["ConnectionTimeout"] = 120;
            Application["CommandTimeout"] = 120;
            Application["ActiveSessions"] = 0;
            Application["AdminPage"] = @"/Admin/Admin.asp";
            Application["ApplicationLogFilename"] = Server.MapPath(@"/Logs") + @"\Application.log";
            Application["DownloadPage"] = "/Admin/Download.asp";
            Application["ErrorLogFilename"] = Server.MapPath(@"/Logs") + @"\Error.log";
            Application["fDebugMode"] = true;
            Application["fTraceMode"] = true;
            Application["MaxTextDisplay"] = 56;
            Application["MinRowsForBottomButtons"] = 10;
            Application["RowsToDisplay"] = 50;
            Application["strFooterGIFdim"] = "width=60 height=59";
            Application["strFooterURL"] = "/";
            Application["strFooterTitle"] = "Back to Ken's Home Page";
            Application["strHomeGIF"] = "/Images/Buttons/home.gif";
            Application["Theme"] = "Blueside";
            Application["TraceLogFilename"] = Server.MapPath(@"/Logs") + @"\Trace.log";
            Application["VisitorCountFileName"] = Server.MapPath(@"/VisitCount.txt");
            Application["WelcomeCountFileName"] = Server.MapPath(@"/_private/Welcome.asp.cnt");

            Application.UnLock();
            #endregion
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
                    Application["Visitors"] = appState.HitCount;
                }
            }
            #region Classic ASP Stuff
            // *********************************************************************************************************
            // Update Counter...
            Application.Lock();
            Session["ID"] = Session.SessionID;
            string TraceLog = (string)Application["TraceLogFilename"];
            //TraceLog = Server.MapPath("/Logs") + "\Trace.log"
            Session.Timeout = 60;
            //Application["Visitors"] = Application["Visitors"] + 1;
            Session["VisitorNumber"] = Application["Visitors"];

            LogMessage($"Session_Start: Beginning session for Visitor #{Session["VisitorNumber"]} (ID: {Session["ID"]}) - Active Sessions: {Application["ActiveSessions"]}...");
            ADODB.Connection adoConn = new ADODB.Connection();

            adoConn.ConnectionTimeout = (int)Application["ConnectionTimeout"];
            adoConn.CommandTimeout = (int)Application["CommandTimeout"];

            LogMessage($@"Session_Start: adoConn.Open ""{(string)Application["ConnectionString"]}"", """", """"");
            adoConn.Open((string)Application["ConnectionString"], "", "");
            Application["adoConn"] = adoConn;
            Application["ConnectionString.asax"] = Application["ConnectionString"]; //To test if ASP stuff gets the same object...
            Session["adoConn"] = adoConn;

            


            bool fDebugLogin = true;
            Application.UnLock();

            // *********************************************************************************************************
            // Validate Visitor against Visitors Table...
            Session["StartTime"] = DateTime.Now;
            Session["DateLastVisit"] = Session["StartTime"];
            Session["Owner"] = false;
            Session["FirstName"] = "";
            Session["ButtonColor"] = "Gold";
            Session["LakeGIF"] = 1;
            Session["TargetPage"] = Request.ServerVariables["URL"];
            Session["RowsToDisplay"] = Application["RowsToDisplay"];
            Session["MinRowsForBottomButtons"] = Application["MinRowsForBottomButtons"];
            Session["MaxTextDisplay"] = Application["MaxTextDisplay"];

            object bc = null;  // Server.CreateObject("MSWC.BrowserType");
            if (bc == null) {    // || bc.Browser = "Unknown") {
                //Default to Internet Explorer 5.5...
                Session["Browser"] = "IE";
                Session["Version"] = "5.5";
                Session["MajorVersion"] = 5;
                Session["MinorVersion"] = 5;
                Session["Frames"] = true;
                Session["Tables"] = true;
                Session["Cookies"] = true;
                Session["BackgroundSounds"] = true;
                Session["VBScript"] = true;
                Session["ActiveXControls"] = true;
                Session["JavaScript"] = true;
                Session["JavaApplets"] = true;
                //Session["Win16"] = false;
                Session["Beta"] = false;
                //Session["AK"] = false;
                //Session["SK"] = false;
                //Session["AOL"] = false;
                Session["Crawler"] = false;
                Session["CDF"] = true;
                LogMessage($@"Warning: MSWC.BrowserType: ""Unknown""; Assuming Internet Explorer Version {Session["Version"]} for Visitor #{Session["VisitorNumber"]} (ID: {Session["ID"]}]...");
            }
            else { 
                //if ((bool)Application["fDebugMode"] || (bool)Application["fTraceMode"]) {
                //    LogMessage($@"DEBUG: Session_Start: \tBrowserType Properties:");
                //    LogMessage($@"DEBUG: Session_Start: \tBrowser:\t{bc.Browser}");
                //    LogMessage($@"DEBUG: Session_Start: \tVersion:\t{bc.Version}");
                //    LogMessage($@"DEBUG: Session_Start: \tMajorVer:\t{bc.MajorVer}");
                //    LogMessage($@"DEBUG: Session_Start: \tMinorVer:\t{bc.MinorVer}");
                //    LogMessage($@"DEBUG: Session_Start: \tFrames:\t{bc.Frames}");
                //    LogMessage($@"DEBUG: Session_Start: \tTables:\t{bc.Tables}");
                //    LogMessage($@"DEBUG: Session_Start: \tCookies:\t{bc.Cookies}");
                //    LogMessage($@"DEBUG: Session_Start: \tBackgroundSounds:\t{bc.BackgroundSounds}");
                //    LogMessage($@"DEBUG: Session_Start: \tVBScript:\t{bc.VBScript}");
                //    LogMessage($@"DEBUG: Session_Start: \tActiveXControls:\t{bc.ActiveXControls}");
                //    LogMessage($@"DEBUG: Session_Start: \tJavaScript:\t{bc.JavaScript}");
                //    LogMessage($@"DEBUG: Session_Start: \tJavaApplets:\t{bc.JavaApplets}");
                //    //LogMessage($@"DEBUG: Session_Start: \tWin16:\t{bc.Win16}");
                //    LogMessage($@"DEBUG: Session_Start: \tBeta:\t{bc.Beta}");
                //    //LogMessage($@"DEBUG: Session_Start: \tAK:\t{bc.AK}");
                //    //LogMessage($@"DEBUG: Session_Start: \tSK:\t{bc.SK}");
                //    //LogMessage($@"DEBUG: Session_Start: \tAOL:\t{bc.AOL}");
                //    LogMessage($@"DEBUG: Session_Start: \tCrawler:\t{bc.Crawler}");
                //    LogMessage($@"DEBUG: Session_Start: \tCDF:\t{bc.CDF}");
                //}
                //Session["Browser"] = bc.Browser;
                //Session["Version"] = bc.Version;
                //Session["MajorVersion"] = bc.MajorVer;
                //Session["MinorVersion"] = bc.MinorVer;
                //Session["Frames"] = bc.Frames.ToString();
                //Session["Tables"] = bc.Tables.ToString();
                //Session["Cookies"] = bc.Cookies.ToString();
                //Session["BackgroundSounds"] = bc.BackgroundSounds.ToString();
                //Session["VBScript"] = bc.VBScript.ToString();
                //Session["ActiveXControls"] = bc.ActiveXControls.ToString();
                //Session["JavaScript"] = bc.JavaScript.ToString();
                //Session["JavaApplets"] = bc.JavaApplets.ToString();
                ////Session["Win16"] = bc.Win16.ToString();
                //Session["Beta"] = bc.Beta.ToString();
                ////Session["AK"] = bc.AK.ToString();
                ////Session["SK"] = bc.SK.ToString();
                ////Session["AOL"] = bc.AOL.ToString();
                //Session["Crawler"] = bc.Crawler.ToString();
                //Session["CDF"] = bc.CDF.ToString();
            }
            Session["ScreenResolution"] = Request.ServerVariables["HTTP_UA_PIXELS"];
            if ((bool)Application["fDebugMode"] || (bool)Application["fTraceMode"]) LogMessage($@"DEBUG: Session_Start: Requested page ""{Session["TargetPage"]}""...");
            Session["VisitorOnFile"] = false;

            HttpCookie cookie = Request.Cookies["E-Mail"];

            //TODO: Remove after testing...
            if (cookie == null)
            {
                cookie = new HttpCookie("E-Mail");
                cookie.Value = "kfc12@comcast.net";
                cookie.Expires = DateTime.Now.AddDays(90);
                Response.Cookies.Add(cookie);
            }

            if (cookie != null) {
                Session["E-Mail"] = cookie.Value;
                LogMessage($@"DEBUG: Session_Start: Retrieved Cookie: ""{Session["E-Mail"]}""");
                Session["VisitorOnFile"] = true;
                if (fDebugLogin) LogMessage($@"DEBUG: Session_Start: Retrieved Cookie: ""{Session["E-Mail"]}""");
                // Record, retrieve information
                if (fDebugLogin) LogMessage($@"DEBUG: Session_Start: Opening Record Set...");

                ADODB.Command cmdTemp = new ADODB.Command();
                ADODB.Recordset rsVisitor = new ADODB.Recordset();
                cmdTemp.CommandText = $"Select * From [Visitors] Where ([E-Mail] Like '{Session["E-Mail"]}')";
                cmdTemp.CommandType = CommandTypeEnum.adCmdText;
                cmdTemp.ActiveConnection = adoConn;
                bool fEmptyRecordSet = true;
                try {
                    //rsVisitor.Open(cmdTemp, null, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
                    rsVisitor.Open($"Select * From [Visitors] Where ([Email] Like '{Session["E-Mail"]}')", adoConn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
                    fEmptyRecordSet = (rsVisitor.BOF && rsVisitor.EOF);
                }
                catch(Exception ex)
                {
                    LogMessage($@"DEBUG: Session_Start: RecordSet Open ({cmdTemp.CommandText}) failed:  {ex.Message}; SQL: {rsVisitor.Source}  (global.asax)");
                };

                if (!fEmptyRecordSet) {
                    Session["VisitorID"] = rsVisitor.Fields["ID"].Value;
                    Session["E-Mail"] = rsVisitor.Fields["Email"].Value;
                    switch (Session["E-Mail"]) {
                        case "kclark@sss.sungard.com":
                        case "kclark12@earthlink.net":
                        case "kfc12@comcast.net":
                        case "ken.clark12g@gmail.com":
                            Session["Owner"] = true;
                            break;
                        default:
                            Session["Owner"] = false;
                            break;
                    }
                    Session["FirstName"] = rsVisitor.Fields["FirstName"].Value;
                    Session["LastName"] = rsVisitor.Fields["LastName"].Value;
                    Session["Address"] = rsVisitor.Fields["Address"].Value;
                    Session["Phone"] = rsVisitor.Fields["Phone"].Value;
                    Session["Visits"] = rsVisitor.Fields["Visits"].Value;
                    Session["Music"] = rsVisitor.Fields["Music"].Value;
                    Session["AutoStart"] = rsVisitor.Fields["AutoStart"].Value;
                    Session["Detached"] = rsVisitor.Fields["Detached"].Value;
                    Session["DoLake"] = rsVisitor.Fields["DoLake"].Value;
                    Session["ButtonColor"] = rsVisitor.Fields["ButtonColor"].Value;
                    Session["LakeGIF"] = rsVisitor.Fields["lakeGIF"].Value;

                    LogMessage($@"Identified visitor #{Session["VisitorNumber"]} as ""{Session["E-Mail"]}""...");

                    if (fDebugLogin) {
                        LogMessage($@"DEBUG: Session_Start: VisitorID=""{Session["VisitorID"]}""");
                        LogMessage($@"DEBUG: Session_Start: E-Mail=""{Session["E-Mail"]}""");
                        LogMessage($@"DEBUG: Session_Start: FirstName=""{Session["FirstName"]}""");
                        LogMessage($@"DEBUG: Session_Start: LastName=""{Session["LastName"]}""");
                        LogMessage($@"DEBUG: Session_Start: Address=""{Session["Address"]}""");
                        LogMessage($@"DEBUG: Session_Start: Phone=""{Session["Phone"]}""");
                        LogMessage($@"DEBUG: Session_Start: DateLastVisit=""{Session["DateLastVisit"]}""");
                        LogMessage($@"DEBUG: Session_Start: Visits=""{Session["Visits"]}""");
                        LogMessage($@"DEBUG: Session_Start: Music=""{Session["Music"]}""");
                        LogMessage($@"DEBUG: Session_Start: AutoStart=""{Session["AutoStart"]}""");
                        LogMessage($@"DEBUG: Session_Start: Detached=""{Session["Detached"]}""");
                        LogMessage($@"DEBUG: Session_Start: DoLake=""{Session["DoLake"]}""");
                        LogMessage($@"DEBUG: Session_Start: ButtonColor=""{Session["ButtonColor"]}""");
                        LogMessage($@"DEBUG: Session_Start: LakeGIF=""{Session["LakeGIF"]}""");
                    }
                    // Refresh Cookie
                    cookie.Value = (string)Session["E-Mail"];
                    cookie.Expires = DateTime.Now.AddDays(90);
                    Response.Cookies.Set(cookie);

                    //Don't want to really do this until the user logs in (taken care of elsewhere)
                    // -- Remember this is being done here for the Classic ASP code --
                    //rsVisitor.Fields["DateLastVisit"].Value = (DateTime)Session["DateLastVisit"];
                    //rsVisitor.Fields["Visits"].Value = (int)Session["Visits"] + 1;
                    //try {
                    //    rsVisitor.Update();
                    //}
                    //catch (Exception ex)
                    //{
                    //    LogMessage($@"DEBUG: Session_Start: RecordSet Update ({cmdTemp.CommandText}) failed;  {ex.Message}; SQL: {rsVisitor.Source}  (global.asax)");
                    //};
                }
                // Cleanup...
                if (fDebugLogin) LogMessage($@"DEBUG: Session_Start: Closing rsVisitor...");
                rsVisitor.Close();
                if (fDebugLogin) LogMessage($@"DEBUG: Session_Start: Closed Record Set rsVisitor;");
            }
            LogMessage($@"Session_Start: Completed process for visitor #{Session["VisitorNumber"]} (ID: {Session["ID"]}) - {(DateTime.Now - (DateTime)Session["StartTime"]).TotalSeconds:#,##0} Seconds elapsed...");
            #endregion
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