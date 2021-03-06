﻿using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Handlers.Commands.Lotto
{
    public class DeleteLottoHandler : CommandHandler<DeleteLotto>
    {
        public DeleteLottoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteLotto cmd)
        {
            Contract.Requires(cmd != null);

            var lotto= EventRepository.GetById<Domain.Lotto>(cmd.Id);

            if (lotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            lotto.Delete();

            EventRepository.Save(lotto, cmd.CommitId);

            return lotto.CommandValidationMessages;
        }
    }
}
