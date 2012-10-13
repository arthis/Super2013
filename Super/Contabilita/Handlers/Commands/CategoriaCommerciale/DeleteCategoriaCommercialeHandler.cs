using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Handlers.Commands.CategoriaCommerciale
{
    public class DeleteCategoriaCommercialeHandler : CommandHandler<DeleteCategoriaCommerciale>
    {
        public DeleteCategoriaCommercialeHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteCategoriaCommerciale cmd)
        {
            Contract.Requires(cmd != null);

            var appaltatore= EventRepository.GetById<Domain.CategoriaCommerciale>(cmd.Id);

            if (appaltatore.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            appaltatore.Delete();

            EventRepository.Save(appaltatore, cmd.CommitId);

            return appaltatore.CommandValidationMessages;
        }
    }
}
