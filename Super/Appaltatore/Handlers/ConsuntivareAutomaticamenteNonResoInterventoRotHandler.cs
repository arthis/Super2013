using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareAutomaticamenteNonResoInterventoRotHandler : CommandHandler<ConsuntivareAutomaticamenteNonResoInterventoRot>
    {
        public ConsuntivareAutomaticamenteNonResoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAutomaticamenteNonResoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForMessageNotFoundException();

            existingIntervento.ConsuntivareAutomaticamenteNonReso(cmd.DataConsuntivazione);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}