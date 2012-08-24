using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using Super.Contabilita.Handlers.Appaltatore;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Cancellazione_di_una_appaltatore_non_esistente : CommandBaseClass<DeleteAppaltatore>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteAppaltatore When()
        {
            return BuildCmd.DeleteAppaltatore
                .Build(_id,0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
