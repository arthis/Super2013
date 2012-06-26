﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Handlers;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Creazione_di_un_nuovo_lotto : CommandBaseClass<CreateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();

        protected override CommandHandler<CreateLotto> OnHandle(IRepository repository)
        {
            return new CreateLottoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateLotto When()
        {
            return BuildCmd.CreateLotto
                .ForCreationDate(_creationDate)
                .ForDescription(_description)
                .ForIntervall(_intervall)
                .Build(_id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.LottoCreated
                                 .ForCreationDate(_creationDate)
                                 .ForDescription(_description)
                                 .ForIntervall(_intervall)
                                 .Build(_id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
