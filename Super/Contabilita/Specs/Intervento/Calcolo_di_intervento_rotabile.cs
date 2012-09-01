using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Events;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Handlers.Intervento;

namespace Super.Contabilita.Specs.Intervento
{
    public class Calcolo_di_intervento_rotabile : CommandBaseClass<CalculateInterventoRotPriceOfPlan>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idPlan = Guid.NewGuid();
        private OggettoRot[] _oggetti;
        private Period _period = new Period(DateTime.Parse("28/08/2012"), DateTime.Parse("29/08/2012"));
        
        private Guid _idBachiBouzouk = Guid.NewGuid();
        private Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private IntervalOpened _intervalPrezzoBase = new IntervalOpened(DateTime.Parse("01/01/2012"), DateTime.Parse("01/01/2015"));
        private decimal _valuePrezzoBase = 25;
        private Guid _idTipoIntervento = Guid.NewGuid();
        
        private decimal _priceCalculated=50;

        private Guid _idCarriage = Guid.NewGuid();
        private string _descriptionCarriage = "descriptionCarriage";
        private string _sign ="signCarriage";
        private bool _isInternationalCarriage = true;


        protected override CommandHandler<CalculateInterventoRotPriceOfPlan> OnHandle(IEventRepository eventRepository)
        {
            return new CalculateInterventoRotPriceOfPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CarriageRotCreated
                .ForDescription(_descriptionCarriage)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .ForSign(_sign)
                .IsInternational(_isInternationalCarriage)
                .Build(_idCarriage, 1);

            yield return BuildEvt.bachibouzoukCreated
                .Build(_idBachiBouzouk, 1);

            yield return BuildEvt.BasePriceUpdated
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .ForInterval(_intervalPrezzoBase)
                .ForType(_idTipoIntervento)
                .ForValue(_valuePrezzoBase)
                .Build(_idBachiBouzouk,2);

        }

        public override CalculateInterventoRotPriceOfPlan When()
        {
            _oggetti = new [] {new OggettoRot("description", 2, _idCarriage)};

            return Commands.Build.CalculateInterventoRotPriceOfPlan
                .ForPeriod(_period)
                .ForPlan(_idPlan)
                .ForTipoIntervento(_idTipoIntervento)
                .WithOggetti(_oggetti)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoPriceOfPlanCalculated
                .ForPlan(_idPlan)
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
