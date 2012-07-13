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
        public ActionResult CreateLotto(Guid id)
        {
            using (var context = GetContainer())
            {
                var command = Build.CreateLotto
                    .ForCreationDate(Now)
                    .ForIntervall(new Intervall(Now, null))
                    .Build(Guid.NewGuid(), Guid.NewGuid(), 0);

                var model = new UI_Web.Models.CreateLotto()
                                {
                                    Command = command,
                                };

                return View("CreateLotto", model);
            }
        }

        [HttpPost]
        public void CreateLotto(CreateLotto command)
        {
            if (ModelState.IsValid)
            {
                //send the command to the bounded context
            }
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


                var command = Build.UpdateLotto
                    .ForIntervall(new Intervall(projection.Start, projection.End))
                    .ForDescription(projection.Description)
                    .Build(projection.Id, Guid.NewGuid(), projection.Version);


                var model = new UI_Web.Models.EditLotto()
                                {
                                    Command = command
                                };

                return View("EditLotto", model);
            }
        }

        [HttpPost]
        public void UpdateLotto(UpdateLotto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
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


                var command = Build.DeleteLotto
                    .Build(projection.Id, Guid.NewGuid(), projection.Version);


                var model = new UI_Web.Models.DeleteLotto()
                 {
                     Command = command,
                     Description = projection.Description,
                     Start = projection.Start,
                     End = projection.End
                 };

                return View("DeleteLotto", model);
            }
        }

        [HttpPost]
        public void Delete(DeleteLotto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }


    }
}
