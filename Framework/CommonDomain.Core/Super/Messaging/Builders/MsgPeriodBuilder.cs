using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class MsgPeriodBuilder
    {
        DateTime _from;
        DateTime _to;

        public MsgPeriodBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public MsgPeriodBuilder To(DateTime value)
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