using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class MsgWorkPeriodBuilder
    {
        DateTime _from;
        DateTime _to;

        public MsgWorkPeriodBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public MsgWorkPeriodBuilder To(DateTime value)
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