using System;
using System.Web.Mvc;
using Core_Web.Attributes;

namespace Core_Web.Controllers
{
    [SetCulture]
    public abstract class BaseController : Controller
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }


}
