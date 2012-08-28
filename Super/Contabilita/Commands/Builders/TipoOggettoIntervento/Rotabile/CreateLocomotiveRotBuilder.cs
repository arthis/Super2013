using System;
using CommonDomain;
using Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile
{
    public class CreateLocomotiveRotBuilder : ICommandBuilder<CreateLocomotiveRot>
    {
        private string _description;
        private string _sign;


        public CreateLocomotiveRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateLocomotiveRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateLocomotiveRot(id, commitId, version, _sign, _description);

            return cmd;
        }


        public CreateLocomotiveRotBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CreateLocomotiveRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }
}
