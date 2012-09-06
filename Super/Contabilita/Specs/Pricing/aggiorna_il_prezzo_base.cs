using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Pricing;

namespace Super.Contabilita.Specs.Pricing
{
    public class aggiorna_il_prezzo_base : CommandBaseClass<UpdateBasePrice>
    {
        private readonly Guid _id = Guid.NewGuid();

        private Guid _idBasePrice = Guid.NewGuid();
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private readonly IntervalOpened _interval = new IntervalOpened(DateTime.Parse("01/08/2012"), DateTime.Parse("01/09/2012"));
        private readonly Guid _idTipoIntervento= Guid.NewGuid();
        private const decimal _value = 25;

        private readonly Guid _idGruppoOggettoInterventoUpdated = Guid.NewGuid();
        private readonly IntervalOpened _intervalUpdated = new IntervalOpened(DateTime.Parse("01/08/2010"), DateTime.Parse("01/09/2014"));
        private readonly Guid _idTipoInterventoUpdated = Guid.NewGuid();
        private const decimal _valueUpdated = 20;


        protected override CommandHandler<UpdateBasePrice> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateBasePriceHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.PricingCreated
                                   .Build(_id,1);
            yield return BuildEvt.BasePriceCreated
                .ForBasePrice(_idBasePrice)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .ForInterval(_interval)
                .ForType(_idTipoIntervento)
                .ForValue(_value)
                .Build(_id, 2);
        }

        public override UpdateBasePrice When()
        {
            return Commands.BuildCmd.UpdateBasePrice
                            .ForBasePrice(_idBasePrice)
                            .ForGruppoOggetto(_idGruppoOggettoInterventoUpdated)
                            .ForInterval(_intervalUpdated)
                            .ForType(_idTipoInterventoUpdated)
                            .ForValue(_valueUpdated)
                            .Build(_id,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.BasePriceUpdated
                .ForBasePrice(_idBasePrice)
                .ForGruppoOggetto(_idGruppoOggettoInterventoUpdated)
                .ForInterval(_intervalUpdated)
                .ForType(_idTipoInterventoUpdated)
                .ForValue(_valueUpdated)
                .Build(_id,3);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
