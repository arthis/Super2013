using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{

    public class CreateLottoHandler : CommandHandler<CreateLotto>
    {
        public CreateLottoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateLotto cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingLotto = EventRepository.GetById<Lotto>(cmd.Id);

            if (!existingLotto.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var lotto=  new Lotto(cmd.Id,
                                          Build.Intervall.FromPeriod(cmd.Intervall).Build(),
                                          cmd.CreationDate,
                                          cmd.Description);

            EventRepository.Save(lotto, cmd.CommitId);


            return lotto.CommandValidationMessages;
        }

    }

 
}
