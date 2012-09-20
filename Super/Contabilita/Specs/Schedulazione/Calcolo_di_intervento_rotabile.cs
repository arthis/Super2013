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
using Super.Contabilita.Handlers.Intervento;

namespace Super.Contabilita.Specs.Schedulazione
{
    public class Calcolo_di_schedulazione_rotabile : CommandBaseClass<CalculateSchedulazioneRotPriceOfScenario>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idSchedulazione= Guid.NewGuid();;
        private OggettoRot[] _oggetti;
        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("28/08/2012 10:00"), DateTime.Parse("28/08/2012 11:00"));
        
        private Guid _idPricing = Guid.NewGuid();
        private Guid _idBasePrice = Guid.NewGuid();
        private Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private IntervalOpened _intervalPrezzoBase = new IntervalOpened(DateTime.Parse("01/01/2012"), DateTime.Parse("01/01/2015"));
        private decimal _valuePrezzoBase = 25;
        private Guid _idTipoIntervento = Guid.NewGuid();
        
        private decimal _priceCalculated=50;

        private Guid _idTipoOggettoIntervento = Guid.NewGuid();
        


        protected override CommandHandler<CalculateSchedulazioneRotPriceOfScenario> OnHandle(IEventRepository eventRepository)
        {
            return new CalculateSchedulazioneRotPriceOfScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.PricingCreated
                .Build(_idPricing, 1);

            yield return BuildEvt.BasePriceCreated
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .ForInterval(_intervalPrezzoBase)
                .ForType(_idTipoIntervento)
                .ForValue(_valuePrezzoBase)
                .ForBasePrice(_idBasePrice)
                .Build(_idPricing,2);

        }

        public override CalculateSchedulazioneRotPriceOfScenario When()
        {
            _oggetti = new[] { BuildMessagingVO.MsgOggettoRot
                                            .ForDescription("description")
                                            .OfType(_idTipoOggettoIntervento)
                                            .ForGruppo(_idGruppoOggettoIntervento)
                                            .OfQuantity(2)
                                            .Build()
                                 };

            return Commands.BuildCmd.CalculateSchedulazioneRotPriceOfScenario
                .ForWorkPeriod(_workPeriod)
                .ForScenario(_idScenario)
                .ForSchedulazione(_idSchedulazione)
                .ForTipoIntervento(_idTipoIntervento)
                .WithOggetti(_oggetti)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.SchedulazioneRotCreated
             
              .ForWorkPeriod(_workPeriod)
             .ForPlan(_idScenario)
             .OfType(_idTipoIntervento)
             .WithOggetti(_oggetti)
             .Build(_id, 1);
            yield return BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(_idScenario)
                .ToPrice(_priceCalculated)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
