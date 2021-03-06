﻿using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Core_Web.Models.Super.Contabilita.Appaltatore;
using Super.Contabilita.Commands.Appaltatore;


namespace Core_Web.Controllers.Contabilita
{
    public class AppaltatoreController : BaseContabilitaController
    {
        public AppaltatoreController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("Appaltatore/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareAppaltatore command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.Appaltatores
                            where  !i.Deleted
                            select i;

                if (!string.IsNullOrEmpty(command.Description))
                    query = query.Where(item => item.Description.IndexOf(command.Description) > -1);

                var results = query.OrderBy(item => item.CreationDate)
                                   .Skip((command.PageNum - 1) * command.PageSize)
                                   .Take(command.PageSize)
                                   .Select(item => new { item.Id,  item.CreationDate, item.Description })
                                   .ToArray();

                var count = query.Count();

                var returnObject = new { results, count };

                return this.Json(returnObject, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult CreateAppaltatore()
        {
            using (var context = GetEntities())
            {
                var model = new CreateAppaltatoreModel()
                                {
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateAppaltatore"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateAppaltatore(CreateAppaltatore command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult UpdateAppaltatore(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Appaltatores.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Update Appaltatore not found for id {0}", id));

                var model = new UpdateAppaltatoreModel()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("UpdateAppaltatore"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateAppaltatore(UpdateAppaltatore command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteAppaltatore(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Appaltatores.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Appaltatore not found for id {0}", id));


                var model = new DeleteAppaltatoreModel()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                 };

                return View(GetView("DeleteAppaltatore"), model);
            }
        }

        [HttpPost]
        public JsonResult DeleteAppaltatore(DeleteAppaltatore command)
        {
            return Execute(command);
        }


    }
}
