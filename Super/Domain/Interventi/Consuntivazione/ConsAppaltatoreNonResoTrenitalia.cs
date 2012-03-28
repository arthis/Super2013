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

    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotNonResoTrenitalia(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }

    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotManNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotManNonResoTrenitalia(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreAmbNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreAmbNonResoTrenitalia(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }

       
    }
}
