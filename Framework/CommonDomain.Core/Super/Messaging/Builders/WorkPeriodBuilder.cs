using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
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

        public WorkPeriod Build()
        {
            return new WorkPeriod(_from, _to);
        }


    }
}