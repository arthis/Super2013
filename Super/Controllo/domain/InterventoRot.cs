using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class InterventoRot : Intervento
    {

        public void ControlReso(Guid idUtente, DateTime  controlDate, WorkPeriod workPeriod, Treno trenoPartenza, Treno trenoArrivo, string convoglio, string note,IEnumerable<OggettoRot> oggetti, string rigaTurnoTreno, string turnoTreno)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoRotControlledReso e)
        {
            throw new NotImplementedException();
        }


        
    }
}
