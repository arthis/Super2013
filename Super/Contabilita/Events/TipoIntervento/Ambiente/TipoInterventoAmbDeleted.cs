using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoIntervento.Ambiente
{
    
    public class TipoInterventoAmbDeleted : CommandBase
    {

        public TipoInterventoAmbDeleted()
        {
                
        }


        public TipoInterventoAmbDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Il tipo intervento ambiente é stato scancellato (Id:'{0}')", Id);
        }

        public bool Equals(TipoInterventoAmbDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoInterventoAmbDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
