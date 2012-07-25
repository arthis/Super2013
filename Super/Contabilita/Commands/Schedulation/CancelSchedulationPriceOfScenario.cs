using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Schedulation
{
    public class CancelSchedulationPriceOfScenario : CommandBase
    {

        public CancelSchedulationPriceOfScenario()
        {
            
        }

        public CancelSchedulationPriceOfScenario(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(CancelSchedulationPriceOfScenario other)
        {
            return base.Equals(other);
        }

        public override string ToDescription()
        {
            return "Cancellare il prezzo della schedulazione nel scenario";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelSchedulationPriceOfScenario);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}