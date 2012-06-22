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
    public class InterventoAmb : Intervento
    {

        public void ControlReso(Guid idUtente, DateTime controlDate, WorkPeriod workPeriod, string note, int quantity, string description)
        {
            var builder = new InterventoAmbControlledResoBuilder();
            var periodBuilder = new WorkPeriodBuilder();

            workPeriod.BuildValue(periodBuilder);

            var evt = builder
                            .ForPeriod(periodBuilder.Build())
                            .ForId(Id)
                            .By(idUtente)
                            .When(controlDate)
                            .WithNote(note)
                            .WithQuantity(quantity)
                            .WithDescription((description))
                            .Build();
            RaiseEvent(evt);
        }

        public void Apply(InterventoAmbControlledReso e)
        {
            throw new NotImplementedException();
        }

    }
}
