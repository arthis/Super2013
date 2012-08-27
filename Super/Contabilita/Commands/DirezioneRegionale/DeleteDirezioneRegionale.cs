using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.DirezioneRegionale
{
    
    public class DeleteDirezioneRegionale : CommandBase
    {
        

        public DeleteDirezioneRegionale()
        {
                
        }
      

         public DeleteDirezioneRegionale(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo la direzione regionale (Id:'{0}')", Id);
        }

        public bool Equals(DeleteDirezioneRegionale other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteDirezioneRegionale);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
