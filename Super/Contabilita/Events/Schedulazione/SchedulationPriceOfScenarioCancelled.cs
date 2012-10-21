using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Schedulazione
{
    public class SchedulazionePriceOfScenarioCancelled : EventBase
    {

        public SchedulazionePriceOfScenarioCancelled()
        {
            
        }

        public SchedulazionePriceOfScenarioCancelled(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(SchedulazionePriceOfScenarioCancelled other)
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
            return Equals(obj as SchedulazionePriceOfScenarioCancelled);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}