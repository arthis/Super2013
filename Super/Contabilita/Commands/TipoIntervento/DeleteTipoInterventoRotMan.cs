using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class DeleteTipoInterventoRotMan : CommandBase
    {
        public long Version { get; private set; }

        public DeleteTipoInterventoRotMan()
        {
                
        }
      

         public DeleteTipoInterventoRotMan(Guid id)
        {
            this.Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento rotabile in manutenzione (Id:'{0}')", Id);
        }


        public bool Equals(DeleteTipoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoInterventoRotMan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Version.GetHashCode();
            }
        }
    }
}
