using System;
using System.Threading;
using Commands;
using NServiceBus;
using Commands.AreaIntervento;


namespace ApplicationService
{

    public class CommandMessageHandler2 : IHandleMessages<CreareNuovoAreaIntervento>
    {
        public IBus Bus { get; set; }

        public void Handle(CreareNuovoAreaIntervento command)
        {
            Console.WriteLine("======================================================================");

        }
    }

    public class CommandMessageHandler : IHandleMessages<AggiornareAreaIntervento>
    {
        public IBus Bus { get; set; }

        public void Handle(AggiornareAreaIntervento command)
        {
            Console.WriteLine("======================================================================");

        }
    }

 
}
