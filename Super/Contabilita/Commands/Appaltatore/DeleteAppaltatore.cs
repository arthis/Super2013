using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Appaltatore
{
    
    public class DeleteAppaltatore : CommandBase
    {
        

        public DeleteAppaltatore()
        {
                
        }
      

         public DeleteAppaltatore(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il Appaltatore (Id:'{0}')", Id);
        }

        public bool Equals(DeleteAppaltatore other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteAppaltatore);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
