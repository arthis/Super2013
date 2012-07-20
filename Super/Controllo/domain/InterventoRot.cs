using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;

namespace Super.Controllo.Domain
{
    public class InterventoRot : Intervento
    {

        public void ControlReso(Guid idUser, DateTime  controlDate, WorkPeriod workPeriod, Treno trenoPartenza, Treno trenoArrivo, string convoglio, string note,IEnumerable<OggettoRot> oggetti, string rigaTurnoTreno, string turnoTreno)
        {
            var periodBuilder = new WorkPeriodBuilder();
            var trenoPartenzaBuilder = new TrenoBuilder();
            var trenoArrivoBuilder = new TrenoBuilder();

            workPeriod.BuildValue(periodBuilder);
            trenoPartenza.BuildValue(trenoPartenzaBuilder);
            trenoArrivo.BuildValue(trenoArrivoBuilder);

            var evt = Build.InterventoRotControlledReso
                .ForPeriod(periodBuilder.Build())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                .WithTrenoArrivo(trenoArrivoBuilder.Build())
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
