using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Pricing
{
    public class BasePriceCreated : EventBase
    {
        public Guid IdBasePrice { get; set; }
        public decimal Value { get; set; }
        public IntervalOpened Interval { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdGruppoOggettoInervento { get; set; }

        public BasePriceCreated()
        {

        }

        public BasePriceCreated(Guid id, Guid commitId, long version, Guid idBasePrice, decimal value, IntervalOpened interval, Guid idTipoIntervento, Guid idGruppoOggettoInervento)
            : base(id, commitId, version)
        {
            Contract.Requires(idBasePrice != Guid.Empty);
            Contract.Requires(interval != null);
            Contract.Requires(idTipoIntervento != Guid.Empty);
            Contract.Requires(idGruppoOggettoInervento != Guid.Empty);

            IdBasePrice = idBasePrice;
            Value = value;
            Interval = interval;
            IdTipoIntervento = idTipoIntervento;
            IdGruppoOggettoInervento = idGruppoOggettoInervento;

        }

        public override string ToDescription()
        {
            return string.Format("Il prezzo di base é stato creato");
        }

        public bool Equals(BasePriceCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdBasePrice.Equals(IdBasePrice) && other.Value == Value && Equals(other.Interval, Interval) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdGruppoOggettoInervento.Equals(IdGruppoOggettoInervento);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ IdBasePrice.GetHashCode();
                result = (result * 397) ^ Value.GetHashCode();
                result = (result * 397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result * 397) ^ IdTipoIntervento.GetHashCode();
                result = (result * 397) ^ IdGruppoOggettoInervento.GetHashCode();
                return result;
            }
        }
    }
}