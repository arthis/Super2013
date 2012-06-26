using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI_Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
               "Appaltatore", // Route name
               "Appaltatore/{action}/{id}", // URL with parameters
               new { controller = "Appaltatore", action = "Index", id = UrlParameter.Optional } // Parameter defaults
               );

            routes.MapRoute(
            "Impianto", // Route name
            "Impianto/{action}/{id}", // URL with parameters
            new { controller = "Impianto", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
            "TipoIntervento", // Route name
            "TipoIntervento/{action}/{id}", // URL with parameters
            new { controller = "TipoIntervento", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
            "InterventoRot", // Route name
            "InterventoRot/{action}/{id}", // URL with parameters
            new { controller = "InterventoRot", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "First", // Route name
                "Note/{action}/{id}", // URL with parameters
                new { controller = "Note", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Note", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //debug routes
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);


            
            

            // We don't have to store the IBus that results from .Start() because it will
            // be injected into all of our controllers for us.
        }
    }
}