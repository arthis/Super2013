﻿using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class LocomotiveRotUpdatedBuilder : IEventBuilder<LocomotiveRotUpdated>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public LocomotiveRotUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public LocomotiveRotUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new LocomotiveRotUpdated(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public LocomotiveRotUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public LocomotiveRotUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LocomotiveRotUpdatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }
    }
}
