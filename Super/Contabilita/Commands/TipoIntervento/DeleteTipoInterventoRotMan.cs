using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class DeleteTipoInterventoRotMan : CommandBase
    {
        

        public DeleteTipoInterventoRotMan()
        {
                
        }
      

         public DeleteTipoInterventoRotMan(Guid id)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);

            Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il tipo intervento rotabile in manutenzione (Id:'{0}')", Id);
        }


       
    }
}
