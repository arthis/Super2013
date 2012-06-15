using System;
using System.ServiceModel;
using CommandService;
using CommonDomain;
using EasyNetQ;
using Super.Administration.Handlers;
using Super.Administration.Projection;

namespace Super.Administration.AdministrationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost"); ;
            var commandHandler = new CommandHandlerService();
            var projectionHandler = new ProjectionHandlerService();
            var commandWebService = new CommandWebService(bus, commandHandler, projectionHandler);
            
            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Administration service started");
                var quitFlag = false;
                while (!quitFlag)
                {
                    var keyInfo = Console.ReadKey();
                    quitFlag = keyInfo.Key == ConsoleKey.C
                               && keyInfo.Modifiers == ConsoleModifiers.Control;
                }
            }



        }
    }
}
