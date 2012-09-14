using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Pricing;

namespace Super.Contabilita.Domain.Pricing
{
    public class Pricing : AggregateBase
    {
        private Dictionary<Guid, BasePrice> _basePrices;

        private class Is_pricing_Already_Deleted : ISpecification<Pricing>
        {
            public bool IsSatisfiedBy(Pricing i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Pricing", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;

        public Pricing()
        {
        }

        public Pricing(Guid id)
        {
            var evt = BuildEvt.PricingCreated;
            RaiseEvent(id, evt);

        }

        public void Apply(PricingCreated e)
        {
            Id = e.Id;
            _basePrices = new Dictionary<Guid, BasePrice>();
        }


        public void UpdateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {
            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceUpdated
                .ForBasePrice(idBasePrice)
                .ForGruppoOggetto(idGruppoOggettoIntervento)
                .ForInterval(builder.Build())
                .ForType(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceUpdated e)
        {
            var priceBase = Build.BasePrice
                .ForGruppoOggettoIntervento(e.IdGruppoOggettoInervento)
                .ForInterval(IntervalOpened.FromMessage(e.Intervall))
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            _basePrices[e.IdBasePrice] = priceBase;
        }

        public void CreateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {

            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceCreated
                .ForBasePrice(idBasePrice)
                .ForGruppoOggetto(idGruppoOggettoIntervento)
                .ForInterval(builder.Build())
                .ForType(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceCreated e)
        {
            var priceBase = Build.BasePrice
                .ForGruppoOggettoIntervento(e.IdGruppoOggettoInervento)
                .ForInterval(IntervalOpened.FromMessage(e.Intervall))
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            _basePrices.Add(e.IdBasePrice, priceBase);
        }



        public decimal CalculateBasePrice(IBasePriceCalculation priceCalculation)
        {
            return priceCalculation.Calculate(_basePrices.Values.ToList());
        }
    }
}