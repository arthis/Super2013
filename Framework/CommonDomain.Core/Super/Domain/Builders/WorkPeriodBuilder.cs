using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class WorkPeriodBuilder
    {
        DateTime _from;
        DateTime _to;

        public WorkPeriodBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public WorkPeriodBuilder To(DateTime value)
        {
            _to = value;
            return this;
        }

        public WorkPeriodBuilder FromPeriod(CommonDomain.Core.Super.Messaging.ValueObjects.WorkPeriod period)
        {
            Contract.Requires(period != null);

            _from = period.StartDate;
            _to = period.EndDate;
            return this;
        }

        public WorkPeriod Build()
        {
            return new WorkPeriod(_from, _to);
        }

    }
}