using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Ambiente
{
    public class TipoOggettoInterventoAmbCreatedBuilder : IEventBuilder<TipoOggettoInterventoAmbCreated>
    {
        private string _description;
        private string _sign;


        public TipoOggettoInterventoAmbCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOggettoInterventoAmbCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOggettoInterventoAmbCreated(id, commitId, version, _sign, _description);

            return cmd;
        }


        public TipoOggettoInterventoAmbCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public TipoOggettoInterventoAmbCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
