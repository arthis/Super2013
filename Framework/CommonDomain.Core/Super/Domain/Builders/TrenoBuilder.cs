using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class TrenoBuilder
    {
        private string _numeroTreno;
        private DateTime _data;

        public TrenoBuilder WithNumero(string numero)
        {
            _numeroTreno = numero;
            return this;
        }

        public TrenoBuilder When(DateTime data)
        {
            _data = data;
            return this;
        }

        public TrenoBuilder FromTrenoMsg(Messaging.ValueObjects.Treno treno)
        {
            _numeroTreno = treno.NumeroTreno;
            _data = treno.Data;
            return this;
        }

        public Treno Build()
        {
            return new Treno(_numeroTreno, _data);
        }

    }
}
