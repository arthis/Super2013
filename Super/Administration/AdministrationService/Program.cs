using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;

namespace CommandService
{
    class Program
    {
        static void Main(string[] args)
        {

            //var service = new ServiceAdministration();
            //service.Start();

            using (var host = new AdministrationService())
            {
                host.Open();

                Console.WriteLine("Administation service started");
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
