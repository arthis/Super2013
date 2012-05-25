using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Domain
{

    public class Is_Already_Deleted : ISpecification<AreaIntervento>
    {
        public bool IsSatisfiedBy(AreaIntervento ai)
        {
            if (ai.Deleted)
            {
                ai.CommandValidationMessages.Add(new ValidationMessage("Fatale : area intervento gia cancellata"));
                return false;
            }

            return true;
        }
    }

    public class Has_start_date_greater_than_end_date : ISpecification<AreaIntervento> 
    {
        public bool IsSatisfiedBy(AreaIntervento ai)
        {
            if (ai.Start > ai.End)
            {
                ai.CommandValidationMessages.Add(new ValidationMessage("Fatale : data inizio maggiore di data fine"));
                return false;
            }

            return true;
        }
    }
}
