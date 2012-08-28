using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class CreateCarriageRotManBuilder : ICommandBuilder<CreateCarriageRotMan>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;


        public CreateCarriageRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateCarriageRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateCarriageRotMan(id, commitId, version, _sign, _description, _isInternational);
            return cmd;
        }


        public CreateCarriageRotManBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CreateCarriageRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateCarriageRotManBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }

    }
}