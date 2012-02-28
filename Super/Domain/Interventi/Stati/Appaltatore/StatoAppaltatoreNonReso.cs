using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoAppaltatoreNonReso : StatoAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        
    }

    public class StatoAppaltatoreNonResoRotabile : StatoAppaltatoreNonReso
    {
        
    }

    public class StatoAppaltatoreNonResoRotabileInManutenzione : StatoAppaltatoreNonReso
    {
        
    }

    public class StatoAppaltatoreNonResoAmbienti : StatoAppaltatoreNonReso
    {

    }
}
