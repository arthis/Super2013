using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Handlers;

namespace Super.Contabilita.Specs.Lotto
{
    public class Cancellazione_di_un_lotto_non_esistente : CommandBaseClass<DeleteLotto>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteLotto> OnHandle(IRepository repository)
        {
            return new DeleteLottoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteLotto When()
        {
            return new DeleteLotto(_id);
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
