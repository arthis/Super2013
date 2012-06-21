using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
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

        public Intervall Build()
        {
            return new Intervall(_from, _to);
        }

       
    }
}
