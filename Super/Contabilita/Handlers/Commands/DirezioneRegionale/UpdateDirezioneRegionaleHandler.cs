using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Handlers.Commands.DirezioneRegionale
{
    public class UpdateDirezioneRegionaleHandler : CommandHandler<UpdateDirezioneRegionale>
    {
        public UpdateDirezioneRegionaleHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateDirezioneRegionale cmd)
        {
            Contract.Requires(cmd != null);

            var direzione = EventRepository.GetById<Domain.DirezioneRegionale>(cmd.Id);

            if (direzione.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            direzione.Update( cmd.Description);

            EventRepository.Save(direzione, cmd.CommitId);

            return direzione.CommandValidationMessages;
        }
      
    }
}
