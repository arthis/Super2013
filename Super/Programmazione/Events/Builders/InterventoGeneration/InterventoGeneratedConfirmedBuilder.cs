using System;
using CommonDomain;
using Super.Programmazione.Events.InterventoGeneration;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.InterventoGeneration
{
    public class InterventoGeneratedConfirmedBuilder : IEventBuilder<InterventoGeneratedConfirmed>
    {
        private Guid _idIntervento;

        public InterventoGeneratedConfirmedBuilder ForIntervento (Guid idIntervento)
        {
            _idIntervento = idIntervento;
            return this;
        }


        public InterventoGeneratedConfirmed Build(Guid id, long version)
        {
            var evt = new InterventoGeneratedConfirmed(id, Guid.NewGuid(), version, _idIntervento);

            return evt;
        }

    }
}