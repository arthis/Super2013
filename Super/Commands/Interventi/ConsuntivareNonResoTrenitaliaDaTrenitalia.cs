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
    [KnownType(typeof(ConsuntivareRotNonResoTrenitaliaDaTrenitalia))]
    [KnownType(typeof(ConsuntivareRotManNonResoTrenitaliaDaTrenitalia))]
    [KnownType(typeof(ConsuntivareAmbNonResoTrenitaliaDaTrenitalia))]
    public abstract class ConsuntivareNonResoTrenitaliaDaTrenitalia : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }


        public ConsuntivareNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
            Id = id;
            InterventoIdAppaltatore = interventoIdAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausale = idCausale;
            Note = note;
        }
    }

    [DataContract]
    public class ConsuntivareRotNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareRotManNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }

        public ConsuntivareRotManNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, IEnumerable<OggettoRot> oggetti, string note)
            : base(id, interventoIdAppaltatore, dataConsuntivazione, idCausale,note)
        {
            Oggetti = oggetti;
        }
    }

    [DataContract]
    public class ConsuntivareAmbNonResoTrenitaliaDaTrenitalia : ConsuntivareNonResoTrenitaliaDaTrenitalia
    {
        public ConsuntivareAmbNonResoTrenitaliaDaTrenitalia(Guid id, string interventoIdAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
            :base (id,interventoIdAppaltatore,dataConsuntivazione,idCausale,note)
        {}
    }
}
