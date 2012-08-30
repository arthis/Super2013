using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class LocomotiveRotCreatedBuilder : IEventBuilder<LocomotiveRotCreated>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public LocomotiveRotCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public LocomotiveRotCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new LocomotiveRotCreated(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public LocomotiveRotCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public LocomotiveRotCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LocomotiveRotCreatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

    }
}
