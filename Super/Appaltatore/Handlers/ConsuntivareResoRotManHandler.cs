using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareResoRotManHandler : CommandHandler<ConsuntivareResoInterventoRotMan>
    {
        public ConsuntivareResoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareResoInterventoRotMan cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<InterventoRotMan>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForMessageNotFoundException();

            existingIntervento.ConsuntivareReso(cmd.Id
                                , cmd.DataConsuntivazione
                                , cmd.WorkPeriod.ToDomain()
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note
                                ,cmd.Oggetti.ToDomain());

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}