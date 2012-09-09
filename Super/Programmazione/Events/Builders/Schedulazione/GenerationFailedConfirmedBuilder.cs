using System;
using CommonDomain;
using Super.Programmazione.Events.InterventoGenerator;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class GenerationFailedConfirmedBuilder : IEventBuilder<GenerationFailedConfirmed>
    {


        public GenerationFailedConfirmed Build(Guid id, long version)
        {
            var evt = new GenerationFailedConfirmed(id, Guid.NewGuid(), version);

            return evt;
        }

    }
}