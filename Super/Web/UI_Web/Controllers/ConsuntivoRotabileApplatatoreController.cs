﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using UI_Web.Models;

namespace Website.Controllers
{
    public class InterventoRotController : Controller
    {
        ////private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        //static InterventoRotController()
        //{
        //    //_channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        //}


        //public ActionResult Index()
        //{
        //    return View();
        //}


        //public JsonResult GetItems(VisualizzareConsuntivoRotAppaltatore command)
        //{
        //    using (var context = new ReadModelContainer())
        //    {
        //        var query = context.ConsuntivazioneRot.Where(item => !item.Deleted);

        //        //if (!string.IsNullOrEmpty(command.Description))
        //        //    query = query.Where(item => item.Description.IndexOf(command.Description) > -1);

        //        var results = query.OrderBy(item => item.CreationDate)
        //                           .Skip((command.PageNum - 1) * command.PageSize)
        //                           .Take(command.PageSize)
        //                           .Select(i => new {i.IdIntervento,
        //                                             i.IdInterventoSuper2010,
        //                                             i.CodiceOrdine,
        //                                             i.IsAvvisoIspezione,
        //                                             i.IsSpunta,
        //                                             i.HasSchedaV,
        //                                             i.HasSchedaQ,
        //                                             i.Data,
        //                                             i.ImpiantoDescription,
        //                                             i.CategoriaTreno,
        //                                             i.NumeroTrenoPartenza,
        //                                             i.DataTrenoPartenza,
        //                                             i.TipoInterventoDescription,
        //                                             i.DataInizioProgrammata,
        //                                             i.DataFineProgrammata,
        //                                             i.ComposizioneProgrammata,
        //                                             i.DataInizioConsuntivataAppaltatore,
        //                                             i.DataFineConsuntivataAppaltatore,
        //                                             i.IsProgrammato,
        //                                             i.IsPLX,
        //                                             i.IsEstemporaneo,
        //                                             i.IsSostitutivo,
        //                                             i.IsReso,
        //                                             i.IsNonResoAppaltatore,
        //                                             i.IsNonReso20mn,
        //                                             i.IsNonResoTrenitalia,
        //                                             i.IsRilevatoNonReso
        //                                                })
        //                           .ToArray();

        //        var count = query.Count();

        //        var returnObject = new { results, count };

        //        return this.Json(returnObject, JsonRequestBehavior.AllowGet);
        //    }
        //}


        //public ActionResult Add()
        //{
        //    var command = new CreareInterventoPLGRot();
        //    command.Id = Guid.NewGuid();

        //    return View(command);
        //}

        //[HttpPost]
        //public ActionResult Add(CreareInterventoPLGRot command)
        //{
        //    //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //    //                    client.Execute(new ExecuteRequest(command)));

        //    // Return user back to the index that
        //    // displays all the Interventi.));
        //    return RedirectToAction("Index", "InterventoRot");
        //}

        ////[HttpPost]
        ////public void Eseguire(EseguireIntervento command)
        ////{
        ////    ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        ////                        client.Execute(new ExecuteRequest(command)));

        ////}


    }
}

