using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.MeasuringUnit
{
    public class MeasuringUnitDeleted : Message, IEvent
    {
        

        public MeasuringUnitDeleted()
        {
            
        }

        public MeasuringUnitDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("l'unità di misura é stata cancellata (Id:'{0}')", Id);
        }

        public bool Equals(MeasuringUnitDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as MeasuringUnitDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
