using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Handlers.Pricing
{

    public class CreateBasePriceHandler : CommandHandler<CreateBasePrice>
    {
        public CreateBasePriceHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateBasePrice cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var pricing = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.Id);

            if (pricing.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            pricing.CreateBasePrice(cmd.IdBasePrice, cmd.Value, cmd.IdGruppoOggettoIntervento, cmd.IdTipoIntervento, IntervalOpened.FromMessage(cmd.Intervall));

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }

 
}

