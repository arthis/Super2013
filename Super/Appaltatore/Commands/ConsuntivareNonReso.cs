using System;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    public abstract class ConsuntivareNonReso : CommandBase
    {
        
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }


        public ConsuntivareNonReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale,string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
            Note = note;
        }
    }

    
    public class ConsuntivareRotNonReso : ConsuntivareNonReso
    {


        public ConsuntivareRotNonReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso il intervento rotabile '{0}' ", Id);
        }
    }

    
    public class ConsuntivareRotManNonReso : ConsuntivareNonReso
    {

        public ConsuntivareRotManNonReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }
        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    
    public class ConsuntivareAmbNonReso : ConsuntivareNonReso
    {

        public ConsuntivareAmbNonReso(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso il intervento ambiente '{0}' ", Id);
        }
    }

}
