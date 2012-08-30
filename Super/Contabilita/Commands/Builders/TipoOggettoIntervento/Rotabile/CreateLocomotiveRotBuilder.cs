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
        private Guid _idGruppoOggettoIntervento;


        public CreateLocomotiveRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateLocomotiveRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateLocomotiveRot(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

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

        public CreateLocomotiveRotBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

    }
}
