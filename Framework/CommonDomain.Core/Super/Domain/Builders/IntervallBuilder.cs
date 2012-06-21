using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class IntervallBuilder
    {
        DateTime _from;
        DateTime? _to;

        public IntervallBuilder From(DateTime value)
        {
            _from = value;
            return this;
        }

        public IntervallBuilder To(DateTime? value)
        {
            _to = value;
            return this;
        }

        public IntervallBuilder FromPeriod(CommonDomain.Core.Super.Messaging.ValueObjects.Intervall period)
        {
            _from = period.Start;
            _to = period.End;
            return this;
        }



        public Intervall Build()
        {
            return new Intervall(_from, _to);
        }

    }
}
