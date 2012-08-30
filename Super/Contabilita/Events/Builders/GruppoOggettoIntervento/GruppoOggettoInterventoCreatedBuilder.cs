using System;
using CommonDomain;
using Super.Contabilita.Events.GruppoOggettoIntervento;

namespace Super.Contabilita.Events.Builders.GruppoOggettoIntervento
{
    public class GruppoOggettoInterventoCreatedBuilder : IEventBuilder<GruppoOggettoInterventoCreated>
    {
        private string _description;


        public GruppoOggettoInterventoCreated Build(Guid id, long version)
        {
            var evt = new GruppoOggettoInterventoCreated(id, Guid.NewGuid() ,version,    _description);
            
            return evt;
        }


        public GruppoOggettoInterventoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }

}