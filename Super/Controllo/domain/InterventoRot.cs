using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Controllo.Events;

using Super.Controllo.Events.Consuntivazione;

namespace Super.Controllo.Domain
{
    public class InterventoRot : Intervento
    {

        public void ControlReso(Guid idUser, DateTime  controlDate, WorkPeriod workPeriod, Treno trenoPartenza, Treno trenoArrivo, string convoglio, string note,IEnumerable<OggettoRot> oggetti, string rigaTurnoTreno, string turnoTreno)
        {

            var evt = BuildEvt.InterventoRotControlledReso
                .ForWorkPeriod(workPeriod.ToMessage())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .ForConvoglio(convoglio)
                .WithOggetti(oggetti.ToMessage().ToArray())
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTurnoTreno(turnoTreno);

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotControlledReso e)
        {
            //do nothing
        }


        
    }
}
