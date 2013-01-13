using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Handlers.Commands.Pricing
{

    public class CreatePricingRotHandler : CommandHandler<CreatePricingRot>
    {
        public CreatePricingRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePricingRot cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingPricing = EventRepository.GetById<Domain.Pricing.PricingRot>(cmd.Id);

            if (!existingPricing.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var pricing = new Domain.Pricing.PricingRot(cmd.Id);

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }
}

