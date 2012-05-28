using System;
using System.ServiceModel;
using CommandService;
using Super.Administration.Handlers;
using Super.Administration.Projection;

namespace Super.Administration.AdministrationService
{
    class Program
    {
        static void Main(string[] args)
        {

            var commandHandler = new CommandHandlerService();
            var projectionHandler = new ProjectionHandlerService();
            var commandWebService = new CommandWebService( commandHandler, projectionHandler);
            
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
