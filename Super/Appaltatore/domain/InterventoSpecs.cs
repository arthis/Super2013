using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Appaltatore.Domain
{
    public class Is_data_consuntivazione_valid : ISpecification<Intervento>
    {
        private readonly DateTime _dataConsuntivazione;

        public Is_data_consuntivazione_valid(DateTime dataConsuntivazione)
        {
            Contract.Requires(dataConsuntivazione != DateTime.MinValue);

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

    public class Has_workPeriod_contained_in_workperiod_programmata : ISpecification<Intervento>
    {
        private WorkPeriod _workeriod;

        public Has_workPeriod_contained_in_workperiod_programmata(WorkPeriod workPeriod)
        {
            Contract.Requires(workPeriod != null);

            _workeriod = workPeriod;
        }

        public bool IsSatisfiedBy(Intervento i)
        {
            if (!i.ProgrammedWorkPeriod.Contains(_workeriod))
            {
                i.CommandValidationMessages.Add(new ValidationMessage("Work Period", " the work period given does not fit in the programmata."));
                return false;
            }
            return true;
        }
    }
}
