using System;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Schedulazione
{
    public class ConfirmGenerationFailedHandler : CommandHandler<ConfirmGenerationFailed>
    {
        public ConfirmGenerationFailedHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConfirmGenerationFailed cmd)
        {
            throw new NotImplementedException();

            //Contract.Requires(cmd != null);

        


            //var existingIntervento = EventRepository.GetById<Plan>(cmd.Id);

            //if (!existingIntervento.IsNull())
            //    throw new AlreadyCreatedAggregateRootException();

            //existingIntervento.AllowControl(cmd.Id);

            //EventRepository.Save(existingIntervento, cmd.CommitId);

            //return existingIntervento.CommandValidationMessages; 
        }
    }
}
