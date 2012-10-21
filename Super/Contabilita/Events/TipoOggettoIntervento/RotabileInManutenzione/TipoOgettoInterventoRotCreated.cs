using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione
{
    public class TipoOgettoInterventoRotManCreated : EventBase
    {

        public TipoOgettoInterventoRotManCreated()
        {

        }


        public TipoOgettoInterventoRotManCreated(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Un tipo oggetto intervento rotabile in manutenzione '{0}'  é stato creato .", Id);
        }

        public bool Equals(TipoOgettoInterventoRotManCreated other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoOgettoInterventoRotManCreated);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}