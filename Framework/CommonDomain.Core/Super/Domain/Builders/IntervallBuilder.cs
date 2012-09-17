using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class IntervalBuilder
    {
        DateTime _from;
        DateTime? _to;

        public IntervalBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public IntervalBuilder To(DateTime? value)
        {
            _to = value;
            return this;
        }

        public IntervalBuilder FromInterval(Messaging.ValueObjects.Interval interval)
        {
            _from = interval.Start;
            _to = interval.End;
            return this;
        }



        public Interval Build()
        {
            return new Interval(_from, _to);
        }

    }
}
