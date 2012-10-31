using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Handlers.Commands.DirezioneRegionale
{

    public class CreateDirezioneRegionaleHandler : CommandHandler<CreateDirezioneRegionale>
    {
        public CreateDirezioneRegionaleHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateDirezioneRegionale cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingDirezioneRegionale = EventRepository.GetById<Domain.DirezioneRegionale>(cmd.Id);

            if (!existingDirezioneRegionale.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var direzione = new Domain.DirezioneRegionale(cmd.Id,
                                          cmd.Description);

            EventRepository.Save(direzione, cmd.CommitId);


            return direzione.CommandValidationMessages;
        }

    }

 
}
