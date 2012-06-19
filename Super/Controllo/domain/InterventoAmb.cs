using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class InterventoAmb : Intervento
    {

        public void ControlReso(Guid idUtente, Guid controlDate, RolloutPeriod rolloutPeriod, string note, int quantita, string descrizione)
        {
            var evt = new InterventoAmbControlledReso()
            {
                End = rolloutPeriod.GetEnd()
                , Start = rolloutPeriod.GetStart()
                , Id = this.Id
                , Note = note
                , ControlDate = controlDate
                , Descrizione = descrizione
                , IdUtente = idUtente
                , Quantita = quantita
            };
            RaiseEvent(evt);
        }

        public void Apply(InterventoAmbControlledReso e)
        {
            throw new NotImplementedException();
        }

    }
}
