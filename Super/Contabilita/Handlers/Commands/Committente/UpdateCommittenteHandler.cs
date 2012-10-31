using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Committente;

namespace Super.Contabilita.Handlers.Commands.Committente
{
    public class UpdateCommittenteHandler : CommandHandler<UpdateCommittente>
    {
        public UpdateCommittenteHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateCommittente cmd)
        {
            Contract.Requires(cmd != null);

            var committente = EventRepository.GetById<Domain.Committente>(cmd.Id);

            if (committente.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            committente.Update( cmd.Description, cmd.Sign);

            EventRepository.Save(committente, cmd.CommitId);

            return committente.CommandValidationMessages;
        }
      
    }
}
