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
using Super.Contabilita.Handlers.Commands.Pricing;

namespace Super.Contabilita.Specs.Pricing
{
    public class aggiorna_il_prezzo_base : CommandBaseClass<UpdateBasePriceRot>
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


        protected override CommandHandler<UpdateBasePriceRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateBasePriceRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.PricingCreated
                                   .Build(_id,1);
            yield return BuildEvt.BasePriceRotCreated
                .ForBasePrice(_idBasePrice)
                .ForGruppoOggettoIntervento(_idGruppoOggettoIntervento)
                .ForInterval(_interval)
                .OfTipoIntervento(_idTipoIntervento)
                .ForValue(_value)
                .Build(_id, 2);
        }

        public override UpdateBasePriceRot When()
        {
            return Commands.BuildCmd.UpdateBasePriceRot
                            .ForBasePrice(_idBasePrice)
                            .ForGruppoOggettoIntervento(_idGruppoOggettoInterventoUpdated)
                            .ForInterval(_intervalUpdated)
                            .OfTipoIntervento(_idTipoInterventoUpdated)
                            .ForValue(_valueUpdated)
                            .Build(_id,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.BasePriceRotUpdated
                .ForBasePrice(_idBasePrice)
                .ForGruppoOggettoIntervento(_idGruppoOggettoInterventoUpdated)
                .ForInterval(_intervalUpdated)
                .OfTipoIntervento(_idTipoInterventoUpdated)
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
