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
    [KnownType(typeof(ConsuntivareRotResoDaTrenitalia))]
    [KnownType(typeof(ConsuntivareRotManResoDaTrenitalia))]
    [KnownType(typeof(ConsuntivareAmbResoDaTrenitalia))]
    public abstract class ConsuntivareResoDaTrenitalia : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public ConsuntivareResoDaTrenitalia(Guid id, string interventoIdAppaltatore,DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
        }
    }

    [DataContract]
    public class ConsuntivareRotResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public OggettoInterventoRot[] Oggetti { get; set; }

        public ConsuntivareRotResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoInterventoRot[] oggetti)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public OggettoInterventoRotMan[] Oggetti { get; set; }

        public ConsuntivareRotManResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoInterventoRotMan[] oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public ConsuntivareAmbResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {}
    }
}
