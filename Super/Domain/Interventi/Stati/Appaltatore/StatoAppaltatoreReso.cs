using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoAppaltatoreReso : StatoAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }

    public class StatoAppaltatoreResoRot : StatoAppaltatoreReso
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreResoRotMan : StatoAppaltatoreReso
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreResoAmb : StatoAppaltatoreReso
    { 
    }

}
