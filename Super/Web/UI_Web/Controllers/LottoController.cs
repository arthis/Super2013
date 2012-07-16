using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.Lotto;



namespace UI_Web.Controllers
{
    public class LottoController : ControllerContabilita
    {


        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetItems(UI_Web.Models.VisualizzareLotto command)
        {
            using (var ctx = GetContainer())
            {
                var query = from i in ctx.Lottoes
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
        public ActionResult CreateLotto()
        {
            using (var context = GetContainer())
            {
                var model = new UI_Web.Models.CreateLotto()
                                {
                                    CreationDate = Now,
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View("CreateLotto", model);
            }
        }

        [HttpPost]
        public JsonResult CreateLotto(CreateLotto command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult EditLotto(Guid id)
        {
            using (var context = GetContainer())
            {
                var query = context.Lottoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Edit Lotto not found for id {0}", id));

                var model = new Models.EditLotto()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View("EditLotto", model);
            }
        }

        [HttpPost]
        public JsonResult UpdateLotto(UpdateLotto command)
        {
            return Execute(command);
        }

        [HttpGet]
        public ActionResult DeleteLotto(Guid id)
        {
            using (var context = GetContainer())
            {
                var query = context.Lottoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Lotto not found for id {0}", id));


                var model = new Models.DeleteLotto()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View("DeleteLotto", model);
            }
        }

        [HttpPost]
        public JsonResult Delete(DeleteLotto command)
        {
            return Execute(command);
        }


    }
}
