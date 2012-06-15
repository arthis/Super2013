using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class InterventoAmb : Intervento
    {

        public void ControlReso(Guid idUtente, Guid controlDate, RangeDate rangeDate, string note, int quantita, string descrizione)
        {
            var evt = new InterventoAmbControlledReso()
            {
                End = rangeDate.GetEnd()
                , Start = rangeDate.GetStart()
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
