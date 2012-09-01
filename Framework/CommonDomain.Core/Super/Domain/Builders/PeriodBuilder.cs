using System;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class PeriodBuilder
    {
        DateTime _from;
        DateTime _to;

        public PeriodBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public PeriodBuilder To(DateTime value)
        {
            _to = value;
            return this;
        }

        public PeriodBuilder FromPeriod(Messaging.ValueObjects.Period period)
        {
            _from = period.StartDate;
            _to = period.EndDate;
            return this;
        }

        public Period Build()
        {
            return new Period(_from, _to);
        }

    }
}