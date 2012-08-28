using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione
{
    
    public class DeleteTipoOggettoInterventoRotMan : CommandBase
    {
        

        public DeleteTipoOggettoInterventoRotMan()
        {
                
        }
      

         public DeleteTipoOggettoInterventoRotMan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo oggetto intervento rotabile (Id:'{0}')", Id);
        }

        public bool Equals(DeleteTipoOggettoInterventoRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoOggettoInterventoRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
