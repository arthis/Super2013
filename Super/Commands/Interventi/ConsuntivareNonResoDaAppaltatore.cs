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
        

         public ConsuntivareNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;

        }
    }

    [DataContract]
    public class ConsuntivareRotabileNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggeti { get; set; }

        public ConsuntivareRotabileNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoInterventoRotabile> oggeti)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine)
        {
            Oggeti = oggeti;
        }
    }

    [DataContract]
    public class ConsuntivareRotabileInManutenzioneNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggeti { get; set; }

        public ConsuntivareRotabileInManutenzioneNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoInterventoRotabile> oggeti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {
            Oggeti = oggeti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbientiNonResoDaAppaltatore : ConsuntivareNonResoDaAppaltatore
    {
        public ConsuntivareAmbientiNonResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {
           
        }  
    }

}
