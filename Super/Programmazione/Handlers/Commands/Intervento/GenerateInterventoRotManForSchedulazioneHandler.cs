using System;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Handlers.Commands.Intervento
{
    public class GenerateInterventoRotManForSchedulazioneHandler : CommandHandler<GenerateInterventoRotManForSchedulazione>
    {
        public GenerateInterventoRotManForSchedulazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(GenerateInterventoRotManForSchedulazione cmd)
        {
            throw new NotImplementedException();

            //Contract.Requires(cmd != null);

        


            //var existingIntervento = EventRepository.GetById<Scenario>(cmd.Id);

            //if (!existingIntervento.IsNull())
            //    throw new AlreadyCreatedAggregateRootException();

            //existingIntervento.AllowControl(cmd.Id);

            //EventRepository.Save(existingIntervento, cmd.CommitId);

            //return existingIntervento.CommandValidationMessages; 
        }
    }
}
