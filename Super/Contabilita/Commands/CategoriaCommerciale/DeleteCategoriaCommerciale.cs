using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.CategoriaCommerciale
{
    
    public class DeleteCategoriaCommerciale : CommandBase
    {
        

        public DeleteCategoriaCommerciale()
        {
                
        }
      

         public DeleteCategoriaCommerciale(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il categoria commerciale (Id:'{0}')", Id);
        }

        public bool Equals(DeleteCategoriaCommerciale other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteCategoriaCommerciale);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
