using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotNonResoTrenitaliaHandler : CommandHandler<ConsuntivareRotNonResoTrenitalia>
    {
        public ConsuntivareRotNonResoTrenitaliaHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotNonResoTrenitalia cmd)
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