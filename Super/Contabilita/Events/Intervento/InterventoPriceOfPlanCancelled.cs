using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Intervento
{
    public class InterventoPriceOfPlanCancelled : Message, IEvent
    {

        public InterventoPriceOfPlanCancelled()
        {
            
        }

        public InterventoPriceOfPlanCancelled(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(InterventoPriceOfPlanCancelled other)
        {
            return base.Equals(other);
        }

        public override string ToDescription()
        {
            return "Cancellare il prezzo del'intervento nel piano";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoPriceOfPlanCancelled);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}