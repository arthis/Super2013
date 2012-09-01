using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Impianto;
using BuildCmd = Super.Contabilita.Commands.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Cancellazione_di_una_impianto_non_esistente : CommandBaseClass<DeleteImpianto>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteImpianto> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteImpianto When()
        {
            return BuildCmd.DeleteImpianto
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
