using System;
using System.ServiceModel;
using CommonDomain.Core;
using Super.Saga.Handlers;

namespace Super.Saga.SagaService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new RabbitBus();
            var messageHandler = new MessageHandlerService();
            var service = new Service(messageHandler, bus);

            service.Start();
            Console.WriteLine("saga service started");
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
