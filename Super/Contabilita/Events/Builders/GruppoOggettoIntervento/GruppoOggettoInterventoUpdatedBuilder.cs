using System;
using CommonDomain;
using Super.Contabilita.Events.GruppoOggettoIntervento;

namespace Super.Contabilita.Events.Builders.GruppoOggettoIntervento
{
    public class GruppoOggettoInterventoUpdatedBuilder : IEventBuilder<GruppoOggettoInterventoUpdated>
    {
        private string _description;

        public GruppoOggettoInterventoUpdated Build(Guid id, long version)
        {
            var evt = new GruppoOggettoInterventoUpdated(id, Guid.NewGuid() ,version,  _description);
            
            return evt;
        }

        public GruppoOggettoInterventoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }


}