using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using CreateTipoInterventoRot = Super.Contabilita.Commands.TipoIntervento.Rotabile.CreateTipoInterventoRot;
using DeleteTipoInterventoRot = Core_Web.Models.DeleteTipoInterventoRot;

namespace Core_Web.Controllers.Contabilita
{
    public class TipoInterventoRotController : BaseContabilitaController
    {
        public TipoInterventoRotController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("TipoInterventoRot/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareTipoInterventoRot command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.TipoInterventoRots
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
        public ActionResult CreateTipoInterventoRot()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateTipoInterventoRot()
                                {
                                    CreationDate = Now,
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateTipoInterventoRot"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateTipoInterventoRot(CreateTipoInterventoRot command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditTipoInterventoRot(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoRots.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit TipoInterventoRot not found for id {0}", id));

                var model = new EditTipoInterventoRot()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditTipoInterventoRot"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateTipoInterventoRot(UpdateTipoInterventoRot command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteTipoInterventoRot(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoRots.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete TipoInterventoRot not found for id {0}", id));


                var model = new DeleteTipoInterventoRot()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeleteTipoInterventoRot"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.TipoIntervento.Rotabile.DeleteTipoInterventoRot command)
        {
            return Execute(command);
        }


    }
}
