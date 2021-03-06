﻿using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Newtonsoft.Json;
using Super.Contabilita.Commands.Lotto;
using CreateLotto = Super.Contabilita.Commands.Lotto.CreateLotto;
using DeleteLotto = Core_Web.Models.DeleteLotto;

namespace Core_Web.Controllers.Contabilita
{

    //public class UserModelBinder : IModelBinder
    //{
    //    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        CreateLotto model;

    //        if (controllerContext.RequestContext.HttpContext.Request.AcceptTypes.Contains("application/json"))
    //        {
    //            var serializer = new JavaScriptSerializer();
    //            string inputContent;
    //            controllerContext.RequestContext.HttpContext.Request.InputStream.Position = 0;
    //            using (var sr = new StreamReader(controllerContext.RequestContext.HttpContext.Request.InputStream))
    //            {
    //                inputContent = sr.ReadToEnd();
    //            }

    //            model = serializer.Deserialize<CreateLotto>(HttpUtility.UrlDecode(inputContent));
    //        }
    //        else
    //        {
    //            model = (CreateLotto)ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
    //        }

    //        return model;
    //    }
    //}

    public class LottoController : BaseContabilitaController
    {
        public LottoController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("Lotto/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareLotto command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.Lottoes
                            select i;

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
        public ActionResult CreateLotto()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateLotto()
                                {
                                    
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateLotto"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateLotto(CreateLotto command)
        {
            
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditLotto(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Lottoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit Lotto not found for id {0}", id));

                var model = new EditLotto()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditLotto"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateLotto(UpdateLotto command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteLotto(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Lottoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Lotto not found for id {0}", id));


                var model = new DeleteLotto()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeleteLotto"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.Lotto.DeleteLotto command)
        {
            return Execute(command);
        }


    }
}
