using System;
using System.Collections.Generic;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.bachibouzouk;

namespace Super.Contabilita.Domain.Intervento
{
    public class InterventoBasePriceCalculation : IBasePriceCalculation
    {
        private readonly Guid _idTipoIntervento;
        private readonly IEnumerable<OggettoRot> _oggetti;
        private readonly Period _period;

        public InterventoBasePriceCalculation(Guid idTipoIntervento, IEnumerable<OggettoRot> oggetti, Period period)
        {
            _idTipoIntervento = idTipoIntervento;
            _oggetti = oggetti;
            _period = period;
        }

       

        public void Calculate(List<BasePrice> prices)
        {
            
        }

        public decimal GetValue()
        {
            throw new NotImplementedException();
        }
    }
}