using System;
using System.ServiceModel;
using CommandService;
using EasyNetQ;
using Super.Controllo.Handlers;
using Super.Controllo.Projection;

namespace Super.Controllo.ControlloService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost"); ;
            var commandHandlerService = new CommandHandlerService();
            var projectionHandler = new ProjectionHandlerService();
            var commandWebService = new CommandWebService(bus, commandHandlerService, projectionHandler);

            commandWebService.Init();

            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Controllo service started");
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
