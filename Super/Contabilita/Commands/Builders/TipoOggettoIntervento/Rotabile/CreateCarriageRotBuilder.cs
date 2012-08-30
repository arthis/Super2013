using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile
{
    public class CreateCarriageRotBuilder : ICommandBuilder<CreateCarriageRot>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;
        private Guid _idGruppoOggettoIntervento;


        public CreateCarriageRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateCarriageRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateCarriageRot(id, commitId, version, _sign, _description, _isInternational, _idGruppoOggettoIntervento);
            return cmd;
        }


        public CreateCarriageRotBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CreateCarriageRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateCarriageRotBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

        public CreateCarriageRotBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }


    }
}