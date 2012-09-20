using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Intervento
{
    public class InterventoPriceOfPlanCalculated: Message, IEvent
    {
        public Guid IdPlan { get; set; }
        public decimal Price { get; set; }

        public InterventoPriceOfPlanCalculated()
        {
            
        }

        public InterventoPriceOfPlanCalculated(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idPlan,
                                   decimal price)
            : base(id,commitId,  version)
        {
            Contract.Requires(idPlan != Guid.Empty);
            
            IdPlan = idPlan;
            Price = price;
        }

        public override string ToDescription()
        {
            return string.Format("IL intervento {0} e stato calcolato", Id);
        }

        public bool Equals(InterventoPriceOfPlanCalculated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPlan.Equals(IdPlan) && other.Price == Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoPriceOfPlanCalculated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdPlan.GetHashCode();
                result = (result*397) ^ Price.GetHashCode();
                return result;
            }
        }
    }

    
}
