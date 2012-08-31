using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.bachibouzouk;

namespace Super.Contabilita.Domain.bachibouzouk
{
    public class bachibouzouk : AggregateBase
    {
        private Dictionary<string, BasePrice> _basePrices;

        private class Is_bachibouzouk_Already_Deleted : ISpecification<bachibouzouk>
        {
            public bool IsSatisfiedBy(bachibouzouk i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("bachibouzouk", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public bachibouzouk()
        {
        }

        public bachibouzouk(Guid id)
        {
            var evt = Build.bachibouzoukCreated;
            RaiseEvent(id, evt);

        }

        public void Apply(bachibouzoukCreated e)
        {
            Id = e.Id;
            _basePrices = new Dictionary<string, BasePrice>();
        }


        public void UpdateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {
            var builder = new IntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = Build.BasePriceUpdated
                .ForBasePrice(idBasePrice)
                .ForGruppoOggetto(idGruppoOggettoIntervento)
                .ForInterval(builder.Build())
                .ForType(idTipoIntervento)
                .ForValue(value);

            RaiseEvent(evt);
        }

        public void Apply(BasePriceUpdated e)
        {
            
        }

        public void CreateBasePrice(Guid idBasePrice, decimal value, Guid idGruppoOggettoIntervento, Guid idTipoIntervento, IntervalOpened interval)
        {

            var builder = new IntervalOpenedBuilder();
            interval.BuildValue(builder);

            var evt = Build.BasePriceCreated
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
                
            _basePrices.Add(e.IdBasePrice, new BasePrice());
        }
    }
}
