using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class RollonPeriodBuilder
    {
        DateTime _from;
        DateTime? _to;

        public RollonPeriodBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public RollonPeriodBuilder To(DateTime? value)
        {
            _to = value;
            return this;
        }

        public RollonPeriodBuilder FromPeriod(CommonDomain.Core.Super.Messaging.ValueObjects.RollonPeriod period)
        {
            _from = period.Start;
            _to = period.End;
            return this;
        }



        public RollonPeriod Build()
        {
            return new RollonPeriod(_from, _to);
        }

    }
}
