using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.InterventoGeneration
{
    public class GenerationOfInterventiStarted : Message,IEvent
    {
        public Guid IdSchedulazione { get; set; }

        public GenerationOfInterventiStarted()
        {
            
        }

        public GenerationOfInterventiStarted(Guid id, Guid idCommitId, long version, Guid idSchedulazione)
            : base(id, idCommitId,version)
        {
            Contract.Requires(idSchedulazione != Guid.Empty);

            IdSchedulazione = idSchedulazione;
        }

        public override string ToDescription()
        {
            return string.Format("la generazione degli interventi della schedulazione  é stata comminciata  ");
        }

        public bool Equals(GenerationOfInterventiStarted other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdSchedulazione.Equals(IdSchedulazione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GenerationOfInterventiStarted);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdSchedulazione.GetHashCode();
            }
        }
    }
}
