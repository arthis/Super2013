using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using CreateTipoInterventoAmb = Super.Contabilita.Commands.TipoIntervento.Ambiente.CreateTipoInterventoAmb;
using DeleteTipoInterventoAmb = Core_Web.Models.DeleteTipoInterventoAmb;

namespace Core_Web.Controllers.Contabilita
{
    public class TipoInterventoAmbController : BaseContabilitaController
    {
        public TipoInterventoAmbController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("TipoInterventoAmb/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareTipoInterventoAmb command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.TipoInterventoAmbs
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
        public ActionResult CreateTipoInterventoAmb()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateTipoInterventoAmb()
                                {
                                    CreationDate = Now,
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateTipoInterventoAmb"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateTipoInterventoAmb(CreateTipoInterventoAmb command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditTipoInterventoAmb(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoAmbs.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit TipoInterventoAmb not found for id {0}", id));

                var model = new EditTipoInterventoAmb()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditTipoInterventoAmb"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateTipoInterventoAmb(UpdateTipoInterventoAmb command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteTipoInterventoAmb(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoAmbs.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete TipoInterventoAmb not found for id {0}", id));


                var model = new DeleteTipoInterventoAmb()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeleteTipoInterventoAmb"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.TipoIntervento.Ambiente.DeleteTipoInterventoAmb command)
        {
            return Execute(command);
        }


    }
}
