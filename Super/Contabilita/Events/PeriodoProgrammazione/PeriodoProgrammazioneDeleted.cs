using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneDeleted : EventBase
    {
        

        public PeriodoProgrammazioneDeleted()
        {
            
        }

        public PeriodoProgrammazioneDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Il periodo programmazione é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(PeriodoProgrammazioneDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PeriodoProgrammazioneDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
