﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Creazione_di_una_nuova_carrozza_rotabile_in_mantenzione : CommandBaseClass<CreateCarriageRotMan>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const bool _isInternational = true;
        private const string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();


        protected override CommandHandler<CreateCarriageRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCarriageRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateCarriageRotMan When()
        {
            return Commands.BuildCmd.CreateCarriageRotMan
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoOggettoInterventoRotManCreated
                .Build(_id, 1);
            yield return BuildEvt.CarriageRotManCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
