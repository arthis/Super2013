using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Events.Interventi;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreNonResoTrenitalia : ConsAppaltatore
    {
        public string IdInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }

        public ConsAppaltatoreNonResoTrenitalia(Guid id)
            : base(id)
        {
            
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotNonResoTrenitalia(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreRotNonResoTrenitaliaCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreRotNonResoTrenitaliaCreato(ConsAppaltatoreRotNonResoTrenitaliaCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotManNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotManNonResoTrenitalia(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreRotManNonResoTrenitaliaCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreRotManNonResoTrenitaliaCreato(ConsAppaltatoreRotManNonResoTrenitaliaCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreAmbNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreAmbNonResoTrenitalia(Guid id, Guid idIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        {
            var evt = new ConsAppaltatoreAmbNonResoTrenitaliaCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                IdCausale = IdCausale
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreAmbNonResoTrenitaliaCreato(ConsAppaltatoreAmbNonResoTrenitaliaCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            IdInterventoAppaltatore = e.IdInterventoAppaltatore;
            IdCausale = e.IdCausale;
            IdIntervento = e.IdIntervento;
        }
    }
}
