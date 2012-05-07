using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    [KnownType(typeof(ConsuntivareRotNonResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareRotManNonResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareAmbNonResoDaAppaltatore))]
    public abstract class ConsuntivareNonResoDaAppaltatore : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }


        public ConsuntivareNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale,string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
            Note = note;
        }
    }

    [DataContract]
    public class ConsuntivareRotNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {


        public ConsuntivareRotNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {

        public ConsuntivareRotManNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {

        public ConsuntivareAmbNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale, note)
        {
            
        }
    }

}
