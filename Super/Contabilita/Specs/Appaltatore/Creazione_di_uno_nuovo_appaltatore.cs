﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using Super.Contabilita.Handlers.Appaltatore;

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
                .ForDescription(_description)
                .Build(_id,0);
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