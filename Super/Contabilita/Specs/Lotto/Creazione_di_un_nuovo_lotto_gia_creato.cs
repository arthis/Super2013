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
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.Lotto;

namespace Super.Contabilita.Specs.Lotto
{
    public class Creazione_di_un_nuovo_lotto_gia_creato : CommandBaseClass<CreateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        public override string ToDescription()
        {
            return "Creare un lotto gia creato con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateLotto> OnHandle(IEventRepository eventRepository)
        {
            return new CreateLottoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                                .ForInterval(_interval)
                                .ForDescription(_description)
                                .Build(_id,1);
        }

        public override CreateLotto When()
        {
            return BuildCmd.CreateLotto
                .ForInterval(_interval)
                .ForDescription(_description)
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
