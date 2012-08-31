﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.bachiBouzouk;

namespace Super.Contabilita.Specs.BachiBouzouk
{
    public class Crea_un_prezzo_base : CommandBaseClass<CreateBasePrice>
    {
        private readonly Guid _id = Guid.NewGuid();

        private Guid _idBasePrice = Guid.NewGuid();
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private readonly IntervalOpened _interval = new IntervalOpened(DateTime.Parse("01/08/2012"), DateTime.Parse("01/09/2012"));
        private readonly Guid _idTipoIntervento= Guid.NewGuid();
        private const decimal _value = 25;



        protected override CommandHandler<CreateBasePrice> OnHandle(IEventRepository eventRepository)
        {
            return new CreateBasePriceHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  Build.bachibouzoukCreated
                                   .Build(_id,1);
           
        }

        public override CreateBasePrice When()
        {
            return Commands.Build.CreateBasePrice
                            .ForBasePrice(_idBasePrice)
                            .ForGruppoOggetto(_idGruppoOggettoIntervento)
                            .ForInterval(_interval)
                            .ForType(_idTipoIntervento)
                            .ForValue(_value)
                            .Build(_id,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.BasePriceCreated
                 .ForBasePrice(_idBasePrice)
                 .ForGruppoOggetto(_idGruppoOggettoIntervento)
                 .ForInterval(_interval)
                 .ForType(_idTipoIntervento)
                 .ForValue(_value)
                 .Build(_id, 2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
