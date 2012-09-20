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
    public class AllowControlInterventoHandler : CommandHandler<AllowControlIntervento>
    {
        public AllowControlInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AllowControlIntervento cmd)
        {
            Contract.Requires(cmd != null);



            var existingIntervento = EventRepository.GetById<Intervento>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.AllowControl(cmd.Id);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
