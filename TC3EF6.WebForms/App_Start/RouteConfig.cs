using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TC3EF6.WebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            //AutoRedirectMode is changed from Permanent to Off because we are going to use ajax call in datatables plugin. 
            //If redirect mode in friendly URL is not Off then the AJAX call will redirect to root page and AJAX call to 
            //serverside will not work...
            settings.AutoRedirectMode = RedirectMode.Off;   // Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
