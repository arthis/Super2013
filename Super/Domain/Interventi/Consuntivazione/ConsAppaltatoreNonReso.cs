using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Events.Interventi;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreNonReso : ConsAppaltatore
    {

        public string IdInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }

        public ConsAppaltatoreNonReso(Guid id)
            : base(id)
        { }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotNonReso : ConsAppaltatoreNonReso
    {
        public ConsAppaltatoreRotNonReso(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreNonResoRotCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreNonResoRotCreato(ConsAppaltatoreNonResoRotCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotManNonReso : ConsAppaltatoreNonReso
    {
        public ConsAppaltatoreRotManNonReso(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreNonResoRotManCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreNonResoRotManCreato(ConsAppaltatoreNonResoRotManCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreAmbNonReso : ConsAppaltatoreNonReso
    {
          public ConsAppaltatoreAmbNonReso(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreNonResoAmbCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreNonResoAmbCreato(ConsAppaltatoreNonResoAmbCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }
}
