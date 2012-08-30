using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Committente;
using BuildEvt = Super.Contabilita.Events.Build;
using BuildCmd = Super.Contabilita.Commands.Build;
using Super.Contabilita.Handlers.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Cancellazione_di_un_committente_gia_cancellato : CommandBaseClass<DeleteCommittente>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private string _sign = "sign";
        

        protected override CommandHandler<DeleteCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CommittenteCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id,1);
            yield return BuildEvt.CommittenteDeleted
                .Build(_id, 2);
        }

        public override DeleteCommittente When()
        {
            return BuildCmd.DeleteCommittente
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
