using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Lotto;
using BuildCmd = Super.Contabilita.Commands.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Creazione_di_un_nuovo_lotto : CommandBaseClass<CreateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();

        protected override CommandHandler<CreateLotto> OnHandle(IEventRepository eventRepository)
        {
            return new CreateLottoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateLotto When()
        {
            return BuildCmd.CreateLotto
                .ForDescription(_description)
                .ForInterval(_interval)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.LottoCreated
                                 .ForDescription(_description)
                                 .ForInterval(_interval)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
