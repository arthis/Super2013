using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.bachibouzouk;

namespace Super.Contabilita.Domain.Builders
{
    public class OggettoInterventoRotBuilder
    {
        private Guid _idGruppoOggettoIntervento;
        private string _description;
        private Guid _idIntervento;
        private Guid _idTipoOggettoIntervento;

        public OggettoInterventoRot Build()
        {
            return new OggettoInterventoRot(_idIntervento,_idTipoOggettoIntervento, _idGruppoOggettoIntervento,_description);
        }

        public OggettoInterventoRotBuilder ForInterventoRotBuilder(decimal value)
        {
            _value = value;
            return this;
        }

        public OggettoInterventoRotBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }

        public OggettoInterventoRotBuilder ForType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public OggettoInterventoRotBuilder ForInterval(IntervalOpened interval)
        {
            _interval = interval;
            return this;
        }
    }
}
