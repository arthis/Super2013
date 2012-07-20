using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Committente
{
    
    public class DeleteCommittente : CommandBase
    {
        

        public DeleteCommittente()
        {
                
        }
      

         public DeleteCommittente(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il Committente (Id:'{0}')", Id);
        }

        public bool Equals(DeleteCommittente other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteCommittente);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
