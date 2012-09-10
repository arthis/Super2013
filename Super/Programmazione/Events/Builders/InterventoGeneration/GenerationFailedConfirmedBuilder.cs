using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.InterventoGeneration
{
    public class GenerationOfInterventiFailedConfirmedBuilder : IEventBuilder<GenerationOfInterventiFailedConfirmed>
    {


        public GenerationOfInterventiFailedConfirmed Build(Guid id, long version)
        {
            var evt = new GenerationOfInterventiFailedConfirmed(id, Guid.NewGuid(), version);

            return evt;
        }

    }
}