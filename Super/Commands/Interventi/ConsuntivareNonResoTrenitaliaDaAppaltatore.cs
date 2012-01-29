using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.Interventi
{

    public class ConsuntivareNonResoTrenitaliaDaAppaltatore : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }


        public ConsuntivareNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }
    }

    public class ConsuntivareRotabileNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggetti { get; set; }

        public ConsuntivareRotabileNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRotabile> oggetti)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {
            Oggetti = oggetti;
        }
    }

    public class ConsuntivareRotabileInManutenzioneNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRotabile> Oggetti { get; set; }

        public ConsuntivareRotabileInManutenzioneNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRotabile> oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            Oggetti = oggetti;
        }
    }

    public class ConsuntivareAmbientiNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public ConsuntivareAmbientiNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {}
    }
}
