using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.AreaIntervento;
using Super.Contabilita.Handlers;

namespace Super.Contabilita.Specs.AreaIntervento
{
    public class Cancellazione_di_una_area_intervento_non_esistente : CommandBaseClass<DeleteAreaIntervento>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteAreaIntervento> OnHandle(IRepository repository)
        {
            return new DeleteAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteAreaIntervento When()
        {
            return new DeleteAreaIntervento(_id);
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
