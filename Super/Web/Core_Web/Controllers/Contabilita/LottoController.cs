using System;
using System.Linq;
using System.Web.Mvc;
using Core_Web.Models;
using Super.Contabilita.Commands.Lotto;
using CreateLotto = Super.Contabilita.Commands.Lotto.CreateLotto;
using DeleteLotto = Core_Web.Models.DeleteLotto;

namespace Core_Web.Controllers
{
    public class LottoController : ControllerContabilitaBase
    {
        protected override string GetView(string url)
        {
            url = string.Format("Lotto/{0}", url);
            return base.GetView(url);
        }

        public ActionResult Index()
        {
            return View(GetView("Index"));
        }


        public JsonResult GetItems(VisualizzareLotto command)
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
                var model = new Models.CreateLotto()
                                {
                                    CreationDate = Now,
                                    Start = Now,
                                    Id = Guid.NewGuid(),
                                    CommitId = Guid.NewGuid(),
                                    Version = 0,
                                };

                return View(GetView("CreateLotto"), model);
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

                var model = new EditLotto()
                                {
                                    Start = projection.Start,
                                    End = projection.End,
                                    Id = projection.Id,
                                    CommitId = Guid.NewGuid(),
                                    Version = projection.Version,
                                    Description = projection.Description
                                };

                return View(GetView("EditLotto"), model);
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


                var model = new DeleteLotto()
                 {
                     Id = projection.Id,
                     CommitId = Guid.NewGuid(),
                     Version = projection.Version,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View(GetView("DeleteLotto"), model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Super.Contabilita.Commands.Lotto.DeleteLotto command)
        {
            return Execute(command);
        }


    }
}
