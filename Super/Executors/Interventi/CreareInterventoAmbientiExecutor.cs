using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace Executors
{
    public class CreareInterventoAmbExecutor : CommandExecutorBase<CreareNuovoInterventoAmb>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoInterventoAmb command)
        {
            // Perform The Consuntivazione
            InterventoAmb i = new InterventoAmb(command.Id, command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento, command.Quantita, command.Descrizione);
             
            // Accept all the work we just did.
            context.Accept();
        } 
    }
}
