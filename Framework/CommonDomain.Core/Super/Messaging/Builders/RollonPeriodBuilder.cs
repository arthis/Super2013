using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
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

        public RollonPeriod Build()
        {
            return new RollonPeriod(_from, _to);
        }

       
    }
}
