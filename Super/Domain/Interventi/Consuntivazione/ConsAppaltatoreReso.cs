using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreReso : ConsAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }

    public class ConsAppaltatoreResoRot : ConsAppaltatoreReso
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class ConsAppaltatoreResoRotMan : ConsAppaltatoreReso
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class ConsAppaltatoreResoAmb : ConsAppaltatoreReso
    { 
    }

}
