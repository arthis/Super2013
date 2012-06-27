﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{

    public class CreateLottoHandler : CommandHandler<CreateLotto>
    {
        public CreateLottoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(CreateLotto cmd, ICommandHandler<CreateLotto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingLotto = Repository.GetById<Lotto>(cmd.Id);

            if (!existingLotto.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var lotto=  new Lotto(cmd.Id,
                                          Build.Intervall.FromPeriod(cmd.Period).Build(),
                                          cmd.CreationDate,
                                          cmd.Description);

            Repository.Save(lotto, cmd.CommitId);


            return lotto.CommandValidationMessages;
        }

    }

 
}