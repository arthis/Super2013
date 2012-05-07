using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class ConsAppaltatoreNonResoTrenitaliaCreato
    {
        public Guid IdIntervento { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
    }

    [Serializable]
    public class ConsAppaltatoreRotNonResoTrenitaliaCreato : ConsAppaltatoreAmbNonResoTrenitaliaCreato
    { }

    [Serializable]
    public class ConsAppaltatoreRotManNonResoTrenitaliaCreato : ConsAppaltatoreAmbNonResoTrenitaliaCreato
    { }

    [Serializable]
    public class ConsAppaltatoreAmbNonResoTrenitaliaCreato : ConsAppaltatoreNonResoTrenitaliaCreato
    { }
}
