using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Security;
using System.Web.Mvc;
using CommonDomain.Core;
using Core_Web.ContabilitaService;
using Super.ReadModel;


namespace Core_Web.Controllers
{
    public abstract class BaseContabilitaController : BaseController
    {
        private ICommandWebService _commandService;

        private Guid SecurityToken
        {
            get
            {
                if (Session["SecurityToken"] == null)
                    throw new SecurityAccessDeniedException("no security token found"); 
                return (Guid)Session["SecurityToken"];
            }
        }
        private Guid UserId
        {
            get
            {
                if (Session["UserId"] == null)
                    throw new SecurityAccessDeniedException("no user Id found");
                return (Guid)Session["UserId"];
            }
        }
        
        public BaseContabilitaController(ICommandWebService commandWebService)
        {

            _commandService = commandWebService;
        }

        public static ContabilitaEntities GetEntities()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Contabilita.ReadStore"].ConnectionString;
            return new ContabilitaEntities(connectionString);
        }

        public JsonResult Execute(CommandBase command)
        {
            try
            {
                #if DEBUG
                Session["SecurityToken"] = Guid.NewGuid();
                Session["UserId"] = Guid.NewGuid();
                #endif
                command.SecurityToken = SecurityToken;
                command.UserId = UserId;

                var response = _commandService.Execute(command);

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
