using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Pricing;

namespace Super.Contabilita.Events.Builders.Pricing
{
    public class BasePriceCreatedBuilder : IEventBuilder<BasePriceCreated>
    {
        private decimal _value;
        private IntervalOpened _interval;
        private Guid _idTipoIntervento;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idBasePrice;

        public BasePriceCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public BasePriceCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new BasePriceCreated(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento,
                                           _idGruppoOggettoIntervento);
            return cmd;
        }

        public BasePriceCreatedBuilder ForBasePrice(Guid idBasePrice)
        {
            _idBasePrice = idBasePrice;
            return this;
        }

        public BasePriceCreatedBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceCreatedBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }

        public BasePriceCreatedBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceCreatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }




    }
}