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
    public class InterventoRotMan : Intervento
    {
        public void ControlReso(Guid idUtente, DateTime controlDate, WorkPeriod workPeriod, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var periodBuilder = new WorkPeriodBuilder();

            workPeriod.BuildValue(periodBuilder);

            var evt = Build.InterventoRotManControlledReso
                .ForPeriod(periodBuilder.Build())
                .By(idUtente)
                .When(controlDate)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotManControlledReso e)
        {
            //do nothing
        }


       
    }
}
