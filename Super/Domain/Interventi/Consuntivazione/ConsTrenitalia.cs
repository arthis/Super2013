using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Domain;


namespace Domain.Interventi.Consuntivazione
{
    
    public abstract class ConsTrenitalia 
    {
        public Guid IdIntervento { get; set; }
        public DateTime DataConsuntivazione { get; set; }

    }
}
