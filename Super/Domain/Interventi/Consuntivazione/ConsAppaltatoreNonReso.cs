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

    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotNonReso : ConsAppaltatoreNonReso
    {
        public ConsAppaltatoreRotNonReso(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
            IdCausale = idCausale;
        }


    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotManNonReso : ConsAppaltatoreNonReso
    {
        public ConsAppaltatoreRotManNonReso(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
            IdCausale = idCausale;
        }


    }

    [DynamicSnapshot]
    public class ConsAppaltatoreAmbNonReso : ConsAppaltatoreNonReso
    {
        public ConsAppaltatoreAmbNonReso(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
            IdCausale = idCausale;
        }

       
    }
}
