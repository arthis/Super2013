using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
//using Cqrs.CommandService.Contracts;
using ReadModel;
using Commands.AreaIntervento;
using Commands;
//using Cqrs.CommandService;
using UI_Web.Models;
using System.Threading;
using NServiceBus;
using RabbitMQ.Client;
using System.Text;
using EasyNetQ;
using Cqrs.Commanding;


namespace UI_Web.Controllers
{
    public class AreaInterventoController : ControllerBaseSuper
    {
        //private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static AreaInterventoController()
        {
            //_channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");

        }

        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetItems(VisualizzareAreaIntervento command)
        {
            using (var context = new ReadModelContainer())
            {
                var query = context.AreaIntervento.Where(item => !item.Deleted);

                if (!string.IsNullOrEmpty(command.Descrizione))
                    query = query.Where(item => item.Descrizione.IndexOf(command.Descrizione) > -1);

                var results = query.OrderBy(item => item.CreationDate)
                                   .Skip((command.PageNum - 1) * command.PageSize)
                                   .Take(command.PageSize)
                                   .Select(item => new { item.Id, item.IdAreaInterventoSuper, item.Inizio, item.Fine, item.CreationDate, item.Descrizione })
                                   .ToArray();

                var count = query.Count();

                var returnObject = new { results, count };

                return this.Json(returnObject, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Creare()
        {
            return View("Details");
        }

        [HttpPost]
        public void Creare(CreareNuovoAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                //               client.Execute(new ExecuteRequest(command)));

                //var msg = new CommandMessage() { Payload = command };
                //var msg = new CommandMessage() { MyProperty = 2 };
                //IAsyncResult res = Bus.Send(command).Register(SimpleCommandCallback, this);
                //WaitHandle asyncWaitHandle = res.AsyncWaitHandle;
                //asyncWaitHandle.WaitOne(50000);

                //var connectionFactory = new ConnectionFactory();
                //connectionFactory.HostName = "localhost";
                //connectionFactory.UserName = "yoann";
                //connectionFactory.Password = "yogolo49";

                //using (IConnection connection =
                //            connectionFactory.CreateConnection())
                //{
                //    using (IModel model = connection.CreateModel())
                //    {
                //        string message = "test";
                //        model.ExchangeDeclare("MyExchange", ExchangeType.Fanout, true);
                //        model.QueueDeclare("MyQueue", true,true,true,new Dictionary<string, object>());
                //        model.QueueBind("MyQueue", "MyExchange", "");
                //        IBasicProperties basicProperties = model.CreateBasicProperties();
                //        model.BasicPublish("MyExchange", "", false, false, basicProperties, Encoding.UTF8.GetBytes(message));
                //    }
                //}

                var bus = RabbitHutch.CreateBus("host=localhost");

                bus.Publish(command);


            }
        }

        [HttpGet]
        public ActionResult Aggiornare()
        {
            return View("Details");
        }


        [HttpPost]
        public void Aggiornare(AggiornareAreaIntervento command)
        {
            if (ModelState.IsValid)
            { 
                //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                //               client.Execute(new ExecuteRequest(command)));

                //var msg = new CommandMessage() { Payload = command };
                //IAsyncResult res = Bus.Send(msg).Register(SimpleCommandCallback, this);
                //WaitHandle asyncWaitHandle = res.AsyncWaitHandle;
                //asyncWaitHandle.WaitOne(50000);
            }
        }

        private void SimpleCommandCallback(IAsyncResult asyncResult)
        {
            var result = asyncResult.AsyncState as CompletionResult;
            //var controller = result.State as AreaInterventoController;
        }

        [HttpPost]
        public void Cancellare(CancellareAreaIntervento command)
        {
            if (ModelState.IsValid)
            {
                //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                //               client.Execute(new ExecuteRequest(command)));
            }
        }


    }
}
