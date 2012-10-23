using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.Appaltatore;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Creazione_di_uno_nuovo_appaltatore : CommandBaseClass<CreateAppaltatore>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<CreateAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new CreateAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateAppaltatore When()
        {
            return BuildCmd.CreateAppaltatore
                .WithDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.AppaltatoreCreated
                                 .ForDescription(_description)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
