using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.Ambiente
{
    
    public class TipoOggettoInterventoAmbDeleted : EventBase
    {

        public TipoOggettoInterventoAmbDeleted()
        {
                
        }
      

         public TipoOggettoInterventoAmbDeleted(Guid id, Guid commitId, long version)
             :base(id,commitId,version)
        {
            
        }


        public override string ToDescription()
        {
            return string.Format("Il tipo oggetto intervento ambiente é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(TipoOggettoInterventoAmbDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoOggettoInterventoAmbDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
