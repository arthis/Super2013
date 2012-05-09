using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using UI_Web.Models;



namespace UI_Web.Controllers
{
    public class TipoInterventoController : ControllerBaseSuper
    {
        ////private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        //static TipoInterventoController()
        //{
        //    //_channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");

        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        
        //public JsonResult GetItems(VisualizzareTipoIntervento command)
        //{
        //    using (var context = new ReadModelContainer())
        //    {
        //        var query = context.TipoIntervento.Where(item => !item.Deleted);

        //        if (!string.IsNullOrEmpty(command.Description))
        //            query = query.Where(item => item.Description.IndexOf(command.Description) > -1);

        //        var results = query.OrderBy(item => item.CreationDate)
        //                           .Skip((command.PageNum - 1) * command.PageSize)
        //                           .Take(command.PageSize)
        //                           .Select(item => new { item.Id, item.IdTipoInterventoSuper, item.Start, item.End, item.CreationDate, item.Description })
        //                           .ToArray();

        //        var count = query.Count();

        //        var returnObject = new { results, count };

        //        return this.Json(returnObject, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public ActionResult CreareRot()
        //{
        //    return View("Details");
        //}

        //[HttpGet]
        //public ActionResult CreareRotMan()
        //{
        //    return View("Details");
        //}

        //[HttpGet]
        //public ActionResult CreareAmb()
        //{
        //    return View("Details");
        //}

        //[HttpPost]
        //public void CreareTipoInterventoRot(CreareTipoInterventoRot command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //        //               client.Execute(new ExecuteRequest(command)));
        //    }
        //}

        //[HttpPost]
        //public void CreareTipoInterventoRotMan(CreareTipoInterventoRotMan command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //        //               client.Execute(new ExecuteRequest(command)));
        //    }
        //}

        //[HttpPost]
        //public void CreareTipoInterventoAmb(CreareTipoInterventoAmb command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //                       //client.Execute(new ExecuteRequest(command)));
        //    }
        //}

        //[HttpGet]
        //public ActionResult AggiornareRot()
        //{
        //    return View("Details");
        //}

        //[HttpGet]
        //public ActionResult AggiornareAmb()
        //{
        //    return View("Details");
        //}

        //[HttpGet]
        //public ActionResult AggiornareRotMan()
        //{
        //    return View("Details");
        //}


        //[HttpPost]
        //public void AggiornareTipoInterventoRot(AggiornareTipoInterventoRot command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //        //               client.Execute(new ExecuteRequest(command)));
        //    }
        //}

        //[HttpPost]
        //public void CancellareTipoInterventoRotMan(CancellareTipoInterventoRotMan command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //        //               client.Execute(new ExecuteRequest(command)));
        //    }
        //}

        //[HttpPost]
        //public void CancellareTipoInterventoAmb(CancellareTipoInterventoAmb command)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //        //               client.Execute(new ExecuteRequest(command)));
        //    }
        //}


    }
}
