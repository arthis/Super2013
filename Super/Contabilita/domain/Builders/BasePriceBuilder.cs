using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Domain.Builders
{
    public class BasePriceRotBuilder
    {
        private decimal _value;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idTipoIntervento;
        private IntervalOpened _interval;

        public BasePriceRot Build()
        {
            return new BasePriceRot(_value, _idGruppoOggettoIntervento, _idTipoIntervento, _interval);
        }

        public BasePriceRotBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceRotBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

        public BasePriceRotBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceRotBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }
    }

    public class BasePriceRotManBuilder
    {
        private decimal _value;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idTipoIntervento;
        private IntervalOpened _interval;

        public BasePriceRotMan Build()
        {
            return new BasePriceRotMan(_value, _idGruppoOggettoIntervento, _idTipoIntervento, _interval);
        }

        public BasePriceRotManBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceRotManBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

        public BasePriceRotManBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceRotManBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }
    }

    public class BasePriceAmbBuilder
    {
        private decimal _value;
        private Guid _idTipoIntervento;
        private IntervalOpened _interval;

        public BasePriceAmb Build()
        {
            return new BasePriceAmb(_value,  _idTipoIntervento, _interval);
        }

        public BasePriceAmbBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceAmbBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceAmbBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }
    }
}
