﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Aggiornamento_di_una_carrozza_rotabile_non_esistente : CommandBaseClass<UpdateCarriageRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const bool _isInternational = true;
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();

        protected override CommandHandler<UpdateCarriageRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCarriageRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateCarriageRot When()
        {

            return BuildCmd.UpdateCarriageRot
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
