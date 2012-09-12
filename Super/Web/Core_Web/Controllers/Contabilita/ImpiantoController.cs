using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.ContabilitaService;
using Core_Web.Models;
using Super.Contabilita.Commands.Impianto;
using CreateImpianto = Core_Web.Models.CreateImpianto;
using DeleteImpianto = Core_Web.Models.DeleteImpianto;

namespace Core_Web.Controllers.Contabilita
{
    public class ImpiantoController : BaseContabilitaController
    {
        public ImpiantoController(ICommandWebService commandWebService) : base(commandWebService)
        {
        }

        protected override string GetView(string url)
        {
            url = string.Format("Impianto/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareImpianto command)
        {
            using (var ctx = GetEntities())
            {
                var query = from i in ctx.Impiantoes
                            join l in ctx.Lottoes
                                on i.IdLotto equals l.Id
                            select new
                                       {
                                           Impianto = i,
                                           Lotto = l
                                       };

                if (!string.IsNullOrEmpty(command.Description))
                    query = query.Where(item => item.Impianto.Description.IndexOf(command.Description) > -1);

                var results = query.OrderBy(item => item.Impianto.CreationDate)
                                   .Skip((command.PageNum - 1) * command.PageSize)
                                   .Take(command.PageSize)
                                   .Select(item => new { item.Impianto.Id, item.Impianto.Start, item.Impianto.End, item.Impianto.CreationDate, item.Impianto.Description, DescriptionLotto = item.Lotto.Description })
                                   .ToArray();

                var count = query.Count();

                var returnObject = new { results, count };

                return this.Json(returnObject, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult CreateImpianto()
        {
            using (var context = GetEntities())
            {
                var lottiRaw = context.Lottoes.OrderBy(x => x.Description)
                    .Select(x => new { Description = x.Description, Value = x.Id})
                                     .ToList();

                var lotti = lottiRaw.Select(x => new SelectListItem()
                                                     {
                                                         Text = x.Description,
                                                         Value = x.Value.ToString()
                                                     })
                    .ToList();
                lotti.Insert(0, new SelectListItem() { Text = "Choose a lotto", Value = Guid.Empty.ToString(), Selected = true });

                var model = new CreateImpianto()
                                {
                                    
                                    Start = Now,
                                    IdLotto = Guid.Empty,
                                    Lotti = lotti,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0
                                };

                return View(GetView("CreateImpianto"), model);
            }
        }

        [HttpPost]
        public JsonResult CreateImpianto(Super.Contabilita.Commands.Impianto.CreateImpianto command)
        {
         
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditImpianto(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Impiantoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit Impianto not found for id {0}", id));

                var lotto = context.Lottoes.Single(x => x.Id == projection.IdLotto);


                var model = new EditImpianto()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Description = projection.Description,
                                    LottoDescription = lotto.Description,
                                    Id= projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version
                                };

                return View(GetView("EditImpianto"), model);
            }
        }

        [HttpPost]
        public JsonResult UpdateImpianto(UpdateImpianto command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteImpianto(Guid id)
        {
            using (var context = GetEntities())
            {
                var query = context.Impiantoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Impianto not found for id {0}", id));

                var lotto = context.Lottoes.Single(x => x.Id == projection.Id);

                var model = new DeleteImpianto()
                                {
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description,
                                    Start = projection.Start,
                                    End = projection.End,
                                    LottoDescription = lotto.Description
                                };

                return View(GetView("DeleteImpianto"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.Impianto.DeleteImpianto command)
        {
            return Execute(command);
        }


    }
}
