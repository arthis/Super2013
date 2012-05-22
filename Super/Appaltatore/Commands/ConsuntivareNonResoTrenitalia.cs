using System;
using System.Collections.Generic;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{

    public abstract class ConsuntivareNonResoTrenitalia : CommandBase
    {
        
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }


        public ConsuntivareNonResoTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
            Note = note;
        }
    }

    
    public class ConsuntivareRotNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotNonResoTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {
            Oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso trenitalia il intervento rotabile '{0}' ", Id);
        }
    }

    
    public class ConsuntivareRotManNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotManNonResoTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale,note)
        {
            Oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso trenitalia il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    
    public class ConsuntivareAmbNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
        public ConsuntivareAmbNonResoTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {}

        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso trenitalia il intervento ambiente '{0}' ", Id);
        }
    }
}
