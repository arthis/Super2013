using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoAmbResoHandler : CommandHandler<ControlInterventoAmbReso>
    {
        public ControlInterventoAmbResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlInterventoAmbReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            Treno trenoPartenza=null, trenoArrivo=null;


            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUtente, cmd.ControlDate, WorkPeriod.FromMessage(cmd.Period),   cmd.Note, cmd.Quantity, cmd.Description);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
