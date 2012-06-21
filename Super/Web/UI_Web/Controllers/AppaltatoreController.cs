using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Super.Appaltatore.Commands;

namespace UI_Web.Controllers
{
    public class AppaltatoreController   : ControllerBaseSuper
    {
        //
        // GET: /Appaltatore/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consuntivare(ConsuntivareRotReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareRotManReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareAmbReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareRotNonReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareRotManNonReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareAmbNonReso cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareRotNonResoTrenitalia cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareRotManNonResoTrenitalia cmd)
        {
            throw new NotImplementedException();
        }

        public ActionResult Consuntivare(ConsuntivareAmbNonResoTrenitalia cmd)
        {
            throw new NotImplementedException();
        }



    }
}
