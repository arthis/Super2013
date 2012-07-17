using System.Web.Mvc;

namespace Core_Web.Controllers
{
    public class ContabilitaController : ControllerContabilitaBase
    {
        public ActionResult Index()
        {
            return View(GetView("Index"));
        }
    }
}
