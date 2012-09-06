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
    public class ConsuntivareAmbNonResoTrenitaliaHandler : CommandHandler<ConsuntivareAmbNonResoTrenitalia>
    {
        public ConsuntivareAmbNonResoTrenitaliaHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbNonResoTrenitalia cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            

            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

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