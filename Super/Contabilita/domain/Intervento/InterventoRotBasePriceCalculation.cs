using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Pricing;
using System.Linq;

namespace Super.Contabilita.Domain.Intervento
{
    public class InterventoRotBasePriceCalculation : IBasePriceCalculation
    {
        private readonly Guid _idTipoIntervento;
        private readonly IEnumerable<OggettoRot> _oggetti;
        private readonly Period _period;

        public InterventoRotBasePriceCalculation(Guid idTipoIntervento, IEnumerable<OggettoRot> oggetti, Period period)
        {
            Contract.Requires(idTipoIntervento!= Guid.Empty);
            Contract.Requires(oggetti!=null);
            Contract.Requires(period!=null);

            _idTipoIntervento = idTipoIntervento;
            _oggetti = oggetti;
            _period = period;
        }

        public decimal Calculate(List<BasePrice> prices)
        {
            var totalPrice = 0M;
            foreach(var date in _period.GetDays())
            {
                foreach(var oggetto  in _oggetti)
                {
                    var price =
                        prices.SingleOrDefault(x => x.Fits(date, oggetto.IdGruppoOggettoIntervento, _idTipoIntervento));

                    if (price != null)
                        totalPrice += price.Value * oggetto.Quantity;
                }
            }

            return totalPrice;
        }
    }
}