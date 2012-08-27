using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.DirezioneRegionale
{
    public class DirezioneRegionaleDeleted : Message, IEvent
    {
        

        public DirezioneRegionaleDeleted()
        {
            
        }

        public DirezioneRegionaleDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("La direzione regionale é stata cancellata (Id:'{0}')", Id);
        }

        public bool Equals(DirezioneRegionaleDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DirezioneRegionaleDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
