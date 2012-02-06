using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Ncqrs.CommandService.Contracts;
using ReadModel;
using Commands.AreaIntervento;
using Commands;
using Ncqrs.CommandService;



namespace UI_Web.Controllers
{
    public class AreaInterventoController : ControllerBaseSuper
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

        public JsonResult GetItems()
        {
            using (var context = new ReadModelContainer())
            {
                var query = from item in context.AreaIntervento
                            where !item.Deleted 
                            orderby item.CreationDate
                            select new { item.Id, item.IdAreaInterventoSuper, item.Inizio, item.Fine, item.CreationDate, item.Descrizione };

                return this.Json(query.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Creare()
        {
            return View("Details");
        }

        [HttpPost]
        public void Creare(CreareNuovoAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                               client.Execute(new ExecuteRequest(command)));
            }
         }

        public ActionResult Aggiornare()
        {
            return View("Details");
        }


        [HttpPost]
        public void Aggiornare(AggiornareAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                               client.Execute(new ExecuteRequest(command)));
            }
        }

        [HttpPost]
        public void Cancellare(CancellareAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                               client.Execute(new ExecuteRequest(command)));
            }
        }


    }
}
