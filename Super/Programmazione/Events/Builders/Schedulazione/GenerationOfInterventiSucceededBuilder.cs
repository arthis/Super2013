using System;
using CommonDomain;
using Super.Programmazione.Events.InterventoGenerator;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class GenerationOfInterventiSucceededBuilder : IEventBuilder<GenerationOfInterventiSucceeded>
    {


        public GenerationOfInterventiSucceeded Build(Guid id, long version)
        {
            var evt = new GenerationOfInterventiSucceeded(id, Guid.NewGuid(), version);

            return evt;
        }

    }
}