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


        public CreateCarriageRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateCarriageRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateCarriageRot(id, commitId, version, _sign, _description, _isInternational);
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

    }
}