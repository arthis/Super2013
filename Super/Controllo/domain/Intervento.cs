using System;
using CommonDomain.Core;
using Super.Controllo.Events;

namespace Super.Controllo.Domain
{
    public class Intervento : AggregateBase
    {

        public Intervento()
        {
            //var evt = new InventoryItemCreatedAdded()
            //{
            //    Id = id,
            //    Name = name
            //};

            //RaiseEvent(evt);
        }

        //public void Apply(InventoryItemCreatedAdded e)
        //{
        //    Id = e.Id;
        //}


        public void AllowControl()
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoControlAllowed e)
        {
            Id = e.Id;
        }

        public void Close(Guid idUtente, DateTime closingDate)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoClosed e)
        {
            throw new NotImplementedException();
        }

        public void ControlNonReso(Guid idUtente, DateTime controlDate, Guid idCausale, string note)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoControlledNonReso e)
        {
            throw new NotImplementedException();
        }

        public void Reopen(Guid idUtente, DateTime reopeningDate)
        {
            throw new NotImplementedException();
        }

        public void Apply(InterventoReopened e)
        {
            throw new NotImplementedException();
        }
    }
}
