using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging;
using Super.Contabilita.Domain.Pricing;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Domain.Intervento
{
    public class InterventoRot : AggregateBase
    {
        private Guid _idPlan;
        private Guid _idTipoIntervento;
        private IEnumerable<OggettoRot> _oggetti;
        private Period _period;

        public InterventoRot()
        {
            
        }

        public InterventoRot(Guid id, Guid idTipoIntervento, Guid idPlan, IEnumerable<OggettoRot> oggetti, Period period)
        {
            var periodBuilder = BuildMessagingVO.Period;
            period.BuildValue(periodBuilder);

            var evt = BuildEvt.InterventoRotCreated
                .ForPeriod(periodBuilder.Build())
                .ForPlan(idPlan)
                .OfType(idTipoIntervento)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotCreated e)
        {
            Id = e.Id;
            _idPlan = e.IdPlan;
            _idTipoIntervento = e.IdTipoIntervento;
            _oggetti = e.Oggetti.ToDomainObjects();
            _period = Period.FromMessage(e.Period);
        }

        public void CalculatePrice(Pricing.Pricing bachibousouk)
        {
            var priceCalculation = new InterventoRotBasePriceCalculation(_idTipoIntervento, _oggetti, _period);
            
            var evt = BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(_idPlan)
                .ToPrice(bachibousouk.CalculateBasePrice(priceCalculation));

            RaiseEvent(evt);
        }

        public void Apply(InterventoPriceOfPlanCalculated e)
        {
            
        }   
    }
}
