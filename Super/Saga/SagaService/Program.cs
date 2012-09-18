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
