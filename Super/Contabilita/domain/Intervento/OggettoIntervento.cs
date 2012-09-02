using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using Super.Contabilita.Domain.TipoOggettoIntervento;
using Super.Contabilita.Events;

namespace Super.Contabilita.Domain.Intervento
{
    public class OggettoInterventoRot : AggregateBase
    {
        

        public OggettoInterventoRot(Guid idIntervento, Guid idTipoOggettoIntervento, Guid idGruppoOggettoIntervento,  string description)
        {
            var evt = BuildEvt.OggettoInterventoRotCreated
                .ForDescription(description)
                .ForGruppoOggettoIntervento(idGruppoOggettoIntervento)
                .ForIntervento(idIntervento)
                .ForType(idTipoOggettoIntervento);

            RaiseEvent(Guid.NewGuid(),evt);
        }


    }
}
