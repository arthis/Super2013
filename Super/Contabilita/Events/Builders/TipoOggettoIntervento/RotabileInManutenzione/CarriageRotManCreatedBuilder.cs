using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class CarriageRotManCreatedBuilder : IEventBuilder<CarriageRotManCreated>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;
        private Guid _idGruppoOggettoIntervento;


        public CarriageRotManCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CarriageRotManCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CarriageRotManCreated(id, commitId, version, _sign, _description, _isInternational, _idGruppoOggettoIntervento);
            return cmd;
        }


        public CarriageRotManCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CarriageRotManCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CarriageRotManCreatedBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

        public CarriageRotManCreatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

    }
}