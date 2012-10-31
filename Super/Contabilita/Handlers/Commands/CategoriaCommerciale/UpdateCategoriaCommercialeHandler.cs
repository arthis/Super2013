using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Handlers.Commands.CategoriaCommerciale
{
    public class UpdateCategoriaCommercialeHandler : CommandHandler<UpdateCategoriaCommerciale>
    {
        public UpdateCategoriaCommercialeHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateCategoriaCommerciale cmd)
        {
            Contract.Requires(cmd != null);

            var appaltatore = EventRepository.GetById<Domain.CategoriaCommerciale>(cmd.Id);

            if (appaltatore.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            appaltatore.Update( cmd.Description);

            EventRepository.Save(appaltatore, cmd.CommitId);

            return appaltatore.CommandValidationMessages;
        }
      
    }
}
