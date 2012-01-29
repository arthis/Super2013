using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace ApplicationService.Executors
{
    public class CreareInterventoRotabileExecutor : CommandExecutorBase<CreareNuovoInterventoRotabile>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoInterventoRotabile command)
        {
            // Perform The Consuntivazione
            InterventoRotabile i = new InterventoRotabile(command.Id, command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento);
             
            // Accept all the work we just did.
            context.Accept();
        } 
    }
}
