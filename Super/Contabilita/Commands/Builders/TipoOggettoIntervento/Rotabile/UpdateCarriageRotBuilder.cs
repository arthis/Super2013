using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile
{
    public class UpdateCarriageRotBuilder : ICommandBuilder<UpdateCarriageRot>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;
        private Guid _idGruppoOggettoIntervento;


        public UpdateCarriageRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateCarriageRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateCarriageRot(id, commitId, version, _sign, _description, _isInternational, _idGruppoOggettoIntervento);
            return cmd;
        }


        public UpdateCarriageRotBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public UpdateCarriageRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateCarriageRotBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

        public UpdateCarriageRotBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }
    }
}