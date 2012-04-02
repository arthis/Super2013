using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using UI_Web.Injection;

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
            "AreaIntervento", // Route name
            "AreaIntervento/{action}/{id}", // URL with parameters
            new { controller = "AreaIntervento", action = "Index", id = UrlParameter.Optional } // Parameter defaults
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

            ModelBinders.Binders.DefaultBinder = new MyCustomModelBinder();

            // NServiceBus configuration
            var configure = Configure.WithWeb()
                .DefaultBuilder()  
                .ForMvc()
                .XmlSerializer()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Commands"))
                .Log4Net()
                    .MsmqTransport()
                    .IsTransactional(false)
                    .PurgeOnStartup(true)
                .UnicastBus()
                    .ImpersonateSender(false)
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

            // We don't have to store the IBus that results from .Start() because it will
            // be injected into all of our controllers for us.
        }
    }
}