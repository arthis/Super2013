using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class CloseInterventoHandler : CommandHandler<CloseIntervento>
    {
        public CloseInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CloseIntervento cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.Close(cmd.IdUser, cmd.ClosingDate);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
