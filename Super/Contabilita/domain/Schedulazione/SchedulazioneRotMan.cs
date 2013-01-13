using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Pricing;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Schedulazione;

namespace Super.Contabilita.Domain.Schedulazione
{
    

    public class SchedulazioneRotMan : AggregateBase
    {
        private readonly Guid _id;
        private Guid _idTipoIntervento;
        private Guid _idScenario;
        private Period _period;
        private WorkPeriod _workPeriod;
        private IEnumerable<OggettoRotMan> _oggetti;

        public SchedulazioneRotMan()
        {
            
        }

        public SchedulazioneRotMan(Guid id, Guid idTipoIntervento, Guid idScenario, int quantity,Period period,  WorkPeriod workPeriod, IEnumerable<OggettoRotMan> oggetti)
        {
            var evt = BuildEvt.SchedulazioneRotManCreated
                .ForPeriod(period.ToMessage())
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriod.ToMessage())
                .WithOggetti(oggetti.ToMessage().ToArray())
                .OfTipoIntervento(idTipoIntervento);

            RaiseEvent(id,evt);
        }

        public void Apply(SchedulazioneRotManCreated evt)
        {
            Id = evt.Id;
            _idTipoIntervento = evt.IdTipoIntervento;
            _idScenario = evt.IdScenario;
            _oggetti = evt.Oggetti.ToDomain();
            _period = evt.Period.ToDomain();
            _workPeriod = evt.WorkPeriod.ToDomain();
        }

        public void CalculateBasePrice(PricingRotMan pricing)
        {

            var prices = from oggetto in _oggetti
                        select pricing.CalculateBasePrice(oggetto.IdGruppoOggettoIntervento, _idTipoIntervento, _period);
            var totalPrice = prices.Sum();

            var evt = BuildEvt.SchedulazionePriceOfScenarioCalculated
                .ForScenario(_idScenario)
                .ForPrice(totalPrice);

            RaiseEvent(evt);
        }
    }
}
