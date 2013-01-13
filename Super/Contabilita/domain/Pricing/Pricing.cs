using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Contabilita.Domain.Schedulazione;
using Super.Contabilita.Events;

namespace Super.Contabilita.Domain.Pricing
{
    public class Pricing : AggregateBase
    {
        
        protected bool IsDeleted;

        protected class Is_pricing_Already_Deleted : ISpecification<Pricing>
        {
            public bool IsSatisfiedBy(Pricing i)
            {
                if (i.IsDeleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Pricing", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        public Pricing()
        {
            
        }

        public Pricing(Guid id)
        {
            var evt = BuildEvt.PricingCreated;
            RaiseEvent(id, evt);
        }

        
    }
}