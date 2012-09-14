using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class MsgIntervalOpenedBuilder
    {
        DateTime? _from;
        DateTime? _to;

        public MsgIntervalOpenedBuilder From(DateTime? value)
        {
            _from = value;
            return this;
        }

        public MsgIntervalOpenedBuilder To(DateTime? value)
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