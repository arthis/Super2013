using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class InterventiAskedTobeGenerated : Message, IEvent
    {

        public InterventiAskedTobeGenerated()
        {

        }

        public InterventiAskedTobeGenerated(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("La schedulazione {0} é stata richiesta di generare interventi ", Id);
        }

        public bool Equals(InterventiAskedTobeGenerated other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventiAskedTobeGenerated);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}