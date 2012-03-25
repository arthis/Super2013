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
    [KnownType(typeof(ConsuntivareRotNonResoTrenitaliaDaTrenitalia))]
    [KnownType(typeof(ConsuntivareRotManNonResoTrenitaliaDaTrenitalia))]
    [KnownType(typeof(ConsuntivareAmbNonResoTrenitaliaDaTrenitalia))]
    public class ConsuntivareNonResoTrenitaliaDaTrenitalia : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }


        public ConsuntivareNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
        }
    }

    [DataContract]
    public class ConsuntivareRotNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public IEnumerable<OggettoInterventoRot> Oggetti { get; set; }

        public ConsuntivareRotNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRot> oggetti)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public IEnumerable<OggettoInterventoRot> Oggetti { get; set; }

        public ConsuntivareRotManNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoInterventoRot> oggetti)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public ConsuntivareAmbNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale)
        {}
    }
}
