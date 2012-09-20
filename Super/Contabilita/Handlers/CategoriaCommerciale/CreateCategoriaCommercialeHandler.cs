using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.CategoriaCommerciale
{

    public class CreateCategoriaCommercialeHandler : CommandHandler<CreateCategoriaCommerciale>
    {
        public CreateCategoriaCommercialeHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateCategoriaCommerciale cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingCategoriaCommerciale = EventRepository.GetById<Domain.CategoriaCommerciale>(cmd.Id);

            if (!existingCategoriaCommerciale.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var appaltatore = new Domain.CategoriaCommerciale(cmd.Id,
                                          cmd.Description);

            EventRepository.Save(appaltatore, cmd.CommitId);


            return appaltatore.CommandValidationMessages;
        }

    }

 
}
