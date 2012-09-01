using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Contabilita.Domain
{
    public class Intervento : AggregateBase
    {
        public void CalculatePrice()
        {
            throw new NotImplementedException();
        }

      public void CalculatePrice(bachibouzouk.bachibouzouk bachibousouk, Guid idPlan, Guid idTipoIntervento, IEnumerable<OggettoRot> toValueObject, Period fromMessage)
        {
            throw new NotImplementedException();
        }
    }
}
