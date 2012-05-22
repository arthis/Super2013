using System;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    
    public abstract class ConsuntivareReso : CommandBase
    {
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Note { get; set; }

        public ConsuntivareReso(Guid id, string interventoIdAppaltatore,DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
            Note= note;
        }
    }

    
    public class ConsuntivareRotReso : ConsuntivareReso
    {
        public OggettoRot[] Oggetti { get; set; }

        public ConsuntivareRotReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note, OggettoRot[] oggetti)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine,note)
        {
            Oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento rotabile '{0}' ", Id);
        }
    }

    public class ConsuntivareRotManReso : ConsuntivareReso
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public ConsuntivareRotManReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note, OggettoRotMan[] oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {
            Oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    public class ConsuntivareAmbReso : ConsuntivareReso
    {
        public ConsuntivareAmbReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {}

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento ambiente '{0}' ", Id);
        }
    }

}
