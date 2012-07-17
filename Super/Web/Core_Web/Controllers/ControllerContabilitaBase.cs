using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CommonDomain.Core;
using Core_Web.ContabilitaService;
using Super.ReadModel;


namespace Core_Web.Controllers
{
    public class ControllerContabilitaBase : ControllerBaseSuper
    {
        private CommandWebServiceClient _commandService;

        public CommandWebServiceClient CommandService
        {
            get { return _commandService; }
        }

        public ControllerContabilitaBase()
        {
            _commandService = new CommandWebServiceClient();
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
                var validations = new { Title = "Exception", Message = e.ToString() };

                var returnObject = new { validations };

                return this.Json(returnObject);
            }
            return null;
        }

       

        protected virtual string GetView(string url)
        {
            return string.Format("~/Views/Contabilita/{0}.cshtml", url);
        }
    }
}
