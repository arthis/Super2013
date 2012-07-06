using System;
using CommonDomain;

namespace Super.Controllo.Events.Builders
{
    public class InterventoControlAllowedBuilder : IEventBuilder<InterventoControlAllowed>
    {
        
        
        public InterventoControlAllowed Build(Guid id, long version)
        {
            var evt = new InterventoControlAllowed(id, Guid.NewGuid(), version);

            return evt;
        }

    }
}