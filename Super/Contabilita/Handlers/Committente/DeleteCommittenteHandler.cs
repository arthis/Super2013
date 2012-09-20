using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Committente;

namespace Super.Contabilita.Handlers.Committente
{
    public class DeleteCommittenteHandler : CommandHandler<DeleteCommittente>
    {
        public DeleteCommittenteHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteCommittente cmd)
        {
            Contract.Requires(cmd != null);

            var committente= EventRepository.GetById<Domain.Committente>(cmd.Id);

            if (committente.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            committente.Delete();

            EventRepository.Save(committente, cmd.CommitId);

            return committente.CommandValidationMessages;
        }
    }
}
