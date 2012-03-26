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
        public string Note { get; set; }

        public ConsuntivareResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
            Note = note;
        }
    }

    [DataContract]
    public class ConsuntivareRotResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public OggettoRot[] Oggetti { get; set; }

        public ConsuntivareRotResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoRot[] oggetti, string note)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public ConsuntivareRotManResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, OggettoRotMan[] oggetti, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbResoDaTrenitalia : ConsuntivareResoDaTrenitalia
    {
        public ConsuntivareAmbResoDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine,note)
        {}
    }
}
