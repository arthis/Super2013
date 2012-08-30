using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class CarriageRotUpdatedBuilder : IEventBuilder<CarriageRotUpdated>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;
        private Guid _idGruppoOggettoIntervento;


        public CarriageRotUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CarriageRotUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CarriageRotUpdated(id, commitId, version, _sign, _description, _isInternational, _idGruppoOggettoIntervento);
            return cmd;
        }


        public CarriageRotUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CarriageRotUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CarriageRotUpdatedBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

        public CarriageRotUpdatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }
    }
}