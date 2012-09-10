using System;
using CommonDomain;
using Super.Programmazione.Events.InterventoGeneration;

namespace Super.Programmazione.Events.Builders.InterventoGeneration
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