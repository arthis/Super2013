using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class ConsuntivatoNonResoTrenitalia : Message, IEvent, IConsuntivato
    {
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }
    }

    public class ConsuntivatoRotNonResoTrenitalia : ConsuntivatoNonResoTrenitalia
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }
    }

    public class ConsuntivatoRotManNonResoTrenitalia : ConsuntivatoNonResoTrenitalia
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }
    }

    public class ConsuntivatoAmbNonResoTrenitalia : ConsuntivatoNonResoTrenitalia
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }
    }
}
