using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreNonResoTrenitalia : ConsAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }
    }

    public class ConsAppaltatoreNonResoTrenitaliaRot : ConsAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class ConsAppaltatoreNonResoTrenitaliaRotMan : ConsAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class ConsAppaltatoreNonResoTrenitaliaAmb : ConsAppaltatoreNonResoTrenitalia
    { }
}
