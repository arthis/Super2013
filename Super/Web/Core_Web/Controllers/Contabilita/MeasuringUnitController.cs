using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.MeasuringUnit;
using CreateMeasuringUnit = Super.Contabilita.Commands.MeasuringUnit.CreateMeasuringUnit;
using DeleteMeasuringUnit = Core_Web.Models.DeleteMeasuringUnit;

namespace Core_Web.Controllers.Contabilita
{
    public class MeasuringUnitController : BaseContabilitaController
    {
        public MeasuringUnitController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("MeasuringUnit/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareMeasuringUnit command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.MeasuringUnits
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
        public ActionResult CreateMeasuringUnit()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateMeasuringUnit()
                                {
                                    
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateMeasuringUnit"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateMeasuringUnit(CreateMeasuringUnit command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditMeasuringUnit(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.MeasuringUnits.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit MeasuringUnit not found for id {0}", id));

                var model = new EditMeasuringUnit()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditMeasuringUnit"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateMeasuringUnit(UpdateMeasuringUnit command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteMeasuringUnit(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.MeasuringUnits.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete MeasuringUnit not found for id {0}", id));


                var model = new DeleteMeasuringUnit()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                 };

                return View(GetView("DeleteMeasuringUnit"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.MeasuringUnit.DeleteMeasuringUnit command)
        {
            return Execute(command);
        }


    }
}
