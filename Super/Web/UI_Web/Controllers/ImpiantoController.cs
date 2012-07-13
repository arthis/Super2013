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
using Super.Contabilita.Commands.Impianto;



namespace UI_Web.Controllers
{
    public class ImpiantoController : ControllerContabilita
    {


        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetItems(UI_Web.Models.VisualizzareImpianto command)
        {
            using (var ctx = GetContainer())
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
        public ActionResult CreateImpianto(Guid id)
        {
            using (var context = GetContainer())
            {
                var command = Build.CreateImpianto
                    .ForCreationDate(Now)
                    .ForIntervall(new Intervall(Now, null))
                    .ForLotto(Guid.NewGuid()) //this guid will be replaced by the correct guid on the client side
                    .Build(Guid.NewGuid(), Guid.NewGuid(), 0);

                var lotti = context.Lottoes.OrderBy(x => x.Description)
                    .Select(x => new SelectListItem()
                                     {
                                         Text = x.Description,
                                         Value = x.Id.ToString()
                                     })
                                     .ToList();
                lotti.Insert(0, new SelectListItem() { Text = "Choose a lotto", Value = Guid.Empty.ToString(), Selected = true });
                var model = new UI_Web.Models.CreateImpianto()
                                {
                                    Command = command,
                                    Lotti = lotti
                                };

                return View("CreateImpianto", model);
            }
        }

        [HttpPost]
        public void CreateImpianto(CreateImpianto command)
        {
            if (ModelState.IsValid)
            {
                //send the command to the bounded context
            }
        }

        [HttpGet]
        public ActionResult EditImpianto(Guid id)
        {
            using (var context = GetContainer())
                    {
                        var query = context.Impiantoes.Where(item => !item.Deleted);

                        var projection = query.Where(x=> x.Id== id).SingleOrDefault();

                        if (projection==null)
                            throw new Exception(string.Format("Edit Impianto not found for id {0}", id));

                 
                var command = Build.UpdateImpianto
                    .ForIntervall(new Intervall(projection.Start, projection.End))
                    .ForDescription(projection.Description)
                    .Build(projection.Id, Guid.NewGuid(), projection.Version);

                var lotto = context.Lottoes.Single(x => x.Id == projection.Id);


                var model = new UI_Web.Models.EditImpianto()
                                {
                                    Command = command,
                                    LottoDescription = lotto.Description
                                };

                return View("EditImpianto", model);
            }
        }

        [HttpPost]
        public void UpdateImpianto(UpdateImpianto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }

        [HttpGet]
        public ActionResult DeleteImpianto(Guid id)
        {
            using (var context = GetContainer())
            {
                var query = context.Impiantoes.Where(item => !item.Deleted);

                var projection = query.Where(x => x.Id == id).SingleOrDefault();

                if (projection == null)
                    throw new Exception(string.Format("Delete Impianto not found for id {0}", id));


                var command = Build.DeleteImpianto
                    .Build(projection.Id, Guid.NewGuid(), projection.Version);

               var lotto = context.Lottoes.Single(x => x.Id == projection.Id);

               var model = new UI_Web.Models.DeleteImpianto()
                {
                    Command = command,
                    Description = projection.Description,
                    Start = projection.Start,
                    End = projection.End,
                    LottoDescription = lotto.Description
                    
                };

                return View("DeleteImpianto", model);
            }
        }

        [HttpPost]
        public void Delete(DeleteImpianto command)
        {
            if (ModelState.IsValid)
            {
                var validation = CommandService.Execute(command);
            }
        }


    }
}
