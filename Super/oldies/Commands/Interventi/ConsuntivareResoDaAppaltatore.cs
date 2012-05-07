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
    [KnownType(typeof(ConsuntivareRotResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareRotManResoDaAppaltatore))]
    [KnownType(typeof(ConsuntivareAmbResoDaAppaltatore))]
    public abstract class ConsuntivareResoDaAppaltatore : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Note { get; set; }

        public ConsuntivareResoDaAppaltatore(Guid id, string interventoIdAppaltatore,DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
            Note= note;
        }
    }

    [DataContract]
    public class ConsuntivareRotResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public OggettoRot[] Oggetti { get; set; }

        public ConsuntivareRotResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note, OggettoRot[] oggetti)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public ConsuntivareRotManResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note, OggettoRotMan[] oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public ConsuntivareAmbResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {}
    }
}
