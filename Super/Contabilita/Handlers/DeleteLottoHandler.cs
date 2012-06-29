using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{
    public class DeleteLottoHandler : CommandHandler<DeleteLotto>
    {
        public DeleteLottoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteLotto cmd, ICommandHandler<DeleteLotto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var lotto= EventRepository.GetById<Lotto>(cmd.Id);

            if (lotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            lotto.Delete();

            EventRepository.Save(lotto, cmd.CommitId);

            return lotto.CommandValidationMessages;
        }
    }
}
