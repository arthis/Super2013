using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Handlers.bachiBouzouk;

namespace Super.Contabilita.Specs.BachiBouzouk
{
    public class Creazione_di_uno_nuovo_bachibouzouk : CommandBaseClass<Createbachibouzouk>
    {
        private Guid _id = Guid.NewGuid();


        protected override CommandHandler<Createbachibouzouk> OnHandle(IEventRepository eventRepository)
        {
            return new CreatebachibouzoukHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override Createbachibouzouk When()
        {
            return Build.CreateBachiBouzouk
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Events.Build.bachibouzoukCreated
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
