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
    public class CreareInterventoRotExecutor : CommandExecutorBase<CreareNuovoInterventoRot>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoInterventoRot command)
        {
            // Perform The Consuntivazione
            InterventoRot i = new InterventoRot(command.Id, command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento);
             
            // Accept all the work we just did.
            context.Accept();
        } 
    }
}
