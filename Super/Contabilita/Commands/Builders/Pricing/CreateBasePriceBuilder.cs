using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Commands.Builders.Pricing
{
    public class CreateBasePriceBuilder : ICommandBuilder<CreateBasePrice>
    {
        private decimal _value;
        private IntervalOpened _interval;
        private Guid _idTipoIntervento;
        private Guid _idGruppoOggettoIntervento;
        private Guid _idBasePrice;

        public CreateBasePrice Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateBasePrice Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateBasePrice(id, commitId, version,_idBasePrice, _value, _interval, _idTipoIntervento,
                                          _idGruppoOggettoIntervento);
            return cmd;
        }

        public CreateBasePriceBuilder ForBasePrice(Guid idBasePrice)
        {
            _idBasePrice = idBasePrice;
            return this;
        }

        public CreateBasePriceBuilder ForValue(decimal value)
        {
            _value = value;
            return this;
        }

        public CreateBasePriceBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }

        public CreateBasePriceBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public CreateBasePriceBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }



        
    }
}