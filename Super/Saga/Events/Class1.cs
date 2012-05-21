using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Saga.Events
{
    public class InterventoProgrammato : Message,IEvent
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string ToDescription()
        {
            return string.Format("The Intervento {0} is programato.", Id);
        }
    }
}
