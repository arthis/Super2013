using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione
{
    
    public class TipoInterventoRotManDeleted : CommandBase
    {
        

        public TipoInterventoRotManDeleted()
        {
                
        }


        public TipoInterventoRotManDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Il tipo intervento rotabile in manutenzione é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(TipoInterventoRotManDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoInterventoRotManDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
}
