using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Core.Super.ValueObjects;

namespace Super.Appaltatore.Commands
{
    
    public abstract class ConsuntivareReso : CommandBase
    {
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }
    }

    
    public class ConsuntivareRotReso : ConsuntivareReso
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
            return string.Format("Consuntivare reso il intervento rotabile '{0}' ", Id);
        }
    }

    public class ConsuntivareRotManReso : ConsuntivareReso
    {
        public OggettoRotMan[] Oggetti { get; set; }

       

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    public class ConsuntivareAmbReso : ConsuntivareReso
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento ambiente '{0}' ", Id);
        }
    }

}
