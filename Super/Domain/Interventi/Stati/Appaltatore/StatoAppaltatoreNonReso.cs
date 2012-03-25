using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoAppaltatoreNonReso : StatoAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }
    }

    public class StatoAppaltatoreNonResoRot : StatoAppaltatoreNonReso
    {
        
    }

    public class StatoAppaltatoreNonResoRotMan : StatoAppaltatoreNonReso
    {
        
    }

    public class StatoAppaltatoreNonResoAmb : StatoAppaltatoreNonReso
    {

    }
}
