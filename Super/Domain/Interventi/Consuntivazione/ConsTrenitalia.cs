using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsTrenitalia : AggregateRootMappedByConvention
    {
        public Guid IdIntervento { get; set; }
        public DateTime DataConsuntivazione { get; set; }

        public ConsTrenitalia(Guid id)
            : base(id)
        { }
    }
}
