using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;
using Ncqrs.Domain;


namespace Domain.Interventi.Consuntivazione
{
     
    public abstract class ConsAppaltatore 
    {
        public Guid IdIntervento { get; set; }
        public DateTime DataConsuntivazione { get; set; }
    }

}
