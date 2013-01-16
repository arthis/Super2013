using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoAmbResoHandler : CommandHandler<ControlResoInterventoAmb>
    {
        public ControlInterventoAmbResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlResoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUser, cmd.ControlDate, cmd.WorkPeriod.ToDomain(),   cmd.Note, cmd.Quantity, cmd.Description);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
