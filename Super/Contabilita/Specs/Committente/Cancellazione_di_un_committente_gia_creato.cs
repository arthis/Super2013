using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Cancellazione_di_un_committente_gia_creato : CommandBaseClass<DeleteCommittente>
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
        }

        public override DeleteCommittente When()
        {
            return BuildCmd.DeleteCommittente
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.CommittenteDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
