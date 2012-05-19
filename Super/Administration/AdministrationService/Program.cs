using System;
using System.ServiceModel;
using CommandService;

namespace Super.Administration.AdministrationService
{
    class Program
    {
        static void Main(string[] args)
        {

            var administrationService = new Service();
            var commandWebService = new CommandWebService(administrationService);
            
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
