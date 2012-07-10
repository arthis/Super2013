using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using CommandService;
using CommonDomain;
using Super.ReadModel;
using Super.Contabilita.Commands.Impianto;
using UI_Web.Models;
using System.Text;
using EasyNetQ;


namespace UI_Web.Controllers
{
    public class ImpiantoController : ControllerContabilita
    {


        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetItems(VisualizzareImpianto command)
        {
            using (var context = GetContainer())
            {
                var query = context.Impiantoes.Where(item => !item.Deleted);

                if (!string.IsNullOrEmpty(command.Description))
                    query = query.Where(item => item.Description.IndexOf(command.Description) > -1);

                var results = query.OrderBy(item => item.CreationDate)
                                   .Skip((command.PageNum - 1) * command.PageSize)
                                   .Take(command.PageSize)
                                   .Select(item => new { item.Id, item.Start, item.End, item.CreationDate, item.Description })
                                   .ToArray();

                var count = query.Count();

                var returnObject = new { results, count };

                return this.Json(returnObject, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Details");
        }

        [HttpPost]
        public void Create(CreateImpianto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }

       

        [HttpGet]
        public ActionResult Update()
        {
            return View("Details");
        }


        [HttpPost]
        public void Update(UpdateImpianto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }


        [HttpPost]
        public void Delete(DeleteImpianto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }


    }
}
