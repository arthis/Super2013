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
    [KnownType(typeof(ConsuntivareRotabileNonResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareRotabileInManutenzioneNonResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareAmbientiNonResoDaAppaltatore))]
    public abstract class ConsuntivareNonResoDaAppaltatore : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        

         public ConsuntivareNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;

        }
    }

    [DataContract]
    public class ConsuntivareRotabileNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {

        public ConsuntivareRotabileNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione)
            :base (id,interventoIdAppaltatore,dataConsuntivazione)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareRotabileInManutenzioneNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {

        public ConsuntivareRotabileInManutenzioneNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione)
            : base(id, interventoIdAppaltatore, dataConsuntivazione)
        {
            
        }
    }

    [DataContract]
    public class ConsuntivareAmbientiNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {
        public ConsuntivareAmbientiNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione)
            : base(id, interventoIdAppaltatore, dataConsuntivazione)
        {
           
        }  
    }

}
