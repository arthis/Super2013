using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Lotto
{
    
    public class DeleteLotto : CommandBase
    {
        public long Version { get; private set; }

        public DeleteLotto()
        {
                
        }
      

         public DeleteLotto(Guid id)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);

            Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il lotto (Id:'{0}')", Id);
        }


        public bool Equals(DeleteLotto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteLotto);
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
