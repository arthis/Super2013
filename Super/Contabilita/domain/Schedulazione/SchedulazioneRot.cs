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
    

    public class SchedulazioneRot : AggregateBase
    {
        private readonly Guid _id;
        private Guid _idTipoIntervento;
        private Guid _idScenario;
        private Period _period;
        private WorkPeriod _workPeriod;
        private IEnumerable<OggettoRot> _oggetti;

        public SchedulazioneRot()
        {
            
        }

        public SchedulazioneRot(Guid id, Guid idTipoIntervento, Guid idScenario, int quantity,Period period,  WorkPeriod workPeriod, IEnumerable<OggettoRot> oggetti)
        {
            var evt = BuildEvt.SchedulazioneRotCreated
                .ForPeriod(period.ToMessage())
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriod.ToMessage())
                .WithOggetti(oggetti.ToMessage().ToArray())
                .OfTipoIntervento(idTipoIntervento);

            RaiseEvent(id,evt);
        }

        public void Apply(SchedulazioneRotCreated evt)
        {
            Id = evt.Id;
            _idTipoIntervento = evt.IdTipoIntervento;
            _idScenario = evt.IdScenario;
            _oggetti = evt.Oggetti.ToDomain();
            _period = evt.Period.ToDomain();
            _workPeriod = evt.WorkPeriod.ToDomain();
        }

        public void CalculateBasePrice(PricingRot pricing)
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
