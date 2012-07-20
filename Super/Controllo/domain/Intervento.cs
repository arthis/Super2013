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

        public void Close(Guid idUser, DateTime closingDate)
        {
            var evt = Build.InterventoClosed
                .By(idUser)
                .When(closingDate);

            RaiseEvent(evt);
        }

        public void Apply(InterventoClosed e)
        {
            _isClosed = true;
        }

        public void ControlNonReso(Guid idUser, DateTime controlDate, Guid idCausale, string note)
        {
            var evt = Build.InterventoControlledNonReso
                .By(idUser)
                .When(controlDate)
                .Because(idCausale)
                .WithNote(note);

            RaiseEvent(evt);
        }

        public void Apply(InterventoControlledNonReso e)
        {
            //do nothing
        }

        public void Reopen(Guid idUser, DateTime reopeningDate)
        {
            var evt = Build.InterventoReopened
                .By(idUser)
                .When(reopeningDate);

            RaiseEvent(evt);
        }

        public void Apply(InterventoReopened e)
        {
            _isClosed = false;
        }
    }
}
