using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonDomain.Core;
using EasyNetQ;
using Super.ReadModel;
using UI_Web.Attributes;
using UI_Web.Contabilita;

namespace UI_Web.Controllers
{
    [SetCulture]
    public class ControllerBaseSuper : Controller
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }

    public class ControllerContabilita : ControllerBaseSuper
    {
        private CommandWebServiceClient _commandService;

        public CommandWebServiceClient CommandService
        {
            get { return  _commandService; }
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

        public JsonResult Execute(CommandBase command)
        {
            try
            {
                var response = CommandService.Execute(command);

                if (response.Validation.Messages.Any())
                {
                    var validations = response.Validation.Messages.Select(x => new { x.Title, x.Message }).ToArray();

                    var returnObject = new { validations };

                    return this.Json(returnObject, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                var validations = new {Title = "Exception", Message = e.ToString()};

                var returnObject = new {validations};

                return this.Json(returnObject);
            }
            return null;
        }

    }
}
