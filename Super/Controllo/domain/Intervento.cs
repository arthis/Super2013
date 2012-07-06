using System;
using CommonDomain.Core;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;

namespace Super.Controllo.Domain
{
    public class Intervento : AggregateBase
    {
        private bool _isClosed;

        public Intervento()
        {
          
        }


        public void AllowControl(Guid id)
        {
            var evt = Build.InterventoControlAllowed;

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoControlAllowed e)
        {
            Id = e.Id;
        }

        public void Close(Guid idUtente, DateTime closingDate)
        {
            var evt = Build.InterventoClosed
                .By(idUtente)
                .When(closingDate);

            RaiseEvent(evt);
        }

        public void Apply(InterventoClosed e)
        {
            _isClosed = true;
        }

        public void ControlNonReso(Guid idUtente, DateTime controlDate, Guid idCausale, string note)
        {
            var evt = Build.InterventoControlledNonReso
                .By(idUtente)
                .When(controlDate)
                .Because(idCausale)
                .WithNote(note);

            RaiseEvent(evt);
        }

        public void Apply(InterventoControlledNonReso e)
        {
            //do nothing
        }

        public void Reopen(Guid idUtente, DateTime reopeningDate)
        {
            var evt = Build.InterventoReopened
                .By(idUtente)
                .When(reopeningDate);

            RaiseEvent(evt);
        }

        public void Apply(InterventoReopened e)
        {
            _isClosed = false;
        }
    }
}
