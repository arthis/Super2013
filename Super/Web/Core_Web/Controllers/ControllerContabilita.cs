using System.Web.Mvc;
using Core_Web.ContabilitaService;

namespace Core_Web.Controllers
{
    public class ContabilitaController : ControllerContabilitaBase
    {
        public ContabilitaController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }
    }
}
