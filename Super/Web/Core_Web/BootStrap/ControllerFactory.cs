using System;
using System.Web.Mvc;
using Ninject;

namespace Core_Web.BootStrap
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel = new StandardKernel(
            new ServiceModule()
            , new ControllerModule()
            );

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            // We don't want to pass null to ninject as we'll get a strange error.
            return controllerType == null ? null
                                          : (IController)kernel.Get(controllerType);
        }
    }
}
