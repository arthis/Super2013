﻿using System;
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
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Aggiornamento_di_un_committente_non_esistente : CommandBaseClass<UpdateCommittente>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private string _sign = "sign";

        protected override CommandHandler<UpdateCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateCommittente When()
        {

            return  BuildCmd.UpdateCommittente
                         .ForDescription(_description)
                         .ForSign(_sign)
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
