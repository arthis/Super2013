using System;
using System.ServiceModel;
using EasyNetQ;
using Super.Saga.Handlers;

namespace Super.Saga.SagaService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            var messageHandler = new MessageHandlerService(bus);
            var service = new Service(messageHandler);

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
