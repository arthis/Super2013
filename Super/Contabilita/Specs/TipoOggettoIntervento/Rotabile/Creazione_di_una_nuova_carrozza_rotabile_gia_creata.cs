﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Creazione_di_una_nuova_carrozza_rotabile_gia_creata : CommandBaseClass<CreateCarriageRot>
    {
        private Guid _id = Guid.NewGuid();
        private const bool _isInternational = true;
        private const string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();

        public override string ToDescription()
        {
            return "Creare una locomotiva rotabile gia creata con il stesso Guid non é possibile";
        }


        protected override CommandHandler<CreateCarriageRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCarriageRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CarriageRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational )
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override CreateCarriageRot When()
        {
            return Commands.BuildCmd.CreateCarriageRot
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
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