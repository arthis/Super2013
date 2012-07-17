using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Core_Web
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly Dictionary<string, Type> _controllersKnown;
        private readonly Dictionary<Type, Func<IController>> _controllerFactories;
         
        

        public ControllerFactory(Dictionary<string,Type> controllersKnown, Dictionary<Type, Func<IController>> controllerFactories)
        {
            Contract.Requires(controllerFactories!=null);
            Contract.Requires(controllersKnown!=null);

            _controllersKnown = controllersKnown;
            _controllerFactories = controllerFactories;
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Contract.Requires(requestContext!=null);
            Contract.Requires(!string.IsNullOrEmpty(controllerName));

            Type controllerType = GetControllerType(requestContext, controllerName);

            return GetControllerInstance(requestContext, controllerType);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            Contract.Requires(requestContext!=null);
            Contract.Requires(controllerType!=null);

            if (!_controllerFactories.ContainsKey(controllerType))
                throw new Exception(string.Format("Dictionnary does not know the type {0}", controllerType.ToString()));

            return _controllerFactories[controllerType]();
        }

        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Contract.Requires(requestContext!=null);
            Contract.Requires(!string.IsNullOrEmpty(controllerName));

            if(!_controllersKnown.ContainsKey(controllerName))
                throw new Exception(string.Format("Dictionnary does not know the controller name {0}", controllerName));

            return _controllersKnown[controllerName];
        }
    }
}
