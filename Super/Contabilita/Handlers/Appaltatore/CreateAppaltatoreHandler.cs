using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Appaltatore
{

    public class CreateAppaltatoreHandler : CommandHandler<CreateAppaltatore>
    {
        public CreateAppaltatoreHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateAppaltatore cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            

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
