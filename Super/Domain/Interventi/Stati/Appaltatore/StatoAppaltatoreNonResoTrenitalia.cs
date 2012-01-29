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

    public class StatoAppaltatoreNonResoTrenitaliaRotabile : StatoAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreNonResoTrenitaliaRotabileInManutenzione : StatoAppaltatoreNonResoTrenitalia
    {
        public IEnumerable<OggettoIntervento> Oggetti { get; set; }
    }

    public class StatoAppaltatoreNonResoTrenitaliaAmbienti : StatoAppaltatoreNonResoTrenitalia
    { }
}
