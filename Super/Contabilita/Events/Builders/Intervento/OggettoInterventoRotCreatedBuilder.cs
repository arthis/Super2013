using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Events.Builders.Intervento
{
    public class InterventoRotCreatedBuilder : IEventBuilder<InterventoRotCreated>
    {
        private Guid _idTipoIntervento;
        private Guid _idPlan;
        private OggettoRot[] _oggetti;
        private Period _period
            ;


        public InterventoRotCreated Build(Guid id, long version)
        {
            var evt = new InterventoRotCreated(id, Guid.NewGuid(), version,_idTipoIntervento,_idPlan, _oggetti, _period);
            
            return evt;
        }


        public InterventoRotCreatedBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotCreatedBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoRotCreatedBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotCreatedBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }



    }

}