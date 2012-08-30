using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Price;

namespace Super.Contabilita.Events.Builders.Price
{
    public class BasePriceUpdatedBuilder : IEventBuilder<BasePriceUpdated>
    {
        private decimal _value;
        private IntervalOpened _interval;
        private Guid _idTipoIntervento;
        private Guid _idGruppoOggettoIntervento;

        public BasePriceUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public BasePriceUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new BasePriceUpdated(id, commitId, version, _value, _interval, _idTipoIntervento,
                                          _idGruppoOggettoIntervento);
            return cmd;
        }

        public BasePriceUpdatedBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public BasePriceUpdatedBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }

        public BasePriceUpdatedBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public BasePriceUpdatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }



        
    }
}