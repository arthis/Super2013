using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Core_Web.Models.Super.Contabilita.CategoriaCommerciale;
using Super.Contabilita.Commands.CategoriaCommerciale;


namespace Core_Web.Controllers.Contabilita
{
    public class CategoriaCommercialeController : BaseContabilitaController
    {
        public CategoriaCommercialeController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("CategoriaCommerciale/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareCategoriaCommerciale command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.CategoriaCommerciales
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
        public ActionResult CreateCategoriaCommerciale()
        {
            using (var context = GetEntities())
            {
                var model = new CreateCategoriaCommercialeModel()
                                {
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateCategoriaCommerciale"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateCategoriaCommerciale(CreateCategoriaCommerciale command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult UpdateCategoriaCommerciale(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.CategoriaCommerciales.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Update CategoriaCommerciale not found for id {0}", id));

                var model = new UpdateCategoriaCommercialeModel()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("UpdateCategoriaCommerciale"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateCategoriaCommerciale(UpdateCategoriaCommerciale command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteCategoriaCommerciale(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.CategoriaCommerciales.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete CategoriaCommerciale not found for id {0}", id));


                var model = new DeleteCategoriaCommercialeModel()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                 };

                return View(GetView("DeleteCategoriaCommerciale"), model);
            }
        }

        [HttpPost]
        public JsonResult DeleteCategoriaCommerciale(DeleteCategoriaCommerciale command)
        {
            return Execute(command);
        }


    }
}
