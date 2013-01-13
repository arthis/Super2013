using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Handlers.Commands.Pricing
{


    public class CreateBasePriceRotHandler : CommandHandler<CreateBasePriceRot>
    {
        public CreateBasePriceRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateBasePriceRot cmd)
        {
            Contract.Requires(cmd != null);


            var pricing = EventRepository.GetById<Domain.Pricing.PricingRot>(cmd.Id);

            if (pricing.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            pricing.CreateBasePrice(cmd.IdBasePrice, cmd.Value, cmd.IdGruppoOggettoIntervento, cmd.IdTipoIntervento, cmd.Interval.ToDomain());

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }
}

