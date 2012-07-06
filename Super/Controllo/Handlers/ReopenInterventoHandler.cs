using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ReopenInterventoHandler : CommandHandler<ReopenIntervento>
    {
        public ReopenInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ReopenIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);



            var existingIntervento = EventRepository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.Reopen(cmd.IdUtente, cmd.ReopeningDate);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
