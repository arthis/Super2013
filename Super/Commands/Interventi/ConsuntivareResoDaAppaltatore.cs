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

        public ConsuntivareResoDaAppaltatore(Guid id, string interventoIdAppaltatore,DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
        }
    }

    [DataContract]
    public class ConsuntivareRotResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public OggettoInterventoRot[] Oggetti { get; set; }

        public ConsuntivareRotResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoInterventoRot[] oggetti)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public OggettoInterventoRot[] Oggetti { get; set; }

        public ConsuntivareRotManResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoInterventoRot[] oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public ConsuntivareAmbResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {}
    }
}
