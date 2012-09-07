using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class InterventiAskedTobeGeneratedBuilder : IEventBuilder<InterventiAskedTobeGenerated>
    {


        public InterventiAskedTobeGenerated Build(Guid id, long version)
        {
            var evt = new InterventiAskedTobeGenerated(id, Guid.NewGuid(), version);

            return evt;
        }

    }
}