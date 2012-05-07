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
        public ConsTrenitaliaNonResoRot(DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = IdCausale;
        }
    }

   
    public class ConsTrenitaliaNonResoRotMan : ConsTrenitaliaNonReso
    {
        public ConsTrenitaliaNonResoRotMan(DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = IdCausale;
        }
    }

   
    public class ConsTrenitaliaNonResoAmb : ConsTrenitaliaNonReso
    {
        public ConsTrenitaliaNonResoAmb(DateTime dataConsuntivazione, Guid idCausale)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = IdCausale;
        }
    }
}
