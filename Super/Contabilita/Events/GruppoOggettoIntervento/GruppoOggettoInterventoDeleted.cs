using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.GruppoOggettoIntervento
{
    
    public class GruppoOggettoInterventoDeleted : Message, IEvent
    {
        

        public GruppoOggettoInterventoDeleted()
        {
                
        }
      

         public GruppoOggettoInterventoDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Il Gruppo Oggetto Intervento (Id:'{0}') é stato cancellato", Id);
        }

        public bool Equals(GruppoOggettoInterventoDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GruppoOggettoInterventoDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
