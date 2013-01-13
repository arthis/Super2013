using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Handlers.Commands.Pricing;

namespace Super.Contabilita.Specs.Pricing
{
    public class Creazione_di_uno_nuovo_pricing : CommandBaseClass<CreatePricingRot>
    {
        private Guid _id = Guid.NewGuid();


        protected override CommandHandler<CreatePricingRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreatePricingRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreatePricingRot When()
        {
            return BuildCmd.CreatePricingRot
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
