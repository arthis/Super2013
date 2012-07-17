using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

namespace Core_Web.Tests
{
    [TestFixture]
    public class ControllerFactoryTests
    {
        public interface IDependency
        {   
        }

        public class Dependency : IDependency
        {
            
        }

        public class FakeController : IController
        {
            private readonly IDependency _dependency;

            public FakeController(IDependency dependency)
            {
                _dependency = dependency;
            }

            public void Execute(RequestContext requestContext)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeControllerFactory
        {
            public IController Create()
            {
                return new FakeController(new Dependency());
            }
        }

        [Test]
        public void Should_return_a_controller()
        {
            var controllerFactories = new Dictionary<Type, Func<IController>>();
            var ControllersKnown = new Dictionary<string, Type>();
            

            controllerFactories.Add(typeof(FakeController), new FakeControllerFactory().Create );
            ControllersKnown.Add("FakeController",typeof(FakeController));
            var controllerFactory = new ControllerFactory(ControllersKnown, controllerFactories);
            var requestContext = new RequestContext();

            var result = controllerFactory.CreateController(null, "FakeController");

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<FakeController>(result);
        }
    }
}
