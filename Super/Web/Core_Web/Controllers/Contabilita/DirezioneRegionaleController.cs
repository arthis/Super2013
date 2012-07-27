using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.DirezioneRegionale;
using CreateDirezioneRegionale = Super.Contabilita.Commands.DirezioneRegionale.CreateDirezioneRegionale;
using DeleteDirezioneRegionale = Core_Web.Models.DeleteDirezioneRegionale;

namespace Core_Web.Controllers.Contabilita
{
    public class DirezioneRegionaleController : BaseContabilitaController
    {
        public DirezioneRegionaleController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("DirezioneRegionale/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareDirezioneRegionale command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.DirezioneRegionales
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
        public ActionResult CreateDirezioneRegionale()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateDirezioneRegionale()
                                {
                                    CreationDate = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateDirezioneRegionale"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateDirezioneRegionale(CreateDirezioneRegionale command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditDirezioneRegionale(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.DirezioneRegionales.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit DirezioneRegionale not found for id {0}", id));

                var model = new EditDirezioneRegionale()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditDirezioneRegionale"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateDirezioneRegionale(UpdateDirezioneRegionale command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteDirezioneRegionale(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.DirezioneRegionales.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete DirezioneRegionale not found for id {0}", id));


                var model = new DeleteDirezioneRegionale()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                 };

                return View(GetView("DeleteDirezioneRegionale"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.DirezioneRegionale.DeleteDirezioneRegionale command)
        {
            return Execute(command);
        }


    }
}
