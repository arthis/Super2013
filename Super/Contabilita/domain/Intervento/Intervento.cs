using System;
using System.Collections.Generic;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.bachibouzouk;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Domain.Intervento
{
    public class Intervento : AggregateBase
    {
        public Intervento(Guid id)
        {
            
        }

        public void CalculatePrice(bachibouzouk.bachibouzouk bachibousouk, Guid idPlan, Guid idTipoIntervento, IEnumerable<OggettoRot> oggetti, Period period)
        {
            IBasePriceCalculation priceCalculation = new InterventoBasePriceCalculation(idTipoIntervento,oggetti,period);

            bachibousouk.CalculateBasePrice(priceCalculation);

            var evt = BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(idPlan);

            RaiseEvent(evt);
        }

        public void Apply(InterventoPriceOfPlanCalculated e)
        {
            
        }   
    }
}
