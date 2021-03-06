﻿using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Handlers.Commands.Appaltatore
{

    public class CreateAppaltatoreHandler : CommandHandler<CreateAppaltatore>
    {
        public CreateAppaltatoreHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateAppaltatore cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingAppaltatore = EventRepository.GetById<Domain.Appaltatore>(cmd.Id);

            if (!existingAppaltatore.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var appaltatore = new Domain.Appaltatore(cmd.Id,
                                          cmd.Description);

            EventRepository.Save(appaltatore, cmd.CommitId);

            
            
            return appaltatore.CommandValidationMessages;
        }

    }

 
}
