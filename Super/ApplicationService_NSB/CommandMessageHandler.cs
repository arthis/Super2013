using System;
using System.Threading;
using Commands;
using NServiceBus;
using Commands.AreaIntervento;
using Ncqrs.NServiceBus;
using Ncqrs.Commanding.ServiceModel;

namespace ApplicationService_NSB
{

    //public class CommandMessageHandler2 : IHandleMessages<CreareNuovoAreaIntervento>
    //{
    //    public IBus Bus { get; set; }

    //    public void Handle(CreareNuovoAreaIntervento command)
    //    {
    //        Console.WriteLine("======================================================================");

    //    }
    //}

    //public class CommandMessageHandler : IHandleMessages<AggiornareAreaIntervento>
    //{
    //    public IBus Bus { get; set; }

    //    public void Handle(AggiornareAreaIntervento command)
    //    {
    //        Console.WriteLine("======================================================================");

    //    }
    //}

    /// <summary>
    /// NServiceBus message handler for messages transporting Ncqrs commands.
    /// </summary>
    public class NcqrsMessageHandler : IHandleMessages<CommandMessage>
    {
        /// <summary>
        /// Command service which is injected by NServiceBus infrastructure.
        /// </summary>
        public ICommandService CommandService { get; set; }

        public void Handle(CommandMessage message)
        {
            CommandService.Execute(message.Payload);
        }
    }
}
