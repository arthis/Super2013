﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Creazione_di_una_nuova_locomotiva_rotabile_in_mantenzione_gia_creata : CommandBaseClass<CreateLocomotiveRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _sign = "sign";

        public override string ToDescription()
        {
            return "Creare una locomotiva rotabile gia creata con il stesso Guid non é possibile";
        }


        protected override CommandHandler<CreateLocomotiveRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateLocomotiveRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.TipoOggettoInterventoAmbCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
        }

        public override CreateLocomotiveRotMan When()
        {
            return Commands.Builders.Build.CreateLocomotiveRotMan
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id,0);
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
