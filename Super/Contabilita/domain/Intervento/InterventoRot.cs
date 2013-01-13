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
        private WorkPeriod _workPeriod;

        public InterventoRot()
        {
            
        }

        public InterventoRot(Guid id, Guid idTipoIntervento, Guid idPlan, IEnumerable<OggettoRot> oggetti, WorkPeriod workPeriod)
        {

            var evt = BuildEvt.InterventoRotCreated
                .ForWorkPeriod(workPeriod.ToMessage())
                .ForPlan(idPlan)
                .OfTipoIntervento(idTipoIntervento)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotCreated e)
        {
            Id = e.Id;
            _idPlan = e.IdPlan;
            _idTipoIntervento = e.IdTipoIntervento;
            _oggetti = e.Oggetti.ToDomain();
            _workPeriod = e.WorkPeriod.ToDomain();
        }

        public void CalculatePrice(PricingRot pricing)
        {
            var prices = from oggetto in _oggetti
                         select pricing.CalculateBasePrice(oggetto.IdGruppoOggettoIntervento, _idTipoIntervento, _workPeriod);
            var totalPrice = prices.Sum();

            var evt = BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(_idPlan)
                .ForPrice(totalPrice);

            RaiseEvent(evt);

        }

        public void Apply(InterventoPriceOfPlanCalculated e)
        {
            
        }   
    }
}
