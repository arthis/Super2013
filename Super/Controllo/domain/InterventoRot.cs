using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class InterventoRot : Intervento
    {

        public void ControlReso(Guid idUtente, Guid controlDate, RangeDate rangeDate, Treno trenoPartenza, Treno trenoArrivo, string convoglio, string note, OggettoRot[] oggetti, string rigaTurnoTreno, string turnoTreno)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoRotControlledReso e)
        {
            throw new NotImplementedException();
        }


        
    }
}
