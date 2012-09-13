using System;
using CommonDomain.Core;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Domain
{
    public class Plan : AggregateBase
    {
        public Plan()
        {
            
        }

        public Plan(Guid id)
        {
            var evt = BuildEvt.PlanCreated;

            RaiseEvent(id, evt);
        }

        public void Apply(PlanCreated e)
        {
            Id = e.Id;
        }
    }
}
