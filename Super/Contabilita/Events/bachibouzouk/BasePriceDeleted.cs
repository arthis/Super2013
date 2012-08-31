using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.bachibouzouk
{
    public class BasePriceDeleted : Message, IEvent
    {
        public Guid IdBasePrice { get; set; }
        
        public BasePriceDeleted()
        {

        }

        public BasePriceDeleted(Guid id, Guid commitId, long version, Guid idBasePrice)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentException>(idBasePrice != Guid.Empty);
        
            IdBasePrice = idBasePrice;
        }

        public override string ToDescription()
        {
            return string.Format("Il prezzo di base é stato creato");
        }

        public bool Equals(BasePriceDeleted other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdBasePrice.Equals(IdBasePrice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceDeleted);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdBasePrice.GetHashCode();
            }
        }
    }
}