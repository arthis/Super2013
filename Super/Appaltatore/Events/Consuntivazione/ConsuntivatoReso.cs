using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Core.Super.ValueObjects;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class ConsuntivatoReso : Message, IEvent, IConsuntivato
    {
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }
    }

    public class ConsuntivatoRotReso : ConsuntivatoReso
    {
        public OggettoRot[] Oggetti { get; set; }
        public string NumeroTrenoArrivo { get; set; }
        public DateTime DataTrenoArrivo { get; set; }
        public string NumeroTrenoPartenza { get; set; }
        public DateTime DataTrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato reso.", Id);
        }
    }

    public class ConsuntivatoRotManReso : ConsuntivatoReso
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato reso.", Id);
        }
    }

    public class ConsuntivatoAmbReso : ConsuntivatoReso
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato reso.", Id);
        }
    }
}
