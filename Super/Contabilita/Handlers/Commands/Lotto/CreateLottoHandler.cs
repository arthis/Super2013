using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Handlers.Commands.Lotto
{

    public class CreateLottoHandler : CommandHandler<CreateLotto>
    {
        public CreateLottoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateLotto cmd)
        {
            Contract.Requires(cmd != null);

            var existingLotto = EventRepository.GetById<Domain.Lotto>(cmd.Id);

            if (!existingLotto.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var lotto = new Domain.Lotto(cmd.Id,
                                          BuildDomainVO.Interval.FromInterval(cmd.Interval).Build(),
                                          cmd.Description);

            EventRepository.Save(lotto, cmd.CommitId);


            return lotto.CommandValidationMessages;
        }

    }

 
}
