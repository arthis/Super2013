using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
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

        public Interval Build()
        {
            return new Interval(_from, _to);
        }

       
    }
}
