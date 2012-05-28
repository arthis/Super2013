using System;
using System.ServiceModel;
using CommandService;
using Super.Administration.Handlers;
using Super.Administration.Projection;

namespace Super.Appaltatore.AppaltatoreService
{
    class Program
    {
        static void Main(string[] args)
        {

            var commandHandlerService = new CommandHandlerService();
            var projectionHandler = new ProjectionHandlerService();
            var commandWebService = new CommandWebService(commandHandlerService , projectionHandler);
            
            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Appaltatore service started");
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
