using System;
using System.Collections.Generic;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Pricing;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Schedulazione;

namespace Super.Contabilita.Domain.Schedulazione
{
    

    public class SchedulazioneAmb : AggregateBase
    {
        private Guid _idTipoIntervento;
        private Guid _idScenario;
        private int _quantity;
        private Period _period;
        private WorkPeriod _workPeriod;

        public SchedulazioneAmb()
        {
            
        }

        public SchedulazioneAmb(Guid id, Guid idTipoIntervento, Guid idScenario, int quantity,Period period,  WorkPeriod workPeriod)
        {
            var evt = BuildEvt.SchedulazioneAmbCreated
                .ForPeriod(period.ToMessage())
                .ForQuantity(quantity)
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento);

            RaiseEvent(id,evt);
        }

        public void Apply(SchedulazioneAmbCreated evt)
        {
            Id = evt.Id;
            _idTipoIntervento = evt.IdTipoIntervento;
            _idScenario = evt.IdScenario;
            _quantity = evt.Quantity;
            _period = evt.Period.ToDomain();
            _workPeriod = evt.WorkPeriod.ToDomain();
        }

        public void CalculateBasePrice(PricingAmb pricing)
        {
            var price = pricing.CalculateBasePrice(_idTipoIntervento,_period) * _quantity;
            var evt = BuildEvt.SchedulazionePriceOfScenarioCalculated
                .ForScenario(_idScenario)
                .ForPrice(price);

            RaiseEvent(evt);
        }
    }
}
