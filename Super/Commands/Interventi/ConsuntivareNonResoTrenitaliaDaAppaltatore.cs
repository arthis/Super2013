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
    [KnownType(typeof(ConsuntivareRotNonResoTrenitaliaDaAppaltatore))]
    [KnownType(typeof(ConsuntivareRotManNonResoTrenitaliaDaAppaltatore))]
    [KnownType(typeof(ConsuntivareAmbNonResoTrenitaliaDaAppaltatore))]
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

    [DataContract]
    public class ConsuntivareRotNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRot> Oggetti { get; set; }

        public ConsuntivareRotNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRot> oggetti)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoInterventoRot> Oggetti { get; set; }

        public ConsuntivareRotManNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRot> oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public ConsuntivareAmbNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {}
    }
}
