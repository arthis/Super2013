using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.GruppoOggettoIntervento
{
    
    public class DeleteGruppoOggettoIntervento : CommandBase
    {
        

        public DeleteGruppoOggettoIntervento()
        {
                
        }
      

         public DeleteGruppoOggettoIntervento(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il Gruppo Oggetto Intervento (Id:'{0}')", Id);
        }

        public bool Equals(DeleteGruppoOggettoIntervento other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteGruppoOggettoIntervento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
