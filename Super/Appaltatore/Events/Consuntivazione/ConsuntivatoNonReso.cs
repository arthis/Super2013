using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class ConsuntivatoNonReso : Message, IEvent, IConsuntivato
    {
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }
    }

    public class ConsuntivatoRotNonReso : ConsuntivatoNonReso
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato non reso.", Id);
        }
    }

    public class ConsuntivatoRotManNonReso : ConsuntivatoNonReso
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato non reso.", Id);
        }
    }

    public class ConsuntivatoAmbNonReso : ConsuntivatoNonReso
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato non reso.", Id);
        }
    }
}
