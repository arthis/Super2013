using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.InterventoGeneration
{
    public class StartGenerationOfInterventi : CommandBase
    {
        public Guid IdSchedulazione { get; set; }


        public StartGenerationOfInterventi()
        {
            
        }

        public StartGenerationOfInterventi(Guid id, Guid idCommitId, long version, Guid idSchedulazione)
            : base(id, idCommitId,version)
        {
            Contract.Requires(idSchedulazione!= Guid.Empty);

            IdSchedulazione = idSchedulazione;
        }

        public override string ToDescription()
        {
            return string.Format("Generare interventi della schedulazione  {0} ", Id);
        }

        public bool Equals(StartGenerationOfInterventi other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdSchedulazione.Equals(IdSchedulazione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as StartGenerationOfInterventi);
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
