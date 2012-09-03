using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Appaltatore;
using Super.Contabilita.Handlers.Pricing;

namespace Super.Contabilita.Specs.Pricing
{
    public class Creazione_di_uno_nuovo_pricing_gia_creato : CommandBaseClass<CreatePricing>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'Pricing gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreatePricing> OnHandle(IEventRepository eventRepository)
        {
            return new CreatePricingHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.PricingCreated
                .Build(_id, 1);
        }

        public override CreatePricing When()
        {
            return Commands.Build.CreatePricing
                                 .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
