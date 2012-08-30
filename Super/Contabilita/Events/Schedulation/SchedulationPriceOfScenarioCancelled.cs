using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Schedulation
{
    public class SchedulationPriceOfScenarioCancelled : Message, IEvent
    {

        public SchedulationPriceOfScenarioCancelled()
        {
            
        }

        public SchedulationPriceOfScenarioCancelled(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(SchedulationPriceOfScenarioCancelled other)
        {
            return base.Equals(other);
        }

        public override string ToDescription()
        {
            return "Il prezzo della schedulazione é stata cancellato nel scenario";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulationPriceOfScenarioCancelled);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}