using System;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Contabilita.Domain.Pricing
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


        public decimal Value
        {
            get { return _value; }
        }

        public bool Fits(DateTime date,Guid idGruppoOggettoIntervento,Guid idTipoIntervento)
        {
            return _interval.Contains(date) && _idGruppoOggettoIntervento == idGruppoOggettoIntervento && _idTipoIntervento == idTipoIntervento;
        }
    }
}