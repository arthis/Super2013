using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Ambiente
{
    public class CreateTipoOggettoInterventoAmbBuilder : ICommandBuilder<CreateTipoOggettoInterventoAmb>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public CreateTipoOggettoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateTipoOggettoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateTipoOggettoInterventoAmb(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public CreateTipoOggettoInterventoAmbBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public CreateTipoOggettoInterventoAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateTipoOggettoInterventoAmbBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }


    }
}
