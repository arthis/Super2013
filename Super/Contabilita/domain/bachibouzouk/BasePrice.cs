using System;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Contabilita.Domain.bachibouzouk
{
    public class BasePrice
    {
        private readonly decimal _value;
        private readonly Guid _idGruppoOggettoIntervento;
        private readonly Guid _idTipoIntervento;
        private readonly IntervalOpened _interval;

        public BasePrice(decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {
            _value = value;
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            _idTipoIntervento = idTipoIntervento;
            _interval = interval;
        }


        public IntervalOpened Interval1
        {
            get { return _interval; }
        }

        public Guid IdTipoIntervento
        {
            get { return _idTipoIntervento; }
        }

        public Guid IdGruppoOggettoIntervento
        {
            get { return _idGruppoOggettoIntervento; }
        }

        public decimal Value
        {
            get { return _value; }
        }
    }
}