using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using Super.Controllo.Commands;
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlResoInterventoNonHandler : CommandHandler<ControlNonResoIntervento>
    {
        public ControlResoInterventoNonHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlNonResoIntervento cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.ControlNonReso( cmd.IdUser, cmd.ControlDate, cmd.IdCausale, cmd.Note);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
