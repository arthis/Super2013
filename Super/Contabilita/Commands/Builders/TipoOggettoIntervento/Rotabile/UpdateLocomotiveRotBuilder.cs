using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile
{
    public class UpdateLocomotiveRotBuilder : ICommandBuilder<UpdateLocomotiveRot>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public UpdateLocomotiveRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateLocomotiveRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateLocomotiveRot(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public UpdateLocomotiveRotBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public UpdateLocomotiveRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateLocomotiveRotBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }
    }
}
