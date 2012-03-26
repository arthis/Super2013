using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsTrenitaliaNonReso : ConsTrenitalia
    {
        public Guid IdCausale { get; set; }
    }

    public class ConsTrenitaliaNonResoRot : ConsTrenitaliaNonReso
    {
        
    }

    public class ConsTrenitaliaNonResoRotMan : ConsTrenitaliaNonReso
    {
        
    }

    public class ConsTrenitaliaNonResoAmb : ConsTrenitaliaNonReso
    {

    }
}
