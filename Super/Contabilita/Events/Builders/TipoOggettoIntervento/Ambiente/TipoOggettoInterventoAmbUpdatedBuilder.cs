using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Ambiente
{
    public class TipoOggettoInterventoAmbUpdatedBuilder : IEventBuilder<TipoOggettoInterventoAmbUpdated>
    {
        private string _description;
        private string _sign;
        private Guid _idGruppoOggettoIntervento;


        public TipoOggettoInterventoAmbUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOggettoInterventoAmbUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOggettoInterventoAmbUpdated(id, commitId, version, _sign, _description, _idGruppoOggettoIntervento);

            return cmd;
        }


        public TipoOggettoInterventoAmbUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public TipoOggettoInterventoAmbUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public TipoOggettoInterventoAmbUpdatedBuilder ForGruppoOggetto(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }


    }
}
