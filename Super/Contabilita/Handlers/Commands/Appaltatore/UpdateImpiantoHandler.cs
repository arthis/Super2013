﻿using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Handlers.Commands.Appaltatore
{
    public class UpdateAppaltatoreHandler : CommandHandler<UpdateAppaltatore>
    {
        public UpdateAppaltatoreHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateAppaltatore cmd)
        {
            Contract.Requires(cmd != null);

            var appaltatore = EventRepository.GetById<Domain.Appaltatore>(cmd.Id);

            if (appaltatore.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            appaltatore.Update( cmd.Description);

            EventRepository.Save(appaltatore, cmd.CommitId);

            return appaltatore.CommandValidationMessages;
        }
      
    }
}
