﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{
    public class UpdateLottoHandler : CommandHandler<UpdateLotto>
    {
        public UpdateLottoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(UpdateLotto cmd, ICommandHandler<UpdateLotto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var lotto= Repository.GetById<Lotto>(cmd.Id);

            if (lotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            lotto.Update(Build.Intervall.FromPeriod(cmd.Period).Build(), cmd.Description);

            Repository.Save(lotto, cmd.CommitId);

            return lotto.CommandValidationMessages;
        }
      
    }
}