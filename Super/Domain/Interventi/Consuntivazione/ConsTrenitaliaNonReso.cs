using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsTrenitaliaNonReso : ConsTrenitalia
    {
        public Guid IdCausale { get; set; }

        public ConsTrenitaliaNonReso(Guid id)
            : base(id)
        { }
    }

    public class ConsTrenitaliaNonResoRot : ConsTrenitaliaNonReso
    {
        public ConsTrenitaliaNonResoRot(Guid id,Guid IdIntervento, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id)
        { 

        }
    }

    public class ConsTrenitaliaNonResoRotMan : ConsTrenitaliaNonReso
    {
        public ConsTrenitaliaNonResoRotMan(Guid id)
            : base(id)
        { }
    }

    public class ConsTrenitaliaNonResoAmb : ConsTrenitaliaNonReso
    {
        public ConsTrenitaliaNonResoAmb(Guid id)
            : base(id)
        { }
    }
}
