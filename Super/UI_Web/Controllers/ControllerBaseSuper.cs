using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NServiceBus;

namespace UI_Web.Controllers
{
    public class ControllerBaseSuper : Controller
    {
        // Add the Bus property to be injected
        public IBus Bus { get; set; }

    }
}
