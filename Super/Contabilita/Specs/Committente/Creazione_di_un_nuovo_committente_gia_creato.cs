using System;
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
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.Committente;

namespace Super.Contabilita.Specs.Committente
{
    public class Creazione_di_un_nuovo_committente_gia_creato : CommandBaseClass<CreateCommittente>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private string _sign = "sign";

        public override string ToDescription()
        {
            return "Creare un'committente gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CommittenteCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
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
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
