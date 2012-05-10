using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Domain
{
    public class Has_start_date_greater_than_end_date : ISpecification<AreaIntervento> 
    {
        public bool IsSatisfiedBy(AreaIntervento ai)
        {
            if (ai.Start > ai.End)
            {
                ai.CommandValidationMessages.Add(new ValidationMessage("Fatale : start date is greater than end date"));
                return false;
            }

            return true;
        }
    }
}
