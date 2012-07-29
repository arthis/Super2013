using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using CreateTipoInterventoRotMan = Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione.CreateTipoInterventoRotMan;
using DeleteTipoInterventoRotMan = Core_Web.Models.DeleteTipoInterventoRotMan;

namespace Core_Web.Controllers.Contabilita
{
    public class TipoInterventoRotManController : BaseContabilitaController
    {
        public TipoInterventoRotManController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("TipoInterventoRotMan/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareTipoInterventoRotMan command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.TipoInterventoRotMen
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
        public ActionResult CreateTipoInterventoRotMan()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateTipoInterventoRotMan()
                                {
                                    
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateTipoInterventoRotMan"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateTipoInterventoRotMan(CreateTipoInterventoRotMan command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditTipoInterventoRotMan(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoRotMen.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit TipoInterventoRotMan not found for id {0}", id));

                var model = new EditTipoInterventoRotMan()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditTipoInterventoRotMan"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateTipoInterventoRotMan(UpdateTipoInterventoRotMan command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteTipoInterventoRotMan(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.TipoInterventoRotMen.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete TipoInterventoRotMan not found for id {0}", id));


                var model = new DeleteTipoInterventoRotMan()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeleteTipoInterventoRotMan"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione.DeleteTipoInterventoRotMan command)
        {
            return Execute(command);
        }


    }
}
