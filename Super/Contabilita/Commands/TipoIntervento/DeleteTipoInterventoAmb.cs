using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
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

        
    }
}
