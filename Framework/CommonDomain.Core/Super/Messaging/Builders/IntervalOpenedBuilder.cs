using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class IntervalOpenedBuilder
    {
        DateTime? _from;
        DateTime? _to;

        public IntervalOpenedBuilder From(DateTime? value)
        {
            _from = value;
            return this;
        }

        public IntervalOpenedBuilder To(DateTime? value)
        {
            _to = value;
            return this;
        }

        public IntervalOpened Build()
        {
            return new IntervalOpened(_from, _to);
        }


    }
}