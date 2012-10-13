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
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.Appaltatore;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Cancellazione_di_una_appaltatore_gia_cancellata : CommandBaseClass<DeleteAppaltatore>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<DeleteAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.AppaltatoreCreated
                .ForDescription(_description)
                .Build(_id,1);
            yield return BuildEvt.AppaltatoreDeleted
                .Build(_id, 2);
        }

        public override DeleteAppaltatore When()
        {
            return BuildCmd.DeleteAppaltatore
                .Build(_id, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
