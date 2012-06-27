﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Creazione_di_una_nuova_impianto : CommandBaseClass<CreateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();

        protected override CommandHandler<CreateImpianto> OnHandle(IRepository repository)
        {
            return new CreateImpiantoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateImpianto When()
        {
            return BuildCmd.CreateImpianto
                .ForCreationDate(_creationDate)
                .ForDescription(_description)
                .ForLotto(_idLotto)
                .ForIntervall(_intervall)
                .Build(_id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ImpiantoCreated
                                 .ForCreationDate(_creationDate)
                                 .ForDescription(_description)
                                 .ForLotto(_idLotto)
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