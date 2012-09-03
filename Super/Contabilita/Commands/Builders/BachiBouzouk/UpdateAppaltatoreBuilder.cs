using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Commands.Builders.Pricing
{
    public class UpdateBasePriceBuilder : ICommandBuilder<UpdateBasePrice>
    {
        private decimal _value;
        private IntervalOpened _interval;
        private Guid _idTipoIntervento;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idBasePrice;

        public UpdateBasePrice Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateBasePrice Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateBasePrice(id, commitId, version,_idBasePrice, _value, _interval, _idTipoIntervento,
                                          _idGruppoOggettoIntervento);
            return cmd;
        }

        public UpdateBasePriceBuilder ForBasePrice(Guid idBasePrice)
        {
            _idBasePrice = idBasePrice;
            return this;
        }

        public UpdateBasePriceBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public UpdateBasePriceBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }

        public UpdateBasePriceBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateBasePriceBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }



        
    }
}