using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.Committente;
using CreateCommittente = Super.Contabilita.Commands.Committente.CreateCommittente;
using DeleteCommittente = Core_Web.Models.DeleteCommittente;

namespace Core_Web.Controllers.Contabilita
{
    public class CommittenteController : BaseContabilitaController
    {
        public CommittenteController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("Committente/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareCommittente command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.Committentes
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
        public ActionResult CreateCommittente()
        {
            using (var context = GetEntities())
            {
                var model = new Models.CreateCommittente()
                                {
                                    
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateCommittente"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateCommittente(CreateCommittente command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditCommittente(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Committentes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit Committente not found for id {0}", id));

                var model = new EditCommittente()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditCommittente"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateCommittente(UpdateCommittente command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteCommittente(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Committentes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Committente not found for id {0}", id));


                var model = new DeleteCommittente()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description
                 };

                return View(GetView("DeleteCommittente"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.Committente.DeleteCommittente command)
        {
            return Execute(command);
        }


    }
}
