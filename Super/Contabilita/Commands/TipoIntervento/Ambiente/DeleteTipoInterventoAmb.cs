using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento.Ambiente
{
    
    public class DeleteTipoInterventoAmb : CommandBase
    {

        public DeleteTipoInterventoAmb()
        {
                
        }
      

         public DeleteTipoInterventoAmb(Guid id)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);

            Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento ambiente (Id:'{0}')", Id);
        }

        public bool Equals(DeleteTipoInterventoAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteTipoInterventoAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
