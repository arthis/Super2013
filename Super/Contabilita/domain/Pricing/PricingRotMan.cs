using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Pricing;

namespace Super.Contabilita.Domain.Pricing
{
    public class PricingRotMan : Pricing
    {
        protected Dictionary<Guid, BasePriceRotMan> BasePrices;



        protected IEnumerable<BasePriceRotMan> GetBasePrice()
        {
            return BasePrices.Select(x => x.Value).ToList();
        } 

        public PricingRotMan()
        {
        }

        public PricingRotMan(Guid id)
            : base(id)
        {
        }

        public void Apply(PricingCreated e)
        {
            Id = e.Id;
            BasePrices = new Dictionary<Guid, BasePriceRotMan>();
        }


        public void UpdateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {
            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceRotManUpdated
                .ForBasePrice(idBasePrice)
                .ForGruppoOggettoIntervento(idGruppoOggettoIntervento)
                .ForInterval(builder.Build())
                .OfTipoIntervento(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceRotManUpdated e)
        {
            var priceBase = Build.BasePriceRotMan
                .ForGruppoOggettoIntervento(e.IdGruppoOggettoIntervento)
                .ForInterval(e.Interval.ToDomain())
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            BasePrices[e.IdBasePrice] = priceBase;
        }

        public void CreateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {

            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceRotManCreated
                .ForBasePrice(idBasePrice)
                .ForGruppoOggettoIntervento(idGruppoOggettoIntervento)
                .ForInterval(builder.Build())
                .OfTipoIntervento(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceRotManCreated e)
        {
            var priceBase = Build.BasePriceRotMan
                .ForGruppoOggettoIntervento(e.IdGruppoOggettoIntervento)
                .ForInterval(e.Interval.ToDomain())
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            BasePrices.Add(e.IdBasePrice, priceBase);
        }

        public decimal CalculateBasePrice(Guid idGruppoOggettoIntervento, Guid idTipoIntervento, Period period)
        {
            decimal totalPrice = 0;
            foreach (var day in period.GetDays())
            {
                var baseprice = GetBasePrice().SingleOrDefault(x => x.Fits(day, idGruppoOggettoIntervento, idTipoIntervento));
                totalPrice += baseprice == null ? 0 : baseprice.Value;
            }
            return totalPrice;
        }

    }
}