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
    public class Crea_un_prezzo_base : CommandBaseClass<CreateBasePriceRot>
    {
        private readonly Guid _id = Guid.NewGuid();

        private Guid _idBasePrice = Guid.NewGuid();
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private readonly IntervalOpened _interval = new IntervalOpened(DateTime.Parse("01/08/2012"), DateTime.Parse("01/09/2012"));
        private readonly Guid _idTipoIntervento= Guid.NewGuid();
        private const decimal _value = 25;



        protected override CommandHandler<CreateBasePriceRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateBasePriceRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.PricingCreated
                                   .Build(_id,1);
           
        }

        public override CreateBasePriceRot When()
        {
            return Commands.BuildCmd.CreateBasePriceRot
                            .ForBasePrice(_idBasePrice)
                            .ForGruppoOggettoIntervento(_idGruppoOggettoIntervento)
                            .ForInterval(_interval)
                            .OfTipoIntervento(_idTipoIntervento)
                            .ForValue(_value)
                            .Build(_id,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.BasePriceRotCreated
                 .ForBasePrice(_idBasePrice)
                 .ForGruppoOggettoIntervento(_idGruppoOggettoIntervento)
                 .ForInterval(_interval)
                 .OfTipoIntervento(_idTipoIntervento)
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
