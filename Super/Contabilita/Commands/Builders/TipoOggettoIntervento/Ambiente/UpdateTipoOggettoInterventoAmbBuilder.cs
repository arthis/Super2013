﻿using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Ambiente
{
    public class UpdateTipoOggettoInterventoAmbBuilder : ICommandBuilder<UpdateTipoOggettoInterventoAmb>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public UpdateTipoOggettoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateTipoOggettoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateTipoOggettoInterventoAmb(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public UpdateTipoOggettoInterventoAmbBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public UpdateTipoOggettoInterventoAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateTipoOggettoInterventoAmbBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }



    }
}
