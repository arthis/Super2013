using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyNetQ;
using Super.ReadModel;
using UI_Web.Attributes;
using UI_Web.Contabilita;

namespace UI_Web.Controllers
{
    [SetCulture]
    public class ControllerBaseSuper : Controller
    {
        
    }

    public class ControllerContabilita : Controller
    {
        private CommandWebServiceClient _commandService;

        public CommandWebServiceClient CommandService
        {
            get { return _commandService; }
        }

        public ControllerContabilita()
        {
            _commandService = new Contabilita.CommandWebServiceClient();
        }

        public ContabilitaContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Contabilita.ReadModel"].ConnectionString;
            return new ContabilitaContainer(connectionString);
        }
    }
}
