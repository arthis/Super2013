using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Pricing;

namespace Super.Contabilita.Domain.Pricing
{
    public class PricingAmb : Pricing
    {
        protected Dictionary<Guid, BasePriceAmb> BasePrices;

        protected IEnumerable<BasePriceAmb> GetBasePrice()
        {
            return BasePrices.Select(x => x.Value).ToList();
        } 

        public PricingAmb()
        {
        }

        public PricingAmb(Guid id)
            : base(id)
        {
        }

        public void Apply(PricingCreated e)
        {
            Id = e.Id;
            BasePrices = new Dictionary<Guid, BasePriceAmb>();
        }


        public void UpdateBasePrice(Guid idBasePrice, decimal value, Guid idTipoIntervento, IntervalOpened interval)
        {
            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceAmbUpdated
                .ForBasePrice(idBasePrice)
                .ForInterval(builder.Build())
                .OfTipoIntervento(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceAmbUpdated e)
        {
            var priceBase = Build.BasePriceAmb
                .ForInterval(e.Interval.ToDomain())
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            BasePrices[e.IdBasePrice] = priceBase;
        }

        public void CreateBasePrice(Guid idBasePrice, decimal value, Guid idTipoIntervento, IntervalOpened interval)
        {

            var builder = new MsgIntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = BuildEvt.BasePriceAmbCreated
                .ForBasePrice(idBasePrice)
                .ForInterval(builder.Build())
                .OfTipoIntervento(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceAmbCreated e)
        {
            var priceBase = Build.BasePriceAmb
                .ForInterval(e.Interval.ToDomain())
                .ForType(e.IdTipoIntervento)
                .ForValue(e.Value)
                .Build();

            BasePrices.Add(e.IdBasePrice, priceBase);
        }

        public decimal CalculateBasePrice( Guid idTipoIntervento, Period period)
        {
            decimal totalPrice = 0;
            foreach (var day in period.GetDays())
            {
                var baseprice = GetBasePrice().SingleOrDefault(x => x.Fits(day, idTipoIntervento));
                totalPrice += baseprice == null ? 0 : baseprice.Value;
            }
            return totalPrice;
        }

    }
}