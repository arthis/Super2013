using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.PeriodoProgrammazione;
using CreatePeriodoProgrammazione = Super.Contabilita.Commands.PeriodoProgrammazione.CreatePeriodoProgrammazione;
using DeletePeriodoProgrammazione = Core_Web.Models.DeletePeriodoProgrammazione;

namespace Core_Web.Controllers.Contabilita
{
    public class PeriodoProgrammazioneController : BaseContabilitaController
    {
        public PeriodoProgrammazioneController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("PeriodoProgrammazione/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzarePeriodoProgrammazione command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.PeriodoProgrammaziones
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
        public ActionResult CreatePeriodoProgrammazione()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreatePeriodoProgrammazione()
                                {
                                    CreationDate = Now,
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreatePeriodoProgrammazione"), model);
            }
        }

        [HttpPost]
        public JsonResult CreatePeriodoProgrammazione(CreatePeriodoProgrammazione command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditPeriodoProgrammazione(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.PeriodoProgrammaziones.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit PeriodoProgrammazione not found for id {0}", id));

                var model = new EditPeriodoProgrammazione()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditPeriodoProgrammazione"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdatePeriodoProgrammazione(UpdatePeriodoProgrammazione command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeletePeriodoProgrammazione(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.PeriodoProgrammaziones.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete PeriodoProgrammazione not found for id {0}", id));


                var model = new DeletePeriodoProgrammazione()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeletePeriodoProgrammazione"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.PeriodoProgrammazione.DeletePeriodoProgrammazione command)
        {
            return Execute(command);
        }


    }
}
