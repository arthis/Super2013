﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.RotabileInManutenzione
{
    public class Aggiornamento_di_un_tipo_intervento_rotabile_in_manutenzione_non_esistente : CommandBaseClass<UpdateTipoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();

        protected override CommandHandler<UpdateTipoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateTipoInterventoRotMan When()
        {

            return  Build.UpdateTipoInterventoRotMan
                         .ForDescription(_description)
                         .ForMnemo(_mnemo)
                         .OfMeasuringUNit(_idMeasuringUnit)
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
