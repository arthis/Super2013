using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Handlers.Commands.Pricing
{
    public class CreatePricingAmbHandler : CommandHandler<CreatePricingAmb>
    {
        public CreatePricingAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePricingAmb cmd)
        {
            Contract.Requires(cmd != null);


            var existingPricing = EventRepository.GetById<Domain.Pricing.PricingAmb>(cmd.Id);

            if (!existingPricing.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var pricing = new Domain.Pricing.PricingAmb(cmd.Id);

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }
}