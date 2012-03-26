using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreNonReso : ConsAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public Guid IdCausale { get; set; }
    }

    public class ConsAppaltatoreNonResoRot : ConsAppaltatoreNonReso
    {
        
    }

    public class ConsAppaltatoreNonResoRotMan : ConsAppaltatoreNonReso
    {
        
    }

    public class ConsAppaltatoreNonResoAmb : ConsAppaltatoreNonReso
    {

    }
}
