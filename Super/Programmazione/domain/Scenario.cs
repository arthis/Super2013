using System;
using CommonDomain.Core;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Domain
{
    public class Scenario : AggregateBase
    {
        public Scenario()
        {
            
        }

        public Scenario(Guid id, Guid userId, string description)
        {
            var evt = BuildEvt.ScenarioCreated
                .ByUser(userId)
                .ForDescription(description);

             RaiseEvent(id, evt);
        }

        public void Apply(ScenarioCreated e)
        {
            Id = e.Id;
        }

        //private bool _isClosed;

        //public Intervento()
        //{
          
        //}


        //public void AllowControl(Guid id)
        //{
        //    var evt = BuildEvt.InterventoControlAllowed;

        //    RaiseEvent(id, evt);
        //}

        //public void Apply(InterventoControlAllowed e)
        //{
        //    Id = e.Id;
        //}

        //public void Close(Guid idUser, DateTime closingDate)
        //{
        //    var evt = BuildEvt.InterventoClosed
        //        .By(idUser)
        //        .When(closingDate);

        //    RaiseEvent(evt);
        //}

        //public void Apply(InterventoClosed e)
        //{
        //    _isClosed = true;
        //}

        //public void ControlNonReso(Guid idUser, DateTime controlDate, Guid idCausale, string note)
        //{
        //    var evt = BuildEvt.InterventoControlledNonReso
        //        .By(idUser)
        //        .When(controlDate)
        //        .Because(idCausale)
        //        .WithNote(note);

        //    RaiseEvent(evt);
        //}

        //public void Apply(InterventoControlledNonReso e)
        //{
        //    //do nothing
        //}

        //public void Reopen(Guid idUser, DateTime reopeningDate)
        //{
        //    var evt = BuildEvt.InterventoReopened
        //        .By(idUser)
        //        .When(reopeningDate);

        //    RaiseEvent(evt);
        //}

        //public void Apply(InterventoReopened e)
        //{
        //    _isClosed = false;
        //}
    }
}
