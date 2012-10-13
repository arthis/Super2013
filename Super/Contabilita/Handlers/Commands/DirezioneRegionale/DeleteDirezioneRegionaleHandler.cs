using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Handlers.Commands.DirezioneRegionale
{
    public class DeleteDirezioneRegionaleHandler : CommandHandler<DeleteDirezioneRegionale>
    {
        public DeleteDirezioneRegionaleHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteDirezioneRegionale cmd)
        {
            Contract.Requires(cmd != null);

            var direzione= EventRepository.GetById<Domain.DirezioneRegionale>(cmd.Id);

            if (direzione.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            direzione.Delete();

            EventRepository.Save(direzione, cmd.CommitId);

            return direzione.CommandValidationMessages;
        }
    }
}
