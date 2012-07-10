using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Handlers;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Cancellazione_di_un_lotto_non_esistente : CommandBaseClass<DeleteLotto>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteLotto> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteLottoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteLotto When()
        {
            return BuildCmd.DeleteLotto
                           .Build(_id, 0); 
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
