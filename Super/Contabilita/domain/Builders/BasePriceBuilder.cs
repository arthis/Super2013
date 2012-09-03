using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Domain.Builders
{
    public class BasePriceBuilder
    {
        private decimal _value;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idTipoIntervento;
        private IntervalOpened _interval;

        public BasePrice Build()
        {
            return new BasePrice(_value,_idGruppoOggettoIntervento,_idTipoIntervento, _interval);
        }

        public BasePriceBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

        public BasePriceBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }
    }
}
