using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Events;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Handlers.Commands.Intervento;

namespace Super.Contabilita.Specs.Intervento
{
    public class Calcolo_di_intervento_rotabile : CommandBaseClass<CalculateInterventoRotPriceOfPlan>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idPlan = Guid.NewGuid();
        private OggettoRot[] _oggetti;
        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("28/08/2012 10:00"), DateTime.Parse("28/08/2012 11:00"));
        
        private Guid _idPricing = Guid.NewGuid();
        private Guid _idBasePrice = Guid.NewGuid();
        private Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private IntervalOpened _intervalPrezzoBase = new IntervalOpened(DateTime.Parse("01/01/2012"), DateTime.Parse("01/01/2015"));
        private decimal _valuePrezzoBase = 25;
        private Guid _idTipoIntervento = Guid.NewGuid();
        
        private decimal _priceCalculated=25;

        private Guid _idTipoOggettoIntervento = Guid.NewGuid();
        


        protected override CommandHandler<CalculateInterventoRotPriceOfPlan> OnHandle(IEventRepository eventRepository)
        {
            var pricing = eventRepository.GetById<Domain.Pricing.PricingRot>(_idPricing);
            return new CalculateInterventoRotPriceOfPlanHandler(eventRepository, pricing);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.PricingCreated
                .Build(_idPricing, 1);

            yield return BuildEvt.BasePriceRotCreated
                .ForGruppoOggettoIntervento(_idGruppoOggettoIntervento)
                .ForInterval(_intervalPrezzoBase)
                .OfTipoIntervento(_idTipoIntervento)
                .ForValue(_valuePrezzoBase)
                .ForBasePrice(_idBasePrice)
                .Build(_idPricing,2);

        }

        public override CalculateInterventoRotPriceOfPlan When()
        {
            _oggetti = new[] { BuildMessagingVO.MsgOggettoRot
                                            .ForDescription("description")
                                            .OfType(_idTipoOggettoIntervento)
                                            .ForGruppo(_idGruppoOggettoIntervento)
                                            .OfQuantity(2)
                                            .Build()
                                 };

            return Commands.BuildCmd.CalculateInterventoRotPriceOfPlan
                .ForWorkPeriod(_workPeriod)
                .ForPlan(_idPlan)
                .ForTipoIntervento(_idTipoIntervento)
                .WithOggetti(_oggetti)
                .ForPricing(_idPricing)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotCreated
             .ForWorkPeriod(_workPeriod)
             .ForPlan(_idPlan)
             .OfTipoIntervento(_idTipoIntervento)
             .WithOggetti(_oggetti)
             .Build(_id, 1);
            yield return BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(_idPlan)
                .ForPrice(_priceCalculated)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
