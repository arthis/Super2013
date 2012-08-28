using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class UpdateLocomotiveRotManBuilder : ICommandBuilder<UpdateLocomotiveRotMan>
    {
        private string _description;
        private string _sign;


        public UpdateLocomotiveRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateLocomotiveRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateLocomotiveRotMan(id, commitId, version, _sign, _description);

            return cmd;
        }


        public UpdateLocomotiveRotManBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public UpdateLocomotiveRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }
    }
}
