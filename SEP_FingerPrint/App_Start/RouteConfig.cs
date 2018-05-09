using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SEP_FingerPrint
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "FullAttendance",
            //    url: "{controller}/{action}/{course}",
            //defaults: new { controller = "Lecturer", action = "Attendace", course = UrlParameter.Optional },
            //namespaces: new[] { "SEP_FingerPrint.Controllers" }
            //);
            routes.MapRoute(
                name: "Attendance",
                url: "{controller}/{action}/{course}/{time}"
            //defaults: new { controller = "Lecturer", action = "Attendace", id = UrlParameter.Optional },
            //namespaces: new[] { "SEP_FingerPrint.Controllers" }
            );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
           );
            
        }
    }
}
