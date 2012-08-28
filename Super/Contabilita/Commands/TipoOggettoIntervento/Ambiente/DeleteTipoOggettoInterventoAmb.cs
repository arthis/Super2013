using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente
{
    
    public class DeleteTipoOggettoInterventoAmb : CommandBase
    {

        public DeleteTipoOggettoInterventoAmb()
        {
                
        }
      

         public DeleteTipoOggettoInterventoAmb(Guid id, Guid commitId, long version)
             :base(id,commitId,version)
        {
            
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento ambiente (Id:'{0}')", Id);
        }

        public bool Equals(DeleteTipoOggettoInterventoAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoOggettoInterventoAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
