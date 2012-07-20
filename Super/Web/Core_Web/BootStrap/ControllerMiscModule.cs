using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Core_Web.Controllers;
using Core_Web.Controllers.Contabilita;
using Ninject.Modules;

namespace Core_Web.BootStrap
{
    public class ControllerMiscModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IController>().To<HomeController>()
                .When(request => request.Target.Member.Name.StartsWith("Home"));
            

        }
    }
}
