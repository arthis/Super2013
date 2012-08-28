using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class UpdateCarriageRotManBuilder : ICommandBuilder<UpdateCarriageRotMan>
    {
        private string _description;
        private string _sign;
        private bool _isInternational;


        public UpdateCarriageRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateCarriageRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateCarriageRotMan(id, commitId, version, _sign, _description, _isInternational);
            return cmd;
        }


        public UpdateCarriageRotManBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public UpdateCarriageRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateCarriageRotManBuilder IsInternational(bool isInternational)
        {
            _isInternational = isInternational;
            return this;
        }
    }
}