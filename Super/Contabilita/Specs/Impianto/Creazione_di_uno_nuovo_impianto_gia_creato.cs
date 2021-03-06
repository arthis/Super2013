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
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Impianto;

namespace Super.Contabilita.Specs.Impianto
{
    public class Creazione_di_uno_nuovo_impianto_gia_creato : CommandBaseClass<CreateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();
        private Interval _intervalLotto = new Interval(DateTime.Now, DateTime.Now.AddHours(4));

        public override string ToDescription()
        {
            return "Creare un'impianto gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateImpianto> OnHandle(IEventRepository eventRepository)
        {
            return new CreateImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                .ForDescription("lotto")
                .ForInterval(_intervalLotto)
                .Build(_idLotto, 0);
            yield return BuildEvt.ImpiantoCreated
                .ForInterval(_interval)
                .ForDescription(_description)
                .ForLotto(_idLotto)
                .Build(_id, 1);
        }

        public override CreateImpianto When()
        {
            return BuildCmd.CreateImpianto
                .ForInterval(_interval)
                .ForLotto(_idLotto)
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
