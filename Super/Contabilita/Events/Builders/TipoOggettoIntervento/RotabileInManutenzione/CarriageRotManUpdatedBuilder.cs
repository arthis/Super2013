using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class CarriageRotManUpdatedBuilder : IEventBuilder<CarriageRotManUpdated>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;
        private Guid _idGruppoOggettoIntervento;


        public CarriageRotManUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CarriageRotManUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CarriageRotManUpdated(id, commitId, version, _sign, _description, _isInternational, _idGruppoOggettoIntervento);
            return cmd;
        }


        public CarriageRotManUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CarriageRotManUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CarriageRotManUpdatedBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

        public CarriageRotManUpdatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }
    }
}