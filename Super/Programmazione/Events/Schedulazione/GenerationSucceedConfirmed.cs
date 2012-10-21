using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class GenerationSucceedConfirmed : EventBase
    {

        public GenerationSucceedConfirmed()
        {

        }

        public GenerationSucceedConfirmed(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Il successo della generazione degli interventi per la schedulazione {0} é stata confirmata", Id);
        }

        public bool Equals(GenerationSucceedConfirmed other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GenerationSucceedConfirmed);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}