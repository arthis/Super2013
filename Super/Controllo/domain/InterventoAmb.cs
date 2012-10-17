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
    public class InterventoAmb : Intervento
    {

        public void ControlReso(Guid idUser, DateTime controlDate, WorkPeriod workPeriod, string note, int quantity, string description)
        {
         
            var evt = BuildEvt.InterventoAmbControlledReso
                .ForWorkPeriod(workPeriod.ToMessage())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .ForQuantity(quantity)
                .ForDescription(description);
            
            RaiseEvent(evt);
            
        }

        public void Apply(InterventoAmbControlledReso e)
        {
            //do nothing
        }

    }
}
