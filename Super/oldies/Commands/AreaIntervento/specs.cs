using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.AreaIntervento
{
    public class InizioGreaterThanFineSpecification : ISpecification<CreareNuovoAreaIntervento>
    {
        public bool IsSatisfiedBy(CreareNuovoAreaIntervento c, ValidationResult validationResult)
        {

            if (c.Fine.HasValue &&  c.Inizio>c.Fine )
            {
                validationResult.MessagiValidazione.Add("Data inizio superiore a data fine");
                return false;
            }

            return true;
        }
    }

    
}
