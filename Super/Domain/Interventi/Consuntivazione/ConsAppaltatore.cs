using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;
using Ncqrs.Domain;

namespace Domain.Interventi.Consuntivazione
{

    public abstract class ConsAppaltatore : AggregateRootMappedByConvention
    {
        public Guid IdIntervento { get; set; }
        public DateTime DataConsuntivazione { get; set; }


        public ConsAppaltatore(Guid id)
            : base(id)
        { }

    }

}
