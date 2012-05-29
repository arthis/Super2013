using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.ServiceModel;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Super.Administration.Commands.AreaIntervento;
using UI_Console.ServiceReference1;



namespace UI_Console
{
    class Program
    {
        //static IBus Bus;

        static void Main(string[] args)
        {

            var cmd = new CreateAreaIntervento()
                          {
                              Id = Guid.NewGuid(),
                              CreationDate = DateTime.Now,
                              Description = "ttt",
                              End = DateTime.Now,
                              Start = DateTime.Now,

                          };
            var client = new CommandWebServiceClient();

            var executeRequest = new ExecuteRequest() { CommandBase = cmd };


            var validation = client.Execute(executeRequest);

            //string s = "dfdf";

            //client.Execute(cmd);    
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
        //        Start = DateTime.Now,
        //        End = DateTime.Now,
        //        IdAreaInterventoSuper = 12
        //    };

        //    Bus.Publish<AreaInterventoCreata>(evt);



        //}
    }

    
}
