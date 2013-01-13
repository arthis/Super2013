using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Handlers.Commands.Pricing
{
    public class CreatePricingRotManHandler : CommandHandler<CreatePricingRotMan>
    {
        public CreatePricingRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePricingRotMan cmd)
        {
            Contract.Requires(cmd != null);


            var existingPricing = EventRepository.GetById<Domain.Pricing.PricingRotMan>(cmd.Id);

            if (!existingPricing.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var pricing = new Domain.Pricing.PricingRotMan(cmd.Id);

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }
}