using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Lotto
{
    
    public class DeleteLotto : CommandBase
    {
        

        public DeleteLotto()
        {
                
        }
      

         public DeleteLotto(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il lotto (Id:'{0}')", Id);
        }


        public bool Equals(DeleteLotto other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteLotto);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
