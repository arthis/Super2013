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
    public class ConsuntivareAmbNonResoHandler : CommandHandler<ConsuntivareAmbNonReso>
    {
        public ConsuntivareAmbNonResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbNonReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForMessageNotFoundException();

            existingIntervento.ConsuntivareNonReso(cmd.Id
                                , cmd.IdInterventoAppaltatore
                                , cmd.DataConsuntivazione
                                , cmd.IdCausaleAppaltatore
                                , cmd.Note);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}