using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Intervento
{
    public class CancelInterventoPriceOfPlan : CommandBase
    {

        public CancelInterventoPriceOfPlan()
        {
            
        }

        public CancelInterventoPriceOfPlan(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(CancelInterventoPriceOfPlan other)
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
            return Equals(obj as CancelInterventoPriceOfPlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}