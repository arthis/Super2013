using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class DeleteTipoInterventoRot : CommandBase
    {
        

        public DeleteTipoInterventoRot()
        {
                
        }
      

         public DeleteTipoInterventoRot(Guid id)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);

            Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento rotabile (Id:'{0}')", Id);
        }


       
    }
}
