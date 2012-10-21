using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class SchedulazioneCancelledFromScenario : EventBase
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
            return string.Format("Schedulazione {0} é stata cancellata dal scenario ", Id);
        }


    }
}