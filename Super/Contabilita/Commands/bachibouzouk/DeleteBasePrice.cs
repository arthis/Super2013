using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Pricing
{
    public class DeleteBasePrice: CommandBase
    {
        public Guid IdBasePrice { get; set; }

        public DeleteBasePrice()
        {
            
        }

        public DeleteBasePrice(Guid id, Guid commitId, long version, Guid idBasePrice)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentException>(idBasePrice != Guid.Empty);

            IdBasePrice = idBasePrice;
        }

        public override string ToDescription()
        {
            return string.Format("Cancelliamo il prezzo di base {0}", IdBasePrice);
        }

        public bool Equals(DeleteBasePrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdBasePrice.Equals(IdBasePrice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteBasePrice);
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
