using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Handlers.Pricing;

namespace Super.Contabilita.Specs.Pricing
{
    public class Creazione_di_uno_nuovo_pricing : CommandBaseClass<CreatePricing>
    {
        private Guid _id = Guid.NewGuid();


        protected override CommandHandler<CreatePricing> OnHandle(IEventRepository eventRepository)
        {
            return new CreatePricingHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreatePricing When()
        {
            return Build.CreatePricing
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Events.BuildEvt.PricingCreated
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
