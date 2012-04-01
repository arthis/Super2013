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
        public string Note { get; set; }


        public ConsuntivareNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
            Note = note;
        }
    }

    [DataContract]
    public class ConsuntivareRotNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotManNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoTrenitaliaDaAppaltatore : ConsuntivareNonResoTrenitaliaDaAppaltatore
    {
        public ConsuntivareAmbNonResoTrenitaliaDaAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {}
    }
}
