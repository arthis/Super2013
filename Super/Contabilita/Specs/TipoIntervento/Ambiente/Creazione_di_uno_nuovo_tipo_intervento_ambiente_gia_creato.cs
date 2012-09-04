﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Ambiente
{
    public class Creazione_di_uno_nuovo_tipo_intervento_ambiente_gia_creato : CommandBaseClass<CreateTipoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();

        public override string ToDescription()
        {
            return "Creare un tipo intervento ambiente gia creato con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateTipoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new CreateTipoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoInterventoAmbCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id, 1);
        }

        public override CreateTipoInterventoAmb When()
        {
            return Commands.BuildCmd.CreateTipoInterventoAmb
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
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
