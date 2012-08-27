using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione
{
    
    public class DeleteTipoInterventoRotMan : CommandBase
    {
        

        public DeleteTipoInterventoRotMan()
        {
                
        }
      

         public DeleteTipoInterventoRotMan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento rotabile in manutenzione (Id:'{0}')", Id);
        }

        public bool Equals(DeleteTipoInterventoRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoInterventoRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
