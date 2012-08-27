using System;
using CommonDomain;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Events.Builders.Intervento
{
    public class InterventoPriceOfPlanCancelledBuilder : IEventBuilder<InterventoPriceOfPlanCancelled>
    {
        public InterventoPriceOfPlanCancelled Build(Guid id, long version)
        {
            var evt = new InterventoPriceOfPlanCancelled(id, Guid.NewGuid(), version);

            return evt;
        }
    }
}