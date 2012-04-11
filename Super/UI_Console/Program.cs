using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Commands;
using Commands.Interventi;
using Commands.AreaIntervento;
using EasyNetQ;
using Events.AreaIntervento;
using System.Data.SqlClient;


namespace UI_Console
{
    class Program
    {
        static IBus Bus;

        static void Main(string[] args)
        {

            Bus = RabbitHutch.CreateBus("host=localhost");

            string subscriptionId = "Super";
            Bus.Subscribe<CreareNuovoAreaIntervento>(subscriptionId, msg => ExecutorMessage(msg));
        }

        static void ExecutorMessage(CreareNuovoAreaIntervento cmd)
        {
            Console.WriteLine("---------------------------------");

            var evt = new AreaInterventoCreata()
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Descrizione = "test descrizione",
                Inizio = DateTime.Now,
                Fine = DateTime.Now,
                IdAreaInterventoSuper = 12
            };

            Bus.Publish<AreaInterventoCreata>(evt);


         
        }
    }
}
