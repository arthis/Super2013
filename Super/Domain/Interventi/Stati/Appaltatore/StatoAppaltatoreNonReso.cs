using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoAppaltatoreNonReso : StatoAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }

    public class StatoAppaltatoreNonResoRotabile : StatoAppaltatoreNonReso
    {
        public IEnumerable<OggettoIntervento> Oggeti;
    }

    public class StatoAppaltatoreNonResoRotabileInManutenzione : StatoAppaltatoreNonReso
    {
        public IEnumerable<OggettoIntervento> Oggeti;
    }

    public class StatoAppaltatoreNonResoAmbienti : StatoAppaltatoreNonReso
    {

    }
}
