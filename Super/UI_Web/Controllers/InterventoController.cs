﻿using System;
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
    public class InterventoController : Controller
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static InterventoController()
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
                var query = from item in context.Intervento_BasicSet
                            orderby item.CreationDate
                            select new { item.Inizio, item.Fine, item.CreationDate, item.IsEseguito };

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
            return RedirectToAction("Index", "Intervento");
        }

        //[HttpPost]
        //public void Eseguire(EseguireIntervento command)
        //{
        //    ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //                        client.Execute(new ExecuteRequest(command)));

        //}


    }
}

