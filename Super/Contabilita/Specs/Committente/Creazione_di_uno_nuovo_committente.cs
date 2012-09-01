using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Events;
using BuildCmd = Super.Contabilita.Commands.Build;
using Super.Contabilita.Handlers.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Creazione_di_uno_nuovo_committente : CommandBaseClass<CreateCommittente>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private string _sign = "test sign";
        

        protected override CommandHandler<CreateCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateCommittente When()
        {
            return BuildCmd.CreateCommittente
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.CommittenteCreated
                                 .ForDescription(_description)
                                 .ForSign(_sign)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
