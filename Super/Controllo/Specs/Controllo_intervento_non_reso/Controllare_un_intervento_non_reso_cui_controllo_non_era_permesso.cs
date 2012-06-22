﻿
using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Builders;
using Super.Controllo.Events;
using Super.Controllo.Handlers;

namespace Super.Controllo.Specs.Controllo_intervento_non_reso
{
    public class Controllare_un_intervento_non_reso_cui_controllo_non_era_permesso : CommandBaseClass<ControlInterventoNonReso>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _controlDate = DateTime.Now;
        private Guid _idUtente = Guid.NewGuid();
        private Guid _idCausale = Guid.NewGuid();
        private string _note = "note";


        protected override CommandHandler<ControlInterventoNonReso> OnHandle(IRepository repository)
        {
            return new ControlInterventoNonResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ControlInterventoNonReso When()
        {
            var builder = new ControlInterventoNonResoBuilder();

            return builder.ForId(_Id)
                .By(_idUtente)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build();
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }



    }
}