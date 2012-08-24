﻿using System;
using System.Collections.Generic;
using CommonDomain;
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
    public class Cancellazione_di_una_appaltatore_gia_creata : CommandBaseClass<DeleteAppaltatore>
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
        }

        public override DeleteAppaltatore When()
        {
            return BuildCmd.DeleteAppaltatore
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.AppaltatoreDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
