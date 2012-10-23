using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.Appaltatore;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Aggiornamento_di_una_appaltatore_non_esistente : CommandBaseClass<UpdateAppaltatore>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        protected override CommandHandler<UpdateAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateAppaltatore When()
        {

            return  BuildCmd.UpdateAppaltatore
                         .WithDescription(_description)
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
