using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class CarriageRotCreatedBuilder : IEventBuilder<CarriageRotCreated>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;


        public CarriageRotCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CarriageRotCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CarriageRotCreated(id, commitId, version, _sign, _description, _isInternational);
            return cmd;
        }


        public CarriageRotCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CarriageRotCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CarriageRotCreatedBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

    }
}