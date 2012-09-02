using System;
using CommonDomain;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Events.Builders.Intervento
{
    public class OggettoInterventoRotCreatedBuilder : IEventBuilder<OggettoInterventoRotCreated>
    {
        private string _description;
        private Guid _idIntervento;
        private Guid _idTipoOggettoIntervento;
        private Guid _idGruppoOggettoIntervento;


        public OggettoInterventoRotCreated Build(Guid id, long version)
        {
            var evt = new OggettoInterventoRotCreated(id, Guid.NewGuid(), version,_idIntervento,_idTipoOggettoIntervento, _idGruppoOggettoIntervento, _description);
            
            return evt;
        }


        public OggettoInterventoRotCreatedBuilder ForIntervento(Guid idIntervento)
        {
            _idIntervento = idIntervento;
            return this;
        }

        public OggettoInterventoRotCreatedBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoOggettoIntervento = idTipoIntervento;
            return this;
        }

        public OggettoInterventoRotCreatedBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

        public OggettoInterventoRotCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }

}