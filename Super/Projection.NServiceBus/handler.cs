using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Events.AreaIntervento;

namespace Projection.NServiceBus
{
    public class EventMessageHandler : IHandleMessages<AreaInterventoCreata>
    {
        public void Handle(AreaInterventoCreata evt)
        {
            //Logger.Info(string.Format("Subscriber 1 received EventMessage with Id {0}.", message.EventId));
            //Logger.Info(string.Format("Message time: {0}.", message.Time));
            //Logger.Info(string.Format("Message duration: {0}.", message.Duration));
            Console.WriteLine("==========================================================================");
        }

        //private static readonly ILog Logger = LogManager.GetLogger(typeof(EventMessageHandler));
    }
}
