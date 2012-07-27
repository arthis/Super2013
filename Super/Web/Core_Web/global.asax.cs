using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Core_Web.BootStrap;
using Core_Web.ContabilitaService;
using Core_Web.Controllers;

namespace Core_Web
{
    public class Global : System.Web.HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            #region Contabilita
            routes.MapRoute(
                "Contabilita",
                "Contabilita",
                new { controller = "Contabilita", action = "Index" },
                new string[] { "Core_Web.Controllers" }
                );

            routes.MapRoute(
                "Contabilita_Controller", // Route name
                "Contabilita/{controller}/{action}/{id}", // URL with parameters
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Core_Web.Controllers" }
                );
            #endregion
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof(NinjectControllerFactory));
        }

        
    }

   
}
