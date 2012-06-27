﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{
    public class UpdateImpiantoHandler : CommandHandler<UpdateImpianto>
    {
        public UpdateImpiantoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(UpdateImpianto cmd, ICommandHandler<UpdateImpianto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var impianto= Repository.GetById<Impianto>(cmd.Id);

            if (impianto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            impianto.Update(Build.Intervall.FromPeriod(cmd.Period).Build(), cmd.Description);

            Repository.Save(impianto, cmd.CommitId);

            return impianto.CommandValidationMessages;
        }
      
    }
}