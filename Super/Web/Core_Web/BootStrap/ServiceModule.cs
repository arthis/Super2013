using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandService;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace Core_Web.BootStrap
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ContabilitaService.ICommandWebService>().To<ContabilitaService.CommandWebServiceClient>();
        }
    }

    
}
