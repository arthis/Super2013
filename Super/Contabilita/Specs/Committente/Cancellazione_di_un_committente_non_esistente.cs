﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Handlers.Commands.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Cancellazione_di_un_committente_non_esistente : CommandBaseClass<DeleteCommittente>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteCommittente When()
        {
            return BuildCmd.DeleteCommittente
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
