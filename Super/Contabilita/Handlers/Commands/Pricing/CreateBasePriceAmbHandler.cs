using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Handlers.Commands.Pricing
{
    public class CreateBasePriceAmbHandler : CommandHandler<CreateBasePriceAmb>
    {
        public CreateBasePriceAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateBasePriceAmb cmd)
        {
            Contract.Requires(cmd != null);


            var pricing = EventRepository.GetById<Domain.Pricing.PricingAmb>(cmd.Id);

            if (pricing.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            pricing.CreateBasePrice(cmd.IdBasePrice, cmd.Value, cmd.IdTipoIntervento, cmd.Interval.ToDomain());

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }
}