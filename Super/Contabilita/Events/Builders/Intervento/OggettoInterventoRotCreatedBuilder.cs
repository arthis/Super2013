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
        private WorkPeriod _workPeriod
            ;


        public InterventoRotCreated Build(Guid id, long version)
        {
            var evt = new InterventoRotCreated(id, Guid.NewGuid(), version,_idTipoIntervento,_idPlan, _oggetti, _workPeriod);
            
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

        public InterventoRotCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }



    }

}