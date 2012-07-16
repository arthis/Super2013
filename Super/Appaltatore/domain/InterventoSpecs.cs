using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Domain
{
    public class Is_data_consuntivazione_valid : ISpecification<Intervento>
    {
        private readonly DateTime _dataConsuntivazione;

        public Is_data_consuntivazione_valid(DateTime dataConsuntivazione)
        {
            Contract.Requires<ArgumentNullException>(dataConsuntivazione != DateTime.MinValue);

            _dataConsuntivazione = dataConsuntivazione;
        }

        public bool IsSatisfiedBy(Intervento i)
        {
            if (_dataConsuntivazione > DateTime.Now)
            {
                i.CommandValidationMessages.Add(new ValidationMessage("Data consuntivazione"," data consuntivazione maggiore di adesso"));
                return false;
            }

            return true;
        }
    }

    public class Has_start_date_greater_than_end_date : ISpecification<Intervento>
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public Has_start_date_greater_than_end_date(DateTime start, DateTime end)
        {
            Contract.Requires<ArgumentNullException>(start != DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(start != DateTime.MinValue);

            _start = start;
            _end = end;
        }

        public bool IsSatisfiedBy(Intervento i)
        {
            if (_start > _end)
            {
                i.CommandValidationMessages.Add(new ValidationMessage("Data Inizio", " data inizio maggiore di data fine"));
                return false;
            }

            return true;
        }
    }
}
