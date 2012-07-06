using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Handlers;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Cancellazione_di_un_lotto_gia_cancellato : CommandBaseClass<DeleteLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        protected override CommandHandler<DeleteLotto> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteLottoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .Build(_id,1);
            yield return BuildEvt.LottoDeleted
                .Build(_id, 2);
        }

        public override DeleteLotto When()
        {
            return BuildCmd.DeleteLotto
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
