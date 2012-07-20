using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoNonResoHandler : CommandHandler<ControlInterventoNonReso>
    {
        public ControlInterventoNonResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlInterventoNonReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = EventRepository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.ControlNonReso( cmd.IdUser, cmd.ControlDate, cmd.IdCausale, cmd.Note);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
