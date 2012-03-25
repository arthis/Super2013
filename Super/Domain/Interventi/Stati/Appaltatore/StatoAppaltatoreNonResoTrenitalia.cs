using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoAppaltatoreNonResoTrenitalia : StatoAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }
    }

    public class StatoAppaltatoreNonResoTrenitaliaRot : StatoAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreNonResoTrenitaliaRotMan : StatoAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreNonResoTrenitaliaAmb : StatoAppaltatoreNonResoTrenitalia
    { }
}
