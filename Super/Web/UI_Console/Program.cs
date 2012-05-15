using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EasyNetQ;
using UI_Console.ServiceReference1;


namespace UI_Console
{
    class Program
    {
        //static IBus Bus;

        static void Main(string[] args)
        {
            //var request = new ExecuteRequest();
            //var client = new CommandWebServiceClient();
            //client.Execute();
            //Bus = RabbitHutch.CreateBus("host=localhost");

            //string subscriptionId = "Super";
            //Bus.Subscribe<CreareNuovoAreaIntervento>(subscriptionId, msg => ExecutorMessage(msg));
        }

        //static void ExecutorMessage(CreareNuovoAreaIntervento cmd)
        //{
        //    Console.WriteLine("---------------------------------");

        //    var evt = new AreaInterventoCreata()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Descrizione = "test descrizione",
        //        Inizio = DateTime.Now,
        //        Fine = DateTime.Now,
        //        IdAreaInterventoSuper = 12
        //    };

        //    Bus.Publish<AreaInterventoCreata>(evt);


         
        //}
    }
}
