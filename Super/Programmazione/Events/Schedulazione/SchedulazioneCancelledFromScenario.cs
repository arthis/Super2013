using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class SchedulazioneCancelledFromScenario : Message,IEvent
    {
        
        public SchedulazioneCancelledFromScenario()
        {

        }

        public SchedulazioneCancelledFromScenario(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Schedulazione {0} � stata cancellata dal scenario ", Id);
        }


    }
}