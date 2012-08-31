using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Appaltatore;
using Super.Contabilita.Handlers.bachiBouzouk;

namespace Super.Contabilita.Specs.BachiBouzouk
{
    public class Creazione_di_uno_nuovo_bachibouzouk_gia_creato : CommandBaseClass<Createbachibouzouk>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'bachibouzouk gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<Createbachibouzouk> OnHandle(IEventRepository eventRepository)
        {
            return new CreatebachibouzoukHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.bachibouzoukCreated
                .Build(_id, 1);
        }

        public override Createbachibouzouk When()
        {
            return Commands.Build.CreateBachiBouzouk
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
