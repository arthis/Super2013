using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Committente
{

    public class CreateCommittenteHandler : CommandHandler<CreateCommittente>
    {
        public CreateCommittenteHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateCommittente cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            

            var existingCommittente = EventRepository.GetById<Domain.Committente>(cmd.Id);

            if (!existingCommittente.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var committente = new Domain.Committente(cmd.Id,
                                          cmd.Description,
                                          cmd.Sign);

            EventRepository.Save(committente, cmd.CommitId);


            return committente.CommandValidationMessages;
        }

    }

 
}
