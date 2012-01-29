using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.Interventi
{

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

    public class ConsuntivareRotabileResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggetti { get; set; }

        public ConsuntivareRotabileResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine,IEnumerable<OggettoInterventoRotabile> oggetti)
            :base(id,interventoIdAppaltatore,dataConsuntivazione,inizio,fine)
        {
            Oggetti = oggetti;
        }
    }

    public class ConsuntivareRotabileInManutenzioneResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggetti { get; set; }

        public ConsuntivareRotabileInManutenzioneResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoInterventoRotabile> oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {
            Oggetti = oggetti;
        }
    }

    public class ConsuntivareAmbientiResoDaAppaltatore : ConsuntivareResoDaAppaltatore
    {
        public ConsuntivareAmbientiResoDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, inizio, fine)
        {}
    }
}
