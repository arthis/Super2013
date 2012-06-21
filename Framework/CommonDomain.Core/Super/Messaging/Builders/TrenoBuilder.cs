using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class TrenoBuilder
    {
        string _numero;
        DateTime _date;

        public TrenoBuilder WithNumeroTreno(string numero)
        {
            _numero = numero;
            return this;
        }

        public TrenoBuilder When(DateTime value)
        {
            _date = value;
            return this;
        }

        public Treno Build()
        {
            return new Treno(_numero, _date);
        }

       
    }
}
