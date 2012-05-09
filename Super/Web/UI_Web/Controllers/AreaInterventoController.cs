using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Super.Administration.ReadModel;
using Super.Administration.Commands.AreaIntervento;
using UI_Web.Models;
using System.Text;
using EasyNetQ;
using UI_Web.ServiceAdministration;


namespace UI_Web.Controllers
{
    public class AreaInterventoController : ControllerBaseSuper
    {
        private readonly IBus _bus;

        public AreaInterventoController()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");

        }

        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetItems(VisualizzareAreaIntervento command)
        {
            using (var context = new Super2013Container())
            {
                var query = context.AreaInterventoes.Where(item => !item.Deleted);

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
        public void Create(CreateAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                var client= new ServiceClient();
                var cr =  client.Execute(command);
            }
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View("Details");
        }


        [HttpPost]
        public void Update(UpdateAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                var client = new ServiceClient();
                var cr = client.Execute(command);
            }
        }


        [HttpPost]
        public void Delete(DeleteAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                var client = new ServiceClient();
                var cr = client.Execute(command);
            }
        }


    }
}
