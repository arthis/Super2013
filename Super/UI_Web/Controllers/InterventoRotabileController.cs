﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ncqrs.CommandService.Contracts;
using ReadModel;
using Commands.Interventi;
using Ncqrs.CommandService;
using System.ServiceModel;

namespace Website.Controllers
{
    public class InterventoRotabileController : Controller
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static InterventoRotabileController()
        {
            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }


        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetInterventi()
        {
            using (var context = new ReadModelContainer())
            {
                var query = from item in context.ConsuntivoRotabile
                            orderby item.CreationDate
                            select new { item.OraInizioProgrammata, item.OraFineProgrammata, item.CreationDate, item.IsReso };

                return this.Json(query.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            var command = new CreareNuovoInterventoRotabile();
            command.Id = Guid.NewGuid();

            return View(command);
        }

        [HttpPost]
        public ActionResult Add(CreareNuovoInterventoRotabile command)
        {
            ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                                client.Execute(new ExecuteRequest(command)));

            // Return user back to the index that
            // displays all the Interventi.));
            return RedirectToAction("Index", "InterventoRotabile");
        }

        //[HttpPost]
        //public void Eseguire(EseguireIntervento command)
        //{
        //    ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //                        client.Execute(new ExecuteRequest(command)));

        //}


    }
}

