using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Ncqrs.CommandService.Contracts;
using ReadModel;
using Commands;
using UI_Web.Models;

namespace UI_Web.Controllers
{
    public class AreaInterventoController : Controller
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static AreaInterventoController()
        {
            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAree()
        {
            using (var context = new ReadModelContainer())
            {
                var query = from item in context.AreaIntervento
                            orderby item.CreationDate
                            select new { item.Id, item.Inizio, item.Fine, item.CreationDate, item.Descrizione };

                return this.Json(query.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            var creareArea = new CreareAreaIntervento();
            creareArea.Id = Guid.NewGuid();

            return View(creareArea);
        }

        [HttpPost]
        public ActionResult Add(CreareAreaIntervento area)
        {
            //using (var context = new ReadModelContainer())
            //{
            //    context.AreaIntervento.AddObject(area);
            //    context.SaveChanges();
            //}
            throw new NotImplementedException();
         }



    }
}
