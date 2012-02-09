﻿using System;
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
using UI_Web.Models;



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

        
        public JsonResult GetItems(VisualizzareAreaIntervento command)
        {
            using (var context = new ReadModelContainer())
            {
                var query = context.AreaIntervento.Where(item => !item.Deleted);

                if (!string.IsNullOrEmpty(command.Descrizione))
                    query = query.Where(item => item.Descrizione.IndexOf(command.Descrizione) > -1);

                var results = query.OrderBy(item => item.CreationDate)
                                   .Skip((command.PageNum - 1) * command.PageSize)
                                   .Take(command.PageSize)
                                   .Select(item => new { item.Id, item.IdAreaInterventoSuper, item.Inizio, item.Fine, item.CreationDate, item.Descrizione })
                                   .ToArray();

                var count = query.Count();

                var returnObject = new { results, count };

                return this.Json(returnObject, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
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

        [HttpGet]
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
