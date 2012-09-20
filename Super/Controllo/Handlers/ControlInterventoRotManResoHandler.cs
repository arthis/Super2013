using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoRotManResoHandler : CommandHandler<ControlInterventoRotManReso>
    {
        public ControlInterventoRotManResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlInterventoRotManReso cmd)
        {
            Contract.Requires(cmd != null);

            Treno trenoPartenza=null, trenoArrivo=null;

            var existingIntervento = EventRepository.GetById<InterventoRotMan>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.ControlReso(cmd.IdUser, cmd.ControlDate, cmd.WorkPeriod.ToDomain(),  cmd.Note, cmd.Oggetti.ToDomain());

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
