using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Handlers.Appaltatore
{
    public class DeleteAppaltatoreHandler : CommandHandler<DeleteAppaltatore>
    {
        public DeleteAppaltatoreHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteAppaltatore cmd)
        {
            Contract.Requires(cmd != null);

            var appaltatore= EventRepository.GetById<Domain.Appaltatore>(cmd.Id);

            if (appaltatore.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            appaltatore.Delete();

            EventRepository.Save(appaltatore, cmd.CommitId);

            return appaltatore.CommandValidationMessages;
        }
    }
}
