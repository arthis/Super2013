using System;
using CommonDomain.Core;
using Super.Controllo.Events;

using Super.Controllo.Events.Consuntivazione;

namespace Super.Controllo.Domain
{
    public class Intervento : AggregateBase
    {
        private bool _isClosed;
        private bool _isControlAllowed;

        public Intervento()
        {
          
        }


        public void AllowControl(Guid id)
        {
            var evt = BuildEvt.InterventoControlAllowed;

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoControlAllowed e)
        {
            Id = e.Id;
            _isControlAllowed = true;
        }

        public void Close(Guid idUser, DateTime closingDate)
        {
            var evt = BuildEvt.InterventoClosed
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
            var evt = BuildEvt.InterventoControlledNonReso
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
            var evt = BuildEvt.InterventoReopened
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
