using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareNonResoTrenitaliaInterventoRotHandler : CommandHandler<ConsuntivareNonResoTrenitaliaInterventoRot>
    {
        public ConsuntivareNonResoTrenitaliaInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareNonResoTrenitaliaInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForMessageNotFoundException();

            existingIntervento.ConsuntivareNonResoTrenitalia(cmd.Id
                                , cmd.DataConsuntivazione
                                , cmd.IdCausaleTrenitalia
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}