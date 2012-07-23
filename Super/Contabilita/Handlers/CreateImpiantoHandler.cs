﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{

    public class CreateImpiantoHandler : CommandHandler<CreateImpianto>
    {
        public CreateImpiantoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateImpianto cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingLotto = EventRepository.GetById<Lotto>(cmd.IdLotto);
            var existingImpianto = EventRepository.GetById<Impianto>(cmd.Id);

            if (!existingImpianto.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if(existingLotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            var impianto=  new Impianto(cmd.Id,
                                          Build.Interval.FromPeriod(cmd.Interval).Build(),
                                          cmd.IdLotto,
                                          cmd.CreationDate,
                                          cmd.Description,
                                          existingLotto);

            EventRepository.Save(impianto, cmd.CommitId);


            return impianto.CommandValidationMessages;
        }

    }

 
}
