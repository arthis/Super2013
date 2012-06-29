using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotManNonResoTrenitaliaHandler : CommandHandler<ConsuntivareRotManNonResoTrenitalia>
    {
        public ConsuntivareRotManNonResoTrenitaliaHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotManNonResoTrenitalia cmd, ICommandHandler<ConsuntivareRotManNonResoTrenitalia> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);



            var existingIntervento = EventRepository.GetById<InterventoRotMan>(cmd.Id);

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