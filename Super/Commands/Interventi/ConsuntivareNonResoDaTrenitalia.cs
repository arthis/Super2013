using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    [KnownType(typeof(ConsuntivareRotNonResoDaTrenitalia))]
    [KnownType(typeof(ConsuntivareRotManNonResoDaTrenitalia))]
    [KnownType(typeof(ConsuntivareAmbNonResoDaTrenitalia))]
    public abstract class ConsuntivareNonResoDaTrenitalia : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }


        public ConsuntivareNonResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }
    }

    [DataContract]
    public class ConsuntivareRotNonResoDaTrenitalia : ConsuntivareNonResoDaTrenitalia
    {
        

        public ConsuntivareRotNonResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoDaTrenitalia : ConsuntivareNonResoDaTrenitalia
    {
       
        public ConsuntivareRotManNonResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoDaTrenitalia : ConsuntivareNonResoDaTrenitalia
    {

        public ConsuntivareAmbNonResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            
        }
    }

}
