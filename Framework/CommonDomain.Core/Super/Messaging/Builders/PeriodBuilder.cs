using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
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

        public Period Build()
        {
            return new Period(_from, _to);
        }


    }
}