using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class CreateLocomotiveRotManBuilder : ICommandBuilder<CreateLocomotiveRotMan>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public CreateLocomotiveRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateLocomotiveRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateLocomotiveRotMan(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public CreateLocomotiveRotManBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CreateLocomotiveRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateLocomotiveRotManBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

    }
}
