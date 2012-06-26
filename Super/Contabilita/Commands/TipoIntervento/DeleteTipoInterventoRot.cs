using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class DeleteTipoInterventoRot : CommandBase
    {
        public long Version { get; private set; }

        public DeleteTipoInterventoRot()
        {
                
        }
      

         public DeleteTipoInterventoRot(Guid id)
        {
            this.Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento rotabile (Id:'{0}')", Id);
        }


        public bool Equals(DeleteTipoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoInterventoRot);
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
