using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.Rotabile
{
    
    public class TipoOggettoInterventoRotDeleted : Message, IEvent
    {
        

        public TipoOggettoInterventoRotDeleted()
        {
                
        }
      

         public TipoOggettoInterventoRotDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Il tipo oggetto intervento rotabile  é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(TipoOggettoInterventoRotDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoOggettoInterventoRotDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
