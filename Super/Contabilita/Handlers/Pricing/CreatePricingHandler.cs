using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Handlers.Pricing
{

    public class CreatePricingHandler : CommandHandler<CreatePricing>
    {
        public CreatePricingHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePricing cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            

            var existingPricing = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.Id);

            if (!existingPricing.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var pricing = new Domain.Pricing.Pricing(cmd.Id);

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }

 
}

