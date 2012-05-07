using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

using Events.Interventi;

namespace Domain.Interventi.Consuntivazione
{
    
    public abstract class ConsAppaltatoreNonResoTrenitalia : ConsAppaltatore
    {
        public string IdInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }

    }

   
    public class ConsAppaltatoreRotNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotNonResoTrenitalia(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }

    }

   
    public class ConsAppaltatoreRotManNonResoTrenitalia : ConsAppaltatoreNonResoTrenitalia
    {
        public ConsAppaltatoreRotManNonResoTrenitalia(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }
    }

   
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
