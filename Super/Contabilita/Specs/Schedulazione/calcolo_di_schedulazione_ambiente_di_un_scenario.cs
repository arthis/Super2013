using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Commands.Schedulazione;
using Super.Contabilita.Events;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Handlers.Commands.Schedulazione;

namespace Super.Contabilita.Specs.Schedulazione
{
    public class calcolo_di_schedulazione_ambiente_di_un_scenario : CommandBaseClass<CalculateSchedulazioneAmbPriceOfScenario>
    {
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idSchedulazione = Guid.NewGuid();
        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("28/08/2012 10:00"), DateTime.Parse("28/08/2012 11:00"));
        private Period _period = new Period(DateTime.Today, DateTime.Today.AddDays(9).AddHours(23).AddMinutes(59).AddSeconds(59));
        private int _quantity = 2;
        private string _description = "description";

        private Guid _idPricing = Guid.NewGuid();
        private Guid _idBasePrice = Guid.NewGuid();
        private IntervalOpened _intervalPrezzoBase = new IntervalOpened(DateTime.Parse("01/01/2012"), DateTime.Parse("01/01/2015"));
        private decimal _valuePrezzoBase = 25;
        private Guid _idTipoIntervento = Guid.NewGuid();

        private decimal _priceCalculated = 500;
        
        
        


        protected override CommandHandler<CalculateSchedulazioneAmbPriceOfScenario> OnHandle(IEventRepository eventRepository)
        {
            var pricing = eventRepository.GetById<Domain.Pricing.PricingAmb>(_idPricing);
            return new CalculateSchedulazioneAmbPriceOfScenarioHandler(eventRepository, pricing);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.PricingCreated
                .Build(_idPricing, 1);

            yield return BuildEvt.BasePriceAmbCreated
                .ForInterval(_intervalPrezzoBase)
                .OfTipoIntervento(_idTipoIntervento)
                .ForValue(_valuePrezzoBase)
                .ForBasePrice(_idBasePrice)
                .Build(_idPricing, 2);

        }

        public override CalculateSchedulazioneAmbPriceOfScenario When()
        {
            return Commands.BuildCmd.CalculateSchedulazioneAmbPriceOfScenario
                .ForWorkPeriod(_workPeriod)
                .ForScenario(_idScenario)
                .ForTipoIntervento(_idTipoIntervento)
                .ForDescription(_description)
                .ForQuantity(_quantity)
                .ForPeriod(_period)
                .Build(_idSchedulazione, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.SchedulazioneAmbCreated
                .ForPeriod(_period)
                .ForQuantity(_quantity)
                .ForScenario(_idScenario)
                .ForWorkPeriod(_workPeriod)
                .OfTipoIntervento(_idTipoIntervento)
                .Build(_idSchedulazione, 1);
            yield return BuildEvt.SchedulazionePriceOfScenarioCalculated
             .ForScenario(_idScenario)
             .ForPrice(_priceCalculated)
             .Build(_idSchedulazione, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
