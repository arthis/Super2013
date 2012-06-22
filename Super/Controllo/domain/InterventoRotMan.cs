using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class InterventoRotMan : Intervento
    {
        public void ControlReso(Guid idUtente, DateTime controlDate, WorkPeriod workPeriod, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoRotManControlledReso e)
        {
            throw new NotImplementedException();
        }


       
    }
}
