using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione
{
    
    public class TipoOggettoInterventoRotManDeleted : Message, IEvent
    {
        

        public TipoOggettoInterventoRotManDeleted()
        {
                
        }
      

         public TipoOggettoInterventoRotManDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Il tipo oggetto intervento rotabile in manutenzione  é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(TipoOggettoInterventoRotManDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoOggettoInterventoRotManDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
